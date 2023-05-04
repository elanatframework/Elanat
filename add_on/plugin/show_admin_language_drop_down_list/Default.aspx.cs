using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class PluginShowAdminLanguageDropDownList : System.Web.UI.Page
    {
        public PluginShowAdminLanguageDropDownListModel model = new PluginShowAdminLanguageDropDownListModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}