using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace elanat
{
    public partial class ActionChangeProfile : System.Web.UI.Page
    {
        public ActionChangeProfileModel model = new ActionChangeProfileModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeProfile"]))
                btn_ChangeProfile_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeProfile_Click(object sender, EventArgs e)
        {
            model.BirthdayYearOptionListSelectedValue = Request.Form["ddlst_BirthdayYear"];
            model.BirthdayMountOptionListSelectedValue = Request.Form["ddlst_BirthdayMount"];
            model.BirthdayDayOptionListSelectedValue = Request.Form["ddlst_BirthdayDay"];
            model.UserNameValue = Request.Form["txt_UserName"];
            model.UserSiteNameValue = Request.Form["txt_UserSiteName"];
            model.UserRealNameValue = Request.Form["txt_UserRealName"];
            model.UserRealLastNameValue = Request.Form["txt_UserRealLastName"];
            model.UserPhoneNumberValue = Request.Form["txt_UserPhoneNumber"];
            model.UserAddressValue = Request.Form["txt_UserAddress"];
            model.UserPostalCodeValue = Request.Form["txt_UserPostalCode"];
            model.UserAboutValue = Request.Form["txt_UserAbout"];
            model.UserPublicEmailValue = Request.Form["txt_UserPublicEmail"];
            model.UserMobileNumberValue = Request.Form["txt_UserMobileNumber"];
            model.UserZipCodeValue = Request.Form["txt_UserZipCode"];
            model.UserOtherInfoValue = Request.Form["txt_UserOtherInfo"];
            model.UserCountryValue = Request.Form["txt_UserCountry"];
            model.UserStateOrProvinceValue = Request.Form["txt_UserStateOrProvince"];
            model.UserCityValue = Request.Form["txt_UserCity"];
            model.UserWebsiteValue = Request.Form["txt_UserWebsite"];
            model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
            model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
            model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            DataUse.User duc = new DataUse.User();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_user", "user_name", model.UserNameValue, duc.GetUserName(ccoc.UserId)))
            {
                model.UserNameCssClass = model.UserNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserNameErrorView();

                return;
            }

            // Unique Value To Column Check
            if (common.ExistValueToColumnCheck("el_user", "user_site_name", model.UserNameValue, duc.GetUserSiteName(ccoc.UserId)))
            {
                model.UserNameCssClass = model.UserNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnUserSiteNameErrorView();

                return;
            }


            model.ChangeProfile();

            model.SuccessView();
        }
    }
}