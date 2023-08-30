
namespace Elanat
{
    public class CurrentClientObjectClass
    {
        private ISession TmpSession;
        public CurrentClientObjectClass()
        {
            TmpSession = new HttpContextAccessor().HttpContext.Session;

            if (string.IsNullOrEmpty(RoleDominantType))
            {
                RoleDominantType = "guest";

                FillGuestClientSetting();
            }
        }

        public void FillGuestClientSetting()
        {
            // Set JavaScript Value
            if (string.IsNullOrEmpty(TmpSession.GetString("el_current_client:java_script_active")))
                JavaScriptIsActive = true;
            else
                JavaScriptIsActive = (TmpSession.GetString("el_current_client:java_script_active") == "true");


            // Set User Value
            UserId = "0";
            UserName = "guest";
            UserSiteName = "guest";

            // Set Process Keeper
            ProcessKeeper.ClientIpIsSecure = "unset";
            ProcessKeeper.ClientRobotIpIsBlocked = "false";

            // Set Robot Detection Request Count
            RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "count").ToNumber();
            RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "after_show_captcha_count").ToNumber();
            RobotDetectionDateTimeLong = DateAndTime.GetDateAndTimeLong();

            // Set Group Value
            GroupName = StaticObject.GuestGroup;
            DataUse.Group dug = new DataUse.Group();

            try
            {
                GroupId = dug.GetGroupIdByGroupName(GroupName);
            }
            catch (Exception ex)
            {
                return;
            }


            // Set Role Value
            SetValueToRoleList(dug.GetRoleIdAndNameByGroupId(GroupId));


            // Set Dominant Role Type
            RoleDominantType = dug.GetDominantRoleType(GroupId);


            // Set Captcha Release Count
            CaptchaReleaseCount = ElanatConfig.GetElanatConfig("security/captcha_guest_release_count", 0, "value").ToNumber();


            // Create Session Data File
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
                File.Create(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")).Close();


            Security sc = new Security();
            IpSessionCount = sc.GetIpSessionCount();


            // Set Process Keeper
            RobotIpBlock rib = new RobotIpBlock();
            ProcessKeeper.ClientRobotIpIsBlocked = rib.RobotIpIsBlocked().BooleanToTrueFalse();


            // Set Site Value
            SiteSiteGlobalName = StaticObject.DefaultSite;
            DataUse.Site dus = new DataUse.Site();
            SiteId = dus.GetSiteIdBySiteGlobalName(SiteSiteGlobalName);


            // Set Language Value
            SiteLanguageGlobalName = StaticObject.DefaultSiteLanguage;
            DataUse.Language dul = new DataUse.Language();
            SiteLanguageId = dul.GetLanguageIdByLanguageGlobalName(SiteLanguageGlobalName);
            dul.FillCurrentLanguage(SiteLanguageId);
            SiteLanguageIsRightToLeft = dul.LanguageIsRightToLeft;

            AdminLanguageGlobalName = SiteLanguageGlobalName;
            AdminLanguageId = SiteLanguageId;
            AdminLanguageIsRightToLeft = SiteLanguageIsRightToLeft;


            // Set Date And Time Value
            Calendar = StaticObject.DefaultSiteCalendar;
            DayDifference = StaticObject.DefaultDayDifference;
            DateFormat = StaticObject.DefaultDateFormat;
            TimeFormat = StaticObject.DefaulttimeFormat;
            FirstDayOfWeek = StaticObject.DefaultFirstDayOfWeek;
            TimeHoursDifference = StaticObject.DefaultTimeDifferenceHours;
            TimeMinutesDifference = StaticObject.DefaultTimeDifferenceMinutes;
            TimeZone = StaticObject.DefaultTimeZone;


            // Set Site Style Value
            string ElanatStyle = StaticObject.DefaultSiteStyle;
            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            SiteStyleId = duss.GetSiteStyleIdBySiteStyleName(ElanatStyle);
            SiteStylePhysicalPath = duss.GetStylePhysicalPath(SiteStyleId);


            // Set Site Template Value
            string ElanatTemplate = StaticObject.DefaultSiteTemplate;
            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
            SiteTemplateId = dust.GetSiteTemplateIdBySiteTemplateName(ElanatTemplate);
            SiteTemplatePhysicalPath = dust.GetTemplatePhysicalPath(SiteTemplateId);

            // Increase Visit Statistics
            if (StaticObject.RoleSubmitVisitCheck())
            {
                DataUse.VisitStatistics duvs = new DataUse.VisitStatistics();
                duvs.IncreaseVisit();
            }
        }

        public void FillUserClientSetting(string UserId, bool FillAdminLanguage = true)
        {           
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_setting", "@user_id", UserId);

            dbdr.dr.Read();

            // Set Site Value
            SiteSiteGlobalName = StaticObject.DefaultSite;
            DataUse.Site dus = new DataUse.Site();
            SiteId = dus.GetSiteIdBySiteGlobalName(SiteSiteGlobalName);


            // Set Language Value
            if (dbdr.dr["site_language_id"].ToString() != "0")
            {
                SiteLanguageGlobalName = dbdr.dr["site_language_global_name"].ToString();
                SiteLanguageId = dbdr.dr["site_language_id"].ToString();

                DataUse.Language dul = new DataUse.Language();
                dul.FillCurrentLanguage(SiteLanguageId);
                SiteLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            }

            if (dbdr.dr["admin_language_id"].ToString() != "0" && FillAdminLanguage)
            {
                AdminLanguageGlobalName = dbdr.dr["admin_language_global_name"].ToString();
                AdminLanguageId = dbdr.dr["admin_language_id"].ToString();

                DataUse.Language dul = new DataUse.Language();
                dul.FillCurrentLanguage(AdminLanguageId);
                AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            }


            // Set Date And Time Value
            if (!string.IsNullOrEmpty(dbdr.dr["user_calendar"].ToString()))
                Calendar = dbdr.dr["user_calendar"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_day_difference"].ToString()))
                DayDifference = dbdr.dr["user_day_difference"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_date_format"].ToString()))
                DateFormat = dbdr.dr["user_date_format"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_first_day_of_week"].ToString()))
                FirstDayOfWeek = dbdr.dr["user_first_day_of_week"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_time_format"].ToString()))
                TimeFormat = dbdr.dr["user_time_format"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_time_hours_difference"].ToString()))
                TimeHoursDifference = dbdr.dr["user_time_hours_difference"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_time_minutes_difference"].ToString()))
                TimeMinutesDifference = dbdr.dr["user_time_minutes_difference"].ToString();

            if (!string.IsNullOrEmpty(dbdr.dr["user_time_zone"].ToString()))
                TimeZone = dbdr.dr["user_time_zone"].ToString();


            // Set Site Style Value
            if (dbdr.dr["site_style_id"].ToString() != "0")
            {
                DataUse.SiteStyle duss = new DataUse.SiteStyle();
                SiteStyleId = dbdr.dr["site_style_id"].ToString();
                SiteStylePhysicalPath = duss.GetStylePhysicalPath(SiteStyleId);
            }


            // Set Site Template Value
            if (dbdr.dr["site_template_id"].ToString() != "0")
            {
                DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
                SiteTemplateId = dbdr.dr["site_template_id"].ToString();
                SiteTemplatePhysicalPath = dust.GetTemplatePhysicalPath(SiteTemplateId);
            }


            // Set Admin Style Value
            if (dbdr.dr["admin_style_id"].ToString() != "0")
            {
                DataUse.AdminStyle duas = new DataUse.AdminStyle();
                AdminStyleId = dbdr.dr["admin_style_id"].ToString();
                AdminStylePhysicalPath = duas.GetStylePhysicalPath(AdminStyleId);
            }


            // Set Admin Template Value
            if (dbdr.dr["admin_template_id"].ToString() != "0")
            {
                DataUse.AdminTemplate duat = new DataUse.AdminTemplate();
                AdminTemplateId = dbdr.dr["admin_template_id"].ToString();
                AdminTemplatePhysicalPath = duat.GetTemplatePhysicalPath(AdminTemplateId);
            }


            // Set Group Value
            GroupName = dbdr.dr["group_name"].ToString();
            GroupId = dbdr.dr["group_id"].ToString();


            // Set Role Value
            DataUse.Group dug = new DataUse.Group();
            SetValueToRoleList(dug.GetRoleIdAndNameByGroupId(GroupId));


            // Set Dominant Role Type
            RoleDominantType = dug.GetDominantRoleType(GroupId);


            // Set Captcha Release Count
            switch (RoleDominantType)
            {
                case "admin": CaptchaReleaseCount = ElanatConfig.GetElanatConfig("security/captcha_admin_release_count", 0, "value").ToNumber(); break;
                case "member": CaptchaReleaseCount = ElanatConfig.GetElanatConfig("security/captcha_member_release_count", 0, "value").ToNumber(); break;
                case "guest": CaptchaReleaseCount = ElanatConfig.GetElanatConfig("security/captcha_guest_release_count", 0, "value").ToNumber(); break;
            }


            // Set Robot Detection Request Count
            switch (RoleDominantType)
            {
                case "admin":
                    RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "count").ToNumber();
                    RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "member":
                    RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "count").ToNumber();
                    RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "guest":
                    RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "count").ToNumber();
                    RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "after_show_captcha_count").ToNumber();
                    break;
            }
            RobotDetectionDateTimeLong = DateAndTime.GetDateAndTimeLong();


            Security sc = new Security();
            IpSessionCount = sc.GetIpSessionCount();


            // Set Process Keeper
            ProcessKeeper.ClientIpIsSecure = "unset";

            RobotIpBlock rib = new RobotIpBlock();
            ProcessKeeper.ClientRobotIpIsBlocked = rib.RobotIpIsBlocked().BooleanToTrueFalse();


            // Set User Value
            this.UserId = dbdr.dr["user_id"].ToString();
            UserName = dbdr.dr["user_name"].ToString();
            UserSiteName = dbdr.dr["user_site_name"].ToString();


            // Set User Online
            StaticObject.ApplicationData.Add(new ListItem("el_user_" + dbdr.dr["user_id"].ToString() + ":online", "1"));


            db.Close();
        }

        public void SetSiteLanguage(string GlobalLanguage)
        {
            if (SiteLanguageGlobalName == GlobalLanguage)
                return;

            DataUse.Language dul = new DataUse.Language();
            string LanguageId = dul.GetLanguageIdByLanguageGlobalName(GlobalLanguage);

            if (string.IsNullOrEmpty(LanguageId))
                return;

            dul.FillCurrentLanguage(LanguageId);

            if (!dul.LanguageActive.ZeroOneToBoolean())
                return;

            dul.FillCurrentLanguage(LanguageId);
            SiteLanguageId = LanguageId;
            SiteLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            SiteLanguageGlobalName = dul.LanguageGlobalName;
        }

        public void SetAdminLanguage(string GlobalLanguage)
        {
            if (AdminLanguageGlobalName == GlobalLanguage)
                return;

            DataUse.Language dul = new DataUse.Language();
            string LanguageId = dul.GetLanguageIdByLanguageGlobalName(GlobalLanguage);

            if (string.IsNullOrEmpty(LanguageId))
                return;

            dul.FillCurrentLanguage(LanguageId);

            if (!dul.LanguageActive.ZeroOneToBoolean())
                return;

            dul.FillCurrentLanguage(LanguageId);
            AdminLanguageId = LanguageId;
            AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            AdminLanguageGlobalName = dul.LanguageGlobalName;
        }

        public void SetLanguage(string LanguageId)
        {
            if (SiteLanguageGlobalName == LanguageId && AdminLanguageGlobalName == LanguageId)
                return;

            if (string.IsNullOrEmpty(LanguageId))
                return;

            DataUse.Language dul = new DataUse.Language();
            dul.FillCurrentLanguage(LanguageId);
            SiteLanguageId = AdminLanguageId = LanguageId;
            SiteLanguageIsRightToLeft = AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;
            SiteLanguageGlobalName = AdminLanguageGlobalName = dul.LanguageGlobalName;
        }

        public void SetSite(string SiteGlobalName)
        {
            if (SiteSiteGlobalName == SiteGlobalName)
                return;

            DataUse.Site dus = new DataUse.Site();
            string SiteId = dus.GetSiteIdBySiteGlobalName(SiteGlobalName);

            if (string.IsNullOrEmpty(SiteId))
                return;

            dus.FillCurrentSite(SiteId);
            this.SiteId = SiteId;
            SiteSiteGlobalName = dus.SiteGlobalName;

            if (dus.LanguageId != "0")
                SetLanguage(dus.LanguageId);
        }

        public string GetCurrentClientDateAndTime(string DateAndTime)
        {
            DateTime dt = Convert.ToDateTime(DateAndTime);
            dt = dt.AddHours(Convert.ToDouble(TimeZone));
            dt = dt.AddHours(Convert.ToInt32(TimeHoursDifference));
            dt = dt.AddMinutes(Convert.ToInt32(TimeMinutesDifference));
            dt = dt.AddDays(Convert.ToInt32(DayDifference));
            dt = dt.AddHours(Convert.ToDouble(TimeZone));
            dt = dt.AddHours(Convert.ToInt32(TimeHoursDifference));
            dt = dt.AddMinutes(Convert.ToInt32(TimeMinutesDifference));

            DateAndTime dat = new DateAndTime();

            string TmpCalendar = dat.GetLocalDate(Calendar, string.Format("{0:yyyy/MM/dd}", dt));

            string TmpDateFormat = (string.IsNullOrEmpty(DateFormat)) ? "{0:" + StaticObject.DefaultDateFormat + "}" : "{0:" + DateFormat + "}";

            string TmpTimeFormat = (string.IsNullOrEmpty(TimeFormat)) ? "{0:" + StaticObject.DefaulttimeFormat + "}" : "{0:" + TimeFormat + "}";

            if (DateFormat == "tuning" && dt.HasTuning())
                return dt.ToDateAndTimeTuning(StaticObject.GetCurrentSiteGlobalLanguage());

            return string.Format(TmpDateFormat, TmpCalendar) + " " + string.Format(TmpTimeFormat, dt);
        }

        public string GetCurrentClientTime(string Time)
        {
            DateTime dt = (Time.Length == 8) ? Convert.ToDateTime(DateAndTime.GetDate("yyyy/MM/dd") + " " + Time) : Convert.ToDateTime(Time);
            dt = dt.AddHours(Convert.ToDouble(TimeZone));
            dt = dt.AddHours(Convert.ToInt32(TimeHoursDifference));
            dt = dt.AddMinutes(Convert.ToInt32(TimeMinutesDifference));

            string TmpTimeFormat = (string.IsNullOrEmpty(TimeFormat)) ? "{0:" + StaticObject.DefaulttimeFormat + "}" : "{0:" + TimeFormat + "}";

            if (TimeFormat == "tuning" && dt.HasTuning())
                return dt.ToDateAndTimeTuning(StaticObject.GetCurrentSiteGlobalLanguage(), "time");

            return string.Format(TmpTimeFormat, dt);
        }

        public string GetCurrentClientDate(string Date)
        {
            DateTime dt = (Date.Length == 10) ? Convert.ToDateTime(Date + " " + DateAndTime.GetTime("HH:mm:ss")) : Convert.ToDateTime(Date);
            dt = dt.AddHours(Convert.ToDouble(TimeZone));
            dt = dt.AddHours(Convert.ToInt32(TimeHoursDifference));
            dt = dt.AddMinutes(Convert.ToInt32(TimeMinutesDifference));
            dt = dt.AddDays(Convert.ToInt32(DayDifference));

            DateAndTime dat = new DateAndTime();

            string TmpCalendar = dat.GetLocalDate(Calendar, string.Format("{0:yyyy/MM/dd}", dt));

            string TmpDateFormat = (string.IsNullOrEmpty(DateFormat)) ? "{0:" + StaticObject.DefaultDateFormat + "}" : "{0:" + DateFormat + "}";

            if (DateFormat == "tuning" && dt.HasTuning())
                return dt.ToDateAndTimeTuning(StaticObject.GetCurrentSiteGlobalLanguage(), "date");

            if (TmpDateFormat == "{0:tuning}")
                TmpDateFormat = "{0:yyyy/MM/dd}";

            return string.Format(TmpDateFormat.Replace("/", "'/'"), Convert.ToDateTime(TmpCalendar));
        }

        public void SetValueToRoleList(List<ListItem> NameValue)
        {
            // If Connection Does Not Attach To DataBase, Below Line Code Does Not Work And Error Occur
            RoleIdList = "";
            RoleNameList = "";

            foreach (ListItem item in NameValue)
            {
                RoleIdList += item.Text + '$';
                RoleNameList += item.Text + '$';
            }

            RoleIdList.Remove(RoleIdList.Length - 1, 1);
            RoleNameList.Remove(RoleNameList.Length - 1, 1);
        }

        public List<string> GetRoleNameList()
        {
            return RoleNameList.Split('$').ToList();
        }

        public List<string> GetRoleIdList()
        {
            return RoleNameList.Split('$').ToList();
        }

        public void KeepUserOnlie(string UserId)
        {
            // Set Current Client Object
            FillUserClientSetting(UserId, false);

            StaticObject.OnlineUser++;

            // Set Secure Value
            Security sc = new Security();
            sc.SetUserLogin();
        }

        public string SiteId
        {
            get { return (TmpSession.GetString("el_current_client:site_id") != null) ? TmpSession.GetString("el_current_client:site_id") : "0"; }
            set { TmpSession.SetString("el_current_client:site_id", value); }
        }

        public string SiteSiteGlobalName
        {
            get { return (TmpSession.GetString("el_current_client:site_site_global_name") != null) ? TmpSession.GetString("el_current_client:site_site_global_name") : null; }
            set { TmpSession.SetString("el_current_client:site_site_global_name", value); }
        }

        public string GroupId
        {
            get { return (TmpSession.GetString("el_current_client:group_id") != null) ? TmpSession.GetString("el_current_client:group_id") : "0"; }
            set { TmpSession.SetString("el_current_client:group_id", value); }
        }

        public string GroupName
        {
            get { return (TmpSession.GetString("el_current_client:group_name") != null) ? TmpSession.GetString("el_current_client:group_name") : null; }
            set { TmpSession.SetString("el_current_client:group_name", value); }
        }

        public string UserId
        {
            get { return (TmpSession.GetString("el_current_client:user_id") != null) ? TmpSession.GetString("el_current_client:user_id") : "0"; }
            set { TmpSession.SetString("el_current_client:user_id", value); }
        }

        public string UserName
        {
            get { return (TmpSession.GetString("el_current_client:user_name") != null) ? TmpSession.GetString("el_current_client:user_name") : null; }
            set { TmpSession.SetString("el_current_client:user_name", value); }
        }

        public string UserSiteName
        {
            get { return (TmpSession.GetString("el_current_client:user_site_name") != null) ? TmpSession.GetString("el_current_client:user_site_name") : null; }
            set { TmpSession.SetString("el_current_client:user_site_name", value); }
        }

        /// <summary>
        /// RoleDominantType: guest, member, admin
        /// </summary>
        public string RoleDominantType
        {
            get { return (TmpSession.GetString("el_current_client:role_dominant_type") != null) ? TmpSession.GetString("el_current_client:role_dominant_type") : null; }
            set { TmpSession.SetString("el_current_client:role_dominant_type", value); }
        }

        private string RoleIdList
        {
            get { return (TmpSession.GetString("el_current_client:role_id_list") != null) ? TmpSession.GetString("el_current_client:role_id_list") : null; }
            set { TmpSession.SetString("el_current_client:role_id_list", value); }
        }

        private string RoleNameList
        {
            get { return (TmpSession.GetString("el_current_client:role_name_list") != null) ? TmpSession.GetString("el_current_client:role_name_list") : null; }
            set { TmpSession.SetString("el_current_client:role_name_list", value); }
        }

        public bool JavaScriptIsActive
        {
            get { return (TmpSession.GetString("el_current_client:java_script_active") != null) ? (TmpSession.GetString("el_current_client:java_script_active") == "1") : false; }
            set { TmpSession.SetString("el_current_client:java_script_active", value.BooleanToZeroOne()); }
        }

        public string SiteLanguageId
        {
            get { return (TmpSession.GetString("el_current_client:site_language_id") != null) ? TmpSession.GetString("el_current_client:site_language_id") : "0"; }
            set { TmpSession.SetString("el_current_client:site_language_id", value); }
        }

        public string SiteLanguageGlobalName
        {
            get { return (TmpSession.GetString("el_current_client:site_language_global_name") != null) ? TmpSession.GetString("el_current_client:site_language_global_name") : null; }
            set { TmpSession.SetString("el_current_client:site_language_global_name", value); }
        }

        public string SiteLanguageIsRightToLeft
        {
            get { return (TmpSession.GetString("el_current_client:site_language_is_right_to_left") != null) ? TmpSession.GetString("el_current_client:site_language_is_right_to_left") : null; }
            set { TmpSession.SetString("el_current_client:site_language_is_right_to_left", value); }
        }

        public string AdminLanguageId
        {
            get { return (TmpSession.GetString("el_current_client:admin_language_id") != null) ? TmpSession.GetString("el_current_client:admin_language_id") : "0"; }
            set { TmpSession.SetString("el_current_client:admin_language_id", value); }
        }

        public string AdminLanguageGlobalName
        {
            get { return (TmpSession.GetString("el_current_client:admin_language_global_name") != null) ? TmpSession.GetString("el_current_client:admin_language_global_name") : null; }
            set { TmpSession.SetString("el_current_client:admin_language_global_name", value); }
        }

        public string AdminLanguageIsRightToLeft
        {
            get { return (TmpSession.GetString("el_current_client:admin_language_is_right_to_left") != null) ? TmpSession.GetString("el_current_client:admin_language_is_right_to_left") : null; }
            set { TmpSession.SetString("el_current_client:admin_language_is_right_to_left", value); }
        }

        public string SiteTemplateId
        {
            get { return (TmpSession.GetString("el_current_client:site_template_id") != null) ? TmpSession.GetString("el_current_client:site_template_id") : "0"; }
            set { TmpSession.SetString("el_current_client:site_template_id", value); }
        }

        public string SiteTemplatePhysicalPath
        {
            get { return (TmpSession.GetString("el_current_client:site_template_physical_path") != null) ? TmpSession.GetString("el_current_client:site_template_physical_path") : null; }
            set { TmpSession.SetString("el_current_client:site_template_physical_path", value); }
        }

        public string AdminTemplateId
        {
            get { return (TmpSession.GetString("el_current_client:admin_template_id") != null) ? TmpSession.GetString("el_current_client:admin_template_id") : "0"; }
            set { TmpSession.SetString("el_current_client:admin_template_id", value); }
        }

        public string AdminTemplatePhysicalPath
        {
            get { return (TmpSession.GetString("el_current_client:admin_template_physical_path") != null) ? TmpSession.GetString("el_current_client:admin_template_physical_path") : null; }
            set { TmpSession.SetString("el_current_client:admin_template_physical_path", value); }
        }

        public string SiteStyleId
        {
            get { return (TmpSession.GetString("el_current_client:site_style_id") != null) ? TmpSession.GetString("el_current_client:site_style_id") : "0"; }
            set { TmpSession.SetString("el_current_client:site_style_id", value); }
        }

        public string SiteStylePhysicalPath
        {
            get { return (TmpSession.GetString("el_current_client:site_style_physical_path") != null) ? TmpSession.GetString("el_current_client:site_style_physical_path") : null; }
            set { TmpSession.SetString("el_current_client:site_style_physical_path", value); }
        }

        public string AdminStyleId
        {
            get { return (TmpSession.GetString("el_current_client:admin_style_id") != null) ? TmpSession.GetString("el_current_client:admin_style_id") : "0"; }
            set { TmpSession.SetString("el_current_client:admin_style_id", value); }
        }

        public string AdminStylePhysicalPath
        {
            get { return (TmpSession.GetString("el_current_client:admin_style_physical_path") != null) ? TmpSession.GetString("el_current_client:admin_style_physical_path") : null; }
            set { TmpSession.SetString("el_current_client:admin_style_physical_path", value); }
        }

        public string Calendar
        {
            get { return (TmpSession.GetString("el_current_client:calendar") != null) ? TmpSession.GetString("el_current_client:calendar") : null; }
            set { TmpSession.SetString("el_current_client:calendar", value); }
        }

        // First Day Of Week
        public string FirstDayOfWeek
        {
            get { return (TmpSession.GetString("el_current_client:first_day_of_week") != null) ? TmpSession.GetString("el_current_client:first_day_of_week") : null; }
            set { TmpSession.SetString("el_current_client:first_day_of_week", value); }
        }

        public string TimeZone
        {
            get { return (TmpSession.GetString("el_current_client:time_zone") != null) ? TmpSession.GetString("el_current_client:time_zone") : null; }
            set { TmpSession.SetString("el_current_client:time_zone", value); }
        }

        public string DateFormat
        {
            get { return (TmpSession.GetString("el_current_client:date_format") != null) ? TmpSession.GetString("el_current_client:date_format") : null; }
            set { TmpSession.SetString("el_current_client:date_format", value); }
        }

        public string TimeFormat
        {
            get { return (TmpSession.GetString("el_current_client:time_format") != null) ? TmpSession.GetString("el_current_client:time_format") : null; }
            set { TmpSession.SetString("el_current_client:time_format", value); }
        }

        public string DayDifference
        {
            get { return (TmpSession.GetString("el_current_client:day_difference") != null) ? TmpSession.GetString("el_current_client:day_difference") : null; }
            set { TmpSession.SetString("el_current_client:day_difference", value); }
        }

        public string TimeHoursDifference
        {
            get { return (TmpSession.GetString("el_current_client:time_hours_difference") != null) ? TmpSession.GetString("el_current_client:time_hours_difference") : null; }
            set { TmpSession.SetString("el_current_client:time_hours_difference", value); }
        }

        public string TimeMinutesDifference
        {
            get { return (TmpSession.GetString("el_current_client:time_minutes_difference") != null) ? TmpSession.GetString("el_current_client:time_minutes_difference") : null; }
            set { TmpSession.SetString("el_current_client:time_minutes_difference", value); }
        }

        public int CaptchaReleaseCount
        {
            get { return (TmpSession.GetString("el_current_client:captcha_release_count") != null) ? TmpSession.GetString("el_current_client:captcha_release_count").ToNumber() : 0; }
            set { TmpSession.SetString("el_current_client:captcha_release_count", value.ToString()); }
        }

        public int RobotDetectionRequestCount
        {
            get { return (TmpSession.GetString("el_current_client:robot_detection_request") != null) ? TmpSession.GetString("el_current_client:robot_detection_request").ToNumber() : 0; }
            set { TmpSession.SetString("el_current_client:robot_detection_request", value.ToString()); }
        }

        public int RobotDetectionRequestAfterShowCaptchaCount
        {
            get { return (TmpSession.GetString("el_current_client:robot_detection_request_after_show_captcha") != null) ? TmpSession.GetString("el_current_client:robot_detection_request_after_show_captcha").ToNumber() : 0; }
            set { TmpSession.SetString("el_current_client:robot_detection_request_after_show_captcha", value.ToString()); }
        }
       
        public long RobotDetectionDateTimeLong
        {
            get { return (TmpSession.GetString("el_current_client:robot_detection_date_time_long") != null) ? long.Parse(TmpSession.GetString("el_current_client:robot_detection_date_time_long")) : DateAndTime.GetDateAndTimeLong(); }
            set { TmpSession.SetString("el_current_client:robot_detection_date_time_long", value.ToString()); }
        }

        public int IpSessionCount
        {
            get { return (TmpSession.GetString("el_current_client:ip_session_count") != null) ? int.Parse(TmpSession.GetString("el_current_client:ip_session_count")) : 1; }
            set { TmpSession.SetString("el_current_client:ip_session_count", value.ToString()); }
        }
    }
}