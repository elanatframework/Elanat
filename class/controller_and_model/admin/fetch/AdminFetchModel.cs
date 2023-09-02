using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminFetchModel : CodeBehindModel
    {
        public string FetchLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddFetchLanguage { get; set; }
        public string FetchPathLanguage { get; set; }
        public string UseFetchPathLanguage { get; set; }
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
        public string RefreshLanguage { get; set; }

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

        public bool UseFetchPathValue { get; set; } = false;
        public IFormFile FetchPathUploadValue { get; set; }
        public string FetchPathTextValue { get; set; }

        public string FetchNameValue { get; set; }
        public string FetchCategoryValue { get; set; }
        public string FetchSqlQueryValue { get; set; }
        public string FetchBoxValue { get; set; }
        public string FetchListItemValue { get; set; }
        public string FetchCacheDurationValue { get; set; }
        public string FetchCacheParametersValue { get; set; }
        public string FetchSortIndexValue { get; set; }
        public string FetchStaticHeadValue { get; set; }
        public string FetchLoadTagValue { get; set; }

        public string FetchNameAttribute { get; set; }
        public string FetchCategoryAttribute { get; set; }
        public string FetchSqlQueryAttribute { get; set; }
        public string FetchBoxAttribute { get; set; }
        public string FetchListItemAttribute { get; set; }
        public string FetchCacheDurationAttribute { get; set; }
        public string FetchCacheParametersAttribute { get; set; }
        public string FetchSortIndexAttribute { get; set; }
        public string FetchStaticHeadAttribute { get; set; }
        public string FetchLoadTagAttribute { get; set; }

        public string FetchNameCssClass { get; set; }
        public string FetchCategoryCssClass { get; set; }
        public string FetchSqlQueryCssClass { get; set; }
        public string FetchBoxCssClass { get; set; }
        public string FetchListItemCssClass { get; set; }
        public string FetchCacheDurationCssClass { get; set; }
        public string FetchCacheParametersCssClass { get; set; }
        public string FetchSortIndexCssClass { get; set; }
        public string FetchStaticHeadCssClass { get; set; }
        public string FetchLoadTagCssClass { get; set; }

        public List<ListItem> SqlQueryColumnListItem = new List<ListItem>();
        public string SqlQueryColumnListValue { get; set; }
        public List<ListItem> FetchMenuListItem = new List<ListItem>();
        public string FetchMenuListValue { get; set; }
        public string FetchMenuTemplateValue { get; set; }
        public List<ListItem> FetchAccessShowListItem = new List<ListItem>();
        public string FetchAccessShowListValue { get; set; }
        public string FetchAccessShowTemplateValue { get; set; }

        public string SqlQueryColumnAttribute { get; set; }
        public string SqlQueryColumnCssClass { get; set; }
        public string FetchMenuAttribute { get; set; }
        public string FetchMenuCssClass { get; set; }
        public string FetchAccessShowAttribute { get; set; }
        public string FetchAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> AddFetchEvaluateErrorList;
        public List<string> UploadFetchEvaluateErrorList;
        public List<string> SqlQueryColumnEvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindAddFetchEvaluateError = false;
        public bool FindUploadFetchEvaluateError = false;
        public bool FindSqlQueryColumnEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/");
            AddFetchLanguage = aol.GetAddOnsLanguage("add_fetch");
            AddLanguage = aol.GetAddOnsLanguage("add");
            GetSqlQueryColumnLanguage = aol.GetAddOnsLanguage("get_sql_query_column");
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
            UseFetchPathLanguage = aol.GetAddOnsLanguage("use_fetch_path");
            FetchAccessShowLanguage = aol.GetAddOnsLanguage("fetch_access_show");
            FetchBoxLanguage = aol.GetAddOnsLanguage("fetch_box");
            FetchCacheDurationLanguage = aol.GetAddOnsLanguage("fetch_cache_duration");
            FetchCategoryLanguage = aol.GetAddOnsLanguage("fetch_category");
            FetchLanguage = aol.GetAddOnsLanguage("fetch");
            FetchListItemLanguage = aol.GetAddOnsLanguage("fetch_list_item");
            FetchLoadTagLanguage = aol.GetAddOnsLanguage("fetch_load_tag");
            FetchMenuLanguage = aol.GetAddOnsLanguage("fetch_menu");
            FetchNameLanguage = aol.GetAddOnsLanguage("fetch_name");
            FetchPathLanguage = aol.GetAddOnsLanguage("fetch_path");
            FetchSortIndexLanguage = aol.GetAddOnsLanguage("fetch_sort_index");
            FetchSqlQueryLanguage = aol.GetAddOnsLanguage("fetch_sql_query");
            FetchStaticHeadLanguage = aol.GetAddOnsLanguage("fetch_static_head");
            SqlQueryColumnLanguage = aol.GetAddOnsLanguage("sql_query_column");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Menu
            ListClass.Menu lcm = new ListClass.Menu();
            lcm.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_FetchMenu");
            HtmlCheckBoxListMenu.AddRange(lcm.MenuListItem);
            FetchMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            FetchMenuListValue = HtmlCheckBoxListMenu.GetList();
            FetchMenuTemplateValue = FetchMenuTemplateValue.Replace("$_asp attribute;", FetchMenuAttribute);
            FetchMenuTemplateValue = FetchMenuTemplateValue.Replace("$_asp css_class;", FetchMenuCssClass);
            FetchMenuTemplateValue = FetchMenuTemplateValue.HtmlInputSetCheckBoxListValue(FetchMenuListItem);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Fetch Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_FetchAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            FetchAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            FetchAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.Replace("$_asp attribute;", FetchAccessShowAttribute);
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.Replace("$_asp css_class;", FetchAccessShowCssClass);
            FetchAccessShowTemplateValue = FetchAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(FetchAccessShowListItem);

            // Set Fetch Template
            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/fetch.xml"));

            if (string.IsNullOrEmpty(FetchBoxValue))
                FetchBoxValue = FetchDocument.SelectSingleNode("fetch_root/box").InnerText;


            FetchCacheDurationValue = "0";
            FetchSortIndexValue = "0";


            // Set Fetch Page List
            ActionGetFetchListModel lm = new ActionGetFetchListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_FetchName", "");
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

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/fetch/");

            FetchNameAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchName");
            FetchSqlQueryAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchSqlQuery");
            FetchBoxAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchBox");
            FetchListItemAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchListItem");
            FetchStaticHeadAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchStaticHead");
            FetchLoadTagAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchLoadTag");
            FetchCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchCategory");
            FetchCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchCacheDuration");
            FetchCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchCacheParameters");
            FetchSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_FetchSortIndex");
            FetchMenuAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_FetchMenu");
            FetchAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_FetchAccessShow");
            SqlQueryColumnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_SqlQueryColumn");

            FetchNameCssClass = FetchNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchName"));
            FetchSqlQueryCssClass = FetchSqlQueryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchSqlQuery"));
            FetchBoxCssClass = FetchBoxCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchBox"));
            FetchListItemCssClass = FetchListItemCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchListItem"));
            FetchStaticHeadCssClass = FetchStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchStaticHead"));
            FetchLoadTagCssClass = FetchLoadTagCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchLoadTag"));
            FetchCategoryCssClass = FetchCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchCategory"));
            FetchCacheDurationCssClass = FetchCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchCacheDuration"));
            FetchCacheParametersCssClass = FetchCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchCacheParameters"));
            FetchSortIndexCssClass = FetchSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FetchSortIndex"));
            FetchMenuCssClass = FetchMenuCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_FetchMenu"));
            FetchAccessShowCssClass = FetchAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_FetchAccessShow"));
            SqlQueryColumnCssClass = SqlQueryColumnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_SqlQueryColumn"));
        }

        public void AddFetchEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/fetch/");

            AddFetchEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindAddFetchEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void UploadFetchEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "use_path", StaticObject.AdminPath + "/fetch/");

            UploadFetchEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindUploadFetchEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SqlQueryColumnEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "sql_query", StaticObject.AdminPath + "/fetch/");

            SqlQueryColumnEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSqlQueryColumnEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddFetch()
        {
            if (!FetchPathUploadValue.HtmlInputHasFile() || (UseFetchPathValue && !string.IsNullOrEmpty(FetchPathTextValue)))
            {
                // Add Data To Database
                DataUse.Fetch duf = new DataUse.Fetch();

                duf.FetchName = FetchNameValue;
                duf.FetchCategory = FetchCategoryValue;
                duf.FetchCacheDuration = FetchCacheDurationValue;
                duf.FetchSortIndex = FetchSortIndexValue;
                duf.FetchPublicAccessShow = FetchPublicAccessShowValue.BooleanToZeroOne();
                duf.FetchActive = FetchActiveValue.BooleanToZeroOne();

                // Add Fetch
                duf.AddWithFillReturnDr();

                // Add Menu Fetch
                duf.AddMenuFetch(duf.FetchId, FetchMenuListItem);

                // Set Fetch Access Show
                duf.SetFetchAccessShow(duf.FetchId, FetchAccessShowListItem);

                // Create Fetch Template
                XmlDocument FetchDocument = new XmlDocument();
                FetchDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/fetch.xml"));

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

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + duf.FetchName + "/"));

                FetchDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + duf.FetchName + "/fetch.xml"));


                // Create New Catalog Document
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                XmlDocument NewCatalogDocument = new XmlDocument();
                NewCatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/catalog.xml"));

                NewCatalogDocument.SelectSingleNode("fetch_catalog_root/fetch_name").Attributes["value"].Value = FetchNameValue;
                NewCatalogDocument.SelectSingleNode("fetch_catalog_root/fetch_author").Attributes["value"].Value = ccoc.UserSiteName;
                NewCatalogDocument.SelectSingleNode("fetch_catalog_root/fetch_release_date").Attributes["value"].Value = DateAndTime.GetDate("yyyy/MM/dd");
                NewCatalogDocument.SelectSingleNode("fetch_catalog_root/fetch_category").Attributes["value"].Value = FetchCategoryValue;

                NewCatalogDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchNameValue + "/catalog.xml"));

                // Set Fetch Default Image
                File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/image.png"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchNameValue + "/image.png"));


                // Set Fetch Template
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
                string RowBoxTemplate = doc.SelectSingleNode("template_root/table/fetch/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string RowListItemTemplate = doc.SelectSingleNode("template_root/table/fetch/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string SumRowBoxTemplate = "";
                string SumRowListItemTemplate = "";
                string TmpRowBoxTemplate = RowBoxTemplate;

                List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/fetch/" + "App_Data/item_view/item_view.xml"));

                XmlNode ItemNode = doc.SelectSingleNode("template_root/table/fetch/item");

                foreach (string Text in ItemList)
                {
                    string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                    string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", duf.GetReturnDrColumnValue(Text));

                    // If Exist More Column For Replace
                    if (ItemNode[Text].Attributes["more_column"] != null)
                    {
                        char[] DelimiterChars = { ',' };
                        string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                        foreach (string Column in MoreColumnList)
                            TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", duf.GetReturnDrColumnValue(Column));
                    }

                    SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
                }

                foreach (XmlNode node in ItemNode.ChildNodes)
                    if (node.Attributes["active"] != null)
                        if (node.Attributes["active"].Value.TrueFalseToBoolean())
                            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", duf.GetReturnDrColumnValue(node.Name));

                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp fetch_id;", duf.FetchId);
                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp fetch_name;", duf.FetchName);
                TmpRowBoxTemplate = (duf.FetchActive.ZeroOneToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

                ContentValue += SumRowBoxTemplate;

                try { duf.ReturnDb.Close(); } catch (Exception) { }


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("add_fetch", duf.FetchName);


                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("fetch_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "success", false, StaticObject.AdminPath + "/fetch/action/FetchNewRow.aspx?fetch_id=" + duf.FetchId, "div_TableBox");

                return;
            }
            else
            {
                string FetchFilePhysicalName = "";
                string FileExtension = "";
                string DirectoryName = "";

                // If Use Fetch Path
                if (UseFetchPathValue)
                {
                    if (string.IsNullOrEmpty(FetchPathTextValue))
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_fetch_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "problem");

                        return;
                    }

                    HttpClient webClient = new HttpClient();

                    FetchFilePhysicalName = Path.GetFileName(FetchPathTextValue);

                    FileExtension = Path.GetExtension(FetchFilePhysicalName);

                    if (FileExtension != ".zip")
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "problem");

                        return;
                    }

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(FetchFilePhysicalName));

                    Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                    webClient.DownloadFile(FetchPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + FetchFilePhysicalName));
                }
                else
                {
                    if (!FetchPathUploadValue.HtmlInputHasFile())
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_fetch_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "problem");

                        return;
                    }

                    FetchFilePhysicalName = FetchPathUploadValue.FileName;

                    FileExtension = Path.GetExtension(FetchFilePhysicalName);

                    if (FileExtension != ".zip")
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "problem");

                        return;
                    }

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(FetchFilePhysicalName));

                    Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                    FetchPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + FetchFilePhysicalName));
                }

                // Check Fetch File Size
                double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + FetchFilePhysicalName)).Length;
                string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_fetch").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfFileSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                    return;
                }

                // Extract Zip File
                ZipFileClass zfc = new ZipFileClass();
                zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + FetchFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/fetch")))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "warning");

                    return;
                }

                XmlDocument CatalogDocument = new XmlDocument();
                CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/fetch/catalog.xml"));

                XmlNode FetchCatalog = CatalogDocument.SelectSingleNode("/fetch_catalog_root");


                // Unique Value To Column Check
                DataUse.Common common = new DataUse.Common();
                if (common.ExistValueToColumnCheck("el_fetch", "fetch_name", FetchCatalog["fetch_name"].Attributes["value"].Value))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("fetch_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "problem");

                    return;
                }


                string FetchCategory = FetchCatalog["fetch_category"].Attributes["value"].Value.SpaceToUnderline();
                string FetchDirectoryPath = FetchCatalog["fetch_name"].Attributes["value"].Value;
                FetchDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/"), FetchDirectoryPath);

                // Move All Fetch File In "fetch" Directory To Fetch
                Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/fetch/"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchDirectoryPath));

                // If "root" Directory Exist
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
                {
                    if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                        if (StaticObject.AdminDirectoryPath != "admin")
                            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));

                    /// <Action> Create Uninstall List
                    DirectoryInfo directory = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                    XmlDocument UninstallDocument = new XmlDocument();
                    UninstallDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                    XmlNode FilePathList = UninstallDocument.SelectSingleNode("uninstall_root/file_path_list");

                    foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                    {
                        XmlElement FilePathElement = UninstallDocument.CreateElement("file_path");
                        FilePathElement.InnerText = file.FullName.Replace(StaticObject.ServerMapPath((StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/").Replace("/","\\")), @"\");
                        FilePathList.AppendChild(FilePathElement);
                    }

                    UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchDirectoryPath + "/uninstall.xml"));


                    /// <Action> Move All File In "root" Directory To Site Path
                    FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
                }

                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // Add Data To Database
                DataUse.Fetch duf = new DataUse.Fetch();

                duf.FetchName = FetchDirectoryPath;
                duf.FetchCategory = FetchCategory;
                duf.FetchCacheDuration = FetchCacheDurationValue;
                duf.FetchSortIndex = FetchSortIndexValue;
                duf.FetchPublicAccessShow = FetchPublicAccessShowValue.BooleanToZeroOne();
                duf.FetchActive = FetchActiveValue.BooleanToZeroOne();

                // Add Fetch
                duf.AddWithFillReturnDr();

                // Add Menu Fetch
                duf.AddMenuFetch(duf.FetchId, FetchMenuListItem);

                // Set Fetch Access Show
                duf.SetFetchAccessShow(duf.FetchId, FetchAccessShowListItem);


                try { duf.ReturnDb.Close(); } catch (Exception) { }


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("add_fetch", duf.FetchName);


                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
                rf.AddLocalMessage(Language.GetAddOnsLanguage("fetch_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/"), "success");
                rf.AddPageLoad(StaticObject.AdminPath + "/fetch/action/FetchNewRow.aspx?fetch_id=" + duf.FetchId, "div_TableBox");
                rf.RedirectToResponseFormPage();
            }
        }

        public void GetSqlQueryColumn()
        {
            AttributeReader ar = new AttributeReader();
            string SqlQuery = FetchSqlQueryValue;
            string SqlQueryAddUsed = "";

            if (SqlQueryUseLanguageValue)
            {
                SqlQuery = ar.ReadLanguage(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_language=true";
            }

            if (SqlQueryUseModuleValue)
            {
                SqlQuery = ar.ReadModule(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_module=true";
            }

            if (SqlQueryUsePluginValue)
            {
                SqlQuery = ar.ReadPlugin(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_plugin=true";
            }

            if (SqlQueryUseReplacePartValue)
            {
                SqlQuery = ar.ReadReplacePart(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_replace_part=true";
            }

            if (SqlQueryUseFetchValue)
            {
                SqlQuery = ar.ReadFetch(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_fetch=true";
            }

            if (SqlQueryUseItemValue)
            {
                SqlQuery = ar.ReadItem(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_item=true";
            }

            if (SqlQueryUseElanatValue)
            {
                SqlQuery = ar.ReadElanat(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());
                SqlQueryAddUsed += "&sql_query_use_elanat=true";
            }


            // Check Query Error
            DataBaseSocket db = new DataBaseSocket();
            db.GetCommand(SqlQuery);

            if (!string.IsNullOrEmpty(db.ErrorMessage))
            {
                string ErrorMessage = db.ErrorMessage;

                db.Close();

                ResponseForm.WriteLocalAlone(ErrorMessage, "problem");

                return;
            }

            SqlQuery = SqlQuery.Replace("&", "$_asp sql_query_amp;");

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddPageLoad(StaticObject.AdminPath + "/fetch/action/GetFetchListItem.aspx?fetch_sql_query=" + SqlQuery + SqlQueryAddUsed, "div_SqlQueryColumnTemplate");
            rf.AddPageLoad(StaticObject.AdminPath + "/fetch/action/GetSqlQueryColumn.aspx?fetch_sql_query=" + SqlQuery + SqlQueryAddUsed, "div_FetchListItemBox");
            rf.RedirectToResponseFormPage();
        }
    }
}