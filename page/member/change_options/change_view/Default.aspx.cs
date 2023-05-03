using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class MemberChangeView : System.Web.UI.Page
    {
        public MemberChangeViewModel model = new MemberChangeViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeView"]))
                btn_ChangeView_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeView_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.UserBackgroundColorValue = Request.Form["txt_UserBackgroundColor"];
            model.UserFontSizeValue = Request.Form["txt_UserFontSize"];
            model.UserCommonLightBackgroundColorValue = Request.Form["txt_UserCommonLightBackgroundColor"];
            model.UserCommonLightTextColorValue = Request.Form["txt_UserCommonLightTextColor"];
            model.UserCommonMiddleBackgroundColorValue = Request.Form["txt_UserCommonMiddleBackgroundColor"];
            model.UserCommonMiddleTextColorValue = Request.Form["txt_UserCommonMiddleTextColor"];
            model.UserCommonDarkBackgroundColorValue = Request.Form["txt_UserCommonDarkBackgroundColor"];
            model.UserCommonDarkTextColorValue = Request.Form["txt_UserCommonDarkTextColor"];
            model.UserNaturalLightBackgroundColorValue = Request.Form["txt_UserNaturalLightBackgroundColor"];
            model.UserNaturalLightTextColorValue = Request.Form["txt_UserNaturalLightTextColor"];
            model.UserNaturalMiddleBackgroundColorValue = Request.Form["txt_UserNaturalMiddleBackgroundColor"];
            model.UserNaturalMiddleTextColorValue = Request.Form["txt_UserNaturalMiddleTextColor"];
            model.UserNaturalDarkBackgroundColorValue = Request.Form["txt_UserNaturalDarkBackgroundColor"];
            model.UserNaturalDarkTextColorValue = Request.Form["txt_UserNaturalDarkTextColor"];
            model.UserInfoBackgroundColorValue = Request.Form["txt_UserInfoBackgroundColor"];
            model.UserInfoFontColorValue = Request.Form["txt_UserInfoFontColor"];
            model.ShowUserAvatarInUserInfoValue = Request.Form["cbx_ShowUserAvatarInUserInfo"] == "on";
            model.ShowUserOnlineInUserInfoValue = Request.Form["cbx_ShowUserOnlineInUserInfo"] == "on";
            model.ShowUserEmailInUserInfoValue = Request.Form["cbx_ShowUserEmailInUserInfo"] == "on";
            model.ShowUserBirthdayInUserInfoValue = Request.Form["cbx_ShowUserBirthdayInUserInfo"] == "on";
            model.ShowUserGenderInUserInfoValue = Request.Form["cbx_ShowUserGenderInUserInfo"] == "on";
            model.ShowUserPhoneNumberInUserInfoValue = Request.Form["cbx_ShowUserPhoneNumberInUserInfo"] == "on";
            model.ShowUserMobileNumberInUserInfoValue = Request.Form["cbx_ShowUserMobileNumberInUserInfo"] == "on";
            model.ShowUserCountryInUserInfoValue = Request.Form["cbx_ShowUserCountryInUserInfo"] == "on";
            model.ShowUserStateOrProvinceInUserInfoValue = Request.Form["cbx_ShowUserStateOrProvinceInUserInfo"] == "on";
            model.ShowUserCityInUserInfoValue = Request.Form["cbx_ShowUserCityInUserInfo"] == "on";
            model.ShowUserZipCodeInUserInfoValue = Request.Form["cbx_ShowUserZipCodeInUserInfo"] == "on";
            model.ShowUserPostalCodeInUserInfoValue = Request.Form["cbx_ShowUserPostalCodeInUserInfo"] == "on";
            model.ShowUserAddressInUserInfoValue = Request.Form["cbx_ShowUserAddressInUserInfo"] == "on";
            model.ShowUserWebsiteInUserInfoValue = Request.Form["cbx_ShowUserWebsiteInUserInfo"] == "on";
            model.ShowUserLastLoginInUserInfoValue = Request.Form["cbx_ShowUserLastLoginInUserInfo"] == "on";


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeView();

            model.SuccessView();
        }
    }
}