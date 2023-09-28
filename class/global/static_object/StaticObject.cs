using System.Xml;

namespace Elanat
{
    public class StaticObject
    {
        public static string ContentRootPath { get; private set; }
        public static List<ListItem> ApplicationData = new List<ListItem>();

        /// <summary>
        /// Do Not Change To True In Static Object Class
        /// </summary>
        public static bool ScheduledTasksHasABeenImplemented = false;
        public static bool StartUpHasABeenImplemented = false;

        // Relate Robot Detection
        public static List<string> IpSessionIndexerKeeperName;
        public static List<int> IpSessionIndexerKeeperValue;

        public static int OnlineUser = 0;
        public static string NullLanguageSuffix { get; private set; } = null ;
        public static string SitePath { get; private set; } = null;
        public static string SitePhysicalPath { get; private set; } = null;
        public static string AdminPath { get; private set; } = null;
        public static string AdminDirectoryPath { get; private set; } = null;
        public static string SystemAccessCode { get; private set; } = null;
        public static string ConnectionString { get; private set; } = null;
        public static string SessionLifeTime { get; private set; } = null;
        public static string CookiesLifeTime { get; private set; } = null;
        public static bool LockLogin = false;
        public static bool SaveLogsError { get; private set; } = false;
        public static bool UseRobotDetection { get; private set; } = false;
        public static int RobotDetectionIpBlockDuration { get; private set; } = 0;
        public static int RobotDetectionResetTimeDuration { get; private set; } = 0;
        public static bool UseVariantDebug { get; private set; } = false;
        public static bool WriteLogsError { get; private set; } = false;

        public static int CornHourDuration { get; private set; } = 0;
        public static bool UseScheduledTasks { get; private set; } = false;
        public static bool UseScheduledLoad { get; private set; } = false;
        public static bool UseScheduledTimer { get; private set; } = false;
        public static bool UseSiteMainCache { get; private set; } = false;
        public static bool UseAdminMainCache { get; private set; } = false;
        public static string SiteMainCacheParameters { get; private set; } = null;
        public static string AdminMainCacheParameters { get; private set; } = null;
        public static bool AddPluginVariantNote { get; private set; } = false;
        public static bool AddModuleVariantNote { get; private set; } = false;
        public static bool AddFetchVariantNote { get; private set; } = false;
        public static bool AddItemVariantNote { get; private set; } = false;

        public static string AdminRoleCacheType { get; private set; } = null;
        public static int AdminRoleCacheDuration { get; private set; } = 0;
        public static string MemeberRoleCacheType { get; private set; } = null;
        public static int MemeberRoleCacheDuration { get; private set; } = 0;
        public static string GuestRoleCacheType { get; private set; } = null;
        public static int GuestRoleCacheDuration { get; private set; } = 0;
        public static bool UseClientCacheForDynamicPage { get; private set; } = false;
        public static bool CheckDynamicPageServerCacheForClientCache { get; private set; } = false;
        public static int DynamicPageClientCacheDuration { get; private set; } = 0;
        public static bool UseClientCacheForStaticPage { get; private set; } = false;
        public static bool CheckStaticPageLastModifiedForClientCache { get; private set; } = false;
        public static int StaticPageClientCacheDuration { get; private set; } = 0;
        public static bool TextCreatorUseServerCache { get; private set; } = false;
        public static string TextCreatorCacheType { get; private set; } = null;
        public static int TextCreatorServerCacheDuration { get; private set; } = 0;
        public static bool TextCreatorUseClientCache { get; private set; } = false;
        public static int TextCreatorClientCacheDuration { get; private set; } = 0;

        public static string GuestGroup { get; private set; } = null;
        public static string DefaultSite { get; private set; } = null;
        public static string DefaultPage { get; private set; } = null;
        public static string DefaultSiteLanguage { get; private set; } = null;
        public static string DefaultSiteCalendar { get; private set; } = null;
        public static string DefaultDateFormat { get; private set; } = null;
        public static string DefaulttimeFormat { get; private set; } = null;
        public static string DefaultFirstDayOfWeek { get; private set; } = null;
        public static string DefaultDayDifference { get; private set; } = null;
        public static string DefaultTimeDifferenceHours { get; private set; } = null;
        public static string DefaultTimeDifferenceMinutes { get; private set; } = null;
        public static string DefaultTimeZone { get; private set; } = null;
        public static string DefaultSiteStyle { get; private set; } = null;
        public static string DefaultSiteTemplate { get; private set; } = null;
        public static string DefaultAdminLanguage { get; private set; } = null;
        public static string DefaultAdminStyle { get; private set; } = null;
        public static string DefaultAdminTemplate { get; private set; } = null;
        public static string ApplicationName { get; private set; } = null;
        public static int ContentTextCharacterLength { get; private set; } = 0;
        public static int NumberOfContentInMainPage { get; private set; } = 0;
        public static int NumberOfContentPerPage { get; private set; } = 0;
        public static int NumberOfCommentInContent { get; private set; } = 0;
        public static int NumberOfCommentReplyInContent { get; private set; } = 0;
        public static int NumberOfRownMainTable { get; private set; } = 0;
        public static int NumberOfRowPerTable { get; private set; } = 0;
        public static bool UseSiteAutoResize { get; private set; } = false;
        public static bool ShowUseCookieMessageAlert { get; private set; } = false;
        public static bool UseViewStyle { get; private set; } = false;
        public static bool CreateExternalLinkForSiteViewStyle { get; private set; } = false;
        public static bool CreateExternalLinkForAdminViewStyle { get; private set; } = false;
        public static bool CreateExternalLinkForUserViewStyle { get; private set; } = false;
        public static bool CreateExternalLinkForCurrentViewStyle { get; private set; } = false;
        public static bool UseSiteClientVariant { get; private set; } = false;
        public static bool CreateExternalLinkForSiteClientVariant { get; private set; } = false;
        public static bool UseAdminClientVariant { get; private set; } = false;
        public static bool CreateExternalLinkForAdminClientVariant { get; private set; } = false;
        public static bool UseSiteClientLanguageVariant { get; private set; } = false;
        public static bool CreateExternalLinkForSiteClientLanguageVariant { get; private set; } = false;
        public static bool UseAdminClientLanguageVariant { get; private set; } = false;
        public static bool CreateExternalLinkForAdminClientLanguageVariant { get; private set; } = false;
        public static string DefaultBoxPath { get; private set; } = null;
        public static string DefaultCaptchaPath { get; private set; } = null;
        public static string DefaultCalendarPath { get; private set; } = null;
        public static string DefaultFileViewerPath { get; private set; } = null;
        public static string DefaultWysiwygPath { get; private set; } = null;

        public static XmlNodeList AfterLoadPathReferenceNodeList { get; private set; }
        public static XmlNodeList BeforeLoadPathReferenceNodeList { get; private set; }
        public static XmlNodeList EventReferenceNodeList { get; private set; }
        public static XmlNodeList DefaultPageNodeList { get; private set; }
        public static XmlNodeList DynamicExtensionNodeList { get; private set; }
        public static XmlNodeList ReplacePartNodeList { get; private set; }
        public static XmlNodeList ScriptExtensionNodeList { get; private set; }
        public static XmlNodeList RoleBitColumnAccessNodeList { get; private set; }
        public static XmlNodeList UrlRedirectNodeList { get; private set; }
        public static XmlNodeList UrlRewriteNodeList { get; private set; }
        public static XmlNodeList StartUpNodeList { get; private set; }
        public static XmlNodeList ScheduledTaskNodeList { get; private set; }

        public static XmlDocument ConfigDocument { get; private set; } = new XmlDocument();
        public static XmlDocument StructDocument { get; private set; } = new XmlDocument();
        public static XmlDocument GlobalTemplateDocument { get; private set; } = new XmlDocument();
        public static XmlDocument SiteGlobalTemplateDocument { get; private set; } = new XmlDocument();
        public static XmlDocument SiteGlobalLocationTemplateDocument { get; private set; } = new XmlDocument();
        public static XmlDocument AdminGlobalTemplateDocument { get; private set; } = new XmlDocument();
        public static XmlDocument AdminGlobalLocationTemplateDocument { get; private set; } = new XmlDocument();
        public static XmlDocument AuthorizedExtensionDocument { get; private set; } = new XmlDocument();
        public static XmlDocument SecurityDocument { get; private set; } = new XmlDocument();
        public static XmlDocument FileExtensionDocument { get; private set; } = new XmlDocument();

        public static List<ListItem> SiteTemplatePhysicalPathNameNumber { get; private set; } = new List<ListItem>();
        public static List<XmlDocument> SiteTemplatePhysicalPathDocumentList { get; private set; } = new List<XmlDocument>();

        public static List<ListItem> AdminTemplatePhysicalPathNameNumber { get; private set; } = new List<ListItem>();
        public static List<XmlDocument> AdminTemplatePhysicalPathDocumentList { get; private set; } = new List<XmlDocument>();

        public static List<ListItem> LanguageGlobalNameNumber { get; private set; } = new List<ListItem>();
        public static List<XmlDocument> LanguageGlobalNameDocumentList { get; private set; } = new List<XmlDocument>();
        public static List<XmlDocument> HandheldLanguageGlobalNameDocumentList { get; private set; } = new List<XmlDocument>();

        public static List<ListItem> RoleNameNumber { get; private set; } = new List<ListItem>();
        public static List<XmlNodeList> RoleAllwoPathAccessNodeList { get; private set; } = new List<XmlNodeList>();
        public static List<XmlNodeList> RoleDenyPathAccessNodeList { get; private set; } = new List<XmlNodeList>();
        public static List<XmlNodeList> RoleProcedureFilterNodeList { get; private set; } = new List<XmlNodeList>();
        public static List<XmlDocument> RoleLimitationsDocumentList { get; private set; } = new List<XmlDocument>();

        public static void SystemStart()
        {
            ContentRootPath = Directory.GetCurrentDirectory();
        }

        public static void ApplicationStart()
        {
            // Set Static Object

            // Set Config Value
            SetConfigValue();

            // Set Code Value
            SetCodeValue();

            // Set Ip Session Indexe Value
            SetIpSessionIndexerValue();

            // Set Static File Data Value
            SetAfterReferenceDocument();
            SetBeforeReferenceDocument();
            SetEventReferenceDocument();
            SetUrlRedirectDocument();
            SetDefaultPageDocument();
            SetDynamicExtensionDocument();
            SetReplacePartDocument();
            SetScriptExtensionDocument();
            SetRoleBitColumnAccessDocument();
            SetUrlRewriteDocument();
            SetStartUpDocument();
            SetScheduledTaskDocument();
            SetStructDocument();
            SetGlobalTemplatesDocument();

            // Run Script Start Command
            RunScriptStartCommand();

            // Set Scheduled Tasks Value
            ScheduledTasksHasABeenImplemented = false;
            StartUpHasABeenImplemented = false;

            // Try For Fetch Data From Database
            try
            {
                SetSiteTemplate();
                SetAdminTemplate();
                SetLanguageDocument();

                // Set Role Value
                SetRoleValue();
            }
            catch(Exception ex) { }
        }

        public static void ApplicationEnd()
        {
            // Clean Disk Cache File
            FileAndDirectory fad = new FileAndDirectory();

            try
            {
                fad.DeleteAllFileAndSubDirectoryInDirectory(StaticObject.ServerMapPath(SitePath + "App_Data/elanat_system_data/cache/disk/"));
                fad.DeleteAllFileAndSubDirectoryInDirectory(StaticObject.ServerMapPath(SitePath + "App_Data/elanat_system_data/session_data/"));
            }
            catch (Exception) { }
        }

        public static void SessionStart()
        {
            // Set Ip Session Indexer
            Security sc = new Security();
            sc.AddIpSessionIndexer();
        }

        public static void SetConfigValue()
        {
            string TmpSitePath = (string.IsNullOrEmpty(SitePath)) ? "/" : SitePath;

            ConfigDocument.Load(ServerMapPath(TmpSitePath + "App_Data/config/config.xml"));

            ApplicationName = ConfigDocument.SelectNodes("elanat_root/elanat/application_name")[0].Attributes["value"].Value;

            GuestGroup = ConfigDocument.SelectNodes("elanat_root/security/guest_group")[0].Attributes["value"].Value;
            SessionLifeTime = ConfigDocument.SelectNodes("elanat_root/security/session_life_time")[0].Attributes["value"].Value;
            CookiesLifeTime = ConfigDocument.SelectNodes("elanat_root/security/cookie_life_time")[0].Attributes["value"].Value;
            LockLogin = ConfigDocument.SelectNodes("elanat_root/security/lock_login_for_first_login")[0].Attributes["active"].Value.TrueFalseToBoolean();
            SaveLogsError = ConfigDocument.SelectNodes("elanat_root/security/save_logs_error")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseRobotDetection = ConfigDocument.SelectNodes("elanat_root/security/robot_detection")[0].Attributes["active"].Value.TrueFalseToBoolean();
            RobotDetectionIpBlockDuration = ConfigDocument.SelectNodes("elanat_root/security/robot_detection_ip_block_duration")[0].Attributes["value"].Value.ToNumber();
            RobotDetectionResetTimeDuration = ConfigDocument.SelectNodes("elanat_root/security/robot_detection_reset_time_duration")[0].Attributes["value"].Value.ToNumber();

            UseVariantDebug = ConfigDocument.SelectNodes("elanat_root/debug/use_variant_debug")[0].Attributes["active"].Value.TrueFalseToBoolean();
            WriteLogsError = ConfigDocument.SelectNodes("elanat_root/debug/write_logs_error")[0].Attributes["active"].Value.TrueFalseToBoolean();

            DefaultSiteCalendar = ConfigDocument.SelectNodes("elanat_root/date_and_time/default_calendar")[0].Attributes["value"].Value;
            DefaultDateFormat = ConfigDocument.SelectNodes("elanat_root/date_and_time/date_format")[0].InnerText.Replace("/", "'/'");
            DefaulttimeFormat = ConfigDocument.SelectNodes("elanat_root/date_and_time/time_format")[0].InnerText;
            DefaultFirstDayOfWeek = ConfigDocument.SelectNodes("elanat_root/date_and_time/first_day_of_week")[0].Attributes["value"].Value;
            DefaultDayDifference = ConfigDocument.SelectNodes("elanat_root/date_and_time/day_difference")[0].Attributes["value"].Value;
            DefaultTimeDifferenceHours = ConfigDocument.SelectNodes("elanat_root/date_and_time/time_difference_hours")[0].Attributes["value"].Value;
            DefaultTimeDifferenceMinutes = ConfigDocument.SelectNodes("elanat_root/date_and_time/time_difference_minutes")[0].Attributes["value"].Value;
            DefaultTimeZone = ConfigDocument.SelectNodes("elanat_root/date_and_time/time_zone")[0].Attributes["value"].Value;

            DefaultBoxPath = ConfigDocument.SelectNodes("elanat_root/default_include_path/box_path")[0].InnerText;
            DefaultCaptchaPath = ConfigDocument.SelectNodes("elanat_root/default_include_path/captcha_path")[0].InnerText;
            DefaultCalendarPath = ConfigDocument.SelectNodes("elanat_root/default_include_path/calendar_path")[0].InnerText;
            DefaultFileViewerPath = ConfigDocument.SelectNodes("elanat_root/default_include_path/file_viewer_path")[0].InnerText;
            DefaultWysiwygPath = ConfigDocument.SelectNodes("elanat_root/default_include_path/wysiwyg_path")[0].InnerText;

            UseSiteMainCache = ConfigDocument.SelectNodes("elanat_root/cache/site_main")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseAdminMainCache = ConfigDocument.SelectNodes("elanat_root/cache/admin_main")[0].Attributes["active"].Value.TrueFalseToBoolean();
            SiteMainCacheParameters = ConfigDocument.SelectNodes("elanat_root/cache/site_main")[0].Attributes["cache_parameters"].Value;
            AdminMainCacheParameters = ConfigDocument.SelectNodes("elanat_root/cache/admin_main")[0].Attributes["cache_parameters"].Value;
            AdminRoleCacheType = ConfigDocument.SelectNodes("elanat_root/cache/admin_role")[0].Attributes["cache_type"].Value;
            AdminRoleCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/admin_role")[0].Attributes["value"].Value);
            MemeberRoleCacheType = ConfigDocument.SelectNodes("elanat_root/cache/member_role")[0].Attributes["cache_type"].Value;
            MemeberRoleCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/member_role")[0].Attributes["value"].Value);
            GuestRoleCacheType = ConfigDocument.SelectNodes("elanat_root/cache/guest_role")[0].Attributes["cache_type"].Value;
            GuestRoleCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/guest_role")[0].Attributes["value"].Value);
            UseClientCacheForDynamicPage = ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_dynamic_page")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CheckDynamicPageServerCacheForClientCache = ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_dynamic_page")[0].Attributes["check_server_cache"].Value.TrueFalseToBoolean();
            DynamicPageClientCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_dynamic_page")[0].Attributes["value"].Value);
            UseClientCacheForStaticPage = ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_static_page")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CheckStaticPageLastModifiedForClientCache = ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_static_page")[0].Attributes["check_last_modified"].Value.TrueFalseToBoolean();
            StaticPageClientCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/use_client_cache_for_static_page")[0].Attributes["value"].Value);
            TextCreatorUseServerCache = ConfigDocument.SelectNodes("elanat_root/cache/text_creator_cache")[0].Attributes["use_server_cache"].Value.TrueFalseToBoolean();
            TextCreatorCacheType = ConfigDocument.SelectNodes("elanat_root/cache/text_creator_cache")[0].Attributes["cache_type"].Value;
            TextCreatorServerCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/text_creator_cache")[0].Attributes["server_value"].Value);
            TextCreatorUseClientCache = ConfigDocument.SelectNodes("elanat_root/cache/text_creator_cache")[0].Attributes["use_client_cache"].Value.TrueFalseToBoolean(); ;
            TextCreatorClientCacheDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/cache/text_creator_cache")[0].Attributes["client_value"].Value); ;

            SitePath = ConfigDocument.SelectNodes("elanat_root/properties/site_path")[0].InnerText;
            NullLanguageSuffix = ConfigDocument.SelectNodes("elanat_root/properties/null_language_suffix")[0].InnerText;
            UseScheduledTasks = ConfigDocument.SelectNodes("elanat_root/properties/scheduled_tasks")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CornHourDuration = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/corn_hour_duration")[0].Attributes["value"].Value);
            UseScheduledLoad = ConfigDocument.SelectNodes("elanat_root/properties/scheduled_load")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseScheduledTimer = ConfigDocument.SelectNodes("elanat_root/properties/scheduled_timer")[0].Attributes["active"].Value.TrueFalseToBoolean();
            DefaultSite = ConfigDocument.SelectNodes("elanat_root/properties/default_site")[0].Attributes["value"].Value;
            DefaultPage = ConfigDocument.SelectNodes("elanat_root/properties/default_page")[0].Attributes["value"].Value;
            DefaultSiteLanguage = ConfigDocument.SelectNodes("elanat_root/properties/default_site_language")[0].Attributes["value"].Value;
            DefaultSiteStyle = ConfigDocument.SelectNodes("elanat_root/properties/default_site_style")[0].Attributes["value"].Value;
            DefaultSiteTemplate = ConfigDocument.SelectNodes("elanat_root/properties/default_site_template")[0].Attributes["value"].Value;
            DefaultAdminLanguage = ConfigDocument.SelectNodes("elanat_root/properties/default_admin_language")[0].Attributes["value"].Value;
            DefaultAdminStyle = ConfigDocument.SelectNodes("elanat_root/properties/default_admin_style")[0].Attributes["value"].Value;
            DefaultAdminTemplate = ConfigDocument.SelectNodes("elanat_root/properties/default_admin_template")[0].Attributes["value"].Value;
            ContentTextCharacterLength = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/content_text_character_length")[0].Attributes["value"].Value);
            NumberOfContentInMainPage = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/content_in_main_page")[0].Attributes["value"].Value);
            NumberOfContentPerPage = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/content_per_page")[0].Attributes["value"].Value);
            NumberOfCommentInContent = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/comment_in_content")[0].Attributes["value"].Value);
            NumberOfCommentReplyInContent = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/comment_reply_in_comment")[0].Attributes["value"].Value);
            NumberOfRownMainTable = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/row_in_main_table")[0].Attributes["value"].Value);
            NumberOfRowPerTable = int.Parse(ConfigDocument.SelectNodes("elanat_root/properties/row_per_table")[0].Attributes["value"].Value);
            UseSiteAutoResize = ConfigDocument.SelectNodes("elanat_root/properties/use_site_auto_resize")[0].Attributes["active"].Value.TrueFalseToBoolean();
            ShowUseCookieMessageAlert = ConfigDocument.SelectNodes("elanat_root/properties/show_use_cookie_message_alert")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseViewStyle = ConfigDocument.SelectNodes("elanat_root/properties/use_view_style")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForSiteViewStyle = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_site_view_style")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForAdminViewStyle = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_admin_view_style")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForUserViewStyle = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_user_view_style")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForCurrentViewStyle = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_current_view_style")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseSiteClientVariant = ConfigDocument.SelectNodes("elanat_root/properties/use_site_client_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForSiteClientVariant = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_site_client_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseAdminClientVariant = ConfigDocument.SelectNodes("elanat_root/properties/use_admin_client_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForAdminClientVariant = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_admin_client_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseSiteClientLanguageVariant = ConfigDocument.SelectNodes("elanat_root/properties/use_site_client_language_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForSiteClientLanguageVariant = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_site_client_language_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            UseAdminClientLanguageVariant = ConfigDocument.SelectNodes("elanat_root/properties/use_admin_client_language_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            CreateExternalLinkForAdminClientLanguageVariant = ConfigDocument.SelectNodes("elanat_root/properties/create_external_link_for_admin_client_language_variant")[0].Attributes["active"].Value.TrueFalseToBoolean();
            AddPluginVariantNote = ConfigDocument.SelectNodes("elanat_root/properties/add_plugin_variant_note")[0].Attributes["active"].Value.TrueFalseToBoolean();
            AddModuleVariantNote = ConfigDocument.SelectNodes("elanat_root/properties/add_module_variant_note")[0].Attributes["active"].Value.TrueFalseToBoolean();
            AddFetchVariantNote = ConfigDocument.SelectNodes("elanat_root/properties/add_fetch_variant_note")[0].Attributes["active"].Value.TrueFalseToBoolean();
            AddItemVariantNote = ConfigDocument.SelectNodes("elanat_root/properties/add_item_variant_note")[0].Attributes["active"].Value.TrueFalseToBoolean();
        }

        public static void SetIpSessionIndexerValue()
        {
            IpSessionIndexerKeeperName = new List<string>();
            IpSessionIndexerKeeperValue = new List<int>();
        }

        public static void SetCodeValue()
        {
            SitePhysicalPath = ServerMapPath(SitePath);
            AdminPath = SitePath + Security.GetCodeIni("admin_directory_path");
            AdminDirectoryPath = Security.GetCodeIni("admin_directory_path");
            SystemAccessCode = Security.GetCodeIni("system_access_code");
            ConnectionString = Security.GetCodeIni("connection_string");
        }

        public static void SetAfterReferenceDocument()
        {
            XmlDocument AfterReferenceDocument = new XmlDocument();
            AfterReferenceDocument.Load(ServerMapPath(SitePath + "App_Data/after_load_path_reference_list/after_load_path_reference.xml"));
            AfterLoadPathReferenceNodeList = AfterReferenceDocument.SelectSingleNode("after_load_path_reference_root/after_load_path_reference_list").ChildNodes;
        }

        public static void SetBeforeReferenceDocument()
        {
            XmlDocument BeforeReferenceDocument = new XmlDocument();
            BeforeReferenceDocument.Load(ServerMapPath(SitePath + "App_Data/before_load_path_reference_list/before_load_path_reference.xml"));
            BeforeLoadPathReferenceNodeList = BeforeReferenceDocument.SelectSingleNode("before_load_path_reference_root/before_load_path_reference_list").ChildNodes;
        }

        public static void SetEventReferenceDocument()
        {
            XmlDocument EventReferenceDocument = new XmlDocument();
            EventReferenceDocument.Load(ServerMapPath(SitePath + "App_Data/event_reference_list/event_reference.xml"));
            EventReferenceNodeList = EventReferenceDocument.SelectSingleNode("event_reference_root/event_reference_list").ChildNodes;
        }

        public static void SetUrlRedirectDocument()
        {
            XmlDocument UrlRedirectDocument = new XmlDocument();
            UrlRedirectDocument.Load(ServerMapPath(SitePath + "App_Data/url_redirect_list/url_redirect.xml"));
            UrlRedirectNodeList = UrlRedirectDocument.SelectSingleNode("url_redirect_root/url_redirect_list").ChildNodes;
        }

        public static void SetDefaultPageDocument()
        {
            XmlDocument DefaultPageDocument = new XmlDocument();
            DefaultPageDocument.Load(ServerMapPath(SitePath + "App_Data/default_page_list/default_page.xml"));
            DefaultPageNodeList = DefaultPageDocument.SelectSingleNode("default_page_root/default_page_list").ChildNodes;
        }

        public static void SetDynamicExtensionDocument()
        {
            XmlDocument DynamicExtensionDocument = new XmlDocument();
            DynamicExtensionDocument.Load(ServerMapPath(SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"));
            DynamicExtensionNodeList = DynamicExtensionDocument.SelectSingleNode("dynamic_extension_root/dynamic_extension_list").ChildNodes;
        }

        public static void SetReplacePartDocument()
        {
            XmlDocument ReplacePartDocument = new XmlDocument();
            ReplacePartDocument.Load(ServerMapPath(SitePath + "App_Data/replace_part/replace_part.xml"));
            ReplacePartNodeList = ReplacePartDocument.SelectSingleNode("replace_part_root/replace_part_list").ChildNodes;
        }

        public static void SetScriptExtensionDocument()
        {
            XmlDocument ScriptExtensionDocument = new XmlDocument();
            ScriptExtensionDocument.Load(ServerMapPath(SitePath + "App_Data/script_extension_list/script_extension.xml"));
            ScriptExtensionNodeList = ScriptExtensionDocument.SelectSingleNode("script_extension_root/script_extension_list").ChildNodes;
        }

        public static void SetRoleBitColumnAccessDocument()
        {
            XmlDocument RoleBitColumnAccessDocument = new XmlDocument();
            RoleBitColumnAccessDocument.Load(ServerMapPath(SitePath + "App_Data/role_bit_column_access_list/role_bit_column_access.xml"));
            RoleBitColumnAccessNodeList = RoleBitColumnAccessDocument.SelectSingleNode("role_bit_column_access_root/role_bit_column_access_list").ChildNodes;
        }

        public static void SetUrlRewriteDocument()
        {
            XmlDocument UrlRewriteDocument = new XmlDocument();
            UrlRewriteDocument.Load(ServerMapPath(SitePath + "App_Data/url_rewrite_list/url_rewrite.xml"));
            UrlRewriteNodeList = UrlRewriteDocument.SelectSingleNode("url_rewrite_root/url_rewrite_list").ChildNodes;
        }

        public static void SetStartUpDocument()
        {
            XmlDocument StartUpDocument = new XmlDocument();
            StartUpDocument.Load(ServerMapPath(SitePath + "App_Data/start_up_list/start_up.xml"));
            StartUpNodeList = StartUpDocument.SelectSingleNode("start_up_root/start_up_list").ChildNodes;
        }

        public static void SetScheduledTaskDocument()
        {
            XmlDocument ScheduledTaskDocument = new XmlDocument();
            ScheduledTaskDocument.Load(ServerMapPath(SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));
            ScheduledTaskNodeList = ScheduledTaskDocument.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list").ChildNodes;
        }

        public static void SetStructDocument()
        {
            StructDocument.Load(ServerMapPath(SitePath + "App_Data/struct/struct.xml"));
            AuthorizedExtensionDocument.Load(ServerMapPath(SitePath + "App_Data/authorized_extension_list/authorized_extension.xml"));
            SecurityDocument.Load(ServerMapPath(SitePath + "App_Data/security/security.xml"));
            FileExtensionDocument.Load(ServerMapPath(SitePath + "App_Data/file_extensions_list/file_extensions.xml"));
        }

        public static void SetGlobalTemplatesDocument()
        {
            GlobalTemplateDocument.Load(ServerMapPath(SitePath + "template/global.xml"));
            SiteGlobalTemplateDocument.Load(ServerMapPath(SitePath + "template/site_global.xml"));
            SiteGlobalLocationTemplateDocument.Load(ServerMapPath(SitePath + "template/site_global_location.xml"));
            AdminGlobalTemplateDocument.Load(ServerMapPath(SitePath + "template/admin_global.xml"));
            AdminGlobalLocationTemplateDocument.Load(ServerMapPath(SitePath + "template/admin_global_location.xml"));
        }

        public static void RunScriptStartCommand()
        {
            foreach (XmlNode node in ScriptExtensionNodeList)
            {
                // Set Arguments
                string StartCommand = node.Attributes["start_command"].Value;
                StartCommand = StartCommand.Replace("$_asp quotation_mark;", "\"");
                StartCommand = StartCommand.Replace("$_asp site_path;", ServerMapPath(SitePath));

                if (string.IsNullOrEmpty(StartCommand))
                    continue;

                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.Arguments = "/C c:& cd " + StartCommand;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.Start();
            }
        }

        public static void RunStartUp()
        {
            try
            {
                // Run Start Up Page
                if (!StartUpHasABeenImplemented)
                {
                    StartUpClass suc = new StartUpClass();
                    suc.Start();

                    StartUpHasABeenImplemented = true;
                }
            }
            catch (Exception) { }
        }

        public static void SetSiteTemplate()
        {
            // Try Catch For Install Issues
            try
            {
                DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
                SiteTemplatePhysicalPathNameNumber = dust.GetActiveTemplatePhysicalPathNameNumber();
                SiteTemplatePhysicalPathDocumentList = dust.SetTemplatePhysicalPathDocumentList(SiteTemplatePhysicalPathNameNumber);
            }
            catch (Exception ex)
            {
                Security.SetLogErrorForApplicationStart(ex);
            }
        }

        public static void SetAdminTemplate()
        {
            // Try Catch For Install Issues
            try
            {
                DataUse.AdminTemplate duat = new DataUse.AdminTemplate();
                AdminTemplatePhysicalPathNameNumber = duat.GetActiveTemplatePhysicalPathNameNumber();
                AdminTemplatePhysicalPathDocumentList = duat.SetTemplatePhysicalPathDocumentList(AdminTemplatePhysicalPathNameNumber);
            }
            catch (Exception ex)
            {
                Security.SetLogErrorForApplicationStart(ex);
            }
        }

        public static void SetLanguageDocument()
        {
            // Try Catch For Install Issues
            try
            {
                DataUse.Language dul = new DataUse.Language();
                LanguageGlobalNameNumber = dul.GetActiveLanguageGlobalNameNumber();
                LanguageGlobalNameDocumentList = dul.SetLanguageGlobalNameDocumentList(LanguageGlobalNameNumber);
                HandheldLanguageGlobalNameDocumentList = dul.SetHandheldLanguageGlobalNameDocumentList(LanguageGlobalNameNumber);
            }
            catch (Exception) {}
        }

        public static void SetRoleValue()
        {
            RoleNameNumber = new List<ListItem>();
            RoleAllwoPathAccessNodeList = new List<XmlNodeList>();
            RoleDenyPathAccessNodeList = new List<XmlNodeList>();
            RoleProcedureFilterNodeList = new List<XmlNodeList>();
            RoleLimitationsDocumentList = new List<XmlDocument>();



            // Try Catch For Install Issues
            try
            {
                ListClass.Role lcr = new ListClass.Role();
                lcr.FillActiveRoleNameListItem();

                int i = 0;
                foreach (ListItem item in lcr.ActiveRoleNameListItem)
                {
                    RoleNameNumber.Add(item.Text, i.ToString());

                    XmlDocument RoleAllwoPathDocument = new XmlDocument();
                    RoleAllwoPathDocument.Load(ServerMapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/allow_path_access.xml"));
                    XmlDocument RoleDenyPathDocument = new XmlDocument();
                    RoleDenyPathDocument.Load(ServerMapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/deny_path_access.xml"));
                    XmlDocument RoleProcedureFilterDocument = new XmlDocument();
                    RoleProcedureFilterDocument.Load(ServerMapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/procedure_filter.xml"));

                    RoleAllwoPathAccessNodeList.Add(RoleAllwoPathDocument.SelectSingleNode("allow_path_access_root/allow_path_access_list").ChildNodes);
                    RoleDenyPathAccessNodeList.Add(RoleDenyPathDocument.SelectSingleNode("deny_path_access_root/deny_path_access_list").ChildNodes);
                    RoleProcedureFilterNodeList.Add(RoleProcedureFilterDocument.SelectSingleNode("procedure_filter_root/procedure_filter_list").ChildNodes);


                    XmlDocument RoleLimitationsDocument = new XmlDocument();
                    RoleLimitationsDocument.Load(ServerMapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/limitations.xml"));

                    RoleLimitationsDocumentList.Add(RoleLimitationsDocument);

                    i++;
                }
            }
            catch (Exception) { }
        }

        public static XmlDocument CurrentAdminTemplateDocument()
        {
            return AdminTemplatePhysicalPathDocumentList[AdminTemplatePhysicalPathNameNumber.GetValue(GetCurrentAdminTemplatePhysicalPath()).ToNumber()];
        }

        public static XmlDocument CurrentSiteTemplateDocument()
        {
            return SiteTemplatePhysicalPathDocumentList[SiteTemplatePhysicalPathNameNumber.GetValue(GetCurrentSiteTemplatePhysicalPath()).ToNumber()];
        }

        public static XmlDocument CurrentLanguageDocument(string GlobalLanguage)
        {
            return LanguageGlobalNameDocumentList[LanguageGlobalNameNumber.GetValue(GlobalLanguage).ToNumber()];
        }

        public static XmlDocument CurrentHandheldLanguageDocument(string GlobalLanguage)
        {
            return HandheldLanguageGlobalNameDocumentList[LanguageGlobalNameNumber.GetValue(GlobalLanguage).ToNumber()];
        }

        public static XmlDocument CurrentRoleLimitationsDocument(string RoleName)
        {
            return RoleLimitationsDocumentList[RoleNameNumber.GetValue(RoleName).ToNumber()];
        }

        public static string GetCurrentAdminTemplatePhysicalPath()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.AdminTemplatePhysicalPath;
        }

        public static string GetCurrentSiteTemplatePhysicalPath()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteTemplatePhysicalPath;
        }

        public static string GetCurrentSiteGlobalLanguage()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteLanguageGlobalName;
        }

        public static string GetCurrentSiteLanguageId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteLanguageId;
        }

        public static string GetCurrentAdminGlobalLanguage()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.AdminLanguageGlobalName;
        }

        public static string GetCurrentAdminLanguageId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.AdminLanguageId;
        }

        public static string GetCurrentSiteSiteId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteId;
        }

        public static string GetCurrentSiteSiteGlobalName()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteSiteGlobalName;
        }

        public static string GetCurrentAdminSiteId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.SiteId;
        }

        public static string GetCurrentUserId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.UserId;
        }

        public static bool UserIsOnline(string UserId)
        {
            if (ApplicationData.HasText("el_user_" + UserId + ":online"))
                return ApplicationData.GetValueByText("el_user_" + UserId + ":online").ZeroOneToBoolean();

            return false;
        }

        public static bool RoleUploadFileCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_upload_file") != "0";
        }

        public static string GetCurrentGroupId()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            return ccoc.GroupId;
        }

        public static bool RoleSubmitFootPrintCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_submit_foot_print") != "0";
        }

        public static bool RoleSubmitVisitCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_submit_visit") != "0";
        }

        public static bool RoleAddFreeCommentContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_add_free_comment_content") != "0";
        }

        public static bool RoleAddAlwaysOnTopContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_add_always_on_top_content") != "0";
        }

        public static bool RoleAddContentWithoutApprovalCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_add_content_without_approval") != "0";
        }

        public static bool RoleWriteHtmlCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_write_html") != "0";
        }

        public static bool RoleWriteScriptCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_write_script") != "0";
        }

        public static bool RoleReplyCommentAllContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_reply_comment_all_content") != "0";
        }

        public static bool RoleReplyCommentOnlyOwnContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_reply_comment_only_own_content") == "1";
        }
        
        public static bool RoleApprovalCommentOnlyOwnContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_approval_comment_only_own_content") == "1";
        }

        public static bool RoleEditCommentOnlyOwnContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_edit_comment_only_own_content") == "1";
        }

        public static bool RoleDeleteCommentOnlyOwnContentCheck()
        {
            Access ac = new Access();
            return ac.AggregationRoleBitColumnAccess("role_delete_comment_only_own_content") == "1";
        }

        public static string GetCurrentCacheType(string RoleType)
        {
            switch (RoleType)
            {
                case "admin": return AdminRoleCacheType;
                case "member": return MemeberRoleCacheType;
                case "guest": return GuestRoleCacheType;
            }

            return "guest";
        }

        public static int GetCurrentCacheDuration(string RoleType)
        {
            switch (RoleType)
            {
                case "admin": return AdminRoleCacheDuration;
                case "member": return MemeberRoleCacheDuration;
                case "guest": return GuestRoleCacheDuration;
            }
            return 0;
        }

        public static string ServerMapPath(string Path)
        {
            return ContentRootPath + "/wwwroot" + Path;
        }

        public static string WebMapPath()
        {
            string TmpPath = new HttpContextAccessor().HttpContext.Request.Path;
            TmpPath = Path.GetDirectoryName(TmpPath);

            return TmpPath;
        }

        public static void SetSession(string Key, string Value)
        {
            Session se = new Session();
            se.SetSessionValue(Key, Value);
        }

        public static string GetSession( string Key)
        {
            Session se = new Session();
            return se.GetSessionValue(Key);
        }

        public static string RemoveSession(string Key)
        {
            Session se = new Session();
            return se.GetSessionValue(Key);
        }

        public static string GetSessionId()
        {
            Session se = new Session();
            return se.GetSessionId();
        }
    }
}