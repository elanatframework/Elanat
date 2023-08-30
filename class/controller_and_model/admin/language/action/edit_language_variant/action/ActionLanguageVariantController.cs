using CodeBehind;

namespace Elanat
{
    public partial class ActionLanguageVariantController : CodeBehindController
    {
        public ActionLanguageVariantModel model = new ActionLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language_variant_value"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            string LanguageVariantValue = context.Request.Query["language_variant_value"];


            Write(model.ViewLanguageVariant(LanguageVariantValue));

            View(model);
        }
    }
}