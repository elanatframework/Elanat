using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveModuleController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["module_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["module_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Module dum = new DataUse.Module();
            dum.Active(context.Request.Query["module_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_module", context.Request.Query["module_id"].ToString());
        }
    }
}