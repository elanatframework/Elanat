using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpPhoneNumber : System.Web.UI.Page
    {
        public SiteSignUpPhoneNumberModel model = new SiteSignUpPhoneNumberModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.PhoneNumberValue = Request.QueryString["phone_number_value"];
            model.PhoneNumberCssClass = Request.QueryString["phone_number_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}