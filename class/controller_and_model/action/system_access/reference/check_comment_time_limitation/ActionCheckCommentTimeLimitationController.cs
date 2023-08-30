using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckCommentTimeLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleCommentTimeLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='comment_time']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (RoleCommentTimeLimitation == int.MaxValue)
                    RoleCommentTimeLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleCommentTimeLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleCommentTimeLimitation = int.Parse(node.Attributes["value"].Value);
            }

            string ContentId = context.Request.Query["content_id"].ToString();

            DataUse.Content duc = new DataUse.Content();
            DateTime ContentTimeCreate = duc.GetContentDateTimeCreate(ContentId);

            if (ContentTimeCreate.AddSeconds(RoleCommentTimeLimitation) < DateTime.Now)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}