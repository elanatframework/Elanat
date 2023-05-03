using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionGetUserCommentListModel
    {
        public string ListValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/" + StaticObject.GetCurrentSiteTemplatePhysicalPath()));
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/comment/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());
            string HeaderListItemTemplate = doc.SelectSingleNode("template_root/table/comment/header/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/comment/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/comment/row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());

            string SumHeaderTemplateItem = "";
            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/member/user_comment/App_Data/item_view/item_view.xml"));

            foreach (string Text in ItemList)
                SumHeaderTemplateItem += HeaderListItemTemplate.Replace("$_asp column_name;", Text).Replace("$_asp item;", Language.GetAddOnsLanguage(Text, StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.AdminPath + "/comment/"));

            if (!string.IsNullOrEmpty(QueryString["search"]))
                SumHeaderTemplateItem = SumHeaderTemplateItem.Replace("$_searched_item;", QueryString["search"]);

            HeaderTemplate = HeaderTemplate.Replace("$_asp item;", SumHeaderTemplateItem);

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string Where = "";
            string TmpWhere = "";
            string Query = "";
            string Count = StaticObject.NumberOfRownMainTable.ToString();

            List<string> ParametersNameList = new List<string>() { "@count" };
            List<string> ParametersValueList = new List<string>() { Count };

            Where += "where el_comment.user_id=" + ccoc.UserId;

            if (!string.IsNullOrEmpty(QueryString["page"]))
            {
                Count = StaticObject.NumberOfRowPerTable.ToString();
                int PageNumber = int.Parse(QueryString["page"]);
                string RowPerTable = StaticObject.NumberOfRowPerTable.ToString();
                int FromNumberRow = ((PageNumber - 1) * int.Parse(RowPerTable)) + 1;
                int UntilNumberRow = (FromNumberRow + int.Parse(RowPerTable)) - 1;

                ParametersNameList.Add("@from_number_row");
                ParametersNameList.Add("@until_number_row");
                ParametersValueList.Add(FromNumberRow.ToString());
                ParametersValueList.Add(UntilNumberRow.ToString());
            }

            if (!string.IsNullOrEmpty(QueryString["search"]))
            {
                Where += GlobalClass.GetSearchedItemListWhereQuery(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/member/user_comment/App_Data/item_view/item_view.xml"), QueryString["search"].ToString().ProtectSqlInjection(true), true);
                Query += "&search=" + QueryString["search"].ToString().ProtectSqlInjection(true).ProtectSqlInjection();
            }

            if (!string.IsNullOrEmpty(QueryString["column_name"]))
            {
                string ColumnName = QueryString["column_name"].ToString().ProtectSqlInjection().ProtectSqlInjection();
                Query += "&column_name=" + ColumnName;
                string SortType = "asc";
                if (!string.IsNullOrEmpty(QueryString["is_desc"]))
                    if (QueryString["is_desc"] == "true")
                    {
                        SortType = "desc";
                        Query += "&is_desc=true";
                    }
                TmpWhere += " order by " + ColumnName + " " + SortType;
            }

            ParametersNameList.Add("@inner_attach");
            ParametersValueList.Add(Where);

            ParametersNameList.Add("@outer_attach");
            ParametersValueList.Add(TmpWhere);

            dbdr.dr = db.GetProcedure("get_comment", ParametersNameList, ParametersValueList);


            string SumRowBoxTemplate = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    string SumRowListItemTemplate = "";
                    string TmpRowBoxTemplate = RowBoxTemplate;

                    foreach (string Text in ItemList)
                        SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", dbdr.dr[Text].ToString());

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp comment_id;", dbdr.dr["comment_id"].ToString());

                    SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
                }

            db.Close();


            // Get Comment Count
            DataUse.Comment duc = new DataUse.Comment();
            string RowCount = duc.GetCommentCountByAttach(Where, TmpWhere);

            int CurrentPage = 0;
            if (!string.IsNullOrEmpty(QueryString["page"]))
                CurrentPage = int.Parse(QueryString["page"]);


            ListValue = HeaderTemplate + SumRowBoxTemplate + InnerModuleClass.PageNumbers(int.Parse(RowCount), Query, CurrentPage);
        }
    }
}