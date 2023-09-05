using CodeBehind;

namespace Elanat
{
    public partial class AdminRefreshController : CodeBehindController
    {
        public AdminRefreshModel model = new AdminRefreshModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ApplicationStart"]))
            {
                btn_ApplicationStart_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_Cache"]))
            {
                btn_Cache_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_Session"]))
            {
                btn_Session_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_LoginIpBlackList"]))
            {
                btn_LoginIpBlackList_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_LockLogin"]))
            {
                btn_LockLogin_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SiteCategory"]))
            {
                btn_SiteCategory_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_UploadFileList"]))
            {
                btn_UploadFileList_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_DiskCacheDirectory"]))
            {
                btn_DiskCacheDirectory();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_TmpDirectory"]))
            {
                btn_TmpDirectory_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_LogsDirectory"]))
            {
                btn_LogsDirectory_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_FoorPrint"]))
            {
                btn_FoorPrint_Click();
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_ApplicationStart_Click()
        {
            StaticObject.ApplicationStart();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("refresh_application_start", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("application_start_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_Cache_Click()
        {
            CacheClass cc = new CacheClass();
            cc.DeleteAll();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_cache", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("cache_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_Session_Click(HttpContext context)
        {
            context.Session.Clear();
            context.Response.Cookies.Append("AspNetCore.Session", "");

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_session", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("session_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_LoginIpBlackList_Click()
        {
            Security.LoginIpBlackList.Clear();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_login_ip_black_list", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("login_ip_black_list_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_LockLogin_Click()
        {
            StaticObject.LockLogin = (ElanatConfig.GetNode("security/lock_login_for_first_login").Attributes["active"].Value == "true");

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("refresh_lock_login", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("lock_login_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_SiteCategory_Click()
        {
            // Set Current Value
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteGlobalNameListItem();

            CategoryMap cm = new CategoryMap();

            foreach (ListItem item in lcs.SiteGlobalNameListItem)
                cm.CreateCategoryMap(item.Text, item.Value);

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("re_create_category_map", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_category_has_been_re_create_in_category_map_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_UploadFileList_Click()
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.ReCreateUploadFileLis();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("re_create_upload_file_list", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_file_in_upload_directory_has_been_re_create_in_upload_file_list_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_DiskCacheDirectory()
        {
            CacheClass cc = new CacheClass();
            cc.DeleteAllFromDisk();

            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_disk_cache_directory", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_disk_cache_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_TmpDirectory_Click()
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_tmp_directory", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_tmp_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_LogsDirectory_Click()
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/logs/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_logs_directory", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_logs_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }

        protected void btn_FoorPrint_Click()
        {
            DataUse.FootPrint duf = new DataUse.FootPrint();
            duf.DeleteAll();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_foot_print", "");

            Write(GlobalClass.Alert(Language.GetAddOnsLanguage("all_foot_prints_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), StaticObject.GetCurrentAdminGlobalLanguage(), "success"));

            IgnoreViewAndModel = true;
        }
    }
}