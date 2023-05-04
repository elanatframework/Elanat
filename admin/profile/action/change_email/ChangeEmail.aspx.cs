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
    public partial class ActionChangeEmail : System.Web.UI.Page
    {
        public ActionChangeEmailModel model = new ActionChangeEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeEmail"]))
                btn_ChangeEmail_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeEmail_Click(object sender, EventArgs e)
        {
            model.UserEmailValue = Request.Form["txt_UserEmail"];
            model.RepeatEmaiValue = Request.Form["txt_RepeatEmail"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            if (Request.Form["txt_UserEmail"] != Request.Form["txt_RepeatEmail"])
            {
                model.EmailEqualityErrorView();
                return;
            }

            model.ChangeEmail();

            model.SuccessView();
        }
    }
}