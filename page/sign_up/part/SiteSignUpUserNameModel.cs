using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpUserNameModel
    {
        public string UserNameLanguage { get; set; }

        public string UserNameValue { get; set; }

        public string UserNameCssClass { get; set; }

        public string UserNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            UserNameLanguage = Language.GetAddOnsLanguage("user_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_UserName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            UserNameAttribute += vc.ImportantInputAttribute["txt_UserName"];

            UserNameCssClass = UserNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_UserName"]);
        }
    }
}