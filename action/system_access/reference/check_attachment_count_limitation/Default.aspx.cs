using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckAttachmentCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleAttachmentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='attachment_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleAttachmentCountLimitation == int.MaxValue)
                    RoleAttachmentCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleAttachmentCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleAttachmentCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.Attachment dua = new DataUse.Attachment();
            int UserAttachmentCount = dua.GetUserAttachmentCount(ccoc.UserId);

            if(UserAttachmentCount >= RoleAttachmentCountLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}