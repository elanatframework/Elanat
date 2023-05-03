using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class SiteMain : System.Web.UI.Page
    {
        public SiteMainModel model = new SiteMainModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue(Request.QueryString);
        }
    }
}