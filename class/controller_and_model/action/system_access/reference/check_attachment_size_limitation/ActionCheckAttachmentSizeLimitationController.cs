using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckAttachmentSizeLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            float RoleAttachmentSizeLimitation = float.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='attachment_size']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
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
                Write("false");
                return;
            }

            Write("true");
        }
    }
}