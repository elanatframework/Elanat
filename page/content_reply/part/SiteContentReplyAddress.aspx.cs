using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyAddress : System.Web.UI.Page
    {
        public SiteContentReplyAddressModel model = new SiteContentReplyAddressModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.AddressValue = Request.QueryString["address_value"];
            model.AddressCssClass = Request.QueryString["address_css_class"];
            model.AddressAttribute = Request.QueryString["address_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}