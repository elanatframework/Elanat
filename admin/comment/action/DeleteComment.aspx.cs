using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["comment_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["comment_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            string CommentId = Request.QueryString["comment_id"].ToString();

            // Delete Comment From Own Content Access Check
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Content Duc = new DataUse.Content();

            string ContentId = Duc.GetContentIdByCommentId(CommentId);

            if (!Duc.IsUserContent(ccoc.UserId, ContentId))
            {
                if (StaticObject.RoleDeleteCommentOnlyOwnContentCheck())
                {
                    GlobalClass.AlertAddOnsLanguageVariant("role_can_delete_comment_in_only_own_content", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/comment/");
                    return;
                }
            }
                

            DataUse.Comment duc = new DataUse.Comment();
            duc.Delete(CommentId);
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_comment", Request.QueryString["comment_id"].ToString());
        }
    }
}