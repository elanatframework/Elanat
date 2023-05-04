using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace elanat
{
    public partial class ActionLockLogin : System.Web.UI.Page
    {
        public ActionLockLoginModel model = new ActionLockLoginModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/lock_login_page").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(Request.QueryString["code"]))
                return;

            if (Security.GetCodeIni("lock_login_password_value") != Request.QueryString["code"])
                return;


            model.SetValue();
        }
    }
}