using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpCity : System.Web.UI.Page
    {
        public SiteSignUpCityModel model = new SiteSignUpCityModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.CityValue = Request.QueryString["city_value"];
            model.CityCssClass = Request.QueryString["city_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}