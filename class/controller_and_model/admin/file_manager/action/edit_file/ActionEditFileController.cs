using CodeBehind;

namespace Elanat
{
    public partial class ActionEditFileController : CodeBehindController
    {
        public ActionEditFileModel model = new ActionEditFileModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveFile"]))
            {
                btn_SaveFile_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_FileName"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["file_path"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (string.IsNullOrEmpty(context.Request.Query["file_name"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (string.IsNullOrEmpty(context.Request.Query["file_type"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveFile_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.FileNameValue = context.Request.Form["txt_FileName"];
            model.FileTextValue = context.Request.Form["txt_FileText"];
            model.OldFilePathValue = context.Request.Form["hdn_FilePath"];
            model.OldFileNameValue = context.Request.Form["hdn_FileName"];
            model.FileTypeValue = context.Request.Form["hdn_FileType"];
            model.MimeTypeValue = context.Request.Form["hdn_MimeType"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveFile();

            model.SuccessView();

            View(model);
        }
    }
}