using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentWebsite : System.Web.UI.Page
    {
        public SiteCommentWebsiteModel model = new SiteCommentWebsiteModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.WebsiteValue = Request.QueryString["website_value"];
            model.WebsiteCssClass = Request.QueryString["website_css_class"];
            model.WebsiteAttribute = Request.QueryString["website_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}