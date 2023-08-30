using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteSiteStyleController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["site_style_id"].ToString(), StaticObject.AdminPath + "/site_style/"))
            {
                Write("false");
                return;
            }

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.Delete(context.Request.Query["site_style_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_site_style", context.Request.Query["site_style_id"].ToString());
        }
    }
}