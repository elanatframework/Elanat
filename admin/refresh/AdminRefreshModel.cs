using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminRefreshModel
    {
        public string ApplicationStartLanguage { get; set; }
        public string LockLoginLanguage { get; set; }
        public string CacheLanguage { get; set; }
        public string CookieLanguage { get; set; }
        public string LoginIpBlackListLanguage { get; set; }
        public string SessionLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string ReCreateLanguage { get; set; }
        public string SiteCategoryLanguage { get; set; }
        public string UploadFileListLanguage { get; set; }
        public string DeleteLanguage { get; set; }
        public string MoveTmpBinDirectoryLanguage { get; set; }
        public string DeleteDeletedAddOnDirectoryLanguage { get; set; }
        public string LogsDirectoryLanguage { get; set; }
        public string FoorPrintLanguage { get; set; }
        public string IssuesLanguage { get; set; }
        public string TmpDirectoryLanguage { get; set; }
        public string DiskCacheDirectoryLanguage { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/refresh/");
            ApplicationStartLanguage = aol.GetAddOnsLanguage("application_start");
            LockLoginLanguage = aol.GetAddOnsLanguage("lock_login");
            CacheLanguage = aol.GetAddOnsLanguage("cache");
            CookieLanguage = aol.GetAddOnsLanguage("cookie");
            LoginIpBlackListLanguage = aol.GetAddOnsLanguage("login_ip_black_list");
            SessionLanguage = aol.GetAddOnsLanguage("session");
            RefreshLanguage = aol.GetAddOnsLanguage("refresh");
            ReCreateLanguage = aol.GetAddOnsLanguage("re_create");
            SiteCategoryLanguage = aol.GetAddOnsLanguage("site_category");
            UploadFileListLanguage = aol.GetAddOnsLanguage("upload_file_list");
            DeleteLanguage = aol.GetAddOnsLanguage("delete");
            DiskCacheDirectoryLanguage = aol.GetAddOnsLanguage("disk_cache_directory");
            TmpDirectoryLanguage = aol.GetAddOnsLanguage("tmp_directory");
            LogsDirectoryLanguage = aol.GetAddOnsLanguage("logs_directory");
            FoorPrintLanguage = aol.GetAddOnsLanguage("foot_print");
            IssuesLanguage = aol.GetAddOnsLanguage("issues");
            MoveTmpBinDirectoryLanguage = aol.GetAddOnsLanguage("move_tmp_bin_directory");
            DeleteDeletedAddOnDirectoryLanguage = aol.GetAddOnsLanguage("delete_deleted_add_on_directory");
        }
    }
}