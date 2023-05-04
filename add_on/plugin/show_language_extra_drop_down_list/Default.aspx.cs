using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class PluginSiteShowLanguageExtraDropDownList : System.Web.UI.Page
    {
        public PluginSiteShowLanguageExtraDropDownListModel model = new PluginSiteShowLanguageExtraDropDownListModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}