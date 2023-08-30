using CodeBehind;

namespace Elanat
{
    public partial class ActionNewUpdateController : CodeBehindController
    {
        public ActionNewUpdateModel model = new ActionNewUpdateModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}