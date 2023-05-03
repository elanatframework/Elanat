using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactStateOrProvince : System.Web.UI.Page
    {
        public SiteContactStateOrProvinceModel model = new SiteContactStateOrProvinceModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.StateOrProvinceValue = Request.QueryString["state_or_province_value"];
            model.StateOrProvinceCssClass = Request.QueryString["state_or_province_css_class"];
            model.StateOrProvinceAttribute = Request.QueryString["state_or_province_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}