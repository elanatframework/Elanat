using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckContentReplyTimeLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentReplyTimeLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_reply_time']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (RoleContentReplyTimeLimitation == int.MaxValue)
                    RoleContentReplyTimeLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContentReplyTimeLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContentReplyTimeLimitation = int.Parse(node.Attributes["value"].Value);
            }

            string ContentId = context.Request.Query["content_id"].ToString();

            DataUse.Content duc = new DataUse.Content();
            DateTime ContentTimeCreate = duc.GetContentDateTimeCreate(ContentId);

            if (ContentTimeCreate.AddSeconds(RoleContentReplyTimeLimitation) < DateTime.Now)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}