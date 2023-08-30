using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveComponentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["component_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["component_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Component duc = new DataUse.Component();
            duc.Inactive(context.Request.Query["component_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_component", context.Request.Query["component_id"].ToString());
        }
    }
}