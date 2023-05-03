using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteError : System.Web.UI.Page
    {
        public SiteErrorModel model = new SiteErrorModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ErrorValue = "";

            if (!string.IsNullOrEmpty(Request.QueryString["value"]))
                ErrorValue = Request.QueryString["value"];

            model.SetValue(ErrorValue);
        }
    }
}