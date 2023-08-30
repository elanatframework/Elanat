using CodeBehind;

namespace Elanat
{
    public partial class ActionViewModuleOptionController : CodeBehindController
    {
        public ActionViewModuleOptionModel model = new ActionViewModuleOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["module_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["module_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            string ModuleId = context.Request.Query["module_id"];


            Write(model.ViewModuleOption(ModuleId));

            View(model);
        }
    }
}