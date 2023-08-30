using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveSiteStyleController : CodeBehindController
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
            duss.Active(context.Request.Query["site_style_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_site_style", context.Request.Query["site_style_id"].ToString());
        }
    }
}