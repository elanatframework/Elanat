using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class MemberChangeLanguageModel
    {
        public string ChangeLanguageLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UserSiteLanguageLanguage { get; set; }
        public string UserAdminLanguageLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        
        public string SiteLanguageOptionListValue { get; set; }
        public string AdminLanguageOptionListValue { get; set; }
        public string SiteLanguageOptionListSelectedValue { get; set; }
        public string AdminLanguageOptionListSelectedValue { get; set; }

        public string UserSiteLanguageAttribute { get; set; }
        public string UserAdminLanguageAttribute { get; set; }

        public string UserSiteLanguageCssClass { get; set; }
        public string UserAdminLanguageCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_options/change_language/");
            MemberLanguage = aol.GetAddOnsLanguage("member");
            ChangeLanguageLanguage = aol.GetAddOnsLanguage("change_language");
            UserSiteLanguageLanguage = aol.GetAddOnsLanguage("user_site_language");
            UserAdminLanguageLanguage = aol.GetAddOnsLanguage("user_admin_language");


            // Set User Info
            if (IsFirstStart)
            {
                DataBaseSocket db = new DataBaseSocket();

                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                DataBaseDataReader dbdr = new DataBaseDataReader();
			    dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);
                if (dbdr.dr != null && dbdr.dr.HasRows)
                    dbdr.dr.Read();

                SiteLanguageOptionListSelectedValue = dbdr.dr["site_language_id"].ToString();
                AdminLanguageOptionListSelectedValue = dbdr.dr["admin_language_id"].ToString();

                db.Close();
            }

            ListClass lc = new ListClass();

            // Set User Language Item
            lc.FillLanguageListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            SiteLanguageOptionListValue += SiteLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteLanguageOptionListValue += lc.LanguageListItem.HtmlInputToOptionTag(SiteLanguageOptionListSelectedValue);
            AdminLanguageOptionListValue += AdminLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminLanguageOptionListValue += lc.LanguageListItem.HtmlInputToOptionTag(AdminLanguageOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_UserSiteLanguage", SiteLanguageOptionListValue);
            InputRequest.Add("ddlst_UserAdminLanguage", AdminLanguageOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/member/change_options/change_language/");


            UserSiteLanguageAttribute += vc.ImportantInputAttribute["ddlst_UserSiteLanguage"];
            UserAdminLanguageAttribute += vc.ImportantInputAttribute["ddlst_UserAdminLanguage"];

            UserSiteLanguageCssClass = UserSiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserSiteLanguage"]);
            UserAdminLanguageCssClass = UserAdminLanguageCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserAdminLanguage"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/member/change_options/change_language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentSiteGlobalLanguage(), "problem");

                //UserSiteLanguageCssClass = UserSiteLanguageCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserSiteLanguage"]);
                //UserAdminLanguageCssClass = UserAdminLanguageCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserAdminLanguage"]);
            }
        }

        public void ChangeLanguage()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.User dur = new DataUse.User();
            dur.ChangeUserLanguage(ccoc.UserId, SiteLanguageOptionListSelectedValue, AdminLanguageOptionListSelectedValue);


            // Set Run Time Update
            if (SiteLanguageOptionListSelectedValue != "0")
                ccoc.SiteLanguageId = SiteLanguageOptionListSelectedValue;

            if (AdminLanguageOptionListSelectedValue != "0")
                ccoc.AdminLanguageId = AdminLanguageOptionListSelectedValue;

            DataUse.Language dul = new DataUse.Language();

            if (SiteLanguageOptionListSelectedValue != "0")
            {
                dul.FillCurrentLanguage(ccoc.SiteLanguageId);
                ccoc.SiteLanguageGlobalName = dul.LanguageGlobalName;
                ccoc.SiteLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            }

            if (AdminLanguageOptionListSelectedValue != "0")
            {
                dul.FillCurrentLanguage(ccoc.AdminLanguageId);
                ccoc.AdminLanguageGlobalName = dul.LanguageGlobalName;
                ccoc.AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_user_language", ccoc.UserId);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/member/change_options/change_language/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}