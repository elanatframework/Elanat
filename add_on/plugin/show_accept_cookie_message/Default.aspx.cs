using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class PluginSiteShowAcceptCookieMessage : System.Web.UI.Page
    {
        public PluginSiteShowAcceptCookieMessageModel model = new PluginSiteShowAcceptCookieMessageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}