using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpPostalCode : System.Web.UI.Page
    {
        public SiteSignUpPostalCodeModel model = new SiteSignUpPostalCodeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.PostalCodeValue = Request.QueryString["postal_code_value"];
            model.PostalCodeCssClass = Request.QueryString["postal_code_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}