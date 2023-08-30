using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckCommentCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleCommentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='comment_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
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
                Write("false");
                return;
            }

            Write("true");
        }
    }
}