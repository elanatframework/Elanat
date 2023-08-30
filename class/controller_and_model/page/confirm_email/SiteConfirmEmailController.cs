using CodeBehind;

namespace Elanat
{
    public partial class SiteConfirmEmailController : CodeBehindController
    {
        public SiteConfirmEmailModel model = new SiteConfirmEmailModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_GetEmailConfirm"]))
            {
                btn_GetEmailConfirm_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_GetEmailConfirm_Click(HttpContext context)
        {
            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];
            model.UserNameOrUserEmailValue = context.Request.Form["txt_UserNameOrUserEmail"];

            model.GetEmailConfirm();

            View(model);
        }
    }
}