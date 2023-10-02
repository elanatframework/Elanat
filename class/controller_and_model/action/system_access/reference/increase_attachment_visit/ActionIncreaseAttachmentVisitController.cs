using CodeBehind;

namespace Elanat
{
    public partial class ActionIncreaseAttachmentVisitController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["path"]))
                return;

            string Path = context.Request.Query["path"].ToString();

            Path = Path.GetTextAfterValue("/upload/attachment/");

            if (string.IsNullOrEmpty(Path))
                return;

            if (Path.Contains("/thumb/"))
                return;

            string AttachmentDirectoryPath = Path.GetTextBeforeLastValue("/");

            string AttachmentPhysicalName = Path.GetTextAfterLastValue("/");

            DataUse.Attachment dua = new DataUse.Attachment();

            string AttachmentId = dua.GetAttachmentIdByAttachmentPhysicalPath(AttachmentDirectoryPath, AttachmentPhysicalName);

            if (string.IsNullOrEmpty(AttachmentId))
                return;

            dua.IncreaseVisit(AttachmentId);
        }
    }
}