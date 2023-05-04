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
    public partial class ActionChangeLanguage : System.Web.UI.Page
    {
        public ActionChangeLanguageModel model = new ActionChangeLanguageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeLanguage"]))
                btn_ChangeLanguage_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeLanguage_Click(object sender, EventArgs e)
        {
            model.SiteLanguageOptionListSelectedValue = Request.Form["ddlst_UserSiteLanguage"];
            model.AdminLanguageOptionListSelectedValue = Request.Form["ddlst_UserAdminLanguage"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeLanguage();

            model.SuccessView();
        }
    }
}