using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveAttachmentController : CodeBehindController
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

            DataUse.Attachment dua = new DataUse.Attachment();
            dua.Active(context.Request.Query["attachment_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_attachment", context.Request.Query["attachment_id"].ToString());
        }
    }
}