using CodeBehind;

namespace Elanat
{
    public partial class ActionAddLanguageVariantController : CodeBehindController
    {
        public ActionAddLanguageVariantModel model = new ActionAddLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddLanguageVariant"]))
            {
                btn_AddLanguageVariant_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddLanguageVariant_Click(HttpContext context)
        {
            model.LanguageVariantValue = context.Request.Form["txt_LanguageVariant"];


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


            model.AddLanguageVariant(context);

            View(model);
        }
    }
}