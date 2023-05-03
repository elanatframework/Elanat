using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class Install : System.Web.UI.Page
    {
        public InstallModel model = new InstallModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep((int.Parse(ElanatConfig.GetNode("delay/main").Attributes["value"].Value) + 1) * 1000);


            if (!string.IsNullOrEmpty(Request.Form["btn_Submit"]))
                btn_Submit_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            model.AgreeLicenseValue = Request.Form["cbx_AgreeLicense"] == "on";
            model.InstallCodeValue = Request.Form["txt_InstallCode"];
            model.HostPathValue = Request.Form["txt_HostPath"];
            model.SiteNameValue = Request.Form["txt_SiteName"];
            model.SiteEmailValue = Request.Form["txt_SiteEmail"];
            model.SiteTitleValue = Request.Form["txt_SiteTitle"];
            model.UserSiteNameValue = Request.Form["txt_UserSiteName"];
            model.UserNameValue = Request.Form["txt_UserName"];
            model.UserRealNameValue = Request.Form["txt_UserRealName"];
            model.UserRealLastNameValue = Request.Form["txt_UserRealLastName"];
            model.UserEmailValue = Request.Form["txt_UserEmail"];
            model.RepeatUserEmailValue = Request.Form["txt_RepeatUserEmail"];
            model.UserPasswordValue = Request.Form["txt_UserPassword"];
            model.RepeatUserPasswordValue = Request.Form["txt_RepeatUserPassword"];
            model.SiteLanguageOptionListSelectedValue = Request.Form["ddlst_SiteLanguage"];
            model.SiteTimeZoneOptionListSelectedValue = Request.Form["ddlst_SiteTimeZone"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            // Check Agree License
            if (!model.AgreeLicenseValue)
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("not_agreement_by_licensing", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), "problem");


            // Check Install Code
            if (ElanatConfig.GetNode("elanat/install_code").Attributes["active"].Value == "true")
                if (ElanatConfig.GetNode("elanat/install_code").Attributes["value"].Value != model.InstallCodeValue)
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_install_code_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), "problem");


            // Check User Email And User Repeat Email
            if (model.UserEmailValue != model.RepeatUserEmailValue)
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_email_and_repeat_user_email_is_not_equal", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), "problem");


            // Check User Password And User Repeat Password
            if (model.UserPasswordValue != model.RepeatUserPasswordValue)
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_password_and_repeat_user_password_is_not_equal", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/"), "problem");


            model.Submit();

            model.SuccessView();
        }
    }
}