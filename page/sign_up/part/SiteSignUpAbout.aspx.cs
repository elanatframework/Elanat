using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpAbout : System.Web.UI.Page
    {
        public SiteSignUpAboutModel model = new SiteSignUpAboutModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.AboutValue = Request.QueryString["about_value"];
            model.AboutCssClass = Request.QueryString["about_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}