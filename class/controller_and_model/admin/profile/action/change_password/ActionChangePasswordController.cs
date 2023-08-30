using CodeBehind;

namespace Elanat
{
    public partial class ActionChangePasswordController : CodeBehindController
    {
        public ActionChangePasswordModel model = new ActionChangePasswordModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangePassword"]))
            {
                btn_ChangePassword_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangePassword_Click(HttpContext context)
        {
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


            if (context.Request.Form["txt_UserPassword"] != context.Request.Form["txt_RepeatPassword"])
            {
                model.PasswordEqualityErrorView();

                View(model);

                return;
            }

            model.UserPasswordValue = context.Request.Form["txt_UserPassword"];


            model.ChangePassword();

            model.SuccessView();

            View(model);
        }
    }
}