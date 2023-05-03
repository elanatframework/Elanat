using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteForgetPassword : System.Web.UI.Page
    {
        public SiteForgetPasswordModel model = new SiteForgetPasswordModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_GetNewPassword"]))
                btn_GetNewPassword_Click(sender, e);


            model.SetValue();
        }

        protected void btn_GetNewPassword_Click(object sender, EventArgs e)
        {
            model.CaptchaTextValue = Request.Form["txt_Captcha"];
            model.UserNameOrUserEmailValue = Request.Form["txt_UserNameOrUserEmail"];
            model.GetNewPassword();
        }
    }
}