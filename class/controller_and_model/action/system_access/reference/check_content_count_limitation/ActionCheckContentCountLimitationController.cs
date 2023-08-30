using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckContentCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (RoleContentCountLimitation == int.MaxValue)
                    RoleContentCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContentCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContentCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.Content duc = new DataUse.Content();
            int UserContentCount = duc.GetUserContentCount(ccoc.UserId);

            if(UserContentCount >= RoleContentCountLimitation)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}