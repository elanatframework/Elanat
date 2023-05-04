using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class AdminRefresh : System.Web.UI.Page
    {
        public AdminRefreshModel model = new AdminRefreshModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ApplicationStart"]))
                btn_ApplicationStart_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_Cache"]))
                btn_Cache_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_Session"]))
                btn_Session_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_LoginIpBlackList"]))
                btn_LoginIpBlackList_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_LockLogin"]))
                btn_LockLogin_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SiteCategory"]))
                btn_SiteCategory_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_UploadFileList"]))
                btn_UploadFileList_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_DiskCacheDirectory"]))
                btn_DiskCacheDirectory(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_TmpDirectory"]))
                btn_TmpDirectory_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_LogsDirectory"]))
                btn_LogsDirectory_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_FoorPrint"]))
                btn_FoorPrint_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_MoveTmpBinDirectory"]))
                btn_MoveTmpBinDirectory_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_DeleteDeletedAddOnDirectory"]))
                btn_DeleteDeletedAddOnDirectory_Click(sender, e);


            model.SetValue();
        }

        protected void btn_ApplicationStart_Click(object sender, EventArgs e)
        {
            Global g = new Global();
            g.Application_Start(sender, e);

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("refresh_application_start", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("application_start_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_Cache_Click(object sender, EventArgs e)
        {
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove((entry.Key).ToString());
            }

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_cache", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("cache_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_Session_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.RemoveAll();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_session", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("session_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_LoginIpBlackList_Click(object sender, EventArgs e)
        {
            Security.LoginIpBlackList.Clear();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_login_ip_black_list", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("login_ip_black_list_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_LockLogin_Click(object sender, EventArgs e)
        {
            StaticObject.LockLogin = (ElanatConfig.GetNode("security/lock_login_for_first_login").Attributes["active"].Value == "true");

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("refresh_lock_login", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("lock_login_was_refresh", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_SiteCategory_Click(object sender, EventArgs e)
        {
            // Set Current Value
            ListClass li = new ListClass();
            li.FillSiteGlobalNameListItem();

            CategoryMap cm = new CategoryMap();

            foreach (ListItem item in li.SiteGlobalNameListItem)
                cm.CreateCategoryMap(item.Text, item.Value);

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("re_create_category_map", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_category_has_been_re_create_in_category_map_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_UploadFileList_Click(object sender, EventArgs e)
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.ReCreateUploadFileLis();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("re_create_upload_file_list", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_file_in_upload_directory_has_been_re_create_in_upload_file_list_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_DiskCacheDirectory(object sender, EventArgs e)
        {
            CacheClass cc = new CacheClass();
            cc.DeleteAllFromDisk();

            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_disk_cache_directory", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_disk_cache_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_TmpDirectory_Click(object sender, EventArgs e)
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_tmp_directory", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_tmp_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_LogsDirectory_Click(object sender, EventArgs e)
        {
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteAllFileAndSubDirectoryInDirectory(Server.MapPath(StaticObject.SitePath + "App_Data/logs/"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_file_and_sub_directory_in_logs_directory", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_file_and_sub_directory_in_logs_directory_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_FoorPrint_Click(object sender, EventArgs e)
        {
            DataUse.FootPrint duf = new DataUse.FootPrint();
            duf.DeleteAll();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_all_foot_print", "");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("all_foot_prints_has_been_delete_successfully", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/"), "success");
        }

        protected void btn_MoveTmpBinDirectory_Click(object sender, EventArgs e)
        {
            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("try_to_move_all_file_in_tmp_bin_directory_to_bin_directory", "");


            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/refresh/action/MoveTmpBinDirectory.aspx", false);
        }

        protected void btn_DeleteDeletedAddOnDirectory_Click(object sender, EventArgs e)
        {
            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("try_to_delete_deleted_add_on_directory", "");


            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/refresh/action/DeleteDeletedAddOnDirectory.aspx", false);
        }
    }
}