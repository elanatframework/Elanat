﻿using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentPhoneNumberModel : CodeBehindModel
    {
        public string PhoneNumberLanguage { get; set; }

        public string PhoneNumberValue { get; set; }

        public string PhoneNumberCssClass { get; set; }

        public string PhoneNumberAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PhoneNumberLanguage = Language.GetAddOnsLanguage("phone_number", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_PhoneNumber", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            PhoneNumberAttribute += vc.ImportantInputAttribute.GetValue("txt_PhoneNumber");

            PhoneNumberCssClass = PhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PhoneNumber"));
        }
    }
}