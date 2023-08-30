using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPluginViewMoreController : CodeBehindController
    {
        public ActionGetPluginViewMoreModel model = new ActionGetPluginViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["plugin_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["plugin_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["plugin_id"]));

            View(model);
        }
    }
}