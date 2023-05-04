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
    public partial class ActionChangeGroup : System.Web.UI.Page
    {
        public ActionChangeGroupModel model = new ActionChangeGroupModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeGroup"]))
                btn_ChangeGroup_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeGroup_Click(object sender, EventArgs e)
        {
            model.UserGroupOptionListSelectedValue = Request.Form["ddlst_UserGroup"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeGroup();

            model.SuccessView();
        }
    }
}