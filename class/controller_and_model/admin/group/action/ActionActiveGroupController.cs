using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveGroupController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["group_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["group_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Group dug = new DataUse.Group();
            dug.Active(context.Request.Query["group_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_group", context.Request.Query["group_id"].ToString());
        }
    }
}