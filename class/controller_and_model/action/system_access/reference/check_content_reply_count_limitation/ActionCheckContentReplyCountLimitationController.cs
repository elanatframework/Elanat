using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckContentReplyCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentReplyCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_reply_count']");

                if(!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
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
                Write("false");
                return;
            }

            Write("true");
        }
    }
}