using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveSiteTemplateController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_template_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["site_template_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
            dust.Active(context.Request.Query["site_template_id"].ToString());
            Write("true");


            // Refill Value
            StaticObject.SetSiteTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_site_template", context.Request.Query["site_template_id"].ToString());
        }
    }
}