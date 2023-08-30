using CodeBehind;

namespace Elanat
{
    public partial class AdminFileManagerController : CodeBehindController
    {
        public AdminFileManagerModel model = new AdminFileManagerModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_CreateFile"]))
            {
                btn_CreateFile_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_CreateDirectory"]))
            {
                btn_CreateDirectory_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_CreateFile_Click(HttpContext context)
        {
            model.FileNameValue = context.Request.Form["txt_FileName"];
            model.FileTextValue = context.Request.Form["txt_FileText"];
            model.PathHiddenValue = context.Request.Form["hdn_PathHidden"];


            // Evaluate Field Check
            model.CreateFileEvaluateField(context.Request.Form);
            if (model.FindCreateFileEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CreateFileEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.CreateFile();

            View(model);
        }

        protected void btn_CreateDirectory_Click(HttpContext context)
        {
            model.DirectoryNameValue = context.Request.Form["txt_DirectoryName"];
            model.PathHiddenValue = context.Request.Form["hdn_PathHidden"];
            

            // Evaluate Field Check
            model.CreateDirectoryEvaluateField(context.Request.Form);
            if (model.FindCreateDirectoryEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CreateDirectoryEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.CreateDirectory();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.FilePathUploadValue = context.Request.Form.Files["upd_FilePath"];
            model.UseFilePathValue = context.Request.Form["cbx_UseFilePath"] == "on";
            model.FilePathTextValue = context.Request.Form["txt_FilePath"];
            model.PathHiddenValue = context.Request.Form["hdn_PathHidden"];


            model.StartUpload();

            View(model);
        }
    }
}