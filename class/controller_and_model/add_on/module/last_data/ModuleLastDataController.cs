using CodeBehind;

namespace Elanat
{
    public partial class ModuleLastDataController : CodeBehindController
    {
        public ModuleLastDataModel model = new ModuleLastDataModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}