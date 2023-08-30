using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteSiteController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["site_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["site_id"].ToString(), StaticObject.AdminPath + "/site/"))
            {
                Write("false");
                return;
            }

            DataUse.Site dus = new DataUse.Site();
            dus.Delete(context.Request.Query["site_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_site", context.Request.Query["site_id"].ToString());
        }
    }
}