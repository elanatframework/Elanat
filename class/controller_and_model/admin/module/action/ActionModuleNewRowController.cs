using CodeBehind;

namespace Elanat
{
    public partial class ActionModuleNewRowController : CodeBehindController
    {
        public ActionModuleNewRowModel model = new ActionModuleNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["module_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["module_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ModuleIdValue = context.Request.Query["module_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}