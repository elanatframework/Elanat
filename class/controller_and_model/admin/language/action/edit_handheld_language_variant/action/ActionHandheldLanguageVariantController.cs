using CodeBehind;

namespace Elanat
{
    public partial class ActionHandheldLanguageVariantController : CodeBehindController
    {
        public ActionHandheldLanguageVariantModel model = new ActionHandheldLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["handheld_language_variant_value"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            string HandheldLanguageVariantValue = context.Request.Query["handheld_language_variant_value"];


            Write(model.ViewHandheldLanguageVariant(HandheldLanguageVariantValue));

            View(model);
        }
    }
}