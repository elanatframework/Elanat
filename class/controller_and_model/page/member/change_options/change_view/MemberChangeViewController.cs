using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeViewController : CodeBehindController
    {
        public MemberChangeViewModel model = new MemberChangeViewModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeView"]))
            {
                btn_ChangeView_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeView_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.UserBackgroundColorValue = context.Request.Form["txt_UserBackgroundColor"];
            model.UserFontSizeValue = context.Request.Form["txt_UserFontSize"];
            model.UserCommonLightBackgroundColorValue = context.Request.Form["txt_UserCommonLightBackgroundColor"];
            model.UserCommonLightTextColorValue = context.Request.Form["txt_UserCommonLightTextColor"];
            model.UserCommonMiddleBackgroundColorValue = context.Request.Form["txt_UserCommonMiddleBackgroundColor"];
            model.UserCommonMiddleTextColorValue = context.Request.Form["txt_UserCommonMiddleTextColor"];
            model.UserCommonDarkBackgroundColorValue = context.Request.Form["txt_UserCommonDarkBackgroundColor"];
            model.UserCommonDarkTextColorValue = context.Request.Form["txt_UserCommonDarkTextColor"];
            model.UserNaturalLightBackgroundColorValue = context.Request.Form["txt_UserNaturalLightBackgroundColor"];
            model.UserNaturalLightTextColorValue = context.Request.Form["txt_UserNaturalLightTextColor"];
            model.UserNaturalMiddleBackgroundColorValue = context.Request.Form["txt_UserNaturalMiddleBackgroundColor"];
            model.UserNaturalMiddleTextColorValue = context.Request.Form["txt_UserNaturalMiddleTextColor"];
            model.UserNaturalDarkBackgroundColorValue = context.Request.Form["txt_UserNaturalDarkBackgroundColor"];
            model.UserNaturalDarkTextColorValue = context.Request.Form["txt_UserNaturalDarkTextColor"];
            model.UserInfoBackgroundColorValue = context.Request.Form["txt_UserInfoBackgroundColor"];
            model.UserInfoFontColorValue = context.Request.Form["txt_UserInfoFontColor"];
            model.ShowUserAvatarInUserInfoValue = context.Request.Form["cbx_ShowUserAvatarInUserInfo"] == "on";
            model.ShowUserOnlineInUserInfoValue = context.Request.Form["cbx_ShowUserOnlineInUserInfo"] == "on";
            model.ShowUserEmailInUserInfoValue = context.Request.Form["cbx_ShowUserEmailInUserInfo"] == "on";
            model.ShowUserBirthdayInUserInfoValue = context.Request.Form["cbx_ShowUserBirthdayInUserInfo"] == "on";
            model.ShowUserGenderInUserInfoValue = context.Request.Form["cbx_ShowUserGenderInUserInfo"] == "on";
            model.ShowUserPhoneNumberInUserInfoValue = context.Request.Form["cbx_ShowUserPhoneNumberInUserInfo"] == "on";
            model.ShowUserMobileNumberInUserInfoValue = context.Request.Form["cbx_ShowUserMobileNumberInUserInfo"] == "on";
            model.ShowUserCountryInUserInfoValue = context.Request.Form["cbx_ShowUserCountryInUserInfo"] == "on";
            model.ShowUserStateOrProvinceInUserInfoValue = context.Request.Form["cbx_ShowUserStateOrProvinceInUserInfo"] == "on";
            model.ShowUserCityInUserInfoValue = context.Request.Form["cbx_ShowUserCityInUserInfo"] == "on";
            model.ShowUserZipCodeInUserInfoValue = context.Request.Form["cbx_ShowUserZipCodeInUserInfo"] == "on";
            model.ShowUserPostalCodeInUserInfoValue = context.Request.Form["cbx_ShowUserPostalCodeInUserInfo"] == "on";
            model.ShowUserAddressInUserInfoValue = context.Request.Form["cbx_ShowUserAddressInUserInfo"] == "on";
            model.ShowUserWebsiteInUserInfoValue = context.Request.Form["cbx_ShowUserWebsiteInUserInfo"] == "on";
            model.ShowUserLastLoginInUserInfoValue = context.Request.Form["cbx_ShowUserLastLoginInUserInfo"] == "on";


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.ChangeView();

            model.SuccessView();

            View(model);
        }
    }
}