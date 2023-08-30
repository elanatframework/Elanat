using CodeBehind;

namespace Elanat
{
    public partial class AdminUserController : CodeBehindController
    {
        public AdminUserModel model = new AdminUserModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddUser"]))
            {
                btn_AddUser_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddUser_Click(HttpContext context)
        {
            model.UserActiveValue = context.Request.Form["cbx_UserActive"] == "on";
            model.UserEmailIsConfirmValue = context.Request.Form["cbx_UserEmailIsConfirm"] == "on";

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_UserBirthdayYear"]))
            {
                model.UserBirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_UserBirthdayYear"];
                model.UserBirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_UserBirthdayMount"];
                model.UserBirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_UserBirthdayDay"];
            }
            else
            {
                model.UserBirthdayYearOptionListSelectedValue = "0000";
                model.UserBirthdayMountOptionListSelectedValue = "00";
                model.UserBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserEmail"]))
                model.UserEmailValue = context.Request.Form["txt_UserEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RepeatEmail"]))
                model.RepeatEmailValue = context.Request.Form["txt_RepeatEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserPassword"]))
                model.UserPasswordValue = context.Request.Form["txt_UserPassword"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RepeatPassword"]))
                model.RepeatPasswordValue = context.Request.Form["txt_RepeatPassword"];

            model.UserGroupOptionListSelectedValue = context.Request.Form["ddlst_UserGroup"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserOtherInfo"]))
                model.UserOtherInfoValue = context.Request.Form["txt_UserOtherInfo"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserAbout"]))
                model.UserAboutValue = context.Request.Form["txt_UserAbout"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserAddress"]))
                model.UserAddressValue = context.Request.Form["txt_UserAddress"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserCity"]))
                model.UserCityValue = context.Request.Form["txt_UserCity"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserCountry"]))
                model.UserCountryValue = context.Request.Form["txt_UserCountry"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserMobileNumber"]))
                model.UserMobileNumberValue = context.Request.Form["txt_UserMobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserPhoneNumber"]))
                model.UserPhoneNumberValue = context.Request.Form["txt_UserPhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserPostalCode"]))
                model.UserPostalCodeValue = context.Request.Form["txt_UserPostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserPublicEmail"]))
                model.UserPublicEmailValue = context.Request.Form["txt_UserPublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserName"]))
                model.UserNameValue = context.Request.Form["txt_UserName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserSiteName"]))
                model.UserSiteNameValue = context.Request.Form["txt_UserSiteName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserRealName"]))
                model.UserRealNameValue = context.Request.Form["txt_UserRealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserRealLastName"]))
                model.UserRealLastNameValue = context.Request.Form["txt_UserRealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserStateOrProvince"]))
                model.UserStateOrProvinceValue = context.Request.Form["txt_UserStateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserWebsite"]))
                model.UserWebsiteValue = context.Request.Form["txt_UserWebsite"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_UserZipCode"]))
                model.UserZipCodeValue = context.Request.Form["txt_UserZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;


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


            if (model.UserPasswordValue != model.RepeatPasswordValue)
            {
                model.PasswordEqualityErrorView();

                View(model);

                return;
            }


            if (model.UserEmailValue != model.RepeatEmailValue)
            {
                model.EmailEqualityErrorView();

                View(model);

                return;
            }


            model.AddUser();

            View(model);
        }
    }
}