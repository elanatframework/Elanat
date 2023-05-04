using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCheckContentReplyTimeLimitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int RoleContentReplyTimeLimitation = int.MaxValue;

            XmlDocument doc = new XmlDocument();

            foreach (string Text in ccoc.GetRoleNameList())
            {
                XmlNode node = StaticObject.CurrentRoleLimitationsDocument(Text).SelectSingleNode("limitation_root/limitation_list/limitation[@name='content_reply_time']");

                if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                {
                    Response.Write("true");
                    return;
                }

                if (RoleContentReplyTimeLimitation == int.MaxValue)
                    RoleContentReplyTimeLimitation = int.Parse(node.Attributes["value"].Value);

                if (RoleContentReplyTimeLimitation < int.Parse(node.Attributes["value"].Value))
                    RoleContentReplyTimeLimitation = int.Parse(node.Attributes["value"].Value);
            }

            string ContentId = Request.QueryString["content_id"].ToString();

            DataUse.Content duc = new DataUse.Content();
            DateTime ContentTimeCreate = duc.GetContentDateTimeCreate(ContentId);

            if (ContentTimeCreate.AddSeconds(RoleContentReplyTimeLimitation) < DateTime.Now)
            {
                Response.Write("false");
                return;
            }

            Response.Write("true");
        }
    }
}