using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperCommentOptionController : CodeBehindController
    {
        public ExtraHelperCommentOptionModel model = new ExtraHelperCommentOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveCommentOption"]))
            {
                btn_SaveCommentOption_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveCommentOption_Click(HttpContext context)
        {
            model.ActiveNameValue = context.Request.Form["cbx_ActiveName"] == "on";
            model.ActiveLastNameValue = context.Request.Form["cbx_ActiveLastName"] == "on";
            model.ActiveEmailValue = context.Request.Form["cbx_ActiveEmail"] == "on";
            model.ActiveTitleValue = context.Request.Form["cbx_ActiveTitle"] == "on";
            model.ActiveTextValue = context.Request.Form["cbx_ActiveText"] == "on";
            model.ActiveFileValue = context.Request.Form["cbx_ActiveFile"] == "on";
            model.ActiveTypeValue = context.Request.Form["cbx_ActiveType"] == "on";
            model.ActivePhoneNumberValue = context.Request.Form["cbx_ActivePhoneNumber"] == "on";
            model.ActiveMobileNumberValue = context.Request.Form["cbx_ActiveMobileNumber"] == "on";
            model.ActiveAddressValue = context.Request.Form["cbx_ActiveAddress"] == "on";
            model.ActivePostalCodeValue = context.Request.Form["cbx_ActivePostalCode"] == "on";
            model.ActiveAboutValue = context.Request.Form["cbx_ActiveAbout"] == "on";
            model.ActiveBirthdayValue = context.Request.Form["cbx_ActiveBirthday"] == "on";
            model.ActiveGenderValue = context.Request.Form["cbx_ActiveGender"] == "on";
            model.ActiveCountryValue = context.Request.Form["cbx_ActiveCountry"] == "on";
            model.ActiveStateOrProvinceValue = context.Request.Form["cbx_ActiveStateOrProvince"] == "on";
            model.ActiveCityValue = context.Request.Form["cbx_ActiveCity"] == "on";
            model.ActiveZipCodeValue = context.Request.Form["cbx_ActiveZipCode"] == "on";
            model.ActivePublicEmailValue = context.Request.Form["cbx_ActivePublicEmail"] == "on";
            model.ActiveWebsiteValue = context.Request.Form["cbx_ActiveWebsite"] == "on";

            model.SaveCommentOption();

            View(model);
        }
    }
}