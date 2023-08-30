﻿using CodeBehind;

namespace Elanat
{
    public partial class SiteContactCityModel : CodeBehindModel
    {
        public string CityLanguage { get; set; }

        public string CityValue { get; set; }

        public string CityCssClass { get; set; }

        public string CityAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            CityLanguage = Language.GetAddOnsLanguage("city", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_City", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            CityAttribute += vc.ImportantInputAttribute.GetValue("txt_City");

            CityCssClass = CityCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_City"));
        }
    }
}