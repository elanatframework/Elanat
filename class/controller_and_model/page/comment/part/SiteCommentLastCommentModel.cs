using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentLastCommentModel : CodeBehindModel
    {
        public string LastCommentValue { get; set; }

        public void SetValue(string ContentId)
        {
            ContentClass cc = new ContentClass();
            LastCommentValue = cc.GetContentComment(ContentId);
        }
    }
}