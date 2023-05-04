using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionShowProtectionContent : System.Web.UI.Page
    {
        public ActionShowProtectionContentModel model = new ActionShowProtectionContentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(Request.QueryString["captcha_value"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["content_password"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
                return;

            if (!Request.QueryString["content_id"].ToString().IsNumber())
                return;

            if (!Request.QueryString["captcha_value"].ToString().MatchByCaptcha())
                return;


            string ContentId = Request.QueryString["content_id"];
            string ContentPassword = Request.QueryString["content_password"].ProtectSqlInjection();

            model.SetValue(ContentId, ContentPassword);
        }
    }
}