using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperSignUpOption : System.Web.UI.Page
    {
        public ExtraHelperSignUpOptionModel model = new ExtraHelperSignUpOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveSignUpOption"]))
                btn_SaveSignUpOption_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveSignUpOption_Click(object sender, EventArgs e)
        {
            model.ActiveUserNameValue = Request.Form["cbx_ActiveUserName"] == "on";
            model.ActiveUserSiteNameValue = Request.Form["cbx_ActiveUserSiteName"] == "on";
            model.ActiveRealNameValue = Request.Form["cbx_ActiveRealName"] == "on";
            model.ActiveRealLastNameValue = Request.Form["cbx_ActiveRealLastName"] == "on";
            model.ActiveEmailValue = Request.Form["cbx_ActiveEmail"] == "on";
            model.ActivePhoneNumberValue = Request.Form["cbx_ActivePhoneNumber"] == "on";
            model.ActiveMobileNumberValue = Request.Form["cbx_ActiveMobileNumber"] == "on";
            model.ActiveAddressValue = Request.Form["cbx_ActiveAddress"] == "on";
            model.ActivePostalCodeValue = Request.Form["cbx_ActivePostalCode"] == "on";
            model.ActiveAboutValue = Request.Form["cbx_ActiveAbout"] == "on";
            model.ActiveBirthdayValue = Request.Form["cbx_ActiveBirthday"] == "on";
            model.ActiveGenderValue = Request.Form["cbx_ActiveGender"] == "on";
            model.ActiveCountryValue = Request.Form["cbx_ActiveCountry"] == "on";
            model.ActiveStateOrProvinceValue = Request.Form["cbx_ActiveStateOrProvince"] == "on";
            model.ActiveCityValue = Request.Form["cbx_ActiveCity"] == "on";
            model.ActiveZipCodeValue = Request.Form["cbx_ActiveZipCode"] == "on";
            model.ActivePublicEmailValue = Request.Form["cbx_ActivePublicEmail"] == "on";
            model.ActiveWebsiteValue = Request.Form["cbx_ActiveWebsite"] == "on";
            model.SaveSignUpOption();
        }
    }
}