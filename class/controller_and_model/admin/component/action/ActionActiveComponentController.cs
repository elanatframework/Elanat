using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveComponentController : CodeBehindController
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

            DataUse.Component duac = new DataUse.Component();
            duac.Active(context.Request.Query["component_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_component", context.Request.Query["component_id"].ToString());
        }
    }
}