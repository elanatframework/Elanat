using CodeBehind;
using Microsoft.AspNetCore.Http.Features;

namespace Elanat
{
    public partial class SiteLoginController : CodeBehindController
    {
        public SiteLoginModel model = new SiteLoginModel();

        public void PageLoad(HttpContext context)
        {
            // Login Redirect
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (ccoc.RoleDominantType == "member")
            {
                context.Response.Redirect(StaticObject.SitePath + "page_content/member/");

                IgnoreViewAndModel = true;

                return;
            }

            if (ccoc.RoleDominantType == "admin")
            {
                context.Response.Redirect(StaticObject.AdminPath + "/");

                IgnoreViewAndModel = true;

                return;
            }

            // Set Login Delay
            int LoginDelay = int.Parse(ElanatConfig.GetNode("delay/login").Attributes["value"].Value);
            Thread.Sleep(LoginDelay * 1000);

            if (!string.IsNullOrEmpty(context.Request.Form["btn_Login"]))
            {
                btn_Login_Click(context);

                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Query["el_return_url"]))
                model.ReturnUrlValue = context.Request.Query["el_return_url"];


            model.SetValue();

            View(model);
        }

        protected void btn_Login_Click(HttpContext context)
        {
            model.UserNameOrUserEmailValue = context.Request.Form["txt_UserNameOrUserEmail"];
            model.PasswordValue = context.Request.Form["txt_Password"];
            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];
            model.LanguageOptionSelectedListValue = context.Request.Form["ddlst_Language"];
            model.SecretKeyValue = context.Request.Form["txt_SecretKey"];
            model.ReturnUrlValue = context.Request.Form["hdn_ReturnUrl"];


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                Write(model.CaptchaIncorrectErrorView());
                IgnoreViewAndModel = true;

                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set User Admin Language
            DataUse.Language dul = new DataUse.Language();

            string CurrentLanguageId = model.LanguageOptionSelectedListValue;

            dul.FillCurrentLanguage(CurrentLanguageId);

            ccoc.AdminLanguageId = dul.LanguageId;
            ccoc.AdminLanguageGlobalName = dul.LanguageGlobalName;
            ccoc.AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;


            if (string.IsNullOrEmpty(model.UserNameOrUserEmailValue) || string.IsNullOrEmpty(model.PasswordValue))
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("you_should_fill_all_options", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }


            // Check Secret Key
            if (ElanatConfig.GetNode("security/use_secret_key_for_login").Attributes["active"].Value == "true")
                if (model.SecretKeyValue != Security.GetCodeIni("secret_key"))
                {
                    Write(GlobalClass.Alert(Language.GetAddOnsLanguage("you_should_fill_secret_key", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                    IgnoreViewAndModel = true;

                    return;
                }

            if (!Security.LoginActiveCheck())
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("login_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }

            Security se = new Security();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("user_login_check", new List<string>() { "@user_name_or_user_email", "@password" }, new List<string>() { model.UserNameOrUserEmailValue.ToLower(), se.GetHash(model.PasswordValue) });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();

                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("the_information_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }

            dbdr.dr.Read();

            string UserId = dbdr.dr["user_id"].ToString();

            db.Close();

            DataUse.User duu = new DataUse.User();
            duu.FillCurrentUser(UserId);

            if (string.IsNullOrEmpty(duu.UserId))
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("user_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }

            if (!duu.UserActive.ZeroOneToBoolean())
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("user_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }

            DataUse.Group dug = new DataUse.Group();
            if (!dug.GroupActiveCheck(duu.GroupId))
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("your_group_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }

            DataUse.Role dur = new DataUse.Role();
            if (!dur.RoleActiveCheckByGroupId(duu.GroupId))
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("your_role_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                IgnoreViewAndModel = true;

                return;
            }


            if (ElanatConfig.GetNode("security/registered_user_after_accept_active_email").Attributes["active"].Value == "true")
            {
                // If Email Is Not Confirmed
                if (!duu.UserEmailIsConfirm.ZeroOneToBoolean())
                {
                    Write(GlobalClass.Alert(Language.GetAddOnsLanguage("user_email_is_not_confirm", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem"));
                    IgnoreViewAndModel = true;

                    return;
                }
            }


            model.Login(UserId);


            model.SuccessView();

            View(model);
        }
    }
}