using CodeBehind;

namespace Elanat
{
    public partial class ActionEditTextFileSetCodeHighlighterController : CodeBehindController
    {
        public ActionEditTextFileSetCodeHighlighterModel model = new ActionEditTextFileSetCodeHighlighterModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["text_file_path"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.TextFilePathValue = context.Request.Query["text_file_path"].ToString();

            model.SetValue();

            View(model);
        }
    }
}