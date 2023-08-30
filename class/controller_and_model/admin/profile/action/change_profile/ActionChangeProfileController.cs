using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeProfileController : CodeBehindController
    {
        public ActionChangeProfileModel model = new ActionChangeProfileModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeProfile"]))
            {
                btn_ChangeProfile_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeProfile_Click(HttpContext context)
        {
            model.BirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_BirthdayYear"];
            model.BirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_BirthdayMount"];
            model.BirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_BirthdayDay"];
            model.UserNameValue = context.Request.Form["txt_UserName"];
            model.UserSiteNameValue = context.Request.Form["txt_UserSiteName"];
            model.UserRealNameValue = context.Request.Form["txt_UserRealName"];
            model.UserRealLastNameValue = context.Request.Form["txt_UserRealLastName"];
            model.UserPhoneNumberValue = context.Request.Form["txt_UserPhoneNumber"];
            model.UserAddressValue = context.Request.Form["txt_UserAddress"];
            model.UserPostalCodeValue = context.Request.Form["txt_UserPostalCode"];
            model.UserAboutValue = context.Request.Form["txt_UserAbout"];
            model.UserPublicEmailValue = context.Request.Form["txt_UserPublicEmail"];
            model.UserMobileNumberValue = context.Request.Form["txt_UserMobileNumber"];
            model.UserZipCodeValue = context.Request.Form["txt_UserZipCode"];
            model.UserOtherInfoValue = context.Request.Form["txt_UserOtherInfo"];
            model.UserCountryValue = context.Request.Form["txt_UserCountry"];
            model.UserStateOrProvinceValue = context.Request.Form["txt_UserStateOrProvince"];
            model.UserCityValue = context.Request.Form["txt_UserCity"];
            model.UserWebsiteValue = context.Request.Form["txt_UserWebsite"];
            model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
            model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
            model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            DataUse.User duc = new DataUse.User();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_user", "user_name", model.UserNameValue, duc.GetUserName(ccoc.UserId)))
            {
                model.UserNameCssClass = model.UserNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserNameErrorView();

                View(model);

                return;
            }

            // Unique Value To Column Check
            if (common.ExistValueToColumnCheck("el_user", "user_site_name", model.UserNameValue, duc.GetUserSiteName(ccoc.UserId)))
            {
                model.UserNameCssClass = model.UserNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserSiteNameErrorView();

                View(model);

                return;
            }


            model.ChangeProfile();

            model.SuccessView();

            View(model);
        }
    }
}