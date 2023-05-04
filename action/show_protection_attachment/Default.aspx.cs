using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionShowProtectionAttachment : System.Web.UI.Page
    {
        public ActionShowProtectionAttachmentModel model = new ActionShowProtectionAttachmentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_attachment").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(Request.QueryString["captcha_value"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["attachment_password"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["attachment_id"]))
                return;

            if (!Request.QueryString["attachment_id"].ToString().IsNumber())
                return;

           if (!Request.QueryString["captcha_value"].ToString().MatchByCaptcha())
               return;


            string AttachmentId = Request.QueryString["attachment_id"];
            string AttachmentPassword = Request.QueryString["attachment_password"].ProtectSqlInjection();

            model.SetValue(AttachmentId, AttachmentPassword);
        }
    }
}