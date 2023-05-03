using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContentReplyAboutModel
    {
        public string AboutLanguage { get; set; }

        public string AboutValue { get; set; }

        public string AboutCssClass { get; set; }

        public string AboutAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            AboutLanguage = Language.GetAddOnsLanguage("about", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_About", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");


            AboutAttribute += vc.ImportantInputAttribute["txt_About"];

            AboutCssClass = AboutCssClass.AddHtmlClass(vc.ImportantInputClass["txt_About"]);
        }
    }
}