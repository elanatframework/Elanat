using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveViewController : CodeBehindController
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
            duv.Active(context.Request.Query["view_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_view", context.Request.Query["view_id"].ToString());
        }
    }
}