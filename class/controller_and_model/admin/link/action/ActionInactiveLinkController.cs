using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveLinkController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["link_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["link_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Link dul = new DataUse.Link();
            dul.Inactive(context.Request.Query["link_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_link", context.Request.Query["link_id"].ToString());
        }
    }
}