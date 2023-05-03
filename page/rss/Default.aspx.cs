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
    public partial class SiteRss : System.Web.UI.Page
    {
        public SiteRssModel model = new SiteRssModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}