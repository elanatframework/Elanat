using CodeBehind;

namespace Elanat
{
    public partial class ModuleTodayActivityController : CodeBehindController
    {
        public ModuleTodayActivityModel model = new ModuleTodayActivityModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}