using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContentReplyTextModel
    {
        public string TextLanguage { get; set; }

        public string TextValue { get; set; }

        public string TextCssClass { get; set; }

        public string TextAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            TextLanguage = Language.GetAddOnsLanguage("text", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_Text", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");


            TextAttribute += vc.ImportantInputAttribute["txt_Text"];

            TextCssClass = TextCssClass.AddHtmlClass(vc.ImportantInputClass["txt_Text"]);
        }
    }
}