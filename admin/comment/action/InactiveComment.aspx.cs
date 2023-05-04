using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveComment : System.Web.UI.Page
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

            string CommentId = Request.QueryString["comment_id"].ToString();

            // Edit Comment From Own Content Access Check
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Content Duc = new DataUse.Content();

            string ContentId = Duc.GetContentIdByCommentId(CommentId);

            if (!Duc.IsUserContent(ccoc.UserId, ContentId))
            {
                if (StaticObject.RoleEditCommentOnlyOwnContentCheck())
                {
                    GlobalClass.AlertAddOnsLanguageVariant("role_can_edit_comment_in_only_own_content", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/comment/");
                    return;
                }
            }


            DataUse.Comment duc = new DataUse.Comment();
            duc.Inactive(Request.QueryString["comment_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_comment", Request.QueryString["comment_id"].ToString());
        }
    }
}