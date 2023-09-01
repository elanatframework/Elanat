using CodeBehind;
using SetCodeBehind;

namespace Elanat
{
    public partial class InstallModel : CodeBehindModel
    {
        public string InstallLanguage { get; set; }
        public string GoToLicenseLanguage { get; set; }
        public string GoToDataBaseLanguage { get; set; }
        public string GoToDateAndTimeLanguage { get; set; }
        public string GoToSiteLanguage { get; set; }
        public string GoToUserLanguage { get; set; }
        public string InstallCodeLanguage { get; set; }
        public string LicenseLanguage { get; set; }
        public string AgreeLicenseLanguage { get; set; }
        public string NextLanguage { get; set; }
        public string DataBaseLanguage { get; set; }
        public string PreviousLanguage { get; set; }
        public string DateAndTimeLanguage { get; set; }
        public string SiteTimeZoneLanguage { get; set; }
        public string SiteLanguage { get; set; }
        public string HostPathLanguage { get; set; }
        public string SiteNameLanguage { get; set; }
        public string SiteLanguageLanguage { get; set; }
        public string SiteEmailLanguage { get; set; }
        public string SiteTitleLanguage { get; set; }
        public string AdminUserLanguage { get; set; }
        public string UserSiteNameLanguage { get; set; }
        public string UserNameLanguage { get; set; }
        public string UserRealNameLanguage { get; set; }
        public string UserRealLastNameLanguage { get; set; }
        public string UserEmailLanguage { get; set; }
        public string RepeatUserEmailLanguage { get; set; }
        public string UserPasswordLanguage { get; set; }
        public string RepeatUserPasswordLanguage { get; set; }
        public string SubmitLanguage { get; set; }

        public string UpdateAlertValue { get; set; }

        public bool AgreeLicenseValue { get; set; } = false;

        public string LicenseValue { get; set; }

        public string InstallCodeValue { get; set; }
        public string HostPathValue { get; set; }
        public string SiteNameValue { get; set; }
        public string SiteEmailValue { get; set; }
        public string SiteTitleValue { get; set; }
        public string UserSiteNameValue { get; set; }
        public string UserNameValue { get; set; }
        public string UserRealNameValue { get; set; }
        public string UserRealLastNameValue { get; set; }
        public string UserEmailValue { get; set; }
        public string RepeatUserEmailValue { get; set; }
        public string UserPasswordValue { get; set; }
        public string RepeatUserPasswordValue { get; set; }

        public string InstallCodeAttribute { get; set; }
        public string HostPathAttribute { get; set; }
        public string SiteNameAttribute { get; set; }
        public string SiteEmailAttribute { get; set; }
        public string SiteTitleAttribute { get; set; }
        public string UserSiteNameAttribute { get; set; }
        public string UserNameAttribute { get; set; }
        public string UserRealNameAttribute { get; set; }
        public string UserRealLastNameAttribute { get; set; }
        public string UserEmailAttribute { get; set; }
        public string RepeatUserEmailAttribute { get; set; }
        public string UserPasswordAttribute { get; set; }
        public string RepeatUserPasswordAttribute { get; set; }
        public string SiteTimeZoneAttribute { get; set; }
        public string SiteLanguageAttribute { get; set; }

        public string InstallCodePanelCssClass { get; set; }
        public string UserPanelCssClass { get; set; }
        public string InstallCodeCssClass { get; set; }
        public string HostPathCssClass { get; set; }
        public string SiteNameCssClass { get; set; }
        public string SiteEmailCssClass { get; set; }
        public string SiteTitleCssClass { get; set; }
        public string UserSiteNameCssClass { get; set; }
        public string UserNameCssClass { get; set; }
        public string UserRealNameCssClass { get; set; }
        public string UserRealLastNameCssClass { get; set; }
        public string UserEmailCssClass { get; set; }
        public string RepeatUserEmailCssClass { get; set; }
        public string UserPasswordCssClass { get; set; }
        public string RepeatUserPasswordCssClass { get; set; }
        public string SiteTimeZoneCssClass { get; set; }
        public string SiteLanguageCssClass { get; set; }

        public string SiteLanguageOptionListValue{ get; set; }
        public string SiteLanguageOptionListSelectedValue { get; set; }
        public string SiteTimeZoneOptionListValue { get; set; }
        public string SiteTimeZoneOptionListSelectedValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/");
            InstallLanguage = aol.GetAddOnsLanguage("install");
            InstallCodeLanguage = aol.GetAddOnsLanguage("install_code");
            AdminUserLanguage = aol.GetAddOnsLanguage("admin_user");
            DataBaseLanguage = aol.GetAddOnsLanguage("database");
            DateAndTimeLanguage = aol.GetAddOnsLanguage("date_and_time");
            UserEmailLanguage = aol.GetAddOnsLanguage("user_email");
            HostPathLanguage = aol.GetAddOnsLanguage("host_path");
            UserRealLastNameLanguage = aol.GetAddOnsLanguage("user_real_last_name");
            LicenseLanguage = aol.GetAddOnsLanguage("license");
            UserRealNameLanguage = aol.GetAddOnsLanguage("user_real_name");
            UserPasswordLanguage = aol.GetAddOnsLanguage("user_password");
            RepeatUserEmailLanguage = aol.GetAddOnsLanguage("repeat_user_email");
            RepeatUserPasswordLanguage = aol.GetAddOnsLanguage("repeat_user_password");
            SiteLanguage = aol.GetAddOnsLanguage("site");
            SiteEmailLanguage = aol.GetAddOnsLanguage("site_email");
            SiteTitleLanguage = aol.GetAddOnsLanguage("site_title");
            SiteLanguageLanguage = aol.GetAddOnsLanguage("site_language");
            SiteNameLanguage = aol.GetAddOnsLanguage("site_name");
            SiteTimeZoneLanguage = aol.GetAddOnsLanguage("site_time_zone");
            UserNameLanguage = aol.GetAddOnsLanguage("user_name");
            UserSiteNameLanguage = aol.GetAddOnsLanguage("user_site_name");
            AgreeLicenseLanguage = aol.GetAddOnsLanguage("agree_license");
            GoToDateAndTimeLanguage = aol.GetAddOnsLanguage("go_to_date_and_time");
            GoToDataBaseLanguage = aol.GetAddOnsLanguage("go_to_database");
            GoToLicenseLanguage = aol.GetAddOnsLanguage("go_to_license");
            NextLanguage = aol.GetAddOnsLanguage("next");
            PreviousLanguage = aol.GetAddOnsLanguage("previous");
            GoToSiteLanguage = aol.GetAddOnsLanguage("go_to_site");
            GoToUserLanguage = aol.GetAddOnsLanguage("go_to_user");
            SubmitLanguage = aol.GetAddOnsLanguage("submit");


            // Set Host Path
            string PathBase = new HttpContextAccessor().HttpContext.Request.PathBase;
            HostPathValue = (string.IsNullOrEmpty(PathBase))? "/" : PathBase;


            // Set License
            LicenseValue = PageLoader.LoadWithText(StaticObject.SitePath + "App_Data/elanat_system_data/license/" + StaticObject.GetCurrentSiteGlobalLanguage() + "/license.txt");


            // Set Language Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillLanguageListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            SiteLanguageOptionListValue = SiteLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteLanguageOptionListValue += lcl.LanguageListItem.HtmlInputToOptionTag(SiteLanguageOptionListSelectedValue);

            // Set Time Zone Item
            ListClass.DateAndTime dat = new ListClass.DateAndTime();
            dat.FillTimeZoneListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteTimeZoneOptionListValue = SiteTimeZoneOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteTimeZoneOptionListValue += dat.TimeZoneListItem.HtmlInputToOptionTag(SiteTimeZoneOptionListSelectedValue);


            if (ElanatConfig.GetNode("elanat/install_code").Attributes["active"].Value != "true")
                InstallCodePanelCssClass = InstallCodePanelCssClass.AddHtmlClass(" el_hidden");

            UserPanelCssClass = UserPanelCssClass.AddHtmlClass(" el_hidden");

            // Check Elanat Last Version
            CheckLastVersion();
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_InstallCode", "");
            InputRequest.Add("ddlst_SiteTimeZone", SiteTimeZoneOptionListValue);
            InputRequest.Add("txt_HostPath", "");
            InputRequest.Add("txt_SiteName", "");
            InputRequest.Add("ddlst_SiteLanguage", SiteLanguageOptionListValue);
            InputRequest.Add("txt_SiteEmail", "");
            InputRequest.Add("txt_SiteTitle", "");
            InputRequest.Add("txt_UserSiteName", "");
            InputRequest.Add("txt_UserName", "");
            InputRequest.Add("txt_UserRealName", "");
            InputRequest.Add("txt_UserRealLastName", "");
            InputRequest.Add("txt_UserEmail", "");
            InputRequest.Add("txt_RepeatUserEmail", "");
            InputRequest.Add("txt_UserPassword", "");
            InputRequest.Add("txt_RepeatUserPassword", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "install/");

            InstallCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_InstallCode");
            HostPathAttribute += vc.ImportantInputAttribute.GetValue("txt_HostPath");
            SiteNameAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteName");
            SiteEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteEmail");
            SiteTitleAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteTitle");
            UserSiteNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserSiteName");
            UserNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserName");
            UserRealNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserRealName");
            UserRealLastNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserRealLastName");
            UserEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_UserEmail");
            RepeatUserEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatUserEmail");
            UserPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_UserPassword");
            RepeatUserPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatUserPassword");
            SiteTimeZoneAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteTimeZone");
            SiteLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteLanguage");

            InstallCodeCssClass = InstallCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_InstallCode"));
            HostPathCssClass = HostPathCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_HostPath"));
            SiteNameCssClass = SiteNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteName"));
            SiteEmailCssClass = SiteEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteEmail"));
            SiteTitleCssClass = SiteTitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteTitle"));
            UserSiteNameCssClass = UserSiteNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserSiteName"));
            UserNameCssClass = UserNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserName"));
            UserRealNameCssClass = UserRealNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserRealName"));
            UserRealLastNameCssClass = UserRealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserRealLastName"));
            UserEmailCssClass = UserEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserEmail"));
            RepeatUserEmailCssClass = RepeatUserEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatUserEmail"));
            UserPasswordCssClass = UserPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserPassword"));
            RepeatUserPasswordCssClass = RepeatUserPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatUserPassword"));
            SiteTimeZoneCssClass = SiteTimeZoneCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteTimeZone"));
            SiteLanguageCssClass = SiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteLanguage"));
    }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "install/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void Submit()
        {
            // Set Host Path
            ElanatConfig.SetElanatConfig(HostPathValue, "properties/site_path");


            // Set Site Data
            DataUse.Site dus = new DataUse.Site();

            dus.SiteTimeZone = SiteTimeZoneOptionListSelectedValue;
            dus.SiteName = SiteNameValue;
            dus.LanguageId = SiteLanguageOptionListSelectedValue;
            dus.SiteEmail = SiteEmailValue.ToLower();
            dus.SiteTitle = SiteTitleValue;
            dus.SiteDateCreate = DateAndTime.GetDate("yyyy/MM/dd");
            dus.SiteTimeCreate = DateAndTime.GetTime("HH:mm:ss");

            dus.InstallSite();


            // Set User Data
            DataUse.User duu = new DataUse.User();

            duu.UserSiteName = UserSiteNameValue;
            duu.UserName = UserNameValue;
            duu.UserRealName = UserRealNameValue;
            duu.UserRealLastName = UserRealLastNameValue;
            duu.UserEmail = UserEmailValue.ToLower();

            Security sc = new Security();
            duu.UserPassword = sc.GetHash(UserPasswordValue);

            duu.InstallUser();


            SetFirstTimeValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("installation_completed", UserNameValue);


            // Set Random Text To Install Code
            int NewRandomTextValueCount = int.Parse(ElanatConfig.GetNode("security/new_random_text_value_count").Attributes["value"].Value);
            StringClass strc = new StringClass();
            string rand = strc.GetCleanRandomText(NewRandomTextValueCount);

            ElanatConfig.SetElanatConfig(rand, "elanat/install_code", 0, "value");
            ElanatConfig.SetElanatConfig("true", "elanat/install_code", 0, "active");


            // Cut Install Directory
            if (ElanatConfig.GetNode("elanat/cut_install_directory_after_install").Attributes["active"].Value == "true")
            {
                DirectoryInfo dir = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "install/"));
                dir.MoveTo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/install"));


                // Recompile
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }
        }

        // Repeated In SetDataBaseModel Class
        public void SetFirstTimeValue()
        {
            // Set Site Birthday
            ElanatConfig.SetElanatConfig(DateAndTime.GetDate("yyyy/MM/dd"), "date_and_time/site_birthday");

            // Set Random String To Code Ini File
            StringClass sc = new StringClass();
            Security.SetCodeIni("lock_login_password_value", sc.GetCleanRandomText(32));
            Security.SetCodeIni("system_access_code", sc.GetCleanRandomText(32));
        }

        public void CheckLastVersion()
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/");

            string ElanatSystemPath = ElanatConfig.GetNode("elanat/site_address").InnerText;
            string ElanatSystemVersion = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            try
            {
                string ElanatLastVesrsion = PageLoader.LoadForeignPage(ElanatSystemPath + "/service/last_version/");
                if (int.Parse(ElanatLastVesrsion.Replace(".", "")) > int.Parse(ElanatSystemVersion.Replace(".", "")))
                    UpdateAlertValue = aol.GetAddOnsLanguage("you_are_trying_to_install_the_old_version_updates_in_elanat_is_hierarchical_and_if_you_do_not_install_the_latest_version_you_will_be_annoyed_by_successive_updates");
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
            }
        }

        public string SuccessView()
        {
            return PageLoader.LoadWithServer(StaticObject.SitePath + "install/action/SuccessMessage.aspx?use_retrieved=true");
        }
    }
}