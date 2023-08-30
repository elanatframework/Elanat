using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckContactCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContactCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='contact_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (RoleContactCountLimitation == int.MaxValue)
                    RoleContactCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContactCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContactCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.Contact duc = new DataUse.Contact();
            int UserContactCount = duc.GetUserContactCount(ccoc.UserId);

            if(UserContactCount >= RoleContactCountLimitation)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}