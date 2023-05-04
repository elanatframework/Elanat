using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionKeepLogin : System.Web.UI.Page
    {
        public ActionKeepLoginModel model = new ActionKeepLoginModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);


            if (!string.IsNullOrEmpty(Request.QueryString["use_start_add_on_install"]))
            {
                if (Request.QueryString["use_start_add_on_install"].ToString() == "true")
                    model.UseStartAddOnInstall = "true";
            }


            string RandomText = Request.Cookies["el_current_user-keep_login_random_text"].Value;
            string UserId = Request.Cookies["el_current_user-keep_login_user_id"].Value;

            model.SetValue(RandomText, UserId);
        }
    }
}