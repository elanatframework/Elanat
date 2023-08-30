using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteViewController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["view_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["view_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["view_id"].ToString(), StaticObject.AdminPath + "/view/"))
            {
                Write("false");
                return;
            }

            DataUse.View duv = new DataUse.View();
            duv.Delete(context.Request.Query["view_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_view", context.Request.Query["view_id"].ToString());
        }
    }
}