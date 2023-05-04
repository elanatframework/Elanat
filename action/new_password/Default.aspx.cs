using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionNewPassword : System.Web.UI.Page
    {
        public ActionNewPasswordModel model = new ActionNewPasswordModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(Request.QueryString["value"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["user_id"]))
                return;

            string UserId = Request.QueryString["user_id"];
            string Value = Request.QueryString["value"];

            model.SetValue(UserId, Value);
        }
    }
}