using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpMobileNumber : System.Web.UI.Page
    {
        public SiteSignUpMobileNumberModel model = new SiteSignUpMobileNumberModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.MobileNumberValue = Request.QueryString["mobile_number_value"];
            model.MobileNumberCssClass = Request.QueryString["mobile_number_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}