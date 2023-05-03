using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpRealName : System.Web.UI.Page
    {
        public SiteSignUpRealNameModel model = new SiteSignUpRealNameModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.RealNameValue = Request.QueryString["real_name_value"];
            model.RealNameCssClass = Request.QueryString["real_name_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}