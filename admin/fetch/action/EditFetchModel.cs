using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionEditFetchModel
    {
        public string EditFetchLanguage { get; set; }
        public string SaveFetchLanguage { get; set; }
        public string FetchCategoryLanguage { get; set; }
        public string FetchActiveLanguage { get; set; }
        public string SqlQueryUseLanguageLanguage { get; set; }
        public string SqlQueryUseModuleLanguage { get; set; }
        public string SqlQueryUsePluginLanguage { get; set; }
        public string SqlQueryUseReplacePartLanguage { get; set; }
        public string SqlQueryUseFetchLanguage { get; set; }
        public string SqlQueryUseItemLanguage { get; set; }
        public string SqlQueryUseElanatLanguage { get; set; }
        public string BoxUseLanguageLanguage { get; set; }
        public string BoxUseModuleLanguage { get; set; }
        public string BoxUsePluginLanguage { get; set; }
        public string BoxUseReplacePartLanguage { get; set; }
        public string BoxUseFetchLanguage { get; set; }
        public string BoxUseItemLanguage { get; set; }
        public string BoxUseElanatLanguage { get; set; }
        public string ListItemUseLanguageLanguage { get; set; }
        public string ListItemUseModuleLanguage { get; set; }
        public string ListItemUsePluginLanguage { get; set; }
        public string ListItemUseReplacePartLanguage { get; set; }
        public string ListItemUseFetchLanguage { get; set; }
        public string ListItemUseItemLanguage { get; set; }
        public string ListItemUseElanatLanguage { get; set; }
        public string FetchCacheDurationLanguage { get; set; }
        public string FetchCacheParametersLanguage { get; set; }
        public string FetchMenuLanguage { get; set; }
        public string FetchMenuQueryStringLanguage { get; set; }
        public string FetchSortIndexLanguage { get; set; }
        public string FetchAccessShowLanguage { get; set; }
        public string FetchPublicAccessShowLanguage { get; set; }
        public string GetSqlQueryColumnLanguage { get; set; }
        public string FetchNameLanguage { get; set; }
        public string FetchSqlQueryLanguage { get; set; }
        public string SqlQueryColumnLanguage { get; set; }
        public string FetchBoxLanguage { get; set; }
        public string FetchListItemLanguage { get; set; }
        public string FetchStaticHeadLanguage { get; set; }
        public string FetchLoadTagLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string FetchIdValue { get; set; }
        public string FetchNameValue { get; set; }

        public bool FetchActiveValue { get; set; } = false;
        public bool SqlQueryUseLanguageValue { get; set; } = false;
        public bool SqlQueryUseModuleValue { get; set; } = false;
        public bool SqlQueryUsePluginValue { get; set; } = false;
        public bool SqlQueryUseReplacePartValue { get; set; } = false;
        public bool SqlQueryUseFetchValue { get; set; } = false;
        public bool SqlQueryUseItemValue { get; set; } = false;
        public bool SqlQueryUseElanatValue { get; set; } = false;
        public bool BoxUseLanguageValue { get; set; } = false;
        public bool BoxUseModuleValue { get; set; } = false;
        public bool BoxUsePluginValue { get; set; } = false;
        public bool BoxUseReplacePartValue { get; set; } = false;
        public bool BoxUseFetchValue { get; set; } = false;
        public bool BoxUseItemValue { get; set; } = false;
        public bool BoxUseElanatValue { get; set; } = false;
        public bool ListItemUseLanguageValue { get; set; } = false;
        public bool ListItemUseModuleValue { get; set; } = false;
        public bool ListItemUsePluginValue { get; set; } = false;
        public bool ListItemUseReplacePartValue { get; set; } = false;
        public bool ListItemUseFetchValue { get; set; } = false;
        public bool ListItemUseItemValue { get; set; } = false;
        public bool ListItemUseElanatValue { get; set; } = false;
        public bool FetchPublicAccessShowValue { get; set; } = false;

        public string FetchCategoryValue { get; set; }
        public string FetchSqlQueryValue { get; set; }
        public string FetchBoxValue { get; set; }
        public string FetchListItemValue { get; set; }
        public string FetchCacheDurationValue { get; set; }
        public string FetchCacheParametersValue { get; set; }
        public string FetchSortIndexValue { get; set; }
        public string FetchStaticHeadValue { get; set; }
        public string FetchLoadTagValue { get; set; }

        public string FetchCategoryAttribute { get; set; }
        public string FetchSqlQueryAttribute { get; set; }
        public string FetchBoxAttribute { get; set; }
        public string FetchListItemAttribute { get; set; }
        public string FetchCacheDurationAttribute { get; set; }
        public string FetchCacheParametersAttribute { get; set; }
        public string FetchSortIndexAttribute { get; set; }
        public string FetchStaticHeadAttribute { get; set; }
        public string FetchLoadTagAttribute { get; set; }

        public string FetchCategoryCssClass { get; set; }
        public string FetchSqlQueryCssClass { get; set; }
        public string FetchBoxCssClass { get; set; }
        public string FetchListItemCssClass { get; set; }
        public string FetchCacheDurationCssClass { get; set; }
        public string FetchCacheParametersCssClass { get; set; }
        public string FetchSortIndexCssClass { get; set; }
        public string FetchStaticHeadCssClass { get; set; }
        public string FetchLoadTagCssClass { get; set; }

        public ListItemCollection SqlQueryColumnListItem = new ListItemCollection();
        public string SqlQueryColumnListValue { get; set; }
        public string SqlQueryColumnTemplateValue { get; set; }
        public ListItemCollection FetchMenuListItem = new ListItemCollection();
        public string FetchMenuListValue { get; set; }
        public string FetchMenuTemplateValue { get; set; }
        public ListItemCollection FetchAccessShowListItem = new ListItemCollection();
        public string FetchAccessShowListValue { get; set; }
        public string FetchAccessShowTemplateValue { get; set; }

        public string SqlQueryColumnAttribute { get; set; }
        public string SqlQueryColumnCssClass { get; set; }
        public string FetchMenuAttribute { get; set; }
        public string FetchMenuCssClass { get; set; }
        public string FetchAccessShowAttribute { get; set; }
        public string FetchAccessShowCssClass { get; set; }

        public List<string> SaveFetchEvaluateErrorList;
        public List<string> SqlQueryColumnEvaluateErrorList;
        public bool FindSaveFetchEvaluateError = false;
        public bool FindSqlQueryColumnEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/");
            GetSqlQueryColumnLanguage = aol.GetAddOnsLanguage("get_sql_query_column");
            SaveFetchLanguage = aol.GetAddOnsLanguage("save_fetch");
            BoxUseElanatLanguage = aol.GetAddOnsLanguage("box_use_elanat");
            BoxUseFetchLanguage = aol.GetAddOnsLanguage("box_use_fetch");
            BoxUseItemLanguage = aol.GetAddOnsLanguage("box_use_item");
            BoxUseLanguageLanguage = aol.GetAddOnsLanguage("box_use_language");
            BoxUseModuleLanguage = aol.GetAddOnsLanguage("box_use_module");
            BoxUsePluginLanguage = aol.GetAddOnsLanguage("box_use_plugin");
            BoxUseReplacePartLanguage = aol.GetAddOnsLanguage("box_use_replace_part");
            FetchActiveLanguage = aol.GetAddOnsLanguage("fetch_active");
            FetchPublicAccessShowLanguage = aol.GetAddOnsLanguage("fetch_public_access_show");
            ListItemUseElanatLanguage = aol.GetAddOnsLanguage("list_item_use_elanat");
            ListItemUseFetchLanguage = aol.GetAddOnsLanguage("list_item_use_fetch");
            ListItemUseItemLanguage = aol.GetAddOnsLanguage("list_item_use_item");
            ListItemUseLanguageLanguage = aol.GetAddOnsLanguage("list_item_use_language");
            ListItemUseModuleLanguage = aol.GetAddOnsLanguage("list_item_use_module");
            ListItemUsePluginLanguage = aol.GetAddOnsLanguage("list_item_use_plugin");
            ListItemUseReplacePartLanguage = aol.GetAddOnsLanguage("list_item_use_replace_part");
            SqlQueryUseElanatLanguage = aol.GetAddOnsLanguage("sql_query_use_elanat");
            SqlQueryUseFetchLanguage = aol.GetAddOnsLanguage("sql_query_use_fetch");
            SqlQueryUseItemLanguage = aol.GetAddOnsLanguage("sql_query_use_item");
            SqlQueryUseLanguageLanguage = aol.GetAddOnsLanguage("sql_query_use_language");
            SqlQueryUseModuleLanguage = aol.GetAddOnsLanguage("sql_query_use_module");
            SqlQueryUsePluginLanguage = aol.GetAddOnsLanguage("sql_query_use_plugin");
            SqlQueryUseReplacePartLanguage = aol.GetAddOnsLanguage("sql_query_use_replace_part");
            EditFetchLanguage = aol.GetAddOnsLanguage("edit_fetch");
            FetchAccessShowLanguage = aol.GetAddOnsLanguage("fetch_access_show");
            FetchBoxLanguage = aol.GetAddOnsLanguage("fetch_box");
            FetchCacheDurationLanguage = aol.GetAddOnsLanguage("fetch_cache_duration");
            FetchCategoryLanguage = aol.GetAddOnsLanguage("fetch_category");
            FetchListItemLanguage = aol.GetAddOnsLanguage("fetch_list_item");
            FetchLoadTagLanguage = aol.GetAddOnsLanguage("fetch_load_tag");
            FetchMenuLanguage = aol.GetAddOnsLanguage("fetch_menu");
            FetchNameLanguage = aol.GetAddOnsLanguage("fetch_name");
            FetchSortIndexLanguage = aol.GetAddOnsLanguage("fetch_sort_index");
            FetchSqlQueryLanguage = aol.GetAddOnsLanguage("fetch_sql_query");
            FetchStaticHeadLanguage = aol.GetAddOnsLanguage("fetch_static_head");
            SqlQueryColumnLanguage = aol.GetAddOnsLanguage("sql_query_column");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Fetch duf = new DataUse.Fetch();
                duf.FillCurrentFetch(FetchIdValue);

                FetchNameValue = duf.FetchName;
                FetchCategoryValue = duf.FetchCategory;
                FetchCacheDurationValue = duf.FetchCacheDuration;
                FetchSortIndexValue = duf.FetchSortIndex;
                FetchPublicAccessShowValue = duf.FetchPublicAccessShow.ZeroOneToBoolean();
                FetchActiveValue = duf.FetchActive.ZeroOneToBoolean();


                // Set Fetch Template
                XmlDocument FetchDocument = new XmlDocument();
                FetchDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/fetch/" + duf.FetchName + "/fetch.xml"));

                FetchSqlQueryValue = FetchDocument.SelectSingleNode("fetch_root/sql_query").InnerText;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_language"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_language"].Value == "true")
                        SqlQueryUseLanguageValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_module"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_module"].Value == "true")
                        SqlQueryUseModuleValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_plugin"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_plugin"].Value == "true")
                        SqlQueryUsePluginValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_replace_part"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_replace_part"].Value == "true")
                        SqlQueryUseReplacePartValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_fetch"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_fetch"].Value == "true")
                        SqlQueryUseFetchValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_item"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_item"].Value == "true")
                        SqlQueryUseItemValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_elanat"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_elanat"].Value == "true")
                        SqlQueryUseElanatValue = true;

                FetchBoxValue = FetchDocument.SelectSingleNode("fetch_root/box").InnerText;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_language"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_language"].Value == "true")
                        BoxUseLanguageValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_module"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_module"].Value == "true")
                        BoxUseModuleValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_plugin"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_plugin"].Value == "true")
                        BoxUsePluginValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_replace_part"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_replace_part"].Value == "true")
                        BoxUseReplacePartValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_fetch"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_fetch"].Value == "true")
                        BoxUseFetchValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_item"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_item"].Value == "true")
                        BoxUseItemValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_elanat"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_elanat"].Value == "true")
                        BoxUseElanatValue = true;

                if (string.IsNullOrEmpty(FetchListItemValue))
                    FetchListItemValue = FetchDocument.SelectSingleNode("fetch_root/list_item").InnerText;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_language"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_language"].Value == "true")
                        ListItemUseLanguageValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_module"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_module"].Value == "true")
                        ListItemUseModuleValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_plugin"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_plugin"].Value == "true")
                        ListItemUsePluginValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_replace_part"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_replace_part"].Value == "true")
                        BoxUseReplacePartValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_fetch"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_fetch"].Value == "true")
                        BoxUseFetchValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_item"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_item"].Value == "true")
                        BoxUseItemValue = true;

                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_elanat"] != null)
                    if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_elanat"].Value == "true")
                        BoxUseElanatValue = true;

                AttributeReader ar = new AttributeReader();
                string SqlQuery = FetchSqlQueryValue;

                if (SqlQueryUseLanguageValue)
                    SqlQuery = ar.ReadLanguage(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUseModuleValue)
                    SqlQuery = ar.ReadModule(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUsePluginValue)
                    SqlQuery = ar.ReadPlugin(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUseReplacePartValue)
                    SqlQuery = ar.ReadReplacePart(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUseFetchValue)
                    SqlQuery = ar.ReadFetch(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUseItemValue)
                    SqlQuery = ar.ReadItem(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                if (SqlQueryUseElanatValue)
                    SqlQuery = ar.ReadElanat(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

                FetchStaticHeadValue = FetchDocument.SelectSingleNode("fetch_root/static_head").InnerText;
                FetchLoadTagValue = FetchDocument.SelectSingleNode("fetch_root/load_tag").InnerText;


                // Check If Submit Get Sql Query Column Button
                if (SqlQueryColumnListItem.Count == 0)
                {
                    DataBaseSocket db = new DataBaseSocket();
                    DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetCommand(SqlQuery);

                    for (int i = 0; i < dbdr.dr.FieldCount; i++)
                        SqlQueryColumnListItem.Add(dbdr.dr.GetName(i));

                    foreach (XmlNode node in FetchDocument.SelectSingleNode("fetch_root/item").ChildNodes)
                        SqlQueryColumnListItem.FindByValue(node.Name).Selected = true;

                    db.Close();
                }
            }

            ListClass lc = new ListClass();

            // Set Menu
            lc.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_FetchMenu");
            HtmlCheckBoxListMenu.AddRange(lc.MenuListItem);
            FetchMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            FetchMenuListValue = HtmlCheckBoxListMenu.GetList();
            FetchMenuTemplateValue = FetchMenuTemplateValue.Replace("$_asp attribute;", FetchMenuAttribute);
            FetchMenuTemplateValue = FetchMenuTemplateValue.Replace("$_asp css_class;", FetchMenuCssClass);
            FetchMenuTemplateValue = FetchMenuTemplateValue.HtmlInputSetCheckBoxListValue(FetchMenuListItem);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Fetch Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_FetchAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            FetchAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            FetchAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.Replace("$_asp attribute;", FetchAccessShowAttribute);
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.Replace("$_asp css_class;", FetchAccessShowCssClass);
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(FetchAccessShowListItem);

            // Check If Submit Get Sql Query Column Button
            if (string.IsNullOrEmpty(SqlQueryColumnTemplateValue))
            {
                // Set Sql Query Column
                HtmlCheckBoxList HtmlCheckBoxListSqlQueryColumn = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_SqlQueryColumn");
                HtmlCheckBoxListSqlQueryColumn.AddRange(SqlQueryColumnListItem);
                SqlQueryColumnTemplateValue = HtmlCheckBoxListSqlQueryColumn.GetValue();
                SqlQueryColumnListValue = HtmlCheckBoxListSqlQueryColumn.GetList();
                SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.Replace("$_asp attribute;", SqlQueryColumnAttribute);
                SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.Replace("$_asp css_class;", SqlQueryColumnCssClass);
                SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.HtmlInputSetCheckBoxListValue(SqlQueryColumnListItem);
            }

            // Set Fetch Access Show Selected Value
            lc.FillFetchAccessShowListItem(FetchIdValue);
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lc.FetchAccessShowListItem);

            // Set Fetch Menu Selected Value
            lc.FillFetchMenuListItem(FetchIdValue);
            FetchMenuTemplateValue = FetchMenuTemplateValue.HtmlInputSetCheckBoxListValue(lc.FetchMenuListItem);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_FetchSqlQuery", "");
            InputRequest.Add("txt_FetchBox", "");
            InputRequest.Add("txt_FetchListItem", "");
            InputRequest.Add("txt_FetchStaticHead", "");
            InputRequest.Add("txt_FetchLoadTag", "");
            InputRequest.Add("txt_FetchCategory", "");
            InputRequest.Add("txt_FetchCacheDuration", "");
            InputRequest.Add("txt_FetchCacheParameters", "");
            InputRequest.Add("txt_FetchSortIndex", "");
            InputRequest.Add("cbxlst_FetchMenu", FetchMenuListValue);
            InputRequest.Add("cbxlst_FetchAccessShow", FetchAccessShowListValue);
            InputRequest.Add("cbxlst_SqlQueryColumn$", SqlQueryColumnListValue);
            InputRequest.Add("hdn_FetchName", FetchNameValue);
            InputRequest.Add("hdn_FetchId", FetchIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/fetch/");

            FetchSqlQueryAttribute += vc.ImportantInputAttribute["txt_FetchSqlQuery"];
            FetchBoxAttribute += vc.ImportantInputAttribute["txt_FetchBox"];
            FetchListItemAttribute += vc.ImportantInputAttribute["txt_FetchListItem"];
            FetchStaticHeadAttribute += vc.ImportantInputAttribute["txt_FetchStaticHead"];
            FetchLoadTagAttribute += vc.ImportantInputAttribute["txt_FetchLoadTag"];
            FetchCategoryAttribute += vc.ImportantInputAttribute["txt_FetchCategory"];
            FetchCacheDurationAttribute += vc.ImportantInputAttribute["txt_FetchCacheDuration"];
            FetchCacheParametersAttribute += vc.ImportantInputAttribute["txt_FetchCacheParameters"];
            FetchSortIndexAttribute += vc.ImportantInputAttribute["txt_FetchSortIndex"];
            FetchMenuAttribute += vc.ImportantInputAttribute["cbxlst_FetchMenu"];
            FetchAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_FetchAccessShow"];
            SqlQueryColumnAttribute += vc.ImportantInputAttribute["cbxlst_SqlQueryColumn"];

            FetchSqlQueryCssClass = FetchSqlQueryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchSqlQuery"]);
            FetchBoxCssClass = FetchBoxCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchBox"]);
            FetchListItemCssClass = FetchListItemCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchListItem"]);
            FetchStaticHeadCssClass = FetchStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchStaticHead"]);
            FetchLoadTagCssClass = FetchLoadTagCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchLoadTag"]);
            FetchCategoryCssClass = FetchCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchCategory"]);
            FetchCacheDurationCssClass = FetchCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchCacheDuration"]);
            FetchCacheParametersCssClass = FetchCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchCacheParameters"]);
            FetchSortIndexCssClass = FetchSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FetchSortIndex"]);
            FetchMenuCssClass = FetchMenuCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_FetchMenu"]);
            FetchAccessShowCssClass = FetchAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_FetchAccessShow"]);
            SqlQueryColumnCssClass = SqlQueryColumnCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_SqlQueryColumn"]);
        }

        public void SaveFetchEvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/fetch/");

            SaveFetchEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSaveFetchEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //FetchSqlQueryCssClass = FetchSqlQueryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchSqlQuery"]);
                //FetchBoxCssClass = FetchBoxCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchBox"]);
                //FetchListItemCssClass = FetchListItemCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchListItem"]);
                //FetchStaticHeadCssClass = FetchStaticHeadCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchStaticHead"]);
                //FetchLoadTagCssClass = FetchLoadTagCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchLoadTag"]);
                //FetchCategoryCssClass = FetchCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchCategory"]);
                //FetchCacheDurationCssClass = FetchCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchCacheDuration"]);
                //FetchCacheParametersCssClass = FetchCacheParametersCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchCacheParameters"]);
                //FetchSortIndexCssClass = FetchSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchSortIndex"]);
                //FetchMenuCssClass = FetchMenuCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_FetchMenu"]);
                //FetchAccessShowCssClass = FetchAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_FetchAccessShow"]);
                //SqlQueryColumnCssClass = SqlQueryColumnCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_SqlQueryColumn"]);
            }
        }

        public void SqlQueryColumnEvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "sql_query", StaticObject.AdminPath + "/fetch/");

            SqlQueryColumnEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSqlQueryColumnEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //FetchSqlQueryCssClass = FetchSqlQueryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FetchSqlQuery"]);
            }
        }

        public void SaveFetch()
        {
            // Change Database Data
            DataUse.Fetch duf = new DataUse.Fetch();

            duf.FetchId = FetchIdValue;
            duf.FetchName = FetchNameValue;
            duf.FetchCategory = FetchCategoryValue;
            duf.FetchCacheDuration = FetchCacheDurationValue;
            duf.FetchSortIndex = FetchSortIndexValue;
            duf.FetchPublicAccessShow = FetchPublicAccessShowValue.BooleanToZeroOne();
            duf.FetchActive = FetchActiveValue.BooleanToZeroOne();

            // Edit Fetch
            duf.Edit();

            // Delete Menu Fetch
            duf.DeleteMenuFetch(duf.FetchId);

            // Add Menu Fetch
            duf.AddMenuFetch(duf.FetchId, FetchMenuListItem);

            // Delete Fetch Access Show
            duf.DeleteFetchAccessShow(duf.FetchId);

            // Set Fetch Access Show
            duf.SetFetchAccessShow(duf.FetchId, FetchAccessShowListItem);

            // Set Fetch Access Show
            duf.SetFetchAccessShow(duf.FetchId, FetchAccessShowListItem);

            // Create Fetch Template
            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/fetch.xml"));

            XmlCDataSection SqlQueryCData = FetchDocument.CreateCDataSection(FetchSqlQueryValue);
            FetchDocument.SelectSingleNode("fetch_root/sql_query").InnerText = "";
            FetchDocument.SelectSingleNode("fetch_root/sql_query").AppendChild(SqlQueryCData);

            if (SqlQueryUseLanguageValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_language", "true");

            if (SqlQueryUseModuleValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_module", "true");

            if (SqlQueryUsePluginValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_plugin", "true");

            if (SqlQueryUseReplacePartValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_replace_part", "true");

            if (SqlQueryUseFetchValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_fetch", "true");

            if (SqlQueryUseItemValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_item", "true");

            if (SqlQueryUseElanatValue)
                FetchDocument.SelectSingleNode("fetch_root")["sql_query"].SetAttribute("use_elanat", "true");


            XmlCDataSection BoxCData = FetchDocument.CreateCDataSection(FetchBoxValue);
            FetchDocument.SelectSingleNode("fetch_root/box").InnerText = "";
            FetchDocument.SelectSingleNode("fetch_root/box").AppendChild(BoxCData);

            if (BoxUseLanguageValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_language", "true");

            if (BoxUseModuleValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_module", "true");

            if (BoxUsePluginValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_plugin", "true");

            if (BoxUseReplacePartValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_replace_part", "true");

            if (BoxUseFetchValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_fetch", "true");

            if (BoxUseItemValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_item", "true");

            if (BoxUseElanatValue)
                FetchDocument.SelectSingleNode("fetch_root")["box"].SetAttribute("use_elanat", "true");


            XmlCDataSection ListItemCData = FetchDocument.CreateCDataSection(FetchListItemValue);
            FetchDocument.SelectSingleNode("fetch_root/list_item").InnerText = "";
            FetchDocument.SelectSingleNode("fetch_root/list_item").AppendChild(ListItemCData);

            if (ListItemUseLanguageValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_language", "true");

            if (ListItemUseModuleValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_module", "true");

            if (ListItemUsePluginValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_plugin", "true");

            if (ListItemUseReplacePartValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_replace_part", "true");

            if (ListItemUseFetchValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_fetch", "true");

            if (ListItemUseItemValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_item", "true");

            if (ListItemUseElanatValue)
                FetchDocument.SelectSingleNode("fetch_root")["list_item"].SetAttribute("use_elanat", "true");


            foreach (ListItem item in SqlQueryColumnListItem)
            {
                if (item.Selected)
                {
                    XmlElement ItemElement = FetchDocument.CreateElement(item.Value);
                    ItemElement.InnerText = "$_db " + item.Value + ";";
                    FetchDocument.SelectSingleNode("fetch_root/item").AppendChild(ItemElement);
                }
            }

            XmlCDataSection StaticHeadCData = FetchDocument.CreateCDataSection(FetchStaticHeadValue);
            FetchDocument.SelectSingleNode("fetch_root/static_head").InnerText = "";
            FetchDocument.SelectSingleNode("fetch_root/static_head").AppendChild(StaticHeadCData);

            XmlCDataSection LoadTagCData = FetchDocument.CreateCDataSection(FetchLoadTagValue);
            FetchDocument.SelectSingleNode("fetch_root/load_tag").InnerText = "";
            FetchDocument.SelectSingleNode("fetch_root/load_tag").AppendChild(LoadTagCData);


            FetchDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/fetch/" + duf.FetchName + "/fetch.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_fetch", duf.FetchName);
        }

        public void GetSqlQueryColumn()
        {
            AttributeReader ar = new AttributeReader();
            string SqlQuery = FetchSqlQueryValue;

            if (SqlQueryUseLanguageValue)
                SqlQuery = ar.ReadLanguage(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseModuleValue)
                SqlQuery = ar.ReadModule(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUsePluginValue)
                SqlQuery = ar.ReadPlugin(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseReplacePartValue)
                SqlQuery = ar.ReadReplacePart(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseFetchValue)
                SqlQuery = ar.ReadFetch(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseItemValue)
                SqlQuery = ar.ReadItem(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseElanatValue)
                SqlQuery = ar.ReadElanat(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            SqlQueryColumnListItem = new ListItemCollection();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseSocket db2 = new DataBaseSocket();

            // Check Query Error
            db.GetCommand(SqlQuery);
            if (!string.IsNullOrEmpty(db.ErrorMessage))
                ResponseForm.WriteLocalAlone(db.ErrorMessage, "problem");

            db.Close();

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db2.GetCommand(SqlQuery);

            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/fetch.xml"));

            string ListItemTemplate = FetchDocument.SelectSingleNode("fetch_root/list_item").InnerText;
            string SumSqlQueryColumn = "";

            for (int i = 0; i < dbdr.dr.FieldCount; i++)
            {
                SqlQueryColumnListItem.Add(dbdr.dr.GetName(i));
                SqlQueryColumnListItem[i].Selected = true;

                SumSqlQueryColumn += "$_db " + dbdr.dr.GetName(i) + ";";
            }

            db2.Close();

            FetchListItemValue = ListItemTemplate.Replace("$_asp item;", SumSqlQueryColumn);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/fetch/action/SuccessMessage.aspx");
        }
    }
}