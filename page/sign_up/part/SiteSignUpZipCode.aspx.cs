using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpZipCode : System.Web.UI.Page
    {
        public SiteSignUpZipCodeModel model = new SiteSignUpZipCodeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.ZipCodeValue = Request.QueryString["zip_code_value"];
            model.ZipCodeCssClass = Request.QueryString["zip_code_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}