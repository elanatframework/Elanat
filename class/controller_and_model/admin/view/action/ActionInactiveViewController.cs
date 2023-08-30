using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveViewController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["view_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["view_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.View duv = new DataUse.View();
            duv.Inactive(context.Request.Query["view_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_view", context.Request.Query["view_id"].ToString());
        }
    }
}