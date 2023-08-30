﻿using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpZipCodeModel : CodeBehindModel
    {
        public string ZipCodeLanguage { get; set; }

        public string ZipCodeValue { get; set; }

        public string ZipCodeCssClass { get; set; }

        public string ZipCodeAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            ZipCodeLanguage = Language.GetAddOnsLanguage("zip_code", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ZipCode", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            ZipCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_ZipCode");

            ZipCodeCssClass = ZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ZipCode"));
        }
    }
}