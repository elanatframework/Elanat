using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyCountry : System.Web.UI.Page
    {
        public SiteContentReplyCountryModel model = new SiteContentReplyCountryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.CountryValue = Request.QueryString["country_value"];
            model.CountryCssClass = Request.QueryString["country_css_class"];
            model.CountryAttribute = Request.QueryString["country_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}