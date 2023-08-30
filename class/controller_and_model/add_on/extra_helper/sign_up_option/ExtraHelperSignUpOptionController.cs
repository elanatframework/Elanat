using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperSignUpOptionController : CodeBehindController
    {
        public ExtraHelperSignUpOptionModel model = new ExtraHelperSignUpOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveSignUpOption"]))
            {
                btn_SaveSignUpOption_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveSignUpOption_Click(HttpContext context)
        {
            model.ActiveAvatarValue = context.Request.Form["cbx_ActiveAvatar"] == "on";
            model.ActiveUserNameValue = context.Request.Form["cbx_ActiveUserName"] == "on";
            model.ActiveUserSiteNameValue = context.Request.Form["cbx_ActiveUserSiteName"] == "on";
            model.ActiveRealNameValue = context.Request.Form["cbx_ActiveRealName"] == "on";
            model.ActiveRealLastNameValue = context.Request.Form["cbx_ActiveRealLastName"] == "on";
            model.ActiveEmailValue = context.Request.Form["cbx_ActiveEmail"] == "on";
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

            model.SaveSignUpOption();

            View(model);
        }
    }
}