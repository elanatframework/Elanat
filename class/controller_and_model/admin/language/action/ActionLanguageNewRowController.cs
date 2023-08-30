using CodeBehind;

namespace Elanat
{
    public partial class ActionLanguageNewRowController : CodeBehindController
    {
        public ActionLanguageNewRowModel model = new ActionLanguageNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["language_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.LanguageIdValue = context.Request.Query["language_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}