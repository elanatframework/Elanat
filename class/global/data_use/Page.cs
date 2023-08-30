using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Page : IDisposable
    {
        public string PageId = "";
        public string PageName = "";
        public string PageGlobalName = "";
        public string UserId = ""; 
        public string PagePublicSite = "";
        public string PageTitle = "";
        public string PageDateCreate = "";
        public string PageTimeCreate = "";
        public string PageActive = "";
        public string PageDirectoryPath = "";
        public string PagePhysicalName = "";
        public string PageUseLanguage = "";
        public string PageUseModule = "";
        public string PageUsePlugin = "";
        public string PageUseReplacePart = "";
        public string PageUseFetch = "";
        public string PageUseItem = "";
        public string PageUseElanat = "";
        public string PageUseLoadTag = "";
        public string PageUseStaticHead = "";
        public string PageShowLinkInSite = "";
        public string PageLoadType = "";
        public string PageLoadTag = "";
        public string PageStaticHead = "";
        public string SiteStyleId = "";
        public string SiteTemplateId = "";
        public string PageLoadAlone = "";
        public string PageCacheDuration = "";
        public string PageCacheParameters = "";
        public string PageUseDescriptionMeta = "";
        public string PageUseRevisitAfterMeta = "";
        public string PageUseRightsMeta = "";
        public string PageUseKeywordsMeta = "";
        public string PageUseAuthorMeta = "";
        public string PageUseClassificationMeta = "";
        public string PageUseCopyrightMeta = "";
        public string PageUseLanguageMeta = "";
        public string PageUseRobotsMeta = "";
        public string PageUseApplicationNameMeta = "";
        public string PageUseGeneratorMeta = "";
        public string PageUseJavascriptInactiveRefreshMeta = "";
        public string PageDescriptionMeta = "";
        public string PageRevisitAfterMeta = "";
        public string PageRightsMeta = "";
        public string PageKeywordsMeta	= "";
        public string PageUseHtml = "";
        public string PagePublicAccessShow = "";
		public string PageQueryString = "";
        public string PageRobotsMeta = "";
        public string PageCopyrightMeta = "";
        public string PageClassificationMeta = "";
        public string PageVisit = "";
        public string PageCategory = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserPage(string UserId, string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_page", new List<string>() { "@user_id", "@page_id" }, new List<string>() { UserId, PageId });

            dbdr.dr.Read();

            bool IsUserPage = dbdr.dr["is_user_page"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserPage;
        }

        public void Active(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_page", "@page_id", PageId);
        }

        public void Inactive(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_page", "@page_id", PageId);
        }

        public void Delete(string PageId)
        {
            DataUse.Page dup = new DataUse.Page();
            dup.FillCurrentPage(PageId);
            
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_page", "@page_id", PageId);


            // Delete All Root File List
            string Path = "page/" + dup.PageDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            DeletePhysicalDirectory(dup.PageDirectoryPath);
        }

        public void DeletePhysicalDirectory(string PageDirectoryPath)
        {
            List<string> ParentDirectoryList = PageDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "page/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public string GetPageIdByPageGlobalName(string PageGlobalName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_id_by_page_global_name", "@page_global_name", PageGlobalName);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string StringPageId = dbdr.dr["page_id"].ToString();

                db.Close();

                return StringPageId;
            }

            db.Close();

            return null;
        }

        public string GetPageTitleByPageId(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_title_by_page_id", "@page_id", PageId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string PageTitle = dbdr.dr["page_title"].ToString();

            db.Close();

            return PageTitle;
        }

        public void IncreaseVisit(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_page_visit", "@page_id", PageId);
        }

        public string GetPageIdByPageDirectoryPath(string PageDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_id_by_page_directory_path", "@page_directory_path", PageDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PageId = dbdr.dr["page_id"].ToString();

                db.Close();

                return PageId;
            }

            db.Close();

            return null;
        }

        public bool GetPageAccessShowCheck(string PageId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("page_access_show_check_by_group_id", new List<string>() { "@page_id", "@group_id" }, new List<string>() { PageId, ccoc.GroupId });

            dbdr.dr.Read();

            string PageAccessShow = dbdr.dr["page_access_show"].ToString();

            db.Close();

            return (PageAccessShow == "1");
        }

        public void DeletePageAccessShow(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_page_access_show", "@page_id", PageId);
        }

        public void DeletePageSite(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_page_site", "@page_id", PageId);
        }
        
        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_page", new List<string>() { "@page_global_name", "@page_name", "@user_id", "@page_public_site", "@page_title", "@page_date_create", "@page_time_create", "@page_active", "@page_directory_path", "@page_physical_name", "@page_use_language", "@page_use_module", "@page_use_plugin", "@page_use_replace_part", "@page_use_fetch", "@page_use_item", "@page_use_elanat", "@page_use_load_tag", "@page_use_static_head", "@page_show_link_in_site", "@page_load_type", "@page_load_tag", "@page_static_head", "@site_style_id", "@site_template_id", "@page_load_alone", "@page_cache_duration", "@page_cache_parameters", "@page_use_classification_meta", "@page_use_copyright_meta", "@page_use_language_meta", "@page_use_robots_meta", "@page_use_application_name_meta", "@page_use_generator_meta", "@page_use_javascript_inactive_refresh_meta", "@page_use_description_meta", "@page_use_revisit_after_meta", "@page_use_rights_meta", "@page_use_keywords_meta", "@page_use_author_meta", "@page_description_meta", "@page_revisit_after_meta", "@page_rights_meta", "@page_keywords_meta", "@page_robots_meta", "@page_copyright_meta", "@page_classification_meta", "@page_visit", "@page_use_html", "@page_public_access_show", "@page_query_string", "@page_category" }, new List<string>() { PageGlobalName, PageName, UserId, PagePublicSite, PageTitle, PageDateCreate, PageTimeCreate, PageActive, PageDirectoryPath, PagePhysicalName, PageUseLanguage, PageUseModule, PageUsePlugin, PageUseReplacePart, PageUseFetch, PageUseItem, PageUseElanat, PageUseLoadTag, PageUseStaticHead, PageShowLinkInSite, PageLoadType, PageLoadTag, PageStaticHead, SiteStyleId, SiteTemplateId, PageLoadAlone, PageCacheDuration, PageCacheParameters, PageUseClassificationMeta, PageUseCopyrightMeta, PageUseLanguageMeta, PageUseRobotsMeta, PageUseApplicationNameMeta, PageUseGeneratorMeta, PageUseJavascriptInactiveRefreshMeta, PageUseDescriptionMeta, PageUseRevisitAfterMeta, PageUseRightsMeta, PageUseKeywordsMeta, PageUseAuthorMeta, PageDescriptionMeta, PageRevisitAfterMeta, PageRightsMeta, PageKeywordsMeta, PageRobotsMeta, PageCopyrightMeta, PageClassificationMeta, PageVisit, PageUseHtml, PagePublicAccessShow, PageQueryString, PageCategory });

            dbdr.dr.Read();

            PageId = dbdr.dr["page_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_page", new List<string>() { "@page_global_name", "@page_name", "@user_id", "@page_public_site", "@page_title", "@page_date_create", "@page_time_create", "@page_active", "@page_directory_path", "@page_physical_name", "@page_use_language", "@page_use_module", "@page_use_plugin", "@page_use_replace_part", "@page_use_fetch", "@page_use_item", "@page_use_elanat", "@page_use_load_tag", "@page_use_static_head", "@page_show_link_in_site", "@page_load_type", "@page_load_tag", "@page_static_head", "@site_style_id", "@site_template_id", "@page_load_alone", "@page_cache_duration", "@page_cache_parameters", "@page_use_classification_meta", "@page_use_copyright_meta", "@page_use_language_meta", "@page_use_robots_meta", "@page_use_application_name_meta", "@page_use_generator_meta", "@page_use_javascript_inactive_refresh_meta", "@page_use_description_meta", "@page_use_revisit_after_meta", "@page_use_rights_meta", "@page_use_keywords_meta", "@page_use_author_meta", "@page_description_meta", "@page_revisit_after_meta", "@page_rights_meta", "@page_keywords_meta", "@page_robots_meta", "@page_copyright_meta", "@page_classification_meta", "@page_visit", "@page_use_html", "@page_public_access_show", "@page_query_string", "@page_category" }, new List<string>() { PageGlobalName, PageName, UserId, PagePublicSite, PageTitle, PageDateCreate, PageTimeCreate, PageActive, PageDirectoryPath, PagePhysicalName, PageUseLanguage, PageUseModule, PageUsePlugin, PageUseReplacePart, PageUseFetch, PageUseItem, PageUseElanat, PageUseLoadTag, PageUseStaticHead, PageShowLinkInSite, PageLoadType, PageLoadTag, PageStaticHead, SiteStyleId, SiteTemplateId, PageLoadAlone, PageCacheDuration, PageCacheParameters, PageUseClassificationMeta, PageUseCopyrightMeta, PageUseLanguageMeta, PageUseRobotsMeta, PageUseApplicationNameMeta, PageUseGeneratorMeta, PageUseJavascriptInactiveRefreshMeta, PageUseDescriptionMeta, PageUseRevisitAfterMeta, PageUseRightsMeta, PageUseKeywordsMeta, PageUseAuthorMeta, PageDescriptionMeta, PageRevisitAfterMeta, PageRightsMeta, PageKeywordsMeta, PageRobotsMeta, PageCopyrightMeta, PageClassificationMeta, PageVisit, PageUseHtml, PagePublicAccessShow, PageQueryString, PageCategory });

            ReturnDr.Read();

            PageId = ReturnDr["page_id"].ToString();
        }
        
        public void SetPageAccessShow(string PageId, List<ListItem> PageAccessShowListPage)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in PageAccessShowListPage)
                if (item.Selected)
                    db.SetProcedure("set_page_access_show", new List<string>() { "@role_id", "@page_id" }, new List<string>() { item.Value, PageId });
        }

        // Overload
        public void SetPageAccessShow(List<ListItem> PageAccessShowListPage)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in PageAccessShowListPage)
                if (item.Selected)
                    db.SetProcedure("set_page_access_show", new List<string>() { "@role_id", "@page_id" }, new List<string>() { item.Value, PageId });
        }

        public void SetPageSite(string PageId, List<ListItem> PageSiteListPage)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in PageSiteListPage)
                if (item.Selected)
                    db.SetProcedure("set_page_site", new List<string>() { "@site_id", "@page_id" }, new List<string>() { item.Value, PageId });
        }

        // Overload
        public void SetPageSite(List<ListItem> PageSiteListPage)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in PageSiteListPage)
                if (item.Selected)
                    db.SetProcedure("set_page_site", new List<string>() { "@site_id", "@page_id" }, new List<string>() { item.Value, PageId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_page", new List<string>() { "@page_id", "@page_global_name", "@page_name", "@user_id", "@page_public_site", "@page_title", "@page_date_create", "@page_time_create", "@page_active", "@page_directory_path", "@page_physical_name", "@page_use_language", "@page_use_module", "@page_use_plugin", "@page_use_replace_part", "@page_use_fetch", "@page_use_item", "@page_use_elanat", "@page_use_load_tag", "@page_use_static_head", "@page_show_link_in_site", "@page_load_type", "@page_load_tag", "@page_static_head", "@site_style_id", "@site_template_id", "@page_load_alone", "@page_cache_duration", "@page_cache_parameters", "@page_use_classification_meta", "@page_use_copyright_meta", "@page_use_language_meta", "@page_use_robots_meta", "@page_use_application_name_meta", "@page_use_generator_meta", "@page_use_javascript_inactive_refresh_meta", "@page_use_description_meta", "@page_use_revisit_after_meta", "@page_use_rights_meta", "@page_use_keywords_meta", "@page_use_author_meta", "@page_description_meta", "@page_revisit_after_meta", "@page_rights_meta", "@page_keywords_meta", "@page_robots_meta", "@page_copyright_meta", "@page_classification_meta", "@page_visit", "@page_use_html", "@page_public_access_show", "@page_query_string", "@page_category" }, new List<string>() { PageId, PageGlobalName, PageName, UserId, PagePublicSite, PageTitle, PageDateCreate, PageTimeCreate, PageActive, PageDirectoryPath, PagePhysicalName, PageUseLanguage, PageUseModule, PageUsePlugin, PageUseReplacePart, PageUseFetch, PageUseItem, PageUseElanat, PageUseLoadTag, PageUseStaticHead, PageShowLinkInSite, PageLoadType, PageLoadTag, PageStaticHead, SiteStyleId, SiteTemplateId, PageLoadAlone, PageCacheDuration, PageCacheParameters, PageUseClassificationMeta, PageUseCopyrightMeta, PageUseLanguageMeta, PageUseRobotsMeta, PageUseApplicationNameMeta, PageUseGeneratorMeta, PageUseJavascriptInactiveRefreshMeta, PageUseDescriptionMeta, PageUseRevisitAfterMeta, PageUseRightsMeta, PageUseKeywordsMeta, PageUseAuthorMeta, PageDescriptionMeta, PageRevisitAfterMeta, PageRightsMeta, PageKeywordsMeta, PageRobotsMeta, PageCopyrightMeta, PageClassificationMeta, PageVisit, PageUseHtml, PagePublicAccessShow, PageQueryString, PageCategory });
        }
        
        public void FillCurrentPage(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_page","@page_id", PageId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.PageId = dbdr.dr["page_id"].ToString();
            PageName = dbdr.dr["page_name"].ToString();
            PageGlobalName = dbdr.dr["page_global_name"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            PagePublicSite = dbdr.dr["page_public_site"].ToString().TrueFalseToZeroOne();
            PageTitle = dbdr.dr["page_title"].ToString();
            PageDateCreate = dbdr.dr["page_date_create"].ToString();
            PageTimeCreate = dbdr.dr["page_time_create"].ToString();
            PageActive = dbdr.dr["page_active"].ToString().TrueFalseToZeroOne();
            PageDirectoryPath = dbdr.dr["page_directory_path"].ToString();
            PagePhysicalName = dbdr.dr["page_physical_name"].ToString();
            PageUseLanguage = dbdr.dr["page_use_language"].ToString().TrueFalseToZeroOne();
            PageUseModule = dbdr.dr["page_use_module"].ToString().TrueFalseToZeroOne();
            PageUsePlugin = dbdr.dr["page_use_plugin"].ToString().TrueFalseToZeroOne();
            PageUseReplacePart = dbdr.dr["page_use_replace_part"].ToString().TrueFalseToZeroOne();
            PageUseFetch= dbdr.dr["page_use_fetch"].ToString().TrueFalseToZeroOne();
            PageUseItem= dbdr.dr["page_use_item"].ToString().TrueFalseToZeroOne();
            PageUseElanat = dbdr.dr["page_use_elanat"].ToString().TrueFalseToZeroOne();
            PageUseLoadTag = dbdr.dr["page_use_load_tag"].ToString().TrueFalseToZeroOne();
            PageUseStaticHead = dbdr.dr["page_use_static_head"].ToString().TrueFalseToZeroOne();
            PageShowLinkInSite = dbdr.dr["page_show_link_in_site"].ToString().TrueFalseToZeroOne();
            PageLoadType = dbdr.dr["page_load_type"].ToString();
            PageLoadTag = dbdr.dr["page_load_tag"].ToString();
            PageStaticHead = dbdr.dr["page_static_head"].ToString();
            SiteStyleId = dbdr.dr["site_style_id"].ToString();
            SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            PageLoadAlone = dbdr.dr["page_load_alone"].ToString().TrueFalseToZeroOne();
            PageCacheDuration = dbdr.dr["page_cache_duration"].ToString();
            PageCacheParameters = dbdr.dr["page_cache_parameters"].ToString();
            PageUseDescriptionMeta = dbdr.dr["page_use_description_meta"].ToString().TrueFalseToZeroOne();
            PageUseRevisitAfterMeta = dbdr.dr["page_use_revisit_after_meta"].ToString().TrueFalseToZeroOne();
            PageUseRightsMeta = dbdr.dr["page_use_rights_meta"].ToString().TrueFalseToZeroOne();
            PageUseKeywordsMeta = dbdr.dr["page_use_keywords_meta"].ToString().TrueFalseToZeroOne();
            PageUseAuthorMeta = dbdr.dr["page_use_author_meta"].ToString().TrueFalseToZeroOne();
            PageUseClassificationMeta = dbdr.dr["page_use_classification_meta"].ToString().TrueFalseToZeroOne();
            PageUseCopyrightMeta = dbdr.dr["page_use_copyright_meta"].ToString().TrueFalseToZeroOne();
            PageUseLanguageMeta = dbdr.dr["page_use_language_meta"].ToString().TrueFalseToZeroOne();
            PageUseRobotsMeta = dbdr.dr["page_use_robots_meta"].ToString().TrueFalseToZeroOne();
            PageUseApplicationNameMeta = dbdr.dr["page_use_application_name_meta"].ToString().TrueFalseToZeroOne();
            PageUseGeneratorMeta = dbdr.dr["page_use_generator_meta"].ToString().TrueFalseToZeroOne();
            PageUseJavascriptInactiveRefreshMeta = dbdr.dr["page_use_javascript_inactive_refresh_meta"].ToString().TrueFalseToZeroOne();
            PageDescriptionMeta = dbdr.dr["page_description_meta"].ToString();
            PageRevisitAfterMeta = dbdr.dr["page_revisit_after_meta"].ToString();
            PageRightsMeta = dbdr.dr["page_rights_meta"].ToString();
            PageKeywordsMeta = dbdr.dr["page_keywords_meta"].ToString();
            PageUseHtml = dbdr.dr["page_use_html"].ToString().TrueFalseToZeroOne();
            PagePublicAccessShow = dbdr.dr["page_public_access_show"].ToString().TrueFalseToZeroOne();
            PageQueryString = dbdr.dr["page_query_string"].ToString();
            PageRobotsMeta = dbdr.dr["page_robots_meta"].ToString();
            PageCopyrightMeta = dbdr.dr["page_copyright_meta"].ToString();
            PageClassificationMeta = dbdr.dr["page_classification_meta"].ToString();
            PageVisit = dbdr.dr["page_visit"].ToString();
            PageCategory = dbdr.dr["page_category"].ToString();

            db.Close();
        }

        public void FillCurrentPageWithReturnDr(string PageId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_page", "@page_id", PageId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }

        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "page_id" : return PageId;
                case "page_name" : return PageName;
                case "page_global_name" : return PageGlobalName;
                case "user_id" : return UserId;
                case "page_public_site" : return PagePublicSite;
                case "page_title" : return PageTitle;
                case "page_date_create" : return PageDateCreate;
                case "page_time_create" : return PageTimeCreate;
                case "page_active" : return PageActive;
                case "page_directory_path" : return PageDirectoryPath;
                case "page_physical_name" : return PagePhysicalName;
                case "page_use_language" : return PageUseLanguage;
                case "page_use_module" : return PageUseModule;
                case "page_use_plugin" : return PageUsePlugin;
                case "page_use_replace_part": return PageUseReplacePart;
                case "page_use_fetch": return PageUseFetch;
                case "page_use_item": return PageUseItem;
                case "page_use_elanat": return PageUseElanat;
                case "page_use_load_tag": return PageUseLoadTag;
                case "page_use_static_head" : return PageUseStaticHead;
                case "page_show_link_in_site" : return PageShowLinkInSite;
                case "page_load_type" : return PageLoadType;
                case "page_load_tag" : return PageLoadTag;
                case "page_static_head" : return PageStaticHead;
                case "site_style_id" : return SiteStyleId;
                case "site_template_id" : return SiteTemplateId;
                case "page_load_alone" : return PageLoadAlone;
                case "page_cache_duration": return PageCacheDuration;
                case "page_cache_parameters": return PageCacheParameters;
                case "page_use_description_meta": return PageUseDescriptionMeta;
                case "page_use_revisit_after_meta" : return PageUseRevisitAfterMeta;
                case "page_use_rights_meta" : return PageUseRightsMeta;
                case "page_use_keywords_meta" : return PageUseKeywordsMeta;
                case "page_use_author_meta" : return PageUseAuthorMeta;
                case "page_use_classification_meta" : return PageUseClassificationMeta;
                case "page_use_copyright_meta" : return PageUseCopyrightMeta;
                case "page_use_language_meta" : return PageUseLanguageMeta;
                case "page_use_robots_meta" : return PageUseRobotsMeta;
                case "page_use_application_name_meta" : return PageUseApplicationNameMeta;
                case "page_use_generator_meta" : return PageUseGeneratorMeta;
                case "page_use_javascript_inactive_refresh_meta" : return PageUseJavascriptInactiveRefreshMeta;
                case "page_description_meta" : return PageDescriptionMeta;
                case "page_revisit_after_meta" : return PageRevisitAfterMeta;
                case "page_rights_meta" : return PageRightsMeta;
                case "page_keywords_meta" : return PageKeywordsMeta;
                case "page_use_html" : return PageUseHtml;
                case "page_public_access_show" : return PagePublicAccessShow;
                case "page_query_string" : return PageQueryString;
                case "page_robots_meta" : return PageRobotsMeta;
                case "page_copyright_meta" : return PageCopyrightMeta;
                case "page_classification_meta" : return PageClassificationMeta;
                case "page_visit" : return PageVisit;
                case "page_category" : return PageCategory;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            PageId = "";
            PageName = "";
            PageGlobalName = "";
            UserId = ""; 
            PagePublicSite = "";
            PageTitle = "";
            PageDateCreate = "";
            PageTimeCreate = "";
            PageActive = "";
            PageDirectoryPath = "";
            PagePhysicalName = "";
            PageUseLanguage = "";
            PageUseModule = "";
            PageUsePlugin = "";
            PageUseReplacePart = "";
            PageUseFetch = "";
            PageUseItem = "";
            PageUseElanat = "";
            PageUseLoadTag = "";
            PageUseStaticHead = "";
            PageShowLinkInSite = "";
            PageLoadType = "";
            PageLoadTag = "";
            PageStaticHead = "";
            SiteStyleId = "";
            SiteTemplateId = "";
            PageLoadAlone = "";
            PageCacheDuration = "";
            PageCacheParameters = "";
            PageUseDescriptionMeta = "";
            PageUseRevisitAfterMeta = "";
            PageUseRightsMeta = "";
            PageUseKeywordsMeta = "";
            PageUseAuthorMeta = "";
            PageUseClassificationMeta = "";
            PageUseCopyrightMeta = "";
            PageUseLanguageMeta = "";
            PageUseRobotsMeta = "";
            PageUseApplicationNameMeta = "";
            PageUseGeneratorMeta = "";
            PageUseJavascriptInactiveRefreshMeta = "";
            PageDescriptionMeta = "";
            PageRevisitAfterMeta = "";
            PageRightsMeta = "";
            PageKeywordsMeta	= "";
            PageUseHtml = "";
            PagePublicAccessShow = "";
		    PageQueryString = "";
            PageRobotsMeta = "";
            PageCopyrightMeta = "";
            PageClassificationMeta = "";
            PageVisit = "";
            PageCategory = "";

            ReturnDr.Close();
        }

        public string GetPageCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string PageCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return PageCount;
        }

        public string GetPageName(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_name", "@page_id", PageId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PageName = dbdr.dr["page_name"].ToString();

                db.Close();

                return PageName;
            }

            db.Close();

            return null;
        }

        public string GetPageGlobalName(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_global_name", "@page_id", PageId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PageGlobalName = dbdr.dr["page_global_name"].ToString();

                db.Close();

                return PageGlobalName;
            }

            db.Close();

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}