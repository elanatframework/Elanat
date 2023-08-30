using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminPropertiesModel : CodeBehindModel
    {
        public string PropertiesLanguage { get; set; }
        public string SaveIncludeLanguage { get; set; }
        public string SavePropertiesLanguage { get; set; }
        public string SaveViewLanguage { get; set; }
        public string ActiveContentPageNumberLanguage { get; set; }
        public string ActiveScheduledDelayLanguage { get; set; }
        public string ActiveScheduledLoadLanguage { get; set; }
        public string ActiveScheduledTimerLanguage { get; set; }
        public string ActiveScheduledTasksLanguage { get; set; }
        public string ActiveAddPluginVariantNoteLanguage { get; set; }
        public string ActiveAddModuleVariantNoteLanguage { get; set; }
        public string ActiveAddFetchVariantNoteLanguage { get; set; }
        public string ActiveAddItemVariantNoteLanguage { get; set; }
        public string ActiveServerRefreshLanguage { get; set; }
        public string CreateExternalLinkForAdminClientLanguageVariantLanguage { get; set; }
        public string CreateExternalLinkForAdminClientVariantLanguage { get; set; }
        public string CreateExternalLinkForAdminViewStyleLanguage { get; set; }
        public string CreateExternalLinkForCurrentViewStyleLanguage { get; set; }
        public string CreateExternalLinkForSiteClientLanguageVariantLanguage { get; set; }
        public string CreateExternalLinkForSiteClientVariantLanguage { get; set; }
        public string CreateExternalLinkForSiteViewStyleLanguage { get; set; }
        public string CreateExternalLinkForUserViewStyleLanguage { get; set; }
        public string ShowAddCommentInContentInContentPageLanguage { get; set; }
        public string ShowAddCommentInContentInMainPageLanguage { get; set; }
        public string ShowAddContentReplyInContentInContentPageLanguage { get; set; }
        public string ShowAddContentReplyInContentInMainPageLanguage { get; set; }
        public string ShowAllSubCategoryWhenSelectFatherCategoryLanguage { get; set; }
        public string ShowAttachmentInContentInContentPageLanguage { get; set; }
        public string ShowAttachmentInContentInMainPageLanguage { get; set; }
        public string ShowAuthorNameInContentInContentPageLanguage { get; set; }
        public string ShowAuthorNameInContentInMainPageLanguage { get; set; }
        public string ShowCategoryNameInContentInContentPageLanguage { get; set; }
        public string ShowCategoryNameInContentInMainPageLanguage { get; set; }
        public string ShowCommentInAddCommentBoxLanguage { get; set; }
        public string ShowCommentInContentInContentPageLanguage { get; set; }
        public string ShowCommentInContentInMainPageLanguage { get; set; }
        public string ShowContentKeywordsInContentInContentPageLanguage { get; set; }
        public string ShowContentKeywordsInContentInMainPageLanguage { get; set; }
        public string ShowContentReplyInContentInContentPageLanguage { get; set; }
        public string ShowContentReplyInContentInMainPageLanguage { get; set; }
        public string ShowDateInContentInContentPageLanguage { get; set; }
        public string ShowDateInContentInMainPageLanguage { get; set; }
        public string ShowSiteNameLanguage { get; set; }
        public string ShowSiteSlogonNameLanguage { get; set; }
        public string ShowTimeInContentInContentPageLanguage { get; set; }
        public string ShowTimeInContentInMainPageLanguage { get; set; }
        public string ShowTitleInContentInContentPageLanguage { get; set; }
        public string ShowTitleInContentInMainPageLanguage { get; set; }
        public string ShowUseCookieMessageAlertLanguage { get; set; }
        public string ShowVisitInContentInContentPageLanguage { get; set; }
        public string ShowVisitInContentInMainPageLanguage { get; set; }
        public string UseAdminClientLanguageVariantLanguage { get; set; }
        public string UseAdminClientVariantLanguage { get; set; }
        public string UseAjaxForContentPageNumberLanguage { get; set; }
        public string UseReadMoreLanguage { get; set; }
        public string UseSiteAutoResizeLanguage { get; set; }
        public string UseSiteClientLanguageVariantLanguage { get; set; }
        public string UseSiteClientVariantLanguage { get; set; }
        public string UseViewStyleLanguage { get; set; }
        public string AddCommentLoadTypeInContentPageLanguage { get; set; }
        public string AddCommentLoadTypeInMainPageLanguage { get; set; }
        public string AddContentReplyLoadTypeInContentPageLanguage { get; set; }
        public string AddContentReplyLoadTypeInMainPageLanguage { get; set; }
        public string CommentInContentLanguage { get; set; }
        public string CommentReplyInCommentLanguage { get; set; }
        public string ContentInMainPageLanguage { get; set; }
        public string ContentPageNumberLocationLanguage { get; set; }
        public string ContentPerPageLanguage { get; set; }
        public string ContentTextCharacterLengthLanguage { get; set; }
        public string CornHourDurationLanguage { get; set; }
        public string DefaultAdminLanguageLanguage { get; set; }
        public string DefaultAdminStyleLanguage { get; set; }
        public string DefaultAdminTemplateLanguage { get; set; }
        public string DefaultComponentLanguage { get; set; }
        public string DefaultPageLanguage { get; set; }
        public string DefaultSiteLanguage { get; set; }
        public string DefaultSiteLanguageLanguage { get; set; }
        public string DefaultSiteStyleLanguage { get; set; }
        public string DefaultSiteTemplateLanguage { get; set; }
        public string DefaultSystemLanguage { get; set; }
        public string IncludeBoxLanguage { get; set; }
        public string IncludeCalendarLanguage { get; set; }
        public string IncludeCaptchaLanguage { get; set; }
        public string IncludeFileViewerLanguage { get; set; }
        public string IncludeLanguage { get; set; }
        public string IncludeWysiwygLanguage { get; set; }
        public string NullLanguageSuffixLanguage { get; set; }
        public string ReadMoreStatusLanguage { get; set; }
        public string RowInMainTableLanguage { get; set; }
        public string RowPerTableLanguage { get; set; }
        public string SitePathLanguage { get; set; }
        public string ViewLanguage { get; set; }

        public bool UseSiteAutoResizeValue { get; set; } = false;
        public bool UseReadMoreValue { get; set; } = false;
        public bool ShowAllSubCategoryWhenSelectFatherCategoryValue { get; set; } = false;
        public bool ShowUseCookieMessageAlertValue { get; set; } = false;
        public bool UseViewStyleValue { get; set; } = false;
        public bool CreateExternalLinkForSiteViewStyleValue { get; set; } = false;
        public bool CreateExternalLinkForAdminViewStyleValue { get; set; } = false;
        public bool CreateExternalLinkForUserViewStyleValue { get; set; } = false;
        public bool CreateExternalLinkForCurrentViewStyleValue { get; set; } = false;
        public bool UseSiteClientVariantValue { get; set; } = false;
        public bool CreateExternalLinkForSiteClientVariantValue { get; set; } = false;
        public bool UseAdminClientVariantValue { get; set; } = false;
        public bool CreateExternalLinkForAdminClientVariantValue { get; set; } = false;
        public bool UseSiteClientLanguageVariantValue { get; set; } = false;
        public bool CreateExternalLinkForSiteClientLanguageVariantValue { get; set; } = false;
        public bool UseAdminClientLanguageVariantValue { get; set; } = false;
        public bool CreateExternalLinkForAdminClientLanguageVariantValue { get; set; } = false;
        public bool ActiveContentPageNumberValue { get; set; } = false;
        public bool UseAjaxForContentPageNumberValue { get; set; } = false;
        public bool ShowCommentInAddCommentBoxValue { get; set; } = false;
        public bool ActiveServerRefreshValue { get; set; } = false;
        public bool ActiveScheduledDelayValue { get; set; } = false;
        public bool ActiveScheduledLoadValue { get; set; } = false;
        public bool ActiveScheduledTimerValue { get; set; } = false;
        public bool ActiveScheduledTasksValue { get; set; } = false;
        public bool ActiveAddPluginVariantNoteValue { get; set; } = false;
        public bool ActiveAddModuleVariantNoteValue { get; set; } = false;
        public bool ActiveAddFetchVariantNoteValue { get; set; } = false;
        public bool ActiveAddItemVariantNoteValue { get; set; } = false;
        public bool ShowSiteNameValue { get; set; } = false;
        public bool ShowSiteSlogonNameValue { get; set; } = false;
        public bool ShowContentKeywordsInContentInMainPageValue { get; set; } = false;
        public bool ShowAttachmentInContentInMainPageValue { get; set; } = false;
        public bool ShowCommentInContentInMainPageValue { get; set; } = false;
        public bool ShowAddCommentInContentInMainPageValue { get; set; } = false;
        public bool ShowAddContentReplyInContentInMainPageValue { get; set; } = false;
        public bool ShowContentReplyInContentInMainPageValue { get; set; } = false;
        public bool ShowAuthorNameInContentInMainPageValue { get; set; } = false;
        public bool ShowCategoryNameInContentInMainPageValue { get; set; } = false;
        public bool ShowTitleInContentInMainPageValue { get; set; } = false;
        public bool ShowDateInContentInMainPageValue { get; set; } = false;
        public bool ShowTimeInContentInMainPageValue { get; set; } = false;
        public bool ShowVisitInContentInMainPageValue { get; set; } = false;
        public bool ShowContentKeywordsInContentInContentPageValue { get; set; } = false;
        public bool ShowAttachmentInContentInContentPageValue { get; set; } = false;
        public bool ShowCommentInContentInContentPageValue { get; set; } = false;
        public bool ShowAddCommentInContentInContentPageValue { get; set; } = false;
        public bool ShowAddContentReplyInContentInContentPageValue { get; set; } = false;
        public bool ShowContentReplyInContentInContentPageValue { get; set; } = false;
        public bool ShowAuthorNameInContentInContentPageValue { get; set; } = false;
        public bool ShowCategoryNameInContentInContentPageValue { get; set; } = false;
        public bool ShowTitleInContentInContentPageValue { get; set; } = false;
        public bool ShowDateInContentInContentPageValue { get; set; } = false;
        public bool ShowTimeInContentInContentPageValue { get; set; } = false;
        public bool ShowVisitInContentInContentPageValue { get; set; } = false;

        public string ReadMoreStatusOptionListValue { get; set; }
        public string ReadMoreStatusOptionListSelectedValue { get; set; }
        public string DefaultSiteOptionListValue { get; set; }
        public string DefaultSiteOptionListSelectedValue { get; set; }
        public string DefaultPageOptionListValue { get; set; }
        public string DefaultPageOptionListSelectedValue { get; set; }
        public string DefaultSiteLanguageOptionListValue { get; set; }
        public string DefaultSiteLanguageOptionListSelectedValue { get; set; }
        public string DefaultAdminLanguageOptionListValue { get; set; }
        public string DefaultAdminLanguageOptionListSelectedValue { get; set; }
        public string DefaultSiteStyleOptionListValue { get; set; }
        public string DefaultSiteStyleOptionListSelectedValue { get; set; }
        public string DefaultSiteTemplateOptionListValue { get; set; }
        public string DefaultSiteTemplateOptionListSelectedValue { get; set; }
        public string DefaultAdminStyleOptionListValue { get; set; }
        public string DefaultAdminStyleOptionListSelectedValue { get; set; }
        public string DefaultAdminTemplateOptionListValue { get; set; }
        public string DefaultAdminTemplateOptionListSelectedValue { get; set; }
        public string DefaultSystemOptionListValue { get; set; }
        public string DefaultSystemOptionListSelectedValue { get; set; }
        public string DefaultComponentOptionListValue { get; set; }
        public string DefaultComponentOptionListSelectedValue { get; set; }
        public string ContentPageNumberLocationOptionListValue { get; set; }
        public string ContentPageNumberLocationOptionListSelectedValue { get; set; }
        public string CommentInAddCommentBoxLocationOptionListValue { get; set; }
        public string CommentInAddCommentBoxLocationOptionListSelectedValue { get; set; }
        public string AddCommentLoadTypeInMainPageOptionListValue { get; set; }
        public string AddCommentLoadTypeInMainPageOptionListSelectedValue { get; set; }
        public string AddContentReplyLoadTypeInMainPageOptionListValue { get; set; }
        public string AddContentReplyLoadTypeInMainPageOptionListSelectedValue { get; set; }
        public string AddCommentLoadTypeInContentPageOptionListValue { get; set; }
        public string AddCommentLoadTypeInContentPageOptionListSelectedValue { get; set; }
        public string AddContentReplyLoadTypeInContentPageOptionListValue { get; set; }
        public string AddContentReplyLoadTypeInContentPageOptionListSelectedValue { get; set; }
        public string IncludeBoxOptionListValue { get; set; }
        public string IncludeBoxOptionListSelectedValue { get; set; }
        public string IncludeCaptchaOptionListValue { get; set; }
        public string IncludeCaptchaOptionListSelectedValue { get; set; }
        public string IncludeCalendarOptionListValue { get; set; }
        public string IncludeCalendarOptionListSelectedValue { get; set; }
        public string IncludeFileViewerOptionListValue { get; set; }
        public string IncludeFileViewerOptionListSelectedValue { get; set; }
        public string IncludeWysiwygOptionListValue { get; set; }
        public string IncludeWysiwygOptionListSelectedValue { get; set; }

        public string ContentInMainPageValue { get; set; }
        public string ContentPerPageValue { get; set; }
        public string CommentInContentValue { get; set; }
        public string CommentReplyInCommentValue { get; set; }
        public string RowInMainTableValue { get; set; }
        public string RowPerTableValue { get; set; }
        public string ContentTextCharacterLengthValue { get; set; }
        public string SitePathValue { get; set; }
        public string NullLanguageSuffixValue { get; set; }
        public string CornHourDurationValue { get; set; }

        public string ContentInMainPageCssClass { get; set; }
        public string ContentPerPageCssClass { get; set; }
        public string CommentInContentCssClass { get; set; }
        public string CommentReplyInCommentCssClass { get; set; }
        public string RowInMainTableCssClass { get; set; }
        public string RowPerTableCssClass { get; set; }
        public string ContentTextCharacterLengthCssClass { get; set; }
        public string SitePathCssClass { get; set; }
        public string NullLanguageSuffixCssClass { get; set; }
        public string CornHourDurationCssClass { get; set; }
        public string ReadMoreStatusCssClass { get; set; }
        public string DefaultSiteCssClass { get; set; }
        public string DefaultPageCssClass { get; set; }
        public string DefaultSiteLanguageCssClass { get; set; }
        public string DefaultAdminLanguageCssClass { get; set; }
        public string DefaultSiteStyleCssClass { get; set; }
        public string DefaultSiteTemplateCssClass { get; set; }
        public string DefaultAdminStyleCssClass { get; set; }
        public string DefaultAdminTemplateCssClass { get; set; }
        public string DefaultSystemCssClass { get; set; }
        public string DefaultComponentCssClass { get; set; }
        public string ContentPageNumberLocationCssClass { get; set; }
        public string CommentInAddCommentBoxLocationCssClass { get; set; }
        public string AddCommentLoadTypeInMainPageCssClass { get; set; }
        public string AddContentReplyLoadTypeInMainPageCssClass { get; set; }
        public string AddCommentLoadTypeInContentPageCssClass { get; set; }
        public string AddContentReplyLoadTypeInContentPageCssClass { get; set; }
        public string IncludeBoxCssClass { get; set; }
        public string IncludeCaptchaCssClass { get; set; }
        public string IncludeCalendarCssClass { get; set; }
        public string IncludeFileViewerCssClass { get; set; }
        public string IncludeWysiwygCssClass { get; set; }

        public string ContentInMainPageAttribute { get; set; }
        public string ContentPerPageAttribute { get; set; }
        public string CommentInContentAttribute { get; set; }
        public string CommentReplyInCommentAttribute { get; set; }
        public string RowInMainTableAttribute { get; set; }
        public string RowPerTableAttribute { get; set; }
        public string ContentTextCharacterLengthAttribute { get; set; }
        public string SitePathAttribute { get; set; }
        public string NullLanguageSuffixAttribute { get; set; }
        public string CornHourDurationAttribute { get; set; }
        public string ReadMoreStatusAttribute { get; set; }
        public string DefaultSiteAttribute { get; set; }
        public string DefaultPageAttribute { get; set; }
        public string DefaultSiteLanguageAttribute { get; set; }
        public string DefaultAdminLanguageAttribute { get; set; }
        public string DefaultSiteStyleAttribute { get; set; }
        public string DefaultSiteTemplateAttribute { get; set; }
        public string DefaultAdminStyleAttribute { get; set; }
        public string DefaultAdminTemplateAttribute { get; set; }
        public string DefaultSystemAttribute { get; set; }
        public string DefaultComponentAttribute { get; set; }
        public string ContentPageNumberLocationAttribute { get; set; }
        public string CommentInAddCommentBoxLocationAttribute { get; set; }
        public string AddCommentLoadTypeInMainPageAttribute { get; set; }
        public string AddContentReplyLoadTypeInMainPageAttribute { get; set; }
        public string AddCommentLoadTypeInContentPageAttribute { get; set; }
        public string AddContentReplyLoadTypeInContentPageAttribute { get; set; }
        public string IncludeBoxAttribute { get; set; }
        public string IncludeCaptchaAttribute { get; set; }
        public string CommentTypeAttribute { get; set; }
        public string IncludeCalendarAttribute { get; set; }
        public string IncludeFileViewerAttribute { get; set; }
        public string IncludeWysiwygAttribute { get; set; }

        public List<string> PropertiesEvaluateErrorList;
        public List<string> ViewEvaluateErrorList;
        public List<string> IncludeEvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindPropertiesEvaluateError = false;
        public bool FindViewEvaluateError = false;
        public bool FindIncludeEvaluateError = false;

        public void SetValue()
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/properties/");
            PropertiesLanguage = aol.GetAddOnsLanguage("properties");
            SaveIncludeLanguage = aol.GetAddOnsLanguage("save_include");
            SavePropertiesLanguage = aol.GetAddOnsLanguage("save_properties");
            SaveViewLanguage = aol.GetAddOnsLanguage("save_view");
            ActiveContentPageNumberLanguage = aol.GetAddOnsLanguage("active_content_page_number");
            ActiveScheduledDelayLanguage = aol.GetAddOnsLanguage("active_scheduled_delay");
            ActiveScheduledLoadLanguage = aol.GetAddOnsLanguage("active_scheduled_load");
            ActiveScheduledTimerLanguage = aol.GetAddOnsLanguage("active_scheduled_timer");
            ActiveScheduledTasksLanguage = aol.GetAddOnsLanguage("active_scheduled_tasks");
            ActiveAddPluginVariantNoteLanguage = aol.GetAddOnsLanguage("active_add_plugin_variant_note");
            ActiveAddModuleVariantNoteLanguage = aol.GetAddOnsLanguage("active_add_module_variant_note");
            ActiveAddFetchVariantNoteLanguage = aol.GetAddOnsLanguage("active_add_fetch_variant_note");
            ActiveAddItemVariantNoteLanguage = aol.GetAddOnsLanguage("active_add_item_variant_note");
            ActiveServerRefreshLanguage = aol.GetAddOnsLanguage("active_server_refresh");
            CreateExternalLinkForAdminClientLanguageVariantLanguage = aol.GetAddOnsLanguage("create_external_link_for_admin_client_language_variant");
            CreateExternalLinkForAdminClientVariantLanguage = aol.GetAddOnsLanguage("create_external_link_for_admin_client_variant");
            CreateExternalLinkForAdminViewStyleLanguage = aol.GetAddOnsLanguage("create_external_link_for_admin_view_style");
            CreateExternalLinkForCurrentViewStyleLanguage = aol.GetAddOnsLanguage("create_external_link_for_current_view_style");
            CreateExternalLinkForSiteClientLanguageVariantLanguage = aol.GetAddOnsLanguage("create_external_link_for_site_client_language_variant");
            CreateExternalLinkForSiteClientVariantLanguage = aol.GetAddOnsLanguage("create_external_link_for_site_client_variant");
            CreateExternalLinkForSiteViewStyleLanguage = aol.GetAddOnsLanguage("create_external_link_for_site_view_style");
            CreateExternalLinkForUserViewStyleLanguage = aol.GetAddOnsLanguage("create_external_link_for_user_view_style");
            ShowAddCommentInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_add_comment_in_content_in_content_page");
            ShowAddCommentInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_add_comment_in_content_in_main_page");
            ShowAddContentReplyInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_add_content_reply_in_content_in_content_page");
            ShowAddContentReplyInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_add_content_reply_in_content_in_main_page");
            ShowAllSubCategoryWhenSelectFatherCategoryLanguage = aol.GetAddOnsLanguage("show_all_sub_category_when_select_father_category");
            ShowAttachmentInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_attachment_in_content_in_content_page");
            ShowAttachmentInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_attachment_in_content_in_main_page");
            ShowAuthorNameInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_author_name_in_content_in_content_page");
            ShowAuthorNameInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_author_name_in_content_in_main_page");
            ShowCategoryNameInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_category_name_in_content_in_content_page");
            ShowCategoryNameInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_category_name_in_content_in_main_page");
            ShowCommentInAddCommentBoxLanguage = aol.GetAddOnsLanguage("show_comment_in_add_comment_box");
            ShowCommentInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_comment_in_content_in_content_page");
            ShowCommentInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_comment_in_content_in_main_page");
            ShowContentKeywordsInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_content_keywords_in_content_in_content_page");
            ShowContentKeywordsInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_content_keywords_in_content_in_main_page");
            ShowContentReplyInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_content_reply_in_content_in_content_page");
            ShowContentReplyInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_content_reply_in_content_in_main_page");
            ShowDateInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_date_in_content_in_content_page");
            ShowDateInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_date_in_content_in_main_page");
            ShowSiteNameLanguage = aol.GetAddOnsLanguage("show_site_name");
            ShowSiteSlogonNameLanguage = aol.GetAddOnsLanguage("show_site_slogan_name");
            ShowTimeInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_time_in_content_in_content_page");
            ShowTimeInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_time_in_content_in_main_page");
            ShowTitleInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_title_in_content_in_content_page");
            ShowTitleInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_title_in_content_in_main_page");
            ShowUseCookieMessageAlertLanguage = aol.GetAddOnsLanguage("show_use_cookie_message_alert");
            ShowVisitInContentInContentPageLanguage = aol.GetAddOnsLanguage("show_visit_in_content_in_content_page");
            ShowVisitInContentInMainPageLanguage = aol.GetAddOnsLanguage("show_visit_in_content_in_main_page");
            UseAdminClientLanguageVariantLanguage = aol.GetAddOnsLanguage("use_admin_client_language_variant");
            UseAdminClientVariantLanguage = aol.GetAddOnsLanguage("use_admin_client_variant");
            UseAjaxForContentPageNumberLanguage = aol.GetAddOnsLanguage("use_ajax_for_content_page_number");
            UseReadMoreLanguage = aol.GetAddOnsLanguage("use_read_more");
            UseSiteAutoResizeLanguage = aol.GetAddOnsLanguage("use_site_auto_resize");
            UseSiteClientLanguageVariantLanguage = aol.GetAddOnsLanguage("use_site_client_language_variant");
            UseSiteClientVariantLanguage = aol.GetAddOnsLanguage("use_site_client_variant");
            UseViewStyleLanguage = aol.GetAddOnsLanguage("use_view_style");
            AddCommentLoadTypeInContentPageLanguage = aol.GetAddOnsLanguage("add_comment_load_type_in_content_page");
            AddCommentLoadTypeInMainPageLanguage = aol.GetAddOnsLanguage("add_comment_load_type_in_main_page");
            AddContentReplyLoadTypeInContentPageLanguage = aol.GetAddOnsLanguage("add_content_reply_load_type_in_content_page");
            AddContentReplyLoadTypeInMainPageLanguage = aol.GetAddOnsLanguage("add_content_reply_load_type_in_main_page");
            CommentInContentLanguage = aol.GetAddOnsLanguage("comment_in_content");
            CommentReplyInCommentLanguage = aol.GetAddOnsLanguage("comment_reply_in_comment");
            ContentInMainPageLanguage = aol.GetAddOnsLanguage("content_in_main_page");
            ContentPageNumberLocationLanguage = aol.GetAddOnsLanguage("content_page_number_location");
            ContentPerPageLanguage = aol.GetAddOnsLanguage("content_per_page");
            ContentTextCharacterLengthLanguage = aol.GetAddOnsLanguage("content_text_character_length");
            CornHourDurationLanguage = aol.GetAddOnsLanguage("corn_hour_duration");
            DefaultAdminLanguageLanguage = aol.GetAddOnsLanguage("default_admin_language");
            DefaultAdminStyleLanguage = aol.GetAddOnsLanguage("default_admin_style");
            DefaultAdminTemplateLanguage = aol.GetAddOnsLanguage("default_admin_template");
            DefaultComponentLanguage = aol.GetAddOnsLanguage("default_component");
            DefaultPageLanguage = aol.GetAddOnsLanguage("default_page");
            DefaultSiteLanguage = aol.GetAddOnsLanguage("default_site");
            DefaultSiteLanguageLanguage = aol.GetAddOnsLanguage("default_site_language");
            DefaultSiteStyleLanguage = aol.GetAddOnsLanguage("default_site_style");
            DefaultSiteTemplateLanguage = aol.GetAddOnsLanguage("default_site_template");
            DefaultSystemLanguage = aol.GetAddOnsLanguage("default_system");
            IncludeBoxLanguage = aol.GetAddOnsLanguage("include_box");
            IncludeCalendarLanguage = aol.GetAddOnsLanguage("include_calendar");
            IncludeCaptchaLanguage = aol.GetAddOnsLanguage("include_captcha");
            IncludeFileViewerLanguage = aol.GetAddOnsLanguage("include_file_viewer");
            IncludeLanguage = aol.GetAddOnsLanguage("include");
            IncludeWysiwygLanguage = aol.GetAddOnsLanguage("include_wysiwyg");
            NullLanguageSuffixLanguage = aol.GetAddOnsLanguage("null_language_suffix");
            ReadMoreStatusLanguage = aol.GetAddOnsLanguage("read_more_status");
            RowInMainTableLanguage = aol.GetAddOnsLanguage("row_in_main_table");
            RowPerTableLanguage = aol.GetAddOnsLanguage("row_per_table");
            SitePathLanguage = aol.GetAddOnsLanguage("site_path");
            ViewLanguage = aol.GetAddOnsLanguage("view");


            // Set Current Value
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            XmlNode node = doc.SelectSingleNode("elanat_root/properties");

            ContentInMainPageValue = node["content_in_main_page"].Attributes["value"].Value;
            ContentPerPageValue = node["content_per_page"].Attributes["value"].Value;
            CommentInContentValue = node["comment_in_content"].Attributes["value"].Value;
            CommentReplyInCommentValue = node["comment_reply_in_comment"].Attributes["value"].Value;
            RowInMainTableValue = node["row_in_main_table"].Attributes["value"].Value;
            RowPerTableValue = node["row_per_table"].Attributes["value"].Value;
            ContentTextCharacterLengthValue = node["content_text_character_length"].Attributes["value"].Value;
            SitePathValue = node["site_path"].InnerText;
            NullLanguageSuffixValue = node["null_language_suffix"].InnerText;
            CornHourDurationValue = node["corn_hour_duration"].Attributes["value"].Value;
            UseSiteAutoResizeValue = node["use_site_auto_resize"].Attributes["active"].Value == "true";
            UseReadMoreValue = node["use_read_more"].Attributes["active"].Value == "true";
            ShowAllSubCategoryWhenSelectFatherCategoryValue = node["show_all_sub_category_when_select_father_category"].Attributes["active"].Value == "true";
            ShowUseCookieMessageAlertValue = node["show_use_cookie_message_alert"].Attributes["active"].Value == "true";
            UseViewStyleValue = node["use_view_style"].Attributes["active"].Value == "true";
            UseSiteClientVariantValue = node["use_site_client_variant"].Attributes["active"].Value == "true";
            CreateExternalLinkForSiteClientVariantValue = node["create_external_link_for_site_client_variant"].Attributes["active"].Value == "true";
            UseAdminClientVariantValue = node["use_admin_client_variant"].Attributes["active"].Value == "true";
            CreateExternalLinkForAdminClientVariantValue = node["create_external_link_for_admin_client_variant"].Attributes["active"].Value == "true";
            UseSiteClientLanguageVariantValue = node["use_site_client_language_variant"].Attributes["active"].Value == "true";
            CreateExternalLinkForSiteClientLanguageVariantValue = node["create_external_link_for_site_client_language_variant"].Attributes["active"].Value == "true";
            UseAdminClientLanguageVariantValue = node["use_admin_client_language_variant"].Attributes["active"].Value == "true";
            CreateExternalLinkForSiteViewStyleValue = node["create_external_link_for_site_view_style"].Attributes["active"].Value == "true";
            CreateExternalLinkForAdminViewStyleValue = node["create_external_link_for_admin_view_style"].Attributes["active"].Value == "true";
            CreateExternalLinkForUserViewStyleValue = node["create_external_link_for_user_view_style"].Attributes["active"].Value == "true";
            CreateExternalLinkForCurrentViewStyleValue = node["create_external_link_for_current_view_style"].Attributes["active"].Value == "true";
            CreateExternalLinkForAdminClientLanguageVariantValue = node["create_external_link_for_admin_client_language_variant"].Attributes["active"].Value == "true";
            ActiveContentPageNumberValue = node["content_page_number"].Attributes["active"].Value == "true";
            UseAjaxForContentPageNumberValue = node["content_page_number"].Attributes["use_ajax"].Value == "true";
            ShowCommentInAddCommentBoxValue = node["show_comment_in_add_comment_box"].Attributes["active"].Value == "true";
            ActiveServerRefreshValue = node["server_refresh"].Attributes["active"].Value == "true";
            ActiveScheduledDelayValue = node["scheduled_delay"].Attributes["active"].Value == "true";
            ActiveScheduledLoadValue = node["scheduled_load"].Attributes["active"].Value == "true";
            ActiveScheduledTimerValue = node["scheduled_timer"].Attributes["active"].Value == "true";
            ActiveScheduledTasksValue = node["scheduled_tasks"].Attributes["active"].Value == "true";
            ActiveAddPluginVariantNoteValue = node["add_plugin_variant_note"].Attributes["active"].Value == "true";
            ActiveAddModuleVariantNoteValue = node["add_module_variant_note"].Attributes["active"].Value == "true";
            ActiveAddFetchVariantNoteValue = node["add_fetch_variant_note"].Attributes["active"].Value == "true";
            ActiveAddItemVariantNoteValue = node["add_item_variant_note"].Attributes["active"].Value == "true";
            DefaultSystemOptionListSelectedValue = node["default_system"].Attributes["value"].Value;
            DefaultComponentOptionListSelectedValue = node["default_component"].Attributes["value"].Value;
            DefaultSiteOptionListSelectedValue = node["default_site"].Attributes["value"].Value;
            DefaultPageOptionListSelectedValue = node["default_page"].Attributes["value"].Value;
            DefaultAdminLanguageOptionListSelectedValue = node["default_admin_language"].Attributes["value"].Value;
            DefaultSiteLanguageOptionListSelectedValue = node["default_site_language"].Attributes["value"].Value;
            DefaultSiteStyleOptionListSelectedValue = node["default_site_style"].Attributes["value"].Value;
            DefaultSiteTemplateOptionListSelectedValue = node["default_site_template"].Attributes["value"].Value;
            DefaultAdminStyleOptionListSelectedValue = node["default_admin_style"].Attributes["value"].Value;
            DefaultAdminTemplateOptionListSelectedValue = node["default_admin_template"].Attributes["value"].Value;
            ContentPageNumberLocationOptionListSelectedValue = node["content_page_number"].Attributes["location"].Value;

            node = doc.SelectSingleNode("elanat_root/view");

            ShowSiteNameValue = node["show_site_name"].Attributes["active"].Value == "true";
            ShowSiteSlogonNameValue = node["show_site_slogan_name"].Attributes["active"].Value == "true";

            node = doc.SelectSingleNode("elanat_root/view/main_page");

            ShowContentKeywordsInContentInMainPageValue = node["show_content_keywords_in_content"].Attributes["active"].Value == "true";
            ShowAttachmentInContentInMainPageValue = node["show_attachment_in_content"].Attributes["active"].Value == "true";
            ShowCommentInContentInMainPageValue = node["show_comment_in_content"].Attributes["active"].Value == "true";
            ShowAddCommentInContentInMainPageValue = node["show_add_comment_in_content"].Attributes["active"].Value == "true";
            AddCommentLoadTypeInMainPageOptionListSelectedValue = node["show_add_comment_in_content"].Attributes["load_with"].Value;
            ShowAddContentReplyInContentInMainPageValue = node["show_add_content_reply_in_content"].Attributes["active"].Value == "true";
            AddContentReplyLoadTypeInMainPageOptionListSelectedValue = node["show_add_content_reply_in_content"].Attributes["load_with"].Value;
            ShowContentReplyInContentInMainPageValue = node["show_content_reply_in_content"].Attributes["active"].Value == "true";
            ShowAuthorNameInContentInMainPageValue = node["show_author_name_in_content"].Attributes["active"].Value == "true";
            ShowCategoryNameInContentInMainPageValue = node["show_category_name_in_content"].Attributes["active"].Value == "true";
            ShowTitleInContentInMainPageValue = node["show_title_in_content"].Attributes["active"].Value == "true";
            ShowDateInContentInMainPageValue = node["show_date_in_content"].Attributes["active"].Value == "true";
            ShowTimeInContentInMainPageValue = node["show_time_in_content"].Attributes["active"].Value == "true";
            ShowVisitInContentInMainPageValue = node["show_visit_in_content"].Attributes["active"].Value == "true";

            node = doc.SelectSingleNode("elanat_root/view/content_page");

            ShowContentKeywordsInContentInContentPageValue = node["show_content_keywords_in_content"].Attributes["active"].Value == "true";
            ShowAttachmentInContentInContentPageValue = node["show_attachment_in_content"].Attributes["active"].Value == "true";
            ShowCommentInContentInContentPageValue = node["show_comment_in_content"].Attributes["active"].Value == "true";
            ShowAddCommentInContentInContentPageValue = node["show_add_comment_in_content"].Attributes["active"].Value == "true";
            AddCommentLoadTypeInContentPageOptionListSelectedValue = node["show_add_comment_in_content"].Attributes["load_with"].Value;
            ShowAddContentReplyInContentInContentPageValue = node["show_add_content_reply_in_content"].Attributes["active"].Value == "true";
            AddContentReplyLoadTypeInContentPageOptionListSelectedValue = node["show_add_content_reply_in_content"].Attributes["load_with"].Value;
            ShowContentReplyInContentInContentPageValue = node["show_content_reply_in_content"].Attributes["active"].Value == "true";
            ShowAuthorNameInContentInContentPageValue = node["show_author_name_in_content"].Attributes["active"].Value == "true";
            ShowCategoryNameInContentInContentPageValue = node["show_category_name_in_content"].Attributes["active"].Value == "true";
            ShowTitleInContentInContentPageValue = node["show_title_in_content"].Attributes["active"].Value == "true";
            ShowDateInContentInContentPageValue = node["show_date_in_content"].Attributes["active"].Value == "true";
            ShowTimeInContentInContentPageValue = node["show_time_in_content"].Attributes["active"].Value == "true";
            ShowVisitInContentInContentPageValue = node["show_visit_in_content"].Attributes["active"].Value == "true";

            node = doc.SelectSingleNode("elanat_root/default_include_path");

            IncludeBoxOptionListSelectedValue = node["box_path"].InnerText;
            IncludeCaptchaOptionListSelectedValue = node["captcha_path"].InnerText;
            IncludeCalendarOptionListSelectedValue = node["calendar_path"].InnerText;
            IncludeFileViewerOptionListSelectedValue = node["file_viewer_path"].InnerText;
            IncludeWysiwygOptionListSelectedValue = node["wysiwyg_path"].InnerText;

            // Set Read More Status Item
            ListClass.Content lcc = new ListClass.Content();
            lcc.FillReadMoreStatusListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ReadMoreStatusOptionListValue += lcc.ReadMoreStatusListItem.HtmlInputToOptionTag(ReadMoreStatusOptionListSelectedValue);

            // Set System Item
            ListClass.System lcsys = new ListClass.System();
            lcsys.FillSystemListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultSystemOptionListValue += lcsys.SystemListItem.HtmlInputToOptionTag(DefaultSystemOptionListSelectedValue);

            // Set Component Item
            ListClass.Component lccomp = new ListClass.Component();
            lccomp.FillComponentNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultComponentOptionListValue += lccomp.ComponentNameListItem.HtmlInputToOptionTag(DefaultComponentOptionListSelectedValue);

            // Set Site Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteNameListItem();
            DefaultSiteOptionListValue += lcs.SiteNameListItem.HtmlInputToOptionTag(DefaultSiteOptionListSelectedValue);

            // Set Page Item
            ListClass.Page lcp = new ListClass.Page();
            lcp.FillPageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultPageOptionListValue += lcp.PageNameListItem.HtmlInputToOptionTag(DefaultPageOptionListSelectedValue);

            ListClass.LanguageList lcl = new ListClass.LanguageList();

            // Set Admin Language Item
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultAdminLanguageOptionListValue += lcl.LanguageNameListItem.HtmlInputToOptionTag(DefaultAdminLanguageOptionListSelectedValue);

            // Set Site Language Item
            DefaultSiteLanguageOptionListValue += lcl.LanguageNameListItem.HtmlInputToOptionTag(DefaultSiteLanguageOptionListSelectedValue);

            // Set Site Style Name Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultSiteStyleOptionListValue += lcss.SiteStyleNameListItem.HtmlInputToOptionTag(DefaultSiteStyleOptionListSelectedValue);

            // Set Site Template Name Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultSiteTemplateOptionListValue += lcst.SiteTemplateNameListItem.HtmlInputToOptionTag(DefaultSiteTemplateOptionListSelectedValue);

            // Set Admin Style Name Item
            ListClass.AdminStyle lcas = new ListClass.AdminStyle();
            lcas.FillAdminStyleNameListItem();
            DefaultAdminStyleOptionListValue += lcas.AdminStyleNameListItem.HtmlInputToOptionTag(DefaultAdminStyleOptionListSelectedValue);

            // Set Admin Template Name Item
            ListClass.AdminTemplate lcat = new ListClass.AdminTemplate();
            lcat.FillAdminTemplateNameListItem();
            DefaultAdminTemplateOptionListValue += lcat.AdminTemplateNameListItem.HtmlInputToOptionTag(DefaultAdminTemplateOptionListSelectedValue);

            // Set Content Page Number Location Item
            lcc.FillContentPageNumberLocationListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContentPageNumberLocationOptionListValue += lcc.ContentPageNumberLocationListItem.HtmlInputToOptionTag(ContentPageNumberLocationOptionListSelectedValue);

            // Set Dynamic Server Page Load Type Item
            ListClass.PageLoadType lcplt = new ListClass.PageLoadType();
            lcplt.FillDynamicServerPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            AddContentReplyLoadTypeInMainPageOptionListValue += lcplt.DynamicServerPageLoadTypeListItem.HtmlInputToOptionTag(AddContentReplyLoadTypeInMainPageOptionListSelectedValue);
            AddCommentLoadTypeInMainPageOptionListValue += lcplt.DynamicServerPageLoadTypeListItem.HtmlInputToOptionTag(AddCommentLoadTypeInMainPageOptionListSelectedValue);
            AddContentReplyLoadTypeInContentPageOptionListValue += lcplt.DynamicServerPageLoadTypeListItem.HtmlInputToOptionTag(AddContentReplyLoadTypeInContentPageOptionListSelectedValue);
            AddCommentLoadTypeInContentPageOptionListValue += lcplt.DynamicServerPageLoadTypeListItem.HtmlInputToOptionTag(AddCommentLoadTypeInContentPageOptionListSelectedValue);

            ListClass.Include lci = new ListClass.Include();

            // Set Include Box Item
            lci.FillIncludeBoxListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            IncludeBoxOptionListValue += lci.IncludeBoxListItem.HtmlInputToOptionTag(IncludeBoxOptionListSelectedValue);

            // Set Include Captcha Item
            lci.FillIncludeCaptchaListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            IncludeCaptchaOptionListValue += lci.IncludeCaptchaListItem.HtmlInputToOptionTag(IncludeCaptchaOptionListSelectedValue);

            // Set Include Calendar Item
            lci.FillIncludeCalendarListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            IncludeCalendarOptionListValue += lci.IncludeCalendarListItem.HtmlInputToOptionTag(IncludeCalendarOptionListSelectedValue);

            // Set Include File Viewer Item
            lci.FillIncludeFileViewerListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            IncludeFileViewerOptionListValue += lci.IncludeFileViewerListItem.HtmlInputToOptionTag(IncludeFileViewerOptionListSelectedValue);

            // Set Include Wysiwyg Item
            lci.FillIncludeWysiwygListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            IncludeWysiwygOptionListValue += lci.IncludeWysiwygListItem.HtmlInputToOptionTag(IncludeWysiwygOptionListSelectedValue);

            // Set Before After Location Item
            ListClass.Location lcloc = new ListClass.Location();
            lcloc.FillBeforeAfterLocationListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            CommentInAddCommentBoxLocationOptionListValue += lcloc.BeforeAfterLocationListItem.HtmlInputToOptionTag(CommentInAddCommentBoxLocationOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ContentInMainPage", "");
            InputRequest.Add("txt_ContentPerPage", "");
            InputRequest.Add("txt_CommentInContent", "");
            InputRequest.Add("txt_CommentReplyInComment", "");
            InputRequest.Add("txt_RowInMainTable", "");
            InputRequest.Add("txt_RowPerTable", "");
            InputRequest.Add("txt_ContentTextCharacterLength", "");
            InputRequest.Add("txt_SitePath", "");
            InputRequest.Add("txt_NullLanguageSuffix", "");
            InputRequest.Add("txt_CornHourDuration", "");
            InputRequest.Add("ddlst_ReadMoreStatus", ReadMoreStatusOptionListValue);
            InputRequest.Add("ddlst_DefaultSite", DefaultSiteOptionListValue);
            InputRequest.Add("ddlst_DefaultPage", DefaultPageOptionListValue);
            InputRequest.Add("ddlst_DefaultSiteLanguage", DefaultSiteLanguageOptionListValue);
            InputRequest.Add("ddlst_DefaultAdminLanguage", DefaultAdminLanguageOptionListValue);
            InputRequest.Add("ddlst_DefaultSiteStyle", DefaultSiteStyleOptionListValue);
            InputRequest.Add("ddlst_DefaultSiteTemplate", DefaultSiteTemplateOptionListValue);
            InputRequest.Add("ddlst_DefaultAdminStyle", DefaultAdminStyleOptionListValue);
            InputRequest.Add("ddlst_DefaultAdminTemplate", DefaultAdminTemplateOptionListValue);
            InputRequest.Add("ddlst_DefaultSystem", DefaultSystemOptionListValue);
            InputRequest.Add("ddlst_DefaultComponent", DefaultComponentOptionListValue);
            InputRequest.Add("ddlst_ContentPageNumberLocation", ContentPageNumberLocationOptionListValue);
            InputRequest.Add("ddlst_CommentInAddCommentBoxLocation", CommentInAddCommentBoxLocationOptionListValue);
            InputRequest.Add("ddlst_AddCommentLoadTypeInMainPage", AddCommentLoadTypeInMainPageOptionListValue);
            InputRequest.Add("ddlst_AddContentReplyLoadTypeInMainPage", AddContentReplyLoadTypeInMainPageOptionListValue);
            InputRequest.Add("ddlst_AddCommentLoadTypeInContentPage", AddCommentLoadTypeInContentPageOptionListValue);
            InputRequest.Add("ddlst_AddContentReplyLoadTypeInContentPage", AddContentReplyLoadTypeInContentPageOptionListValue);
            InputRequest.Add("ddlst_IncludeBox", IncludeBoxOptionListValue);
            InputRequest.Add("ddlst_IncludeCaptcha", IncludeCaptchaOptionListValue);
            InputRequest.Add("ddlst_IncludeCalendar", IncludeCalendarOptionListValue);
            InputRequest.Add("ddlst_IncludeFileViewer", IncludeFileViewerOptionListValue);
            InputRequest.Add("ddlst_IncludeWysiwyg", IncludeWysiwygOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/properties/", "*");

            ContentInMainPageAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentInMainPage");
            ContentPerPageAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentPerPage");
            CommentInContentAttribute += vc.ImportantInputAttribute.GetValue("txt_CommentInContent");
            CommentReplyInCommentAttribute += vc.ImportantInputAttribute.GetValue("txt_CommentReplyInComment");
            RowInMainTableAttribute += vc.ImportantInputAttribute.GetValue("txt_RowInMainTable");
            RowPerTableAttribute += vc.ImportantInputAttribute.GetValue("txt_RowPerTable");
            ContentTextCharacterLengthAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentTextCharacterLength");
            SitePathAttribute += vc.ImportantInputAttribute.GetValue("txt_SitePath");
            NullLanguageSuffixAttribute += vc.ImportantInputAttribute.GetValue("txt_NullLanguageSuffix");
            CornHourDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_CornHourDuration");
            ReadMoreStatusAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ReadMoreStatus");
            DefaultSiteAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultSite");
            DefaultPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultPage");
            DefaultSiteLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultSiteLanguage");
            DefaultAdminLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultAdminLanguage");
            DefaultSiteStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultSiteStyle");
            DefaultSiteTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultSiteTemplate");
            DefaultAdminStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultAdminStyle");
            DefaultAdminTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultAdminTemplate");
            DefaultSystemAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultSystem");
            DefaultComponentAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultComponent");
            ContentPageNumberLocationAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ContentPageNumberLocation");
            CommentInAddCommentBoxLocationAttribute += vc.ImportantInputAttribute.GetValue("ddlst_CommentInAddCommentBoxLocation");
            AddCommentLoadTypeInMainPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_AddCommentLoadTypeInMainPage");
            AddContentReplyLoadTypeInMainPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_AddContentReplyLoadTypeInMainPage");
            AddCommentLoadTypeInContentPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_AddCommentLoadTypeInContentPage");
            AddContentReplyLoadTypeInContentPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_AddContentReplyLoadTypeInContentPage");
            IncludeBoxAttribute += vc.ImportantInputAttribute.GetValue("ddlst_IncludeBox");
            IncludeCaptchaAttribute += vc.ImportantInputAttribute.GetValue("ddlst_IncludeCaptcha");
            IncludeCalendarAttribute += vc.ImportantInputAttribute.GetValue("ddlst_IncludeCalendar");
            IncludeFileViewerAttribute += vc.ImportantInputAttribute.GetValue("ddlst_IncludeFileViewer");
            IncludeWysiwygAttribute += vc.ImportantInputAttribute.GetValue("ddlst_IncludeWysiwyg");

            ContentInMainPageCssClass = ContentInMainPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentInMainPage"));
            ContentPerPageCssClass = ContentPerPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentPerPage"));
            CommentInContentCssClass = CommentInContentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CommentInContent"));
            CommentReplyInCommentCssClass = CommentReplyInCommentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CommentReplyInComment"));
            RowInMainTableCssClass = RowInMainTableCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RowInMainTable"));
            RowPerTableCssClass = RowPerTableCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RowPerTable"));
            ContentTextCharacterLengthCssClass = ContentTextCharacterLengthCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentTextCharacterLength"));
            SitePathCssClass = SitePathCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SitePath"));
            NullLanguageSuffixCssClass = NullLanguageSuffixCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_NullLanguageSuffix"));
            CornHourDurationCssClass = CornHourDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CornHourDuration"));
            ReadMoreStatusCssClass = ReadMoreStatusCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ReadMoreStatus"));
            DefaultSiteCssClass = DefaultSiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultSite"));
            DefaultPageCssClass = DefaultPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultPage"));
            DefaultSiteLanguageCssClass = DefaultSiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultSiteLanguage"));
            DefaultAdminLanguageCssClass = DefaultAdminLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultAdminLanguage"));
            DefaultSiteStyleCssClass = DefaultSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultSiteStyle"));
            DefaultSiteTemplateCssClass = DefaultSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultSiteTemplate"));
            DefaultAdminStyleCssClass = DefaultAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultAdminStyle"));
            DefaultAdminTemplateCssClass = DefaultAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultAdminTemplate"));
            DefaultSystemCssClass = DefaultSystemCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultSystem"));
            DefaultComponentCssClass = DefaultComponentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultComponent"));
            ContentPageNumberLocationCssClass = ContentPageNumberLocationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ContentPageNumberLocation"));
            CommentInAddCommentBoxLocationCssClass = CommentInAddCommentBoxLocationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_CommentInAddCommentBoxLocation"));
            AddCommentLoadTypeInMainPageCssClass = AddCommentLoadTypeInMainPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_AddCommentLoadTypeInMainPage"));
            AddContentReplyLoadTypeInMainPageCssClass = AddContentReplyLoadTypeInMainPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_AddContentReplyLoadTypeInMainPage"));
            AddCommentLoadTypeInContentPageCssClass = AddCommentLoadTypeInContentPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_AddCommentLoadTypeInContentPage"));
            AddContentReplyLoadTypeInContentPageCssClass = AddContentReplyLoadTypeInContentPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_AddContentReplyLoadTypeInContentPage"));
            IncludeBoxCssClass = IncludeBoxCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_IncludeBox"));
            IncludeCaptchaCssClass = IncludeCaptchaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_IncludeCaptcha"));
            IncludeCalendarCssClass = IncludeCalendarCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_IncludeCalendar"));
            IncludeFileViewerCssClass = IncludeFileViewerCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_IncludeFileViewer"));
            IncludeWysiwygCssClass = IncludeWysiwygCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_IncludeWysiwyg"));
        }

        public void PropertiesEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "properties", StaticObject.AdminPath + "/properties/");

            PropertiesEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindPropertiesEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void ViewEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "view", StaticObject.AdminPath + "/properties/");

            ViewEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindViewEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void IncludeEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "include", StaticObject.AdminPath + "/properties/");

            IncludeEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindIncludeEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveProperties()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/properties/content_in_main_page").Attributes["value"].Value = ContentInMainPageValue;
            doc.SelectSingleNode("elanat_root/properties/content_per_page").Attributes["value"].Value = ContentPerPageValue;
            doc.SelectSingleNode("elanat_root/properties/comment_in_content").Attributes["value"].Value = CommentInContentValue;
            doc.SelectSingleNode("elanat_root/properties/comment_reply_in_comment").Attributes["value"].Value = CommentReplyInCommentValue;
            doc.SelectSingleNode("elanat_root/properties/row_in_main_table").Attributes["value"].Value = RowInMainTableValue;
            doc.SelectSingleNode("elanat_root/properties/row_per_table").Attributes["value"].Value = RowPerTableValue;
            doc.SelectSingleNode("elanat_root/properties/use_site_auto_resize").Attributes["active"].Value = (UseSiteAutoResizeValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_read_more").Attributes["active"].Value = (UseReadMoreValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_read_more").Attributes["load_type"].Value = ReadMoreStatusOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/content_text_character_length").Attributes["value"].Value = ContentTextCharacterLengthValue;
            doc.SelectSingleNode("elanat_root/properties/show_all_sub_category_when_select_father_category").Attributes["active"].Value = (ShowAllSubCategoryWhenSelectFatherCategoryValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/site_path").InnerText = SitePathValue;
            doc.SelectSingleNode("elanat_root/properties/null_language_suffix").InnerText = NullLanguageSuffixValue;
            doc.SelectSingleNode("elanat_root/properties/default_system").Attributes["value"].Value = DefaultSystemOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_component").Attributes["value"].Value = DefaultComponentOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_site").Attributes["value"].Value = DefaultSiteOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_page").Attributes["value"].Value = DefaultPageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_admin_language").Attributes["value"].Value = DefaultAdminLanguageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_site_language").Attributes["value"].Value = DefaultSiteLanguageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_site_style").Attributes["value"].Value = DefaultSiteStyleOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_site_template").Attributes["value"].Value = DefaultSiteTemplateOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_admin_style").Attributes["value"].Value = DefaultAdminStyleOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/default_admin_template").Attributes["value"].Value = DefaultAdminTemplateOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/show_use_cookie_message_alert").Attributes["active"].Value = (ShowUseCookieMessageAlertValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_view_style").Attributes["active"].Value = (UseReadMoreValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_site_client_variant").Attributes["active"].Value = (UseSiteClientVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_site_client_variant").Attributes["active"].Value = (CreateExternalLinkForSiteClientVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_admin_client_variant").Attributes["active"].Value = (UseAdminClientVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_admin_client_variant").Attributes["active"].Value = (CreateExternalLinkForAdminClientVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_site_client_language_variant").Attributes["active"].Value = (UseSiteClientLanguageVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_site_client_language_variant").Attributes["active"].Value = (CreateExternalLinkForSiteClientLanguageVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/use_admin_client_language_variant").Attributes["active"].Value = (UseAdminClientLanguageVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_site_view_style").Attributes["active"].Value = (CreateExternalLinkForSiteViewStyleValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_admin_view_style").Attributes["active"].Value = (CreateExternalLinkForAdminViewStyleValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_user_view_style").Attributes["active"].Value = (CreateExternalLinkForUserViewStyleValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_current_view_style").Attributes["active"].Value = (CreateExternalLinkForCurrentViewStyleValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/create_external_link_for_admin_client_language_variant").Attributes["active"].Value = (CreateExternalLinkForAdminClientLanguageVariantValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/content_page_number").Attributes["active"].Value = (ActiveContentPageNumberValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/content_page_number").Attributes["use_ajax"].Value = (UseAjaxForContentPageNumberValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/content_page_number").Attributes["location"].Value = ContentPageNumberLocationOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/show_comment_in_add_comment_box").Attributes["active"].Value = (ShowCommentInAddCommentBoxValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/show_comment_in_add_comment_box").Attributes["location"].Value = CommentInAddCommentBoxLocationOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/properties/server_refresh").Attributes["active"].Value = (ActiveServerRefreshValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/scheduled_delay").Attributes["active"].Value = (ActiveScheduledDelayValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/scheduled_load").Attributes["active"].Value = (ActiveScheduledLoadValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/scheduled_timer").Attributes["active"].Value = (ActiveScheduledTimerValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/scheduled_tasks").Attributes["active"].Value = (ActiveScheduledTasksValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/corn_hour_duration").Attributes["value"].Value = CornHourDurationValue;
            doc.SelectSingleNode("elanat_root/properties/add_plugin_variant_note").Attributes["active"].Value = (ActiveAddPluginVariantNoteValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/add_module_variant_note").Attributes["active"].Value = (ActiveAddModuleVariantNoteValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/add_fetch_variant_note").Attributes["active"].Value = (ActiveAddFetchVariantNoteValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/properties/add_item_variant_note").Attributes["active"].Value = (ActiveAddItemVariantNoteValue) ? "true" : "false";

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_properties", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("properties_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/properties/"), "success");
        }

        public void SaveView()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/view/show_site_name").Attributes["active"].Value = (ShowSiteNameValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/show_site_slogan_name").Attributes["active"].Value = (ShowSiteSlogonNameValue) ? "true" : "false";

            doc.SelectSingleNode("elanat_root/view/main_page/show_content_keywords_in_content").Attributes["active"].Value = (ShowContentKeywordsInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_attachment_in_content").Attributes["active"].Value = (ShowAttachmentInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_comment_in_content").Attributes["active"].Value = (ShowCommentInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_add_comment_in_content").Attributes["active"].Value = (ShowAddCommentInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_add_comment_in_content").Attributes["load_with"].Value = AddCommentLoadTypeInMainPageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/view/main_page/show_add_content_reply_in_content").Attributes["active"].Value = (ShowAddContentReplyInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_add_content_reply_in_content").Attributes["load_with"].Value = AddContentReplyLoadTypeInMainPageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/view/main_page/show_content_reply_in_content").Attributes["active"].Value = (ShowContentReplyInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_author_name_in_content").Attributes["active"].Value = (ShowAuthorNameInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_category_name_in_content").Attributes["active"].Value = (ShowCategoryNameInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_title_in_content").Attributes["active"].Value = (ShowTitleInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_date_in_content").Attributes["active"].Value = (ShowDateInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_time_in_content").Attributes["active"].Value = (ShowTimeInContentInMainPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/main_page/show_visit_in_content").Attributes["active"].Value = (ShowVisitInContentInMainPageValue) ? "true" : "false";

            doc.SelectSingleNode("elanat_root/view/content_page/show_content_keywords_in_content").Attributes["active"].Value = (ShowContentKeywordsInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_attachment_in_content").Attributes["active"].Value = (ShowAttachmentInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_comment_in_content").Attributes["active"].Value = (ShowCommentInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_add_comment_in_content").Attributes["active"].Value = (ShowAddCommentInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_add_comment_in_content").Attributes["load_with"].Value = AddCommentLoadTypeInContentPageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/view/content_page/show_add_content_reply_in_content").Attributes["active"].Value = (ShowAddContentReplyInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_add_content_reply_in_content").Attributes["load_with"].Value = AddContentReplyLoadTypeInContentPageOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/view/content_page/show_content_reply_in_content").Attributes["active"].Value = (ShowContentReplyInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_author_name_in_content").Attributes["active"].Value = (ShowAuthorNameInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_category_name_in_content").Attributes["active"].Value = (ShowCategoryNameInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_title_in_content").Attributes["active"].Value = (ShowTitleInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_date_in_content").Attributes["active"].Value = (ShowDateInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_time_in_content").Attributes["active"].Value = (ShowTimeInContentInContentPageValue) ? "true" : "false";
            doc.SelectSingleNode("elanat_root/view/content_page/show_visit_in_content").Attributes["active"].Value = (ShowVisitInContentInContentPageValue) ? "true" : "false";

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_view", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("view_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/properties/"), "success");
        }

        public void SaveInclude()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/default_include_path/box_path").InnerText = IncludeBoxOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/default_include_path/captcha_path").InnerText = IncludeCaptchaOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/default_include_path/calendar_path").InnerText = IncludeCalendarOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/default_include_path/file_viewer_path").InnerText = IncludeFileViewerOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/default_include_path/wysiwyg_path").InnerText = IncludeWysiwygOptionListSelectedValue;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_include", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("include_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/properties/"), "success");
        }
    }
}