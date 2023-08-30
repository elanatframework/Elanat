using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteLinkController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["link_id"].ToString(), StaticObject.AdminPath + "/link/"))
            {
                Write("false");
                return;
            }

            DataUse.Link dul = new DataUse.Link();
            dul.Delete(context.Request.Query["link_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_link", context.Request.Query["link_id"].ToString());
        }
    }
}