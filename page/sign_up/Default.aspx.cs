using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class SiteSignUp : System.Web.UI.Page
    {
        public SiteSignUpModel model = new SiteSignUpModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/sign_up").Attributes["value"].Value) * 1000);


            if (ElanatConfig.GetNode("active/sign_up_active").Attributes["active"].Value != "true")
                Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetAddOnsLanguage("sign_up_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/")));


            if (!string.IsNullOrEmpty(Request.Form["btn_SignUp"]))
                btn_SignUp_Click(sender, e);


            if (!string.IsNullOrEmpty(Request.QueryString["el_return_url"]))
                model.ReturnUrlValue = Request.QueryString["el_return_url"];


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            model.PasswordValue = Request.Form["txt_Password"];
            model.RepeatPasswordValue = Request.Form["txt_RepeatPassword"];
            model.UserNameValue = Request.Form["txt_UserName"];
            model.EmailValue = Request.Form["txt_Email"];
            model.RepeatEmailValue = Request.Form["txt_RepeatEmail"];
            model.UserSiteNameValue = Request.Form["txt_UserSiteName"];

            model.UseAvatarPathValue = Request.Form["cbx_UseAvatarPath"] == "on";
            model.AvatarPathTextValue = Request.Form["txt_AvatarPath"];
            model.AvatarPathUploadValue = Request.Files["upd_AvatarPath"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_BirthdayYear"]))
            {
                model.BirthdayYearOptionListSelectedValue = Request.Form["ddlst_BirthdayYear"];
                model.BirthdayMountOptionListSelectedValue = Request.Form["ddlst_BirthdayMount"];
                model.BirthdayDayOptionListSelectedValue = Request.Form["ddlst_BirthdayDay"];
            }
            else
            {
                model.BirthdayYearOptionListSelectedValue = "0000";
                model.BirthdayMountOptionListSelectedValue = "00";
                model.BirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_About"]))
                model.AboutValue = Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Address"]))
                model.AddressValue = Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(Request.Form["txt_City"]))
                model.CityValue = Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Country"]))
                model.CountryValue = Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(Request.Form["txt_MobileNumber"]))
                model.MobileNumberValue = Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PhoneNumber"]))
                model.PhoneNumberValue = Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PostalCode"]))
                model.PostalCodeValue = Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PublicEmail"]))
                model.PublicEmailValue = Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealName"]))
                model.RealNameValue = Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealLastName"]))
                model.RealLastNameValue = Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_StateOrProvince"]))
                model.StateOrProvinceValue = Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Website"]))
                model.WebsiteValue = Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ZipCode"]))
                model.ZipCodeValue = Request.Form["txt_ZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.CaptchaTextValue = Request.Form["txt_Captcha"];
            model.ReturnUrlValue = Request.Form["hdn_ReturnUrl"];


            if (ElanatConfig.GetNode("active/sign_up_active").Attributes["active"].Value != "true")
            {
                model.SignUpInactiveErrorView();
                return;
            }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            if (Request.Form["cbx_Agree"] != "on")
            {
                model.AgreeNotAcceptErrorView();
                return;
            }

            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
                return;
            }

            if (Request.Form["txt_Password"] != Request.Form["txt_RepeatPassword"])
            {
                model.PasswordEqualityErrorView();
                return;
            }

            if (Request.Form["txt_Email"] != Request.Form["txt_RepeatEmail"])
            {
                model.EmailEqualityErrorView();
                return;
            }


            model.SignUp();


            model.SuccessView();
        }
    }
}