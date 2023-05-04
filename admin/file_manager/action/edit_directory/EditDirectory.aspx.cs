using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditDirectory : System.Web.UI.Page
    {
        public ActionEditDirectoryModel model = new ActionEditDirectoryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveDirectory"]))
                btn_SaveDirectory_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_DirectoryName"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["directory_path"]))
                    return;

                if (string.IsNullOrEmpty(Request.QueryString["directory_name"]))
                    return;
            }


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveDirectory_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.DirectoryNameValue = Request.Form["txt_DirectoryName"];
            model.OldDirectoryNameValue = Request.Form["hdn_DirectoryName"];
            model.DirectoryPathValue = Request.Form["hdn_DirectoryPath"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveDirectory();

            model.SuccessView();
        }
    }
}