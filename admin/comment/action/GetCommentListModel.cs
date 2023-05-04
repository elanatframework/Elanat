using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionGetCommentListModel
    {
        public string ListValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            string SiteId = StaticObject.GetCurrentAdminSiteId();

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ClientLanguageVariantTemplate = doc.SelectSingleNode("template_root/table/comment/client_language_variant").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/comment/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderListItemTemplate = doc.SelectSingleNode("template_root/table/comment/header/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/comment/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/comment/row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_delete;", Language.GetLanguage("are_you_sure_want_to_delete", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_active;", Language.GetLanguage("are_you_sure_want_to_active", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_inactive;", Language.GetLanguage("are_you_sure_want_to_inactive", StaticObject.GetCurrentAdminGlobalLanguage()));

            string SumHeaderTemplateItem = "";
            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/comment/" + "App_Data/item_view/item_view.xml"));


            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/");

            foreach (string Text in ItemList)
                SumHeaderTemplateItem += HeaderListItemTemplate.Replace("$_asp column_name;", Text).Replace("$_asp item;", aol.GetAddOnsLanguage(Text));

            if (!string.IsNullOrEmpty(QueryString["search"]))
                SumHeaderTemplateItem = SumHeaderTemplateItem.Replace("$_searched_item;", QueryString["search"]);

            HeaderTemplate = HeaderTemplate.Replace("$_asp item;", SumHeaderTemplateItem);

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();

            string Where = "";
            string TmpWhere = "";
            string Query = "";
            string Count = StaticObject.NumberOfRownMainTable.ToString();

            List<string> ParametersNameList = new List<string>() { "@count" };
            List<string> ParametersValueList = new List<string>() { Count };

            Where += "where (el_category.site_id = " + SiteId + " or el_category.site_id = 0)";

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
                Where += GlobalClass.GetSearchedItemListWhereQuery(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/comment/" + "App_Data/item_view/item_view.xml"), QueryString["search"].ToString().ProtectSqlInjection(true), true);
                Query += "&search=" + QueryString["search"].ToString().ProtectSqlInjection(true);
            }

            if (!string.IsNullOrEmpty(QueryString["column_name"]))
            {
                string ColumnName = QueryString["column_name"].ToString().ProtectSqlInjection();
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

                    XmlNode ItemNode = doc.SelectSingleNode("template_root/table/comment/item");

                    foreach (string Text in ItemList)
                    {
                        string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                        string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", dbdr.dr[Text].ToString());

                        // If Exist More Column For Replace
                        if (ItemNode[Text].Attributes["more_column"] != null)
                        {
                            char[] DelimiterChars = { ',' };
                            string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                            foreach (string Column in MoreColumnList)
                                TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", dbdr.dr[Column].ToString());
                        }

                        SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
                    }

                    foreach (XmlNode node in ItemNode.ChildNodes)
                        if (node.Attributes["active"] != null)
                            if (node.Attributes["active"].Value.TrueFalseToBoolean())
                                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", dbdr.dr[node.Name].ToString());

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp comment_id;", dbdr.dr["comment_id"].ToString());
                    TmpRowBoxTemplate = (bool)dbdr.dr["comment_active"] ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");
                    TmpRowBoxTemplate = (string.IsNullOrEmpty(dbdr.dr["comment_file_physical_name"].ToString())) ? TmpRowBoxTemplate.Replace("$_asp check_file_exist;", "false") : TmpRowBoxTemplate.Replace("$_asp check_file_exist;", "true");
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp parent_comment;", dbdr.dr["parent_comment"].ToString());
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp content_id;", dbdr.dr["content_id"].ToString());

                    SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
                }

            db.Close();


            // Get Comment Count
            DataUse.Comment duc = new DataUse.Comment();
            string RowCount = duc.GetCommentCountByAttach(Where, TmpWhere);

            int CurrentPage = 0;
            if (!string.IsNullOrEmpty(QueryString["page"]))
                CurrentPage = int.Parse(QueryString["page"]);

            ListValue = ClientLanguageVariantTemplate + HeaderTemplate + SumRowBoxTemplate + InnerModuleClass.PageNumbers(int.Parse(RowCount), Query, CurrentPage);
        }
    }
}