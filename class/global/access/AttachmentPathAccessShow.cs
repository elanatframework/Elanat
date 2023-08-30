namespace Elanat
{
    public class AttachmentPathAccessShow
    {
        public string CurrentAttachmentId { get; private set; }

        public bool PathAccessToAttachment(string Path)
        {
            string AttachmentDirectoryPath;
            string AttachmentPhysicalName;

            Path = Path.Replace("/thumb/", "/");

            if (Path.Contains('/'))
            {
                AttachmentDirectoryPath = Path.GetTextBeforeLastValue("/");
                AttachmentPhysicalName = Path.GetTextAfterLastValue("/");
            }
            else
            {
                AttachmentDirectoryPath = "";
                AttachmentPhysicalName = Path;
            }


            if (string.IsNullOrEmpty(AttachmentDirectoryPath + AttachmentPhysicalName))
                return false;

            DataUse.Attachment dua = new DataUse.Attachment();

            string AttachmentId = dua.GetAttachmentIdByAttachmentPhysicalPath(AttachmentDirectoryPath, AttachmentPhysicalName);

            if (string.IsNullOrEmpty(AttachmentId))
                return false;

            CurrentAttachmentId = AttachmentId;


            return dua.GetAttachmentAccessShowCheck(AttachmentId);
        }
    }
}