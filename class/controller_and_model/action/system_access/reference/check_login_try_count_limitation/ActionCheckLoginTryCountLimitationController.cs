using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckLoginTryCountLimitationController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (context.Session.GetString("el_login_try") == null)
            {
                context.Session.SetString("el_login_try", "1");

                Write("true");
                return;
            }

            int RoleLoginTryCountLimitation = 0;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='login_try_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Write("true");
                    return;
                }

                if (node.Attributes["value"].Value == "0")
                {
                    Write("true");
                    return;
                }

                if (RoleLoginTryCountLimitation == 0)
                    RoleLoginTryCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleLoginTryCountLimitation > int.Parse(node.Attributes["value"].Value))
                    RoleLoginTryCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            int UserLoginTryCount = int.Parse(context.Session.GetString("el_login_try"));

            if (UserLoginTryCount >= RoleLoginTryCountLimitation)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}