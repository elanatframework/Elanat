using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteFetchController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["fetch_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["fetch_id"].ToString(), StaticObject.AdminPath + "/fetch/"))
            {
                Write("false");
                return;
            }

            DataUse.Fetch duf = new DataUse.Fetch();
            duf.Delete(context.Request.Query["fetch_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_fetch", context.Request.Query["fetch_id"].ToString());
        }
    }
}