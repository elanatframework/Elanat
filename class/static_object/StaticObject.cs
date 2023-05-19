using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class StaticObject
    {
        /// <summary>
        /// Do Not Change To True In Static Object Class
        /// </summary>
        public static bool ScheduledTasksHasABeenImplemented = false;
        public static bool StartUpHasABeenImplemented = false;

        // Relate Robot Detection
        public static List<string> IpSessionIndexerKeeperName;
        public static List<int> IpSessionIndexerKeeperValue;

        public static int OnlineGuest = 0;
        public static int OnlineUser = 0;
        public static string NullLanguageSuffix = null;
        public static string SitePath = null;
        public static string SitePhysicalPath = null;
        public static string AdminPath = null;
        public static string AdminDirectoryPath = null;
        public static string SystemAccessCode = null;
        public static string ConnectionString = null;
        public static string SessionLifeTime = null;
        public static string CookiesLifeTime = null;
        public static bool LockLogin = false;
        public static bool SaveLogsError = false;
        public static bool UseRobotDetection = false;
        public static int RobotDetectionIpBlockDuration = 0;
        public static int RobotDetectionResetTimeDuration = 0;
        public static bool UseVariantDebug = false;
        public static bool WriteLogsError = false;

        public static int CornHourDuration = 0;
        public static bool UseScheduledTasks = false;
        public static bool UseScheduledLoad = false;
        public static bool UseScheduledTimer = false;
        public static bool UseSiteMainCache = false;
        public static bool UseAdminMainCache = false;
        public static string SiteMainCacheParameters = null;
        public static string AdminMainCacheParameters = null;
        public static bool AddPluginVariantNote = false;
        public static bool AddModuleVariantNote = false;
        public static bool AddFetchVariantNote = false;
        public static bool AddItemVariantNote = false;

        public static string AdminRoleCacheType = null;
        public static int AdminRoleCacheDuration = 0;
        public static string MemeberRoleCacheType = null;
        public static int MemeberRoleCacheDuration = 0;
        public static string GuestRoleCacheType = null;
        public static int GuestRoleCacheDuration = 0;
        public static bool UseClientCacheForDynamicPage = false;
        public static bool CheckDynamicPageServerCacheForClientCache = false;
        public static int DynamicPageClientCacheDuration = 0;
        public static bool UseClientCacheForStaticPage = false;
        public static bool CheckStaticPageLastModifiedForClientCache = false;
        public static int StaticPageClientCacheDuration = 0;
        public static bool TextCreatorUseServerCache = false;
        public static string TextCreatorCacheType = null;
        public static int TextCreatorServerCacheDuration = 0;
        public static bool TextCreatorUseClientCache = false;
        public static int TextCreatorClientCacheDuration = 0;

        public static string GuestGroup = null;
        public static string DefaultSite = null;
        public static string DefaultPage = null;
        public static string DefaultSiteLanguage = null;
        public static string DefaultSiteCalendar = null;
        public static string DefaultDateFormat = null;
        public static string DefaulttimeFormat = null;
        public static string DefaultFirstDayOfWeek = null;
        public static string DefaultDayDifference = null;
        public static string DefaultTimeDifferenceHours = null;
        public static string DefaultTimeDifferenceMinutes = null;
        public static string DefaultTimeZone = null;
        public static string DefaultSiteStyle = null;
        public static string DefaultSiteTemplate = null;
        public static string DefaultAdminLanguage = null;
        public static string DefaultAdminStyle = null;
        public static string DefaultAdminTemplate = null;
        public static string ApplicationName = null;
        public static int ContentTextCharacterLength = 0;
        public static int NumberOfContentInMainPage = 0;
        public static int NumberOfContentPerPage = 0;
        public static int NumberOfCommentInContent = 0;
        public static int NumberOfCommentReplyInContent = 0;
        public static int NumberOfRownMainTable = 0;
        public static int NumberOfRowPerTable = 0;
        public static bool UseSiteAutoResize = false;
        public static bool ShowUseCookieMessageAlert = false;
        public static bool UseViewStyle = false;
        public static bool CreateExternalLinkForSiteViewStyle = false;
        public static bool CreateExternalLinkForAdminViewStyle = false;
        public static bool CreateExternalLinkForUserViewStyle = false;
        public static bool CreateExternalLinkForCurrentViewStyle = false;
        public static bool UseSiteClientVariant = false;
        public static bool CreateExternalLinkForSiteClientVariant = false;
        public static bool UseAdminClientVariant = false;
        public static bool CreateExternalLinkForAdminClientVariant = false;
        public static bool UseSiteClientLanguageVariant = false;
        public static bool CreateExternalLinkForSiteClientLanguageVariant = false;
        public static bool UseAdminClientLanguageVariant = false;
        public static bool CreateExternalLinkForAdminClientLanguageVariant = false;
        public static string DefaultBoxPath = null;
        public static string DefaultCaptchaPath = null;
        public static string DefaultCalendarPath = null;
        public static string DefaultFileViewerPath = "";
        public static string DefaultWysiwygPath = null;

        public static XmlNodeList AfterLoadPathReferenceNodeList;
        public static XmlNodeList BeforeLoadPathReferenceNodeList;
        public static XmlNodeList EventReferenceNodeList;
        public static XmlNodeList DefaultPageNodeList;
        public static XmlNodeList DynamicExtensionNodeList;
        public static XmlNodeList ReplacePartNodeList;
        public static XmlNodeList ScriptExtensionNodeList;
        public static XmlNodeList RoleBitColumnAccessNodeList;
        public static XmlNodeList UrlRedirectNodeList;
        public static XmlNodeList UrlRewriteNodeList;
        public static XmlNodeList StartUpNodeList;
        public static XmlNodeList ScheduledTaskNodeList;

        public static XmlDocument ConfigDocument = new XmlDocument();
        public static XmlDocument StructDocument = new XmlDocument();
        public static XmlDocument GlobalTemplateDocument = new XmlDocument();
        public static XmlDocument SiteGlobalTemplateDocument = new XmlDocument();
        public static XmlDocument SiteGlobalLocationTemplateDocument = new XmlDocument();
        public static XmlDocument AdminGlobalTemplateDocument = new XmlDocument();
        public static XmlDocument AdminGlobalLocationTemplateDocument = new XmlDocument();
        public static XmlDocument AuthorizedExtensionDocument = new XmlDocument();
        public static XmlDocument SecurityDocument = new XmlDocument();
        public static XmlDocument FileExtensionDocument = new XmlDocument();

        public static NameValueCollection SiteTemplatePhysicalPathNameNumber = new NameValueCollection();
        public static List<XmlDocument> SiteTemplatePhysicalPathDocumentList = new List<XmlDocument>();

        public static NameValueCollection AdminTemplatePhysicalPathNameNumber = new NameValueCollection();
        public static List<XmlDocument> AdminTemplatePhysicalPathDocumentList = new List<XmlDocument>();

        public static NameValueCollection LanguageGlobalNameNumber = new NameValueCollection();
        public static List<XmlDocument> LanguageGlobalNameDocumentList = new List<XmlDocument>();
        public static List<XmlDocument> HandheldLanguageGlobalNameDocumentList = new List<XmlDocument>();

        public static NameValueCollection RoleNameNumber = new NameValueCollection();
        public static List<XmlNodeList> RoleAllwoPathAccessNodeList = new List<XmlNodeList>();
        public static List<XmlNodeList> RoleDenyPathAccessNodeList = new List<XmlNodeList>();
        public static List<XmlNodeList> RoleProcedureFilterNodeList = new List<XmlNodeList>();
        public static List<XmlDocument> RoleLimitationsDocumentList = new List<XmlDocument>();

        public static void SetConfigValue()
        {
            string TmpSitePath = (string.IsNullOrEmpty(SitePath)) ? "/" : SitePath;

            ConfigDocument.Load(HttpContext.Current.Server.MapPath(TmpSitePath + "App_Data/config/config.xml"));

            ApplicationName = ConfigDocument.SelectNodes("elanat_root/elanat/application_name")[0].Attributes["value"].Value;

            GuestGroup = ConfigDocument.SelectNodes("elanat_root/security/guest_group")[0].Attributes["value"].Value;
            SessionLifeTime = ConfigDocument.SelectNodes("elanat_root/security/session_life_time")[0].Attributes["value"].Value;
            CookiesLifeTime = ConfigDocument.SelectNodes("elanat_root/security/cookies_life_time")[0].Attributes["value"].Value;
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
            SitePhysicalPath = HttpContext.Current.Server.MapPath(SitePath);
            AdminPath = SitePath + Security.GetCodeIni("admin_directory_path");
            AdminDirectoryPath = Security.GetCodeIni("admin_directory_path");
            SystemAccessCode = Security.GetCodeIni("system_access_code");
            ConnectionString = Security.GetCodeIni("connection_string");
        }

        public static void SetAfterReferenceDocument()
        {
            XmlDocument AfterReferenceDocument = new XmlDocument();
            AfterReferenceDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/after_load_path_reference_list/after_load_path_reference.xml"));
            AfterLoadPathReferenceNodeList = AfterReferenceDocument.SelectSingleNode("after_load_path_reference_root/after_load_path_reference_list").ChildNodes;
        }

        public static void SetBeforeReferenceDocument()
        {
            XmlDocument BeforeReferenceDocument = new XmlDocument();
            BeforeReferenceDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/before_load_path_reference_list/before_load_path_reference.xml"));
            BeforeLoadPathReferenceNodeList = BeforeReferenceDocument.SelectSingleNode("before_load_path_reference_root/before_load_path_reference_list").ChildNodes;
        }

        public static void SetEventReferenceDocument()
        {
            XmlDocument EventReferenceDocument = new XmlDocument();
            EventReferenceDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/event_reference_list/event_reference.xml"));
            EventReferenceNodeList = EventReferenceDocument.SelectSingleNode("event_reference_root/event_reference_list").ChildNodes;
        }

        public static void SetUrlRedirectDocument()
        {
            XmlDocument UrlRedirectDocument = new XmlDocument();
            UrlRedirectDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/url_redirect_list/url_redirect.xml"));
            UrlRedirectNodeList = UrlRedirectDocument.SelectSingleNode("url_redirect_root/url_redirect_list").ChildNodes;
        }

        public static void SetDefaultPageDocument()
        {
            XmlDocument DefaultPageDocument = new XmlDocument();
            DefaultPageDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/default_page_list/default_page.xml"));
            DefaultPageNodeList = DefaultPageDocument.SelectSingleNode("default_page_root/default_page_list").ChildNodes;
        }

        public static void SetDynamicExtensionDocument()
        {
            XmlDocument DynamicExtensionDocument = new XmlDocument();
            DynamicExtensionDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"));
            DynamicExtensionNodeList = DynamicExtensionDocument.SelectSingleNode("dynamic_extension_root/dynamic_extension_list").ChildNodes;
        }

        public static void SetReplacePartDocument()
        {
            XmlDocument ReplacePartDocument = new XmlDocument();
            ReplacePartDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/replace_part/replace_part.xml"));
            ReplacePartNodeList = ReplacePartDocument.SelectSingleNode("replace_part_root/replace_part_list").ChildNodes;
        }

        public static void SetScriptExtensionDocument()
        {
            XmlDocument ScriptExtensionDocument = new XmlDocument();
            ScriptExtensionDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/script_extension_list/script_extension.xml"));
            ScriptExtensionNodeList = ScriptExtensionDocument.SelectSingleNode("script_extension_root/script_extension_list").ChildNodes;
        }

        public static void SetRoleBitColumnAccessDocument()
        {
            XmlDocument RoleBitColumnAccessDocument = new XmlDocument();
            RoleBitColumnAccessDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/role_bit_column_access_list/role_bit_column_access.xml"));
            RoleBitColumnAccessNodeList = RoleBitColumnAccessDocument.SelectSingleNode("role_bit_column_access_root/role_bit_column_access_list").ChildNodes;
        }

        public static void SetUrlRewriteDocument()
        {
            XmlDocument UrlRewriteDocument = new XmlDocument();
            UrlRewriteDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/url_rewrite_list/url_rewrite.xml"));
            UrlRewriteNodeList = UrlRewriteDocument.SelectSingleNode("url_rewrite_root/url_rewrite_list").ChildNodes;
        }

        public static void SetStartUpDocument()
        {
            XmlDocument StartUpDocument = new XmlDocument();
            StartUpDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/start_up_list/start_up.xml"));
            StartUpNodeList = StartUpDocument.SelectSingleNode("start_up_root/start_up_list").ChildNodes;
        }

        public static void SetScheduledTaskDocument()
        {
            XmlDocument ScheduledTaskDocument = new XmlDocument();
            ScheduledTaskDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));
            ScheduledTaskNodeList = ScheduledTaskDocument.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list").ChildNodes;
        }

        public static void SetStructDocument()
        {
            StructDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/struct/struct.xml"));
            AuthorizedExtensionDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/authorized_extension_list/authorized_extension.xml"));
            SecurityDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/security/security.xml"));
            FileExtensionDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/file_extensions_list/file_extensions.xml"));
        }

        public static void SetGlobalTemplatesDocument()
        {
            GlobalTemplateDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "template/global.xml"));
            SiteGlobalTemplateDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "template/site_global.xml"));
            SiteGlobalLocationTemplateDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "template/site_global_location.xml"));
            AdminGlobalTemplateDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "template/admin_global.xml"));
            AdminGlobalLocationTemplateDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "template/admin_global_location.xml"));
        }

        public static void RunScriptStartCommand()
        {
            foreach (XmlNode node in ScriptExtensionNodeList)
            {
                // Set Arguments
                string StartCommand = node.Attributes["start_command"].Value;
                StartCommand = StartCommand.Replace("$_asp quotation_mark;", "\"");
                StartCommand = StartCommand.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));

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

        public static void SetSiteTemplate()
        {
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
            catch (Exception) { }
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
            // Try Catch For Install Issues
            try
            {
                ListClass lc = new ListClass();
                lc.FillActiveRoleNameListItem();

                int i = 0;
                foreach (ListItem item in lc.ActiveRoleNameListItem)
                {
                    RoleNameNumber.Add(item.Text, i.ToString());

                    XmlDocument RoleAllwoPathDocument = new XmlDocument();
                    RoleAllwoPathDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/allow_path_access.xml"));
                    XmlDocument RoleDenyPathDocument = new XmlDocument();
                    RoleDenyPathDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/deny_path_access.xml"));
                    XmlDocument RoleProcedureFilterDocument = new XmlDocument();
                    RoleProcedureFilterDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/procedure_filter.xml"));

                    RoleAllwoPathAccessNodeList.Add(RoleAllwoPathDocument.SelectSingleNode("allow_path_access_root/allow_path_access_list").ChildNodes);
                    RoleDenyPathAccessNodeList.Add(RoleDenyPathDocument.SelectSingleNode("deny_path_access_root/deny_path_access_list").ChildNodes);
                    RoleProcedureFilterNodeList.Add(RoleProcedureFilterDocument.SelectSingleNode("procedure_filter_root/procedure_filter_list").ChildNodes);


                    XmlDocument RoleLimitationsDocument = new XmlDocument();
                    RoleLimitationsDocument.Load(HttpContext.Current.Server.MapPath(SitePath + "App_Data/elanat_system_data/role_data/" + item.Text + "/limitations.xml"));

                    RoleLimitationsDocumentList.Add(RoleLimitationsDocument);

                    i++;
                }
            }
            catch (Exception) { }
        }

        public static XmlDocument CurrentAdminTemplateDocument()
        {
            return AdminTemplatePhysicalPathDocumentList[AdminTemplatePhysicalPathNameNumber[GetCurrentAdminTemplatePhysicalPath()].ToNumber()];
        }

        public static XmlDocument CurrentSiteTemplateDocument()
        {
            return SiteTemplatePhysicalPathDocumentList[SiteTemplatePhysicalPathNameNumber[GetCurrentSiteTemplatePhysicalPath()].ToNumber()];
        }

        public static XmlDocument CurrentLanguageDocument(string GlobalLanguage)
        {
            return LanguageGlobalNameDocumentList[LanguageGlobalNameNumber[GlobalLanguage].ToNumber()];
        }

        public static XmlDocument CurrentHandheldLanguageDocument(string GlobalLanguage)
        {
            return HandheldLanguageGlobalNameDocumentList[LanguageGlobalNameNumber[GlobalLanguage].ToNumber()];
        }

        public static XmlDocument CurrentRoleLimitationsDocument(string RoleName)
        {
            return RoleLimitationsDocumentList[RoleNameNumber[RoleName].ToNumber()];
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
            if (HttpContext.Current.Application["el_user_" + UserId + ":online"] != null)
                return (bool)HttpContext.Current.Application["el_user_" + UserId + ":online"];

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
    }
}
