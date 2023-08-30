using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperShowExtraHelperListController : CodeBehindController
    {
        public ExtraHelperShowExtraHelperListModel model = new ExtraHelperShowExtraHelperListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}