using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperContactOption : System.Web.UI.Page
    {
        public ExtraHelperContactOptionModel model = new ExtraHelperContactOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveContactOption"]))
                btn_SaveContactOption_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveContactOption_Click(object sender, EventArgs e)
        {
            model.ActiveNameValue = Request.Form["cbx_ActiveName"] == "on";
            model.ActiveLastNameValue = Request.Form["cbx_ActiveLastName"] == "on";
            model.ActiveEmailValue = Request.Form["cbx_ActiveEmail"] == "on";
            model.ActiveTitleValue = Request.Form["cbx_ActiveTitle"] == "on";
            model.ActiveTextValue = Request.Form["cbx_ActiveText"] == "on";
            model.ActiveFileValue = Request.Form["cbx_ActiveFile"] == "on";
            model.ActiveTypeValue = Request.Form["cbx_ActiveType"] == "on";
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
            model.SaveContactOption();
        }
    }
}