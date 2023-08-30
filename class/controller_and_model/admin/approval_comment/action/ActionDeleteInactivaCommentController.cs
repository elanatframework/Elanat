using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteInactivaCommentController : CodeBehindController
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
            if (pc.IsProtected(context.Request.Query["comment_id"].ToString(), StaticObject.AdminPath + "/approval_comment/"))
            {
                Write("false");
                return;
            }

            DataUse.Comment duc = new DataUse.Comment();
            duc.Delete(context.Request.Query["comment_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_comment", context.Request.Query["comment_id"].ToString());
        }
    }
}