using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserAttachmentController : CodeBehindController
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

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string AttachmentId = context.Request.Query["attachment_id"].ToString();

            DataUse.Attachment dua = new DataUse.Attachment();

            if(dua.IsUserAttachment(ccoc.UserId ,AttachmentId))
                Write("true");
            else
                Write("false");
        }
    }
}