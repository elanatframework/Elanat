using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionGetSiteListModel
    {
        public string ListValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ClientLanguageVariantTemplate = doc.SelectSingleNode("template_root/table/site/client_language_variant").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/site/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderListItemTemplate = doc.SelectSingleNode("template_root/table/site/header/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/site/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/site/row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_active;", Language.GetLanguage("are_you_sure_want_to_active", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_delete;", Language.GetLanguage("are_you_sure_want_to_delete", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_inactive;", Language.GetLanguage("are_you_sure_want_to_inactive", StaticObject.GetCurrentAdminGlobalLanguage()));

            string SumHeaderTemplateItem = "";
            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/site/" + "App_Data/item_view/item_view.xml"));


            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/");

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
            if (!string.IsNullOrEmpty(QueryString["site"]))
            {
                Count = StaticObject.NumberOfRowPerTable.ToString();
                int SiteNumber = int.Parse(QueryString["site"]);
                string RowPerTable = StaticObject.NumberOfRowPerTable.ToString();
                int FromNumberRow = ((SiteNumber - 1) * int.Parse(RowPerTable)) + 1;
                int UntilNumberRow = (FromNumberRow + int.Parse(RowPerTable)) - 1;

                ParametersNameList.Add("@from_number_row");
                ParametersNameList.Add("@until_number_row");
                ParametersValueList.Add(FromNumberRow.ToString());
                ParametersValueList.Add(UntilNumberRow.ToString());
            }

            if (!string.IsNullOrEmpty(QueryString["search"]))
            {
                Where = GlobalClass.GetSearchedItemListWhereQuery(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/site/" + "App_Data/item_view/item_view.xml"), QueryString["search"].ToString().ProtectSqlInjection(true));
                ParametersNameList.Add("@inner_attach");
                ParametersValueList.Add(Where);
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
                ParametersNameList.Add("@outer_attach");
                ParametersValueList.Add(TmpWhere);
            }

            dbdr.dr = db.GetProcedure("get_site", ParametersNameList, ParametersValueList);


            string SumRowBoxTemplate = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    string SumRowListItemTemplate = "";
                    string TmpRowBoxTemplate = RowBoxTemplate;

                    XmlNode ItemNode = doc.SelectSingleNode("template_root/table/site/item");

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

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp site_id;", dbdr.dr["site_id"].ToString());
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp site_name;", dbdr.dr["site_name"].ToString());
                    TmpRowBoxTemplate = (bool)dbdr.dr["site_active"] ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                    SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
                }

            db.Close();


            // Get Site Count
            DataUse.Site dua = new DataUse.Site();
            string RowCount = dua.GetSiteCountByAttach(Where, TmpWhere);

            int CurrentSite = 0;
            if (!string.IsNullOrEmpty(QueryString["site"]))
                CurrentSite = int.Parse(QueryString["site"]);

            ListValue = ClientLanguageVariantTemplate + HeaderTemplate + SumRowBoxTemplate + InnerModuleClass.PageNumbers(int.Parse(RowCount), Query, CurrentSite);
        }
    }
}