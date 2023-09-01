using CodeBehind;

namespace Elanat
{
    public partial class InstallController : CodeBehindController
    {
        public InstallModel model = new InstallModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep((int.Parse(ElanatConfig.GetNode("delay/main").Attributes["value"].Value) + 1) * 1000);


            if (!string.IsNullOrEmpty(context.Request.Form["btn_Submit"]))
            {
                btn_Submit_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_Submit_Click(HttpContext context)
        {
            model.AgreeLicenseValue = context.Request.Form["cbx_AgreeLicense"] == "on";
            model.InstallCodeValue = context.Request.Form["txt_InstallCode"];
            model.HostPathValue = context.Request.Form["txt_HostPath"];
            model.SiteNameValue = context.Request.Form["txt_SiteName"];
            model.SiteEmailValue = context.Request.Form["txt_SiteEmail"];
            model.SiteTitleValue = context.Request.Form["txt_SiteTitle"];
            model.UserSiteNameValue = context.Request.Form["txt_UserSiteName"];
            model.UserNameValue = context.Request.Form["txt_UserName"];
            model.UserRealNameValue = context.Request.Form["txt_UserRealName"];
            model.UserRealLastNameValue = context.Request.Form["txt_UserRealLastName"];
            model.UserEmailValue = context.Request.Form["txt_UserEmail"];
            model.RepeatUserEmailValue = context.Request.Form["txt_RepeatUserEmail"];
            model.UserPasswordValue = context.Request.Form["txt_UserPassword"];
            model.RepeatUserPasswordValue = context.Request.Form["txt_RepeatUserPassword"];
            model.SiteLanguageOptionListSelectedValue = context.Request.Form["ddlst_SiteLanguage"];
            model.SiteTimeZoneOptionListSelectedValue = context.Request.Form["ddlst_SiteTimeZone"];


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


            // Check Agree License
            if (!model.AgreeLicenseValue)
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("not_agreement_by_licensing", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                
                IgnoreViewAndModel = true;

                return;
            }


            // Check Install Code
            if (ElanatConfig.GetNode("elanat/install_code").Attributes["active"].Value == "true")
                if (ElanatConfig.GetNode("elanat/install_code").Attributes["value"].Value != model.InstallCodeValue)
                {
                    Write(GlobalClass.Alert(Language.GetAddOnsLanguage("the_install_code_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                    
                    IgnoreViewAndModel = true;

                    return;
                }


            // Check User Email And User Repeat Email
            if (model.UserEmailValue != model.RepeatUserEmailValue)
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("user_email_and_repeat_user_email_is_not_equal", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                
                IgnoreViewAndModel = true;

                return;
            }


            // Check User Password And User Repeat Password
            if (model.UserPasswordValue != model.RepeatUserPasswordValue)
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("user_password_and_repeat_user_password_is_not_equal", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                
                IgnoreViewAndModel = true;

                return;
            }

            string SuccessView = model.SuccessView();

            model.Submit();

            Write(SuccessView);

            IgnoreViewAndModel = true;
        }
    }
}