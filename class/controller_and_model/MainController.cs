using CodeBehind;

namespace Elanat
{
    public partial class MainController : CodeBehindController
    {
        public MainModel model = new MainModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            if (model.IgnoreViewAndModel)
            {
                Write(model.CurrentPageContent);

                IgnoreViewAndModel = true;

                return;
            }

            View(model);
        }
    }
}