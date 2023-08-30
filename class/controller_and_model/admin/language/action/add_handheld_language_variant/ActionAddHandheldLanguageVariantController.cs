using CodeBehind;

namespace Elanat
{
    public partial class ActionAddHandheldLanguageVariantController : CodeBehindController
    {
        public ActionAddHandheldLanguageVariantModel model = new ActionAddHandheldLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddHandheldLanguageVariant"]))
            {
                btn_AddHandheldLanguageVariant_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddHandheldLanguageVariant_Click(HttpContext context)
        {
            model.HandheldLanguageVariantValue = context.Request.Form["txt_HandheldLanguageVariant"];


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


            model.AddHandheldLanguageVariant(context);

            View(model);
        }
    }
}