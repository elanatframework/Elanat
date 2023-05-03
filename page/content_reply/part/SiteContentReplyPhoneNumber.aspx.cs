using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyPhoneNumber : System.Web.UI.Page
    {
        public SiteContentReplyPhoneNumberModel model = new SiteContentReplyPhoneNumberModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.PhoneNumberValue = Request.QueryString["phone_number_value"];
            model.PhoneNumberCssClass = Request.QueryString["phone_number_css_class"];
            model.PhoneNumberAttribute = Request.QueryString["phone_number_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}