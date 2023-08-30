using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeLanguageController : CodeBehindController
    {
        public ActionChangeLanguageModel model = new ActionChangeLanguageModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeLanguage"]))
            {
                btn_ChangeLanguage_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeLanguage_Click(HttpContext context)
        {
            model.SiteLanguageOptionListSelectedValue = context.Request.Form["ddlst_UserSiteLanguage"];
            model.AdminLanguageOptionListSelectedValue = context.Request.Form["ddlst_UserAdminLanguage"];


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


            model.ChangeLanguage();

            model.SuccessView();

            View(model);
        }
    }
}