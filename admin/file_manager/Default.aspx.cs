using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace elanat
{
    public partial class AdminFileManager : System.Web.UI.Page
    {
        public AdminFileManagerModel model = new AdminFileManagerModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_CreateFile"]))
                btn_CreateFile_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_CreateDirectory"]))
                btn_CreateDirectory_Click(sender, e);
            
            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_CreateFile_Click(object sender, EventArgs e)
        {
            model.FileNameValue = Request.Form["txt_FileName"];
            model.FileTextValue = Request.Form["txt_FileText"];
            model.PathHiddenValue = Request.Form["hdn_PathHidden"];


            // Evaluate Field Check
            model.CreateFileEvaluateField(Request.Form);
            if (model.FindCreateFileEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CreateFileEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.CreateFile();
        }

        protected void btn_CreateDirectory_Click(object sender, EventArgs e)
        {
            model.DirectoryNameValue = Request.Form["txt_DirectoryName"];
            model.PathHiddenValue = Request.Form["hdn_PathHidden"];
            

            // Evaluate Field Check
            model.CreateDirectoryEvaluateField(Request.Form);
            if (model.FindCreateDirectoryEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CreateDirectoryEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.CreateDirectory();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.FilePathUploadValue = Request.Files["upd_FilePath"];
            model.UseFilePathValue = Request.Form["cbx_UseFilePath"] == "on";
            model.FilePathTextValue = Request.Form["txt_FilePath"];
            model.PathHiddenValue = Request.Form["hdn_PathHidden"];


            model.StartUpload();
        }
    }
}