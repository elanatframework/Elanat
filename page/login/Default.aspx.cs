using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace elanat
{
    public partial class SiteLogin : System.Web.UI.Page
    {
        public SiteLoginModel model = new SiteLoginModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Login Redirect
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (ccoc.RoleDominantType == "member")
                Response.Redirect(StaticObject.SitePath + "page_content/member/");

            if (ccoc.RoleDominantType == "admin")
                Response.Redirect(StaticObject.AdminPath);

            // Set Login Delay
            int LoginDelay = int.Parse(ElanatConfig.GetNode("delay/login").Attributes["value"].Value);
            System.Threading.Thread.Sleep(LoginDelay * 1000);


            if (!string.IsNullOrEmpty(Request.Form["btn_Login"]))
                btn_Login_Click(sender, e);


            if (!string.IsNullOrEmpty(Request.QueryString["el_return_url"]))
                model.ReturnUrlValue = Request.QueryString["el_return_url"];


            model.SetValue();
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            model.UserNameOrUserEmailValue = Request.Form["txt_UserNameOrUserEmail"];
            model.PasswordValue = Request.Form["txt_Password"];
            model.CaptchaTextValue = Request.Form["txt_Captcha"];
            model.LanguageOptionSelectedListValue = Request.Form["ddlst_Language"];
            model.SecretKeyValue = Request.Form["txt_SecretKey"];
            model.ReturnUrlValue = Request.Form["hdn_ReturnUrl"];


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
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


            if (string.IsNullOrEmpty(model.UserNameOrUserEmailValue) || string.IsNullOrEmpty(model.PasswordValue) || (ccoc.CaptchaReleaseCount == 0 && string.IsNullOrEmpty(model.CaptchaTextValue)))
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_fill_all_options", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");


            // Check Secret Key
            if (ElanatConfig.GetNode("security/use_secret_key_for_login").Attributes["active"].Value == "true")
                if (model.SecretKeyValue != Security.GetCodeIni("secret_key"))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_fill_secret_key", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");


            if (!Security.LoginActiveCheck())
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("login_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");


            Security se = new Security();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("user_login_check", new List<string>() { "@user_name_or_user_email", "@password" }, new List<string>() { model.UserNameOrUserEmailValue.ToLower(), se.GetHash(model.PasswordValue) });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_information_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");
            }

            dbdr.dr.Read();

            string UserId = dbdr.dr["user_id"].ToString();

            db.Close();

            DataUse.User duu = new DataUse.User();
            duu.FillCurrentUser(UserId);

            if (string.IsNullOrEmpty(duu.UserId))
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");

            if (!duu.UserActive.ZeroOneToBoolean())
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");

            DataUse.Group dug = new DataUse.Group();
            if (!dug.GroupActiveCheck(duu.GroupId))
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_group_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");

            DataUse.Role dur = new DataUse.Role();
            if (!dur.RoleActiveCheckByGroupId(duu.GroupId))
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_role_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");


            if (ElanatConfig.GetNode("security/registered_user_after_accept_active_email").Attributes["active"].Value == "true")
            {
                // If Email Is Not Confirmed
                if (!duu.UserEmailIsConfirm.ZeroOneToBoolean())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_email_is_not_confirm", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), "problem");
            }


            model.Login(UserId);


            model.SuccessView();
        }
    }
}