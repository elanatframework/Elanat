using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentEmail : System.Web.UI.Page
    {
        public SiteCommentEmailModel model = new SiteCommentEmailModel();

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