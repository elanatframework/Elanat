using CodeBehind;

namespace Elanat
{
    public partial class ActionPluginNewRowController : CodeBehindController
    {
        public ActionPluginNewRowModel model = new ActionPluginNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["plugin_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["plugin_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.PluginIdValue = context.Request.Query["plugin_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}