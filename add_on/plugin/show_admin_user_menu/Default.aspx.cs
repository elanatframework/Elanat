using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class PluginShowAdminUserMenu : System.Web.UI.Page
    {
        public PluginShowAdminUserMenuModel model = new PluginShowAdminUserMenuModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}