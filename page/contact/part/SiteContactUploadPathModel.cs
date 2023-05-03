using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactUploadPathModel
    {
        public string UploadPathLanguage { get; set; }
        public string UseUploadPathLanguage { get; set; }

        public string UploadPathTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
            UploadPathLanguage = aol.GetAddOnsLanguage("upload_path");
            UseUploadPathLanguage = aol.GetAddOnsLanguage("use_upload_path");
        }
    }
}