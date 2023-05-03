using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpUserName : System.Web.UI.Page
    {
        public SiteSignUpUserNameModel model = new SiteSignUpUserNameModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.UserNameValue = Request.QueryString["user_name_value"];
            model.UserNameCssClass = Request.QueryString["user_name_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}