using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEmailConfirm : System.Web.UI.Page
    {
        public ActionEmailConfirmModel model = new ActionEmailConfirmModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(Request.QueryString["user_name_or_user_email"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["captcha"]))
                return;

            if (Session["el_captcha"] == null)
                return;

            if (!Request.QueryString["captcha"].ToString().MatchByCaptcha())
            {
                // Set Random Number To Captcha Session For Security
                Random rand = new Random();
                Session["el_captcha"] = rand.Next(int.MaxValue).ToString();

                return;
            }

            string UserNameOrUserEmail = Request.QueryString["user_name_or_user_email"].ProtectSqlInjection();

            model.SetValue(UserNameOrUserEmail);
        }
    }
}