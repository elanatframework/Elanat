using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpPublicEmail : System.Web.UI.Page
    {
        public SiteSignUpPublicEmailModel model = new SiteSignUpPublicEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.PublicEmailValue = Request.QueryString["public_email_value"];
            model.PublicEmailCssClass = Request.QueryString["public_email_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}