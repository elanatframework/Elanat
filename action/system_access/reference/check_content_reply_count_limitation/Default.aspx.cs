using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckContentReplyCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentReplyCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_reply_count']");

                if(!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleContentReplyCountLimitation == int.MaxValue)
                    RoleContentReplyCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContentReplyCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContentReplyCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.ContentReply duc = new DataUse.ContentReply();
            int UserContentReplyCount = duc.GetUserContentReplyCount(ccoc.UserId);

            if(UserContentReplyCount >= RoleContentReplyCountLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}