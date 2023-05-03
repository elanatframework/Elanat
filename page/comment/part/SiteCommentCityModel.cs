using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteCommentCityModel
    {
        public string CityLanguage { get; set; }

        public string CityValue { get; set; }

        public string CityCssClass { get; set; }

        public string CityAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            CityLanguage = Language.GetAddOnsLanguage("city", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_City", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            CityAttribute += vc.ImportantInputAttribute["txt_City"];

            CityCssClass = CityCssClass.AddHtmlClass(vc.ImportantInputClass["txt_City"]);
        }
    }
}