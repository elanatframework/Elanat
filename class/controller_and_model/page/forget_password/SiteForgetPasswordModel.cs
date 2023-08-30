using CodeBehind;

namespace Elanat
{
    public partial class SiteForgetPasswordModel : CodeBehindModel
    {
        public string ForgetPasswordLanguage { get; set; }
        public string GetNewPasswordLanguage { get; set; }
        public string UserNameOrUserEmailLanguage { get; set; }

        public string UserNameOrUserEmailValue { get; set; }
        public string CaptchaTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/forget_password/");
            ForgetPasswordLanguage = aol.GetAddOnsLanguage("forget_password");
            UserNameOrUserEmailLanguage = aol.GetAddOnsLanguage("user_name_or_user_email");
            GetNewPasswordLanguage = aol.GetAddOnsLanguage("get_new_password");
        }

        public void GetNewPassword()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "action/get_new_password/?user_name_or_user_email=" + UserNameOrUserEmailValue + "&captcha=" + CaptchaTextValue + "&use_retrieved=true");
        }
    }
}