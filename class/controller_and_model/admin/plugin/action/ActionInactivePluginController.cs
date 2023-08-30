using CodeBehind;

namespace Elanat
{
    public partial class ActionInactivePluginController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["plugin_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["plugin_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Plugin dup = new DataUse.Plugin();
            dup.Inactive(context.Request.Query["plugin_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_plugin", context.Request.Query["plugin_id"].ToString());
        }
    }
}