using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpUserSiteName : System.Web.UI.Page
    {
        public SiteSignUpUserSiteNameModel model = new SiteSignUpUserSiteNameModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.UserSiteNameValue = Request.QueryString["user_site_name_value"];
            model.UserSiteNameCssClass = Request.QueryString["user_site_name_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}