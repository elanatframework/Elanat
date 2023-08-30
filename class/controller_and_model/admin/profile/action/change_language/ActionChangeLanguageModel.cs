using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeLanguageModel : CodeBehindModel
    {
        public string LanguageLanguage { get; set; }
        public string ChangeLanguageLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UserSiteLanguageLanguage { get; set; }
        public string UserAdminLanguageLanguage { get; set; }

        public string SiteLanguageOptionListValue { get; set; }
        public string AdminLanguageOptionListValue { get; set; }
        public string SiteLanguageOptionListSelectedValue { get; set; }
        public string AdminLanguageOptionListSelectedValue { get; set; }

        public string UserSiteLanguageAttribute { get; set; }
        public string UserAdminLanguageAttribute { get; set; }

        public string UserSiteLanguageCssClass { get; set; }
        public string UserAdminLanguageCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            LanguageLanguage = aol.GetAddOnsLanguage("language");
            ChangeLanguageLanguage = aol.GetAddOnsLanguage("change_language");
            UserSiteLanguageLanguage = aol.GetAddOnsLanguage("user_site_language");
            UserAdminLanguageLanguage = aol.GetAddOnsLanguage("user_admin_language");


            // Set User Info
            DataBaseSocket db = new DataBaseSocket();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);
            if (dbdr.dr != null && dbdr.dr.HasRows)
                dbdr.dr.Read();

            string UserSiteLanguageId = dbdr.dr["site_language_id"].ToString();
            string UserAdminLanguageId = dbdr.dr["admin_language_id"].ToString();

            db.Close();


            // Set User Language Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillLanguageListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteLanguageOptionListValue += SiteLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteLanguageOptionListValue += lcl.LanguageListItem.HtmlInputToOptionTag(UserSiteLanguageId);
            AdminLanguageOptionListValue += AdminLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminLanguageOptionListValue += lcl.LanguageListItem.HtmlInputToOptionTag(UserAdminLanguageId);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_UserSiteLanguage", SiteLanguageOptionListValue);
            InputRequest.Add("ddlst_UserAdminLanguage", AdminLanguageOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_language");


            UserSiteLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserSiteLanguage");
            UserAdminLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserAdminLanguage");

            UserSiteLanguageCssClass = UserSiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserSiteLanguage"));
            UserAdminLanguageCssClass = UserAdminLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserAdminLanguage"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_language", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_language/action/SuccessMessage.aspx", true);
        }
    }
}