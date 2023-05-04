using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditUser : System.Web.UI.Page
    {
        public ActionEditUserModel model = new ActionEditUserModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveUser"]))
                btn_SaveUser_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_UserId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["user_id"]))
                    return;

                if (!Request.QueryString["user_id"].ToString().IsNumber())
                    return;

                model.UserIdValue = Request.QueryString["user_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveUser_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.UserActiveValue = Request.Form["cbx_UserActive"] == "on";
            model.UserEmailIsConfirmValue = Request.Form["cbx_UserEmailIsConfirm"] == "on";

            if (!string.IsNullOrEmpty(Request.Form["ddlst_UserBirthdayYear"]))
            {
                model.UserBirthdayYearOptionListSelectedValue = Request.Form["ddlst_UserBirthdayYear"];
                model.UserBirthdayMountOptionListSelectedValue = Request.Form["ddlst_UserBirthdayMount"];
                model.UserBirthdayDayOptionListSelectedValue = Request.Form["ddlst_UserBirthdayDay"];
            }
            else
            {
                model.UserBirthdayYearOptionListSelectedValue = "0000";
                model.UserBirthdayMountOptionListSelectedValue = "00";
                model.UserBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_UserEmail"]))
                model.UserEmailValue = Request.Form["txt_UserEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RepeatEmail"]))
                model.RepeatEmailValue = Request.Form["txt_RepeatEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserPassword"]))
                model.UserPasswordValue = Request.Form["txt_UserPassword"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RepeatPassword"]))
                model.RepeatPasswordValue = Request.Form["txt_RepeatPassword"];

            model.UserGroupOptionListSelectedValue = Request.Form["ddlst_UserGroup"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserOtherInfo"]))
                model.UserOtherInfoValue = Request.Form["txt_UserOtherInfo"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserAbout"]))
                model.UserAboutValue = Request.Form["txt_UserAbout"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserAddress"]))
                model.UserAddressValue = Request.Form["txt_UserAddress"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserCity"]))
                model.UserCityValue = Request.Form["txt_UserCity"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserCountry"]))
                model.UserCountryValue = Request.Form["txt_UserCountry"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserMobileNumber"]))
                model.UserMobileNumberValue = Request.Form["txt_UserMobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserPhoneNumber"]))
                model.UserPhoneNumberValue = Request.Form["txt_UserPhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserPostalCode"]))
                model.UserPostalCodeValue = Request.Form["txt_UserPostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserPublicEmail"]))
                model.UserPublicEmailValue = Request.Form["txt_UserPublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserName"]))
                model.UserNameValue = Request.Form["txt_UserName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserSiteName"]))
                model.UserSiteNameValue = Request.Form["txt_UserSiteName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserRealName"]))
                model.UserRealNameValue = Request.Form["txt_UserRealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserRealLastName"]))
                model.UserRealLastNameValue = Request.Form["txt_UserRealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserStateOrProvince"]))
                model.UserStateOrProvinceValue = Request.Form["txt_UserStateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserWebsite"]))
                model.UserWebsiteValue = Request.Form["txt_UserWebsite"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserZipCode"]))
                model.UserZipCodeValue = Request.Form["txt_UserZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_UserDateCreate"]))
                model.UserDateCreateValue = Request.Form["txt_UserDateCreate"];

            model.UserIdValue = Request.Form["hdn_UserId"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            DataUse.User duu = new DataUse.User();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_user", "user_name", model.UserNameValue, duu.GetUserName(model.UserIdValue)))
            {
                model.UserNameCssClass = model.UserNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserNameErrorView();

                return;
            }

            if (common.ExistValueToColumnCheck("el_user", "user_site_name", model.UserSiteNameValue, duu.GetUserSiteName(model.UserIdValue)))
            {
                model.UserSiteNameCssClass = model.UserSiteNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserSiteNameErrorView();

                return;
            }

            if (model.UserPasswordValue != model.RepeatPasswordValue)
            {
                model.PasswordEqualityErrorView();

                return;
            }


            if (model.UserEmailValue != model.RepeatEmailValue)
            {
                model.EmailEqualityErrorView();

                return;
            }


            model.SaveUser();

            model.SuccessView();
        }
    }
}