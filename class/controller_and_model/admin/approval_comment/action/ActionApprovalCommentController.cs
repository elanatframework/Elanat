using CodeBehind;

namespace Elanat
{
    public partial class ActionApprovalCommentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["comment_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["comment_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            string CommentId = context.Request.Query["comment_id"].ToString();

            // Approval Comment in Own Content  Access Check
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Content Duc = new DataUse.Content();

            string ContentId = Duc.GetContentIdByCommentId(CommentId);

            if (!Duc.IsUserContent(ccoc.UserId, ContentId))
            {
                if (StaticObject.RoleApprovalCommentOnlyOwnContentCheck())
                {
                    Write(GlobalClass.AlertAddOnsLanguageVariant("role_can_approval_comment_in_only_own_content", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/comment/"));
                    return;
                }
            }

            DataUse.Comment duc = new DataUse.Comment();
            duc.Approval(context.Request.Query["comment_id"].ToString());
            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("approval_comment", context.Request.Query["comment_id"].ToString());               
        }
    }
}