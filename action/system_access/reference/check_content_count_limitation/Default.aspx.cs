using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckContentCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
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
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}