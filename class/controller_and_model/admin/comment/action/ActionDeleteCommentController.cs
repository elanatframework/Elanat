using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteCommentController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["comment_id"].ToString(), StaticObject.AdminPath + "/comment/"))
            {
                Write("false");
                return;
            }

            string CommentId = context.Request.Query["comment_id"].ToString();

            // Delete Comment From Own Content Access Check
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Content Duc = new DataUse.Content();

            string ContentId = Duc.GetContentIdByCommentId(CommentId);

            if (!Duc.IsUserContent(ccoc.UserId, ContentId))
            {
                if (StaticObject.RoleDeleteCommentOnlyOwnContentCheck())
                {
                    Write(GlobalClass.AlertAddOnsLanguageVariant("role_can_delete_comment_in_only_own_content", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/comment/"));
                    return;
                }
            }
                

            DataUse.Comment duc = new DataUse.Comment();
            duc.Delete(CommentId);
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_comment", context.Request.Query["comment_id"].ToString());
        }
    }
}