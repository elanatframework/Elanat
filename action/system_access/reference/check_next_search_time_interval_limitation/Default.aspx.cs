using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckNextSearchTimeIntervalLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DateTime dt = DateTime.Now;

            if (Session["el_last_search_time"] == null)
            {
                Session.Add("el_last_search_time", dt);

                Response.Write("true");
                return;
            }

            int RoleNextSearchTimeIntervalLimitation = 0;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='next_search_time_interval']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleNextSearchTimeIntervalLimitation == 0)
                    RoleNextSearchTimeIntervalLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleNextSearchTimeIntervalLimitation > int.Parse(node.Attributes["value"].Value))
                    RoleNextSearchTimeIntervalLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DateTime UserLastSearchTime = DateTime.Parse(Session["el_last_search_time"].ToString());

            if (UserLastSearchTime.AddSeconds(RoleNextSearchTimeIntervalLimitation) > dt)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}