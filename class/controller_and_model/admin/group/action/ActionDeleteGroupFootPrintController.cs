using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteGroupFootPrintController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["group_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["group_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["group_id"].ToString(), StaticObject.AdminPath + "/group/"))
            {
                Write("false");
                return;
            }

            DataUse.Group dug = new DataUse.Group();
            dug.DeleteFootPrint(context.Request.Query["group_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_group_foot_print", context.Request.Query["group_id"].ToString());
        }
    }
}