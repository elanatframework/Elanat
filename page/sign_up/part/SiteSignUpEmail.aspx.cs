using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpEmail : System.Web.UI.Page
    {
        public SiteSignUpEmailModel model = new SiteSignUpEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.EmailValue = Request.QueryString["email_value"];
            model.EmailCssClass = Request.QueryString["email_css_class"];
            model.RepeatEmailValue = Request.QueryString["repeat_email_value"];
            model.RepeatEmailCssClass = Request.QueryString["repeat_email_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}