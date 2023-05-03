using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactEmail : System.Web.UI.Page
    {
        public SiteContactEmailModel model = new SiteContactEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.EmailValue = Request.QueryString["email_value"];
            model.EmailCssClass = Request.QueryString["email_css_class"];
            model.EmailAttribute = Request.QueryString["email_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}