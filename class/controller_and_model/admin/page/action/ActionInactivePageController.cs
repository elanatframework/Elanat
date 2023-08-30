using CodeBehind;

namespace Elanat
{
    public partial class ActionInactivePageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["page_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["page_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Page dup = new DataUse.Page();
            dup.Inactive(context.Request.Query["page_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_page", context.Request.Query["page_id"].ToString());
        }
    }
}