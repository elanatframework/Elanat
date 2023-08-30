﻿using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpRealLastNameModel : CodeBehindModel
    {
        public string RealLastNameLanguage { get; set; }

        public string RealLastNameValue { get; set; }

        public string RealLastNameCssClass { get; set; }

        public string RealLastNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            RealLastNameLanguage = Language.GetAddOnsLanguage("real_last_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_RealLastName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            RealLastNameAttribute += vc.ImportantInputAttribute.GetValue("txt_RealLastName");

            RealLastNameCssClass = RealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RealLastName"));
        }
    }
}