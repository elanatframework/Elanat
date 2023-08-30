using CodeBehind;

namespace Elanat
{
    public partial class ActionEditDirectoryController : CodeBehindController
    {
        public ActionEditDirectoryModel model = new ActionEditDirectoryModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveDirectory"]))
            {
                btn_SaveDirectory_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_DirectoryName"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["directory_path"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (string.IsNullOrEmpty(context.Request.Query["directory_name"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }
            }


            model.SetValue( context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveDirectory_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.DirectoryNameValue = context.Request.Form["txt_DirectoryName"];
            model.OldDirectoryNameValue = context.Request.Form["hdn_DirectoryName"];
            model.DirectoryPathValue = context.Request.Form["hdn_DirectoryPath"];


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


            model.SaveDirectory();

            model.SuccessView();

            View(model);
        }
    }
}