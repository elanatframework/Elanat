using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckNextSearchTimeIntervalLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DateTime dt = DateTime.Now;

            if (context.Session.GetString("el_last_search_time") == null)
            {
                context.Session.SetString("el_last_search_time", dt.ToString());

                Write("true");
                return;
            }

            int RoleNextSearchTimeIntervalLimitation = 0;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='next_search_time_interval']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (RoleNextSearchTimeIntervalLimitation == 0)
                    RoleNextSearchTimeIntervalLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleNextSearchTimeIntervalLimitation > int.Parse(node.Attributes["value"].Value))
                    RoleNextSearchTimeIntervalLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DateTime UserLastSearchTime = DateTime.Parse(context.Session.GetString("el_last_search_time"));

            if (UserLastSearchTime.AddSeconds(RoleNextSearchTimeIntervalLimitation) > dt)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}