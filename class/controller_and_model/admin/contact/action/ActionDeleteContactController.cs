using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteContactController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["contact_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["contact_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["contact_id"].ToString(), StaticObject.AdminPath + "/contact/"))
            {
                Write("false");
                return;
            }

            DataUse.Contact duc = new DataUse.Contact();
            duc.Delete(context.Request.Query["contact_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_contact", context.Request.Query["contact_id"].ToString());
        }
    }
}