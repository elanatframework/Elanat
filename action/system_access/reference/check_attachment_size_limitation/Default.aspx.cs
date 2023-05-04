using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckAttachmentSizeLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            float RoleAttachmentSizeLimitation = float.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='attachment_size']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleAttachmentSizeLimitation == float.MaxValue)
                    RoleAttachmentSizeLimitation = float.Parse(node.Attributes["value"].Value);

                if (RoleAttachmentSizeLimitation < float.Parse(node.Attributes["value"].Value))
                    RoleAttachmentSizeLimitation = float.Parse(node.Attributes["value"].Value);
            }

            DataUse.Attachment dua = new DataUse.Attachment();
            float UserAttachmentSize = dua.GetUserAttachmentSize(ccoc.UserId);

            if (UserAttachmentSize >= RoleAttachmentSizeLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}