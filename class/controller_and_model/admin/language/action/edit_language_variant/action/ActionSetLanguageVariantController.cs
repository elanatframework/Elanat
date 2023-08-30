using CodeBehind;

namespace Elanat
{
    public partial class ActionSetLanguageVariantController : CodeBehindController
    {
        public ActionSetLanguageVariantModel model = new ActionSetLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language_character"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.LanguageCharacterValue = context.Request.Query["language_character"].ToString();


            model.SetValue();

            View(model);
        }
    }
}