using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpRealLastName : System.Web.UI.Page
    {
        public SiteSignUpRealLastNameModel model = new SiteSignUpRealLastNameModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.RealLastNameValue = Request.QueryString["real_last_name_value"];
            model.RealLastNameCssClass = Request.QueryString["real_last_name_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}