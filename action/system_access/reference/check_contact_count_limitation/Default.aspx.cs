using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckContactCountLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContactCountLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='contact_count']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleContactCountLimitation == int.MaxValue)
                    RoleContactCountLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContactCountLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContactCountLimitation = int.Parse(node.Attributes["value"].Value);
            }

            DataUse.Contact duc = new DataUse.Contact();
            int UserContactCount = duc.GetUserContactCount(ccoc.UserId);

            if(UserContactCount >= RoleContactCountLimitation)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}