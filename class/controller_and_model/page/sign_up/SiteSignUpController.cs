using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteSignUpController : CodeBehindController
    {
        public SiteSignUpModel model = new SiteSignUpModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/sign_up").Attributes["value"].Value) * 1000);


            if (ElanatConfig.GetNode("active/sign_up_active").Attributes["active"].Value != "true")
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetAddOnsLanguage("sign_up_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/")));
                IgnoreViewAndModel = true;

                return;
            }



            if (!string.IsNullOrEmpty(context.Request.Form["btn_SignUp"]))
            {
                btn_SignUp_Click(context);
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Query["el_return_url"]))
                model.ReturnUrlValue = context.Request.Query["el_return_url"];


            model.SetValue(context);


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SignUp_Click(HttpContext context)
        {
            // Set Option Value
            XmlDocument ContactOptionDocument = new XmlDocument();
            ContactOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sign_up_option/option/sign_up_option.xml"));
            XmlNode node = ContactOptionDocument.SelectSingleNode("sign_up_option_root");


            model.PasswordValue = context.Request.Form["txt_Password"];
            model.RepeatPasswordValue = context.Request.Form["txt_RepeatPassword"];

            if (node["user_name"].Attributes["active"].Value == "true")
                model.UserNameValue = context.Request.Form["txt_UserName"];

            if (node["email"].Attributes["active"].Value == "true")
            {
                model.EmailValue = context.Request.Form["txt_Email"];
                model.RepeatEmailValue = context.Request.Form["txt_RepeatEmail"];
            }

            if (node["user_site_name"].Attributes["active"].Value == "true")
                model.UserSiteNameValue = context.Request.Form["txt_UserSiteName"];

            if (node["avatar"].Attributes["active"].Value == "true")
            {
                model.UseAvatarPathValue = context.Request.Form["cbx_UseAvatarPath"] == "on";
                model.AvatarPathTextValue = context.Request.Form["txt_AvatarPath"];
                model.AvatarPathUploadValue = context.Request.Form.Files["upd_AvatarPath"];
            }

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_BirthdayYear"]) && node["birthday"].Attributes["active"].Value == "true")
            {
                model.BirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_BirthdayYear"];
                model.BirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_BirthdayMount"];
                model.BirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_BirthdayDay"];
            }
            else
            {
                model.BirthdayYearOptionListSelectedValue = "0000";
                model.BirthdayMountOptionListSelectedValue = "00";
                model.BirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_About"]) && node["about"].Attributes["active"].Value == "true")
                model.AboutValue = context.Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Address"]) && node["address"].Attributes["active"].Value == "true")
                model.AddressValue = context.Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_City"]) && node["city"].Attributes["active"].Value == "true")
                model.CityValue = context.Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Country"]) && node["country"].Attributes["active"].Value == "true")
                model.CountryValue = context.Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_MobileNumber"]) && node["mobile_number"].Attributes["active"].Value == "true")
                model.MobileNumberValue = context.Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PhoneNumber"]) && node["phone_number"].Attributes["active"].Value == "true")
                model.PhoneNumberValue = context.Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PostalCode"]) && node["postal_code"].Attributes["active"].Value == "true")
                model.PostalCodeValue = context.Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PublicEmail"]) && node["public_email"].Attributes["active"].Value == "true")
                model.PublicEmailValue = context.Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealName"]) && node["real_name"].Attributes["active"].Value == "true")
                model.RealNameValue = context.Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealLastName"]) && node["real_last_name"].Attributes["active"].Value == "true")
                model.RealLastNameValue = context.Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_StateOrProvince"]) && node["state_or_province"].Attributes["active"].Value == "true")
                model.StateOrProvinceValue = context.Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Website"]) && node["website"].Attributes["active"].Value == "true")
                model.WebsiteValue = context.Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ZipCode"]) && node["zip_code"].Attributes["active"].Value == "true")
                model.ZipCodeValue = context.Request.Form["txt_ZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]) && node["gender"].Attributes["active"].Value == "true")
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];
            model.ReturnUrlValue = context.Request.Form["hdn_ReturnUrl"];


            if (ElanatConfig.GetNode("active/sign_up_active").Attributes["active"].Value != "true")
            {
                model.SignUpInactiveErrorView();

                View(model);

                return;
            }


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


            if (context.Request.Form["cbx_Agree"] != "on")
            {
                model.AgreeNotAcceptErrorView();

                View(model);

                return;
            }

            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();

                View(model);

                return;
            }

            if (context.Request.Form["txt_Password"] != context.Request.Form["txt_RepeatPassword"])
            {
                model.PasswordEqualityErrorView();

                View(model);

                return;
            }

            if (context.Request.Form["txt_Email"] != context.Request.Form["txt_RepeatEmail"])
            {
                model.EmailEqualityErrorView();

                View(model);

                return;
            }


            model.SignUp();

            model.SuccessView();

            View(model);
        }
    }
}