using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentRealName : System.Web.UI.Page
    {
        public SiteCommentRealNameModel model = new SiteCommentRealNameModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.RealNameValue = Request.QueryString["real_name_value"];
            model.RealNameCssClass = Request.QueryString["real_name_css_class"];
            model.RealNameAttribute = Request.QueryString["real_name_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}