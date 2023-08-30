using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetEditorTemplateListModel : CodeBehindModel
    {
        public string ListValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ClientLanguageVariantTemplate = doc.SelectSingleNode("template_root/table/editor_template/client_language_variant").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/editor_template/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderListItemTemplate = doc.SelectSingleNode("template_root/table/editor_template/header/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/editor_template/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/editor_template/row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_active;", Language.GetLanguage("are_you_sure_want_to_active", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_delete;", Language.GetLanguage("are_you_sure_want_to_delete", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_inactive;", Language.GetLanguage("are_you_sure_want_to_inactive", StaticObject.GetCurrentAdminGlobalLanguage()));

            string SumHeaderTemplateItem = "";
            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/editor_template/" + "App_Data/item_view/item_view.xml"));


            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");

            foreach (string Text in ItemList)
                SumHeaderTemplateItem += HeaderListItemTemplate.Replace("$_asp column_name;", Text).Replace("$_asp item;", aol.GetAddOnsLanguage(Text));

            if (!string.IsNullOrEmpty(QueryString.GetValue("search")))
                SumHeaderTemplateItem = SumHeaderTemplateItem.Replace("$_searched_item;", QueryString.GetValue("search"));

            HeaderTemplate = HeaderTemplate.Replace("$_asp item;", SumHeaderTemplateItem);

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();

            string Where = "";
            string TmpWhere = "";
            string Query = "";
            string Count = StaticObject.NumberOfRownMainTable.ToString();

            List<string> ParametersNameList = new List<string>() { "@count" };
            List<string> ParametersValueList = new List<string>() { Count };
            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
            {
                Count = StaticObject.NumberOfRowPerTable.ToString();
                int PageNumber = int.Parse(QueryString.GetValue("page"));
                string RowPerTable = StaticObject.NumberOfRowPerTable.ToString();
                int FromNumberRow = ((PageNumber - 1) * int.Parse(RowPerTable)) + 1;
                int UntilNumberRow = (FromNumberRow + int.Parse(RowPerTable)) - 1;

                ParametersNameList.Add("@from_number_row");
                ParametersNameList.Add("@until_number_row");
                ParametersValueList.Add(FromNumberRow.ToString());
                ParametersValueList.Add(UntilNumberRow.ToString());
            }

            if (!string.IsNullOrEmpty(QueryString.GetValue("search")))
            {
                Where = GlobalClass.GetSearchedItemListWhereQuery(StaticObject.ServerMapPath(StaticObject.AdminPath + "/editor_template/" + "App_Data/item_view/item_view.xml"), QueryString.GetValue("search").ProtectSqlInjection(true));
                ParametersNameList.Add("@inner_attach");
                ParametersValueList.Add(Where);
                Query += "&search=" + QueryString.GetValue("search").ProtectSqlInjection(true);
            }

            if (!string.IsNullOrEmpty(QueryString.GetValue("column_name")))
            {
                string ColumnName = QueryString.GetValue("column_name").ProtectSqlInjection();
                Query += "&column_name=" + ColumnName;
                string SortType = "asc";
                if (!string.IsNullOrEmpty(QueryString.GetValue("is_desc")))
                    if (QueryString.GetValue("is_desc") == "true")
                    {
                        SortType = "desc";
                        Query += "&is_desc=true";
                    }
                TmpWhere += " order by " + ColumnName + " " + SortType;
                ParametersNameList.Add("@outer_attach");
                ParametersValueList.Add(TmpWhere);
            }

            dbdr.dr = db.GetProcedure("get_editor_template", ParametersNameList, ParametersValueList);


            string SumRowBoxTemplate = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    string SumRowListItemTemplate = "";
                    string TmpRowBoxTemplate = RowBoxTemplate;

                    XmlNode ItemNode = doc.SelectSingleNode("template_root/table/editor_template/item");

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

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp editor_template_id;", dbdr.dr["editor_template_id"].ToString());
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp editor_template_directory_path;", dbdr.dr["editor_template_directory_path"].ToString());
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp editor_template_extension_name;", Path.GetExtension(dbdr.dr["editor_template_physical_path"].ToString()).Remove(0, 1));
                    TmpRowBoxTemplate = (bool)dbdr.dr["editor_template_active"] ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                    SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
                }

            db.Close();


            // Get Editor Template Count
            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
            string RowCount = duet.GetEditorTemplateCountByAttach(Where, TmpWhere);

            int CurrentPage = 0;
            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
                CurrentPage = int.Parse(QueryString.GetValue("page"));

            if (!string.IsNullOrEmpty(Query))
                if (Query[0] == '&')
                    Query = "?" + Query.Remove(0, 1);

            ListValue = ClientLanguageVariantTemplate + HeaderTemplate + SumRowBoxTemplate + InnerModuleClass.PageNumbers(int.Parse(RowCount), StaticObject.AdminPath + "/editor_template/action/GetEditorTemplateList.aspx" + Query, CurrentPage, 10, "?page=", true, "div_TableBox");
        }
    }
}