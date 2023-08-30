using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckAttachmentCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleAttachmentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='attachment_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
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
                Write("false");
                return;
            }

            Write("true");
        }
    }
}