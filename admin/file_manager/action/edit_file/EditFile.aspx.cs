using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditFile : System.Web.UI.Page
    {
        public ActionEditFileModel model = new ActionEditFileModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveFile"]))
                btn_SaveFile_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_FileName"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["file_path"]))
                    return;

                if (string.IsNullOrEmpty(Request.QueryString["file_name"]))
                    return;

                if (string.IsNullOrEmpty(Request.QueryString["file_type"]))
                    return;
            }


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveFile_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.FileNameValue = Request.Form["txt_FileName"];
            model.FileTextValue = Request.Form["txt_FileText"];
            model.OldFilePathValue = Request.Form["hdn_FilePath"];
            model.OldFileNameValue = Request.Form["hdn_FileName"];
            model.FileTypeValue = Request.Form["hdn_FileType"];
            model.MimeTypeValue = Request.Form["hdn_MimeType"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveFile();

            model.SuccessView();
        }
    }
}