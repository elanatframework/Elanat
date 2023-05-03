using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpAddress : System.Web.UI.Page
    {
        public SiteSignUpAddressModel model = new SiteSignUpAddressModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.AddressValue = Request.QueryString["address_value"];
            model.AddressCssClass= Request.QueryString["address_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}