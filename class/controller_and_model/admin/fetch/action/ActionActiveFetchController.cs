using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveFetchController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["fetch_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Fetch duf = new DataUse.Fetch();
            duf.Active(context.Request.Query["fetch_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_fetch", context.Request.Query["fetch_id"].ToString());
        }
    }
}