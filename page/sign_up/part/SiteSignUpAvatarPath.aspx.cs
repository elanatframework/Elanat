using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpAvatarPath : System.Web.UI.Page
    {
        public SiteSignUpAvatarPathModel model = new SiteSignUpAvatarPathModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.AvatarPathTextValue = Request.QueryString["avatar_path_text_value"];


            model.SetValue();
        }
    }
}