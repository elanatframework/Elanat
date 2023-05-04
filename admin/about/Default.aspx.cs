using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class AdminAbout : System.Web.UI.Page
    {
        public AdminAboutModel model = new AdminAboutModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_CheckNewUpdate"]))
                btn_CheckNewUpdate_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_Update"]))
                btn_Update_Click(sender, e);


            model.SetValue();
        }

        protected void btn_CheckNewUpdate_Click(object sender, EventArgs e)
        {
            model.CheckNewUpdate();
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            model.BreakSupportCheckValue = Request.Form["cbx_BreakSupportCheck"] == "on";

            model.Update();
        }
    }
}