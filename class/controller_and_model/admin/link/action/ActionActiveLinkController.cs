using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveLinkController : CodeBehindController
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
            dul.Active(context.Request.Query["link_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_link", context.Request.Query["link_id"].ToString());
        }
    }
}