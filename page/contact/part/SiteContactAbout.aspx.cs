using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactAbout : System.Web.UI.Page
    {
        public SiteContactAboutModel model = new SiteContactAboutModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.AboutValue = Request.QueryString["about_value"];
            model.AboutCssClass = Request.QueryString["about_css_class"];
            model.AboutAttribute = Request.QueryString["about_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}