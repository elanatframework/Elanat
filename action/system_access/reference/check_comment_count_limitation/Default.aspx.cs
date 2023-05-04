using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckCommentCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleCommentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='comment_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleCommentCountLimitation == int.MaxValue)
                    RoleCommentCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleCommentCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleCommentCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.Comment duc = new DataUse.Comment();
            int UserCommentCount = duc.GetUserCommentCount(ccoc.UserId);

            if(UserCommentCount >= RoleCommentCountLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}