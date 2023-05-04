using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class AdminConfiguration : System.Web.UI.Page
    {
        public AdminConfigurationModel model = new AdminConfigurationModel();

        string CurrentLanguage = StaticObject.GetCurrentAdminGlobalLanguage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveConfig"]))
                btn_SaveConfig_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveConfig_Click(object sender, EventArgs e)
        {
            model.ConfigValue = Request.Form["txt_Config"];


            model.SaveConfig(sender, e);
        }
    }
}