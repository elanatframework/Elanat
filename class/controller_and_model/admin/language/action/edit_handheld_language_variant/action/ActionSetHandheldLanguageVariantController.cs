using CodeBehind;

namespace Elanat
{
    public partial class ActionSetHandheldLanguageVariantController : CodeBehindController
    {
        public ActionSetHandheldLanguageVariantModel model = new ActionSetHandheldLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["handheld_language_character"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.HandheldLanguageCharacterValue = context.Request.Query["handheld_language_character"].ToString();


            model.SetValue();

            View(model);
        }
    }
}