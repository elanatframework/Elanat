using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyCity : System.Web.UI.Page
    {
        public SiteContentReplyCityModel model = new SiteContentReplyCityModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.CityValue = Request.QueryString["city_value"];
            model.CityCssClass = Request.QueryString["city_css_class"];
            model.CityAttribute = Request.QueryString["city_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}