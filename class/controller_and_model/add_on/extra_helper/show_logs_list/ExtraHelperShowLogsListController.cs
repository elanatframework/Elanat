using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperShowLogsListController : CodeBehindController
    {
        public ExtraHelperShowLogsListModel model = new ExtraHelperShowLogsListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}