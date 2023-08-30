using CodeBehind;

namespace Elanat
{
    public partial class ModuleInformationController : CodeBehindController
    {
        public ModuleInformationModel model = new ModuleInformationModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}