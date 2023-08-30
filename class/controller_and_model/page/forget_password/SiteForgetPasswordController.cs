using CodeBehind;

namespace Elanat
{
    public partial class SiteForgetPasswordController : CodeBehindController
    {
        public SiteForgetPasswordModel model = new SiteForgetPasswordModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_GetNewPassword"]))
            {
                btn_GetNewPassword_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_GetNewPassword_Click(HttpContext context)
        {
            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];
            model.UserNameOrUserEmailValue = context.Request.Form["txt_UserNameOrUserEmail"];

            model.GetNewPassword();

            View(model);
        }
    }
}