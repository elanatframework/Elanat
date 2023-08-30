using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteAttachmentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["attachment_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["attachment_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["attachment_id"].ToString(), StaticObject.AdminPath + "/attachment/"))
            {
                Write("false");
                return;
            }

            DataUse.Attachment dua = new DataUse.Attachment();
            dua.Delete(context.Request.Query["attachment_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_attachment", context.Request.Query["attachment_id"].ToString());
        }
    }
}