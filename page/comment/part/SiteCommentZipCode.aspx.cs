using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentZipCode : System.Web.UI.Page
    {
        public SiteCommentZipCodeModel model = new SiteCommentZipCodeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.ZipCodeValue = Request.QueryString["zip_code_value"];
            model.ZipCodeCssClass = Request.QueryString["zip_code_css_class"];
            model.ZipCodeAttribute = Request.QueryString["zip_code_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}