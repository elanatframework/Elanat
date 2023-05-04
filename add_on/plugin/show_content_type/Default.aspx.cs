using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class PluginSiteShowContentType : System.Web.UI.Page
    {
        public PluginSiteShowContentTypeModel model = new PluginSiteShowContentTypeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}