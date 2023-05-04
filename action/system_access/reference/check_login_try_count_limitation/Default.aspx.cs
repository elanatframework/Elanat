using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckLoginTryCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (Session["el_login_try"] == null)
            {
                Session.Add("el_login_try", 1);

                Response.Write("true");
                return;
            }

            int RoleLoginTryCountLimitation = 0;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='login_try_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (node.Attributes["value"].Value == "0")
                {
                    Response.Write("true");
                    return;
                }

                if (RoleLoginTryCountLimitation == 0)
                    RoleLoginTryCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleLoginTryCountLimitation > int.Parse(node.Attributes["value"].Value))
                    RoleLoginTryCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            int UserLoginTryCount = int.Parse(Session["el_login_try"].ToString());

            if (UserLoginTryCount >= RoleLoginTryCountLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}