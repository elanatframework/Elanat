using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveSiteStyleController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["site_style_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.Inactive(context.Request.Query["site_style_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_site_style", context.Request.Query["site_style_id"].ToString());
        }
    }
}