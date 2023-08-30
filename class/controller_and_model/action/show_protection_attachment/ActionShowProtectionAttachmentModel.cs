using CodeBehind;

namespace Elanat
{
    public partial class ActionShowProtectionAttachmentModel : CodeBehindModel
    {
        public void SetValue(string AttachmentId, string AttachmentPassword)
        {
            ContentClass cc = new ContentClass();
            Write(cc.GetCurrentProtectionAttachment(AttachmentId, AttachmentPassword));
        }
    }
}