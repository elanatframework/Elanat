using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteContentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["content_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["content_id"].ToString(), StaticObject.AdminPath + "/approval_content/"))
            {
                Write("false");
                return;
            }

            DataUse.Content duc = new DataUse.Content();
            duc.Delete(context.Request.Query["content_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_content", context.Request.Query["content_id"].ToString());
        }
    }
}