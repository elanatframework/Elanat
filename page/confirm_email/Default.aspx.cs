using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteConfirmEmail : System.Web.UI.Page
    {
        public SiteConfirmEmailModel model = new SiteConfirmEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_GetEmailConfirm"]))
                btn_GetEmailConfirm_Click(sender, e);


            model.SetValue();
        }

        protected void btn_GetEmailConfirm_Click(object sender, EventArgs e)
        {
            model.CaptchaTextValue = Request.Form["txt_Captcha"];
            model.UserNameOrUserEmailValue = Request.Form["txt_UserNameOrUserEmail"];
            model.GetEmailConfirm();
        }
    }
}