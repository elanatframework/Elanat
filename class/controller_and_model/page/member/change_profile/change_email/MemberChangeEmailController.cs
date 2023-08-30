using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeEmailController : CodeBehindController
    {
        public MemberChangeEmailModel model = new MemberChangeEmailModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeEmail"]))
            {
                btn_ChangeEmail_Click(context);
                return;
            }


            model.SetValue();
            

            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeEmail_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.UserEmailValue = context.Request.Form["txt_UserEmail"];
            model.RepeatEmaiValue = context.Request.Form["txt_RepeatEmail"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            if (context.Request.Form["txt_UserEmail"] != context.Request.Form["txt_RepeatEmail"])
            {
                model.EmailEqualityErrorView();

                View(model);

                return;
            }

            model.ChangeEmail();

            model.SuccessView();

            View(model);
        }
    }
}