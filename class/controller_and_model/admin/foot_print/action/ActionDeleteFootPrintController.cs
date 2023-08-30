using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteFootPrintController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["foot_print_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["foot_print_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["foot_print_id"].ToString(), StaticObject.AdminPath + "/foot_print/"))
            {
                Write("false");
                return;
            }

            DataUse.FootPrint dufp = new DataUse.FootPrint();
            dufp.Delete(context.Request.Query["foot_print_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_foot_print", context.Request.Query["foot_print_id"].ToString());
        }
    }
}