using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpCountry : System.Web.UI.Page
    {
        public SiteSignUpCountryModel model = new SiteSignUpCountryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.CountryValue = Request.QueryString["country_value"];
            model.CountryCssClass = Request.QueryString["country_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}