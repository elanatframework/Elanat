using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminOptionsModel : CodeBehindModel
    {
        public string TestLanguage { get; set; }
        public string OptionsLanguage { get; set; }
        public string SaveActiveLanguage { get; set; }
        public string SaveCacheLanguage { get; set; }
        public string SaveDateAndTimeLanguage { get; set; }
        public string SaveDebugLanguage { get; set; }
        public string SaveDelayLanguage { get; set; }
        public string SaveEmailLanguage { get; set; }
        public string SaveFileAndDirectoryLanguage { get; set; }
        public string SaveSecurityLanguage { get; set; }
        public string AddCommentLanguage { get; set; }
        public string AutoCreateThumbnailImageLanguage { get; set; }
        public string CheckLastModifiedLanguage { get; set; }
        public string CheckServerCacheLanguage { get; set; }
        public string EmailUseHttpsLanguage { get; set; }
        public string InactiveSiteLanguage { get; set; }
        public string JustUseHttpsLanguage { get; set; }
        public string JustUseHttpsForAdminLanguage { get; set; }
        public string JustUseHttpsForLoginPageLanguage { get; set; }
        public string JustUseHttpsForSiteLanguage { get; set; }
        public string LockLoginForFirstLoginLanguage { get; set; }
        public string LoginActiveLanguage { get; set; }
        public string SaveLogsErrorLanguage { get; set; }
        public string SensitivityCaseCaptchaLanguage { get; set; }
        public string SignUpActiveLanguage { get; set; }
        public string UseAdminActivationLanguage { get; set; }
        public string UseClientCacheForDynamicPageLanguage { get; set; }
        public string UseClientCacheForStaticPageLanguage { get; set; }
        public string UseEmailActivationLanguage { get; set; }
        public string UseSecretKeyForLoginLanguage { get; set; }
        public string UseSensitivityCaseCaptchaLanguage { get; set; }
        public string UseVariantDebugLanguage { get; set; }
        public string WriteLogsErrorLanguage { get; set; }
        public string UseSiteMainCacheLanguage { get; set; }
        public string UseAdminMainCacheLanguage { get; set; }
        public string ActiveLanguage { get; set; }
        public string AdminDirectoryPathLanguage { get; set; }
        public string AdminLifeTimeLanguage { get; set; }
        public string AdminRoleCacheLanguage { get; set; }
        public string AdminRoleCacheTypeLanguage { get; set; }
        public string SiteMainCacheParametersLanguage { get; set; }
        public string AdminMainCacheParametersLanguage { get; set; }
        public string CacheLanguage { get; set; }
        public string CalendarLanguage { get; set; }
        public string CaptchaCharacterLanguage { get; set; }
        public string CaptchaCharacterCountFromLanguage { get; set; }
        public string CaptchaCharacterCountToLanguage { get; set; }
        public string CaptchaDelayLanguage { get; set; }
        public string CaptchaFontLanguage { get; set; }
        public string CaptchaFontSizeLanguage { get; set; }
        public string CaptchaHeightLanguage { get; set; }
        public string CaptchaNoiseLanguage { get; set; }
        public string CaptchaRepeatTimeLanguage { get; set; }
        public string CaptchaRotateTransformLanguage { get; set; }
        public string CaptchaWidthLanguage { get; set; }
        public string CaptchaAdminReleaseCountLanguage { get; set; }
        public string CaptchaMemberReleaseCountLanguage { get; set; }
        public string CaptchaGuestReleaseCountLanguage { get; set; }
        public string UseRobotDetectionLanguage { get; set; }
        public string RobotDetectionIpBlockDurationLanguage { get; set; }
        public string RobotDetectionResetTimeDurationLanguage { get; set; }
        public string RobotDetectionAdminRequestCountLanguage { get; set; }
        public string RobotDetectionMemberRequestCountLanguage { get; set; }
        public string RobotDetectionGuestRequestCountLanguage { get; set; }
        public string RobotDetectionAdminRequestAfterShowCaptchaCountLanguage { get; set; }
        public string RobotDetectionMemberRequestAfterShowCaptchaCountLanguage { get; set; }
        public string RobotDetectionGuestRequestAfterShowCaptchaCountLanguage { get; set; }
        public string ClientCacheForDynamicPageCacheLanguage { get; set; }
        public string ClientCacheForStaticPageCacheLanguage { get; set; }
        public string TextCreatorUseServerCacheLanguage { get; set; }
        public string TextCreatorUseClientCacheLanguage { get; set; }
        public string TextCreatorCacheTypeLanguage { get; set; }
        public string TextCreatorServerCacheDurationLanguage { get; set; }
        public string TextCreatorClientCacheDurationLanguage { get; set; }
        public string ConectionStringLanguage { get; set; }
        public string CookieLifeTimeLanguage { get; set; }
        public string DataBaseNameLanguage { get; set; }
        public string DateAndTimeLanguage { get; set; }
        public string DateFormatLanguage { get; set; }
        public string DayDifferenceLanguage { get; set; }
        public string DebugLanguage { get; set; }
        public string DefaultGroupLanguage { get; set; }
        public string DelayLanguage { get; set; }
        public string EmailHostLanguage { get; set; }
        public string EmailPasswordLanguage { get; set; }
        public string EmailPortLanguage { get; set; }
        public string EmailSenderLanguage { get; set; }
        public string EmailLanguage { get; set; }
        public string EmailUserNameLanguage { get; set; }
        public string FileAndDirectoryLanguage { get; set; }
        public string FirstDayOfWeekLanguage { get; set; }
        public string GuestLifeTimeLanguage { get; set; }
        public string GuestGroupLanguage { get; set; }
        public string GuestRoleCacheLanguage { get; set; }
        public string GuestRoleCacheTypeLanguage { get; set; }
        public string LockLoginDirectoryPathLanguage { get; set; }
        public string LockLoginPageDelayLanguage { get; set; }
        public string LockLoginPasswordLanguage { get; set; }
        public string LoginDelayLanguage { get; set; }
        public string MainDelayLanguage { get; set; }
        public string MaximumSizeForAdminStyleLanguage { get; set; }
        public string MaximumSizeForAdminTemplateLanguage { get; set; }
        public string MaximumSizeForAttachmentLanguage { get; set; }
        public string MaximumSizeForBackupLanguage { get; set; }
        public string MaximumSizeForCommentLanguage { get; set; }
        public string MaximumSizeForComponentLanguage { get; set; }
        public string MaximumSizeForContactLanguage { get; set; }
        public string MaximumSizeForContentAvatarLanguage { get; set; }
        public string MaximumSizeForEditorTemplateLanguage { get; set; }
        public string MaximumSizeForExtraHelperLanguage { get; set; }
        public string MaximumSizeForFetchLanguage { get; set; }
        public string MaximumSizeForLanguageLanguage { get; set; }
        public string MaximumSizeForModuleLanguage { get; set; }
        public string MaximumSizeForPageLanguage { get; set; }
        public string MaximumSizeForPatchLanguage { get; set; }
        public string MaximumSizeForPluginLanguage { get; set; }
        public string MaximumSizeForSiteStyleLanguage { get; set; }
        public string MaximumSizeForSiteTemplateLanguage { get; set; }
        public string MaximumSizeForUploadLanguage { get; set; }
        public string MaximumSizeForUserAvatarLanguage { get; set; }
        public string MaximumSizeForUserUploadLanguage { get; set; }
        public string MemberLifeTimeLanguage { get; set; }
        public string MemberRoleCacheLanguage { get; set; }
        public string MemberRoleCacheTypeLanguage { get; set; }
        public string NewPasswordLengthLanguage { get; set; }
        public string NewRandomTextValueCountLanguage { get; set; }
        public string SecretKeyLanguage { get; set; }
        public string SecurityLanguage { get; set; }
        public string SessionLifeTimeLanguage { get; set; }
        public string SystemAccessCodeLanguage { get; set; }
        public string ShowProtectionAttachmentDelayLanguage { get; set; }
        public string ShowProtectionContentDelayLanguage { get; set; }
        public string SignUpDelayLanguage { get; set; }
        public string TextAfterEmailBodyLanguage { get; set; }
        public string TextAfterEmailSubjectLanguage { get; set; }
        public string TextBeforeEmailBodyLanguage { get; set; }
        public string TextBeforeEmailSubjectLanguage { get; set; }
        public string ThumbnailImageHeightLanguage { get; set; }
        public string ThumbnailImageWidthLanguage { get; set; }
        public string TimeFormatLanguage { get; set; }
        public string TimeHoursDifferenceLanguage { get; set; }
        public string TimeMinutesDifferenceLanguage { get; set; }
        public string TimeZoneLanguage { get; set; }
        public string UserSecureValueSizeLanguage { get; set; }

        public bool InactiveSiteValue { get; set; } = false;
        public bool JustUseHttpsForSiteValue { get; set; } = false;
        public bool JustUseHttpsForAdminValue { get; set; } = false;
        public bool JustUseHttpsForLoginPageValue { get; set; } = false;
        public bool LockLoginForFirstLoginValue { get; set; } = false;
        public bool UseSensitivityCaseCaptchaValue { get; set; } = false;
        public bool UseRobotDetectionValue { get; set; } = false;
        public bool JustUseHttpsValue { get; set; } = false;
        public bool SaveLogsErrorValue { get; set; } = false;
        public bool UseEmailActivationValue { get; set; } = false;
        public bool UseAdminActivationValue { get; set; } = false;
        public bool UseSecretKeyForLoginValue { get; set; } = false;
        public bool WriteLogsErrorValue { get; set; } = false;
        public bool UseVariantDebugValue { get; set; } = false;
        public bool LoginActiveValue { get; set; } = false;
        public bool SignUpActiveValue { get; set; } = false;
        public bool AddCommentValue { get; set; } = false;
        public bool EmailUseHttpsValue { get; set; } = false;
        public bool AutoCreateThumbnailImageValue { get; set; } = false;
        public bool UseSiteMainCacheValue { get; set; } = false;
        public bool UseAdminMainCacheValue { get; set; } = false;
        public bool UseClientCacheForDynamicPageValue { get; set; } = false;
        public bool CheckServerCacheValue { get; set; } = false;
        public bool UseClientCacheForStaticPageValue { get; set; } = false;
        public bool CheckLastModifiedValue { get; set; } = false;
        public bool TextCreatorUseServerCacheValue { get; set; } = false;
        public bool TextCreatorUseClientCacheValue { get; set; } = false;

        public string DefaultGroupOptionListValue { get; set; }
        public string DefaultGroupOptionListSelectedValue { get; set; }
        public string GuestGroupOptionListValue { get; set; }
        public string GuestGroupOptionListSelectedValue { get; set; }
        public string CalendarOptionListValue { get; set; }
        public string CalendarOptionListSelectedValue { get; set; }
        public string FirstDayOfWeekOptionListValue { get; set; }
        public string FirstDayOfWeekOptionListSelectedValue { get; set; }
        public string TimeZoneOptionListValue { get; set; }
        public string TimeZoneOptionListSelectedValue { get; set; }
        public string AdminRoleCacheTypeOptionListValue { get; set; }
        public string AdminRoleCacheTypeOptionListSelectedValue { get; set; }
        public string MemberRoleCacheTypeOptionListValue { get; set; }
        public string MemberRoleCacheTypeOptionListSelectedValue { get; set; }
        public string GuestRoleCacheTypeOptionListValue { get; set; }
        public string GuestRoleCacheTypeOptionListSelectedValue { get; set; }
        public string TextCreatorCacheTypeOptionListValue { get; set; }
        public string TextCreatorCacheTypeOptionListSelectedValue { get; set; }

        public string AdminDirectoryPathValue { get; set; }
        public string LockLoginDirectoryPathValue { get; set; }
        public string SecretKeyValue { get; set; }
        public string SystemAccessCodeValue { get; set; }
        public string LockLoginPasswordValue { get; set; }
        public string NewPasswordLengthValue { get; set; }
        public string DataBaseNameValue { get; set; }
        public string ConectionStringValue { get; set; }
        public string UserSecureValueSizeValue { get; set; }
        public string NewRandomTextValueCountValue { get; set; }
        public string CaptchaNoiseValue { get; set; }
        public string CaptchaCharacterCountFromValue { get; set; }
        public string CaptchaCharacterCountToValue { get; set; }
        public string CaptchaCharacterValue { get; set; }
        public string CaptchaFontValue { get; set; }
        public string CaptchaFontSizeValue { get; set; }
        public string CaptchaRotateTransformValue { get; set; }
        public string CaptchaWidthValue { get; set; }
        public string CaptchaHeightValue { get; set; }
        public string CaptchaRepeatTimeValue { get; set; }
        public string CaptchaAdminReleaseCountValue { get; set; }
        public string CaptchaMemberReleaseCountValue { get; set; }
        public string CaptchaGuestReleaseCountValue { get; set; }
        public string RobotDetectionIpBlockDurationValue { get; set; }
        public string RobotDetectionResetTimeDurationValue { get; set; }
        public string RobotDetectionAdminRequestCountValue { get; set; }
        public string RobotDetectionMemberRequestCountValue { get; set; }
        public string RobotDetectionGuestRequestCountValue { get; set; }
        public string RobotDetectionAdminRequestAfterShowCaptchaCountValue { get; set; }
        public string RobotDetectionMemberRequestAfterShowCaptchaCountValue { get; set; }
        public string RobotDetectionGuestRequestAfterShowCaptchaCountValue { get; set; }
        public string AdminLifeTimeValue { get; set; }
        public string MemberLifeTimeValue { get; set; }
        public string GuestLifeTimeValue { get; set; }
        public string SessionLifeTimeValue { get; set; }
        public string CookieLifeTimeValue { get; set; }
        public string EmailHostValue { get; set; }
        public string EmailPortValue { get; set; }
        public string EmailUserNameValue { get; set; }
        public string EmailPasswordValue { get; set; }
        public string EmailSenderValue { get; set; }
        public string TextBeforeEmailSubjectValue { get; set; }
        public string TextAfterEmailSubjectValue { get; set; }
        public string TextBeforeEmailBodyValue { get; set; }
        public string TextAfterEmailBodyValue { get; set; }
        public string DateFormatValue { get; set; }
        public string TimeFormatValue { get; set; }
        public string DayDifferenceValue { get; set; }
        public string TimeHoursDifferenceValue { get; set; }
        public string TimeMinutesDifferenceValue { get; set; }
        public string MaximumSizeForBackupValue { get; set; }
        public string MaximumSizeForUploadValue { get; set; }
        public string MaximumSizeForAttachmentValue { get; set; }
        public string MaximumSizeForPluginValue { get; set; }
        public string MaximumSizeForModuleValue { get; set; }
        public string MaximumSizeForComponentValue { get; set; }
        public string MaximumSizeForExtraHelperValue { get; set; }
        public string MaximumSizeForEditorTemplateValue { get; set; }
        public string MaximumSizeForPatchValue { get; set; }
        public string MaximumSizeForFetchValue { get; set; }
        public string MaximumSizeForSiteTemplateValue { get; set; }
        public string MaximumSizeForSiteStyleValue { get; set; }
        public string MaximumSizeForAdminTemplateValue { get; set; }
        public string MaximumSizeForAdminStyleValue { get; set; }
        public string MaximumSizeForCommentValue { get; set; }
        public string MaximumSizeForContactValue { get; set; }
        public string MaximumSizeForPageValue { get; set; }
        public string MaximumSizeForLanguageValue { get; set; }
        public string MaximumSizeForContentAvatarValue { get; set; }
        public string MaximumSizeForUserAvatarValue { get; set; }
        public string MaximumSizeForUserUploadValue { get; set; }
        public string ThumbnailImageHeightValue { get; set; }
        public string ThumbnailImageWidthValue { get; set; }
        public string SiteMainCacheParametersValue { get; set; }
        public string AdminMainCacheParametersValue { get; set; }
        public string AdminRoleCacheValue { get; set; }
        public string MemberRoleCacheValue { get; set; }
        public string GuestRoleCacheValue { get; set; }
        public string ClientCacheForDynamicPageCacheValue { get; set; }
        public string ClientCacheForStaticPageCacheValue { get; set; }
        public string TextCreatorServerCacheDurationValue { get; set; }
        public string TextCreatorClientCacheDurationValue { get; set; }
        public string MainDelayValue { get; set; }
        public string SignUpDelayValue { get; set; }
        public string LoginDelayValue { get; set; }
        public string LockLoginPageDelayValue { get; set; }
        public string CaptchaDelayValue { get; set; }
        public string ShowProtectionContentDelayValue { get; set; }
        public string ShowProtectionAttachmentDelayValue { get; set; }
        
        public string AdminDirectoryPathCssClass { get; set; }
        public string LockLoginDirectoryPathCssClass { get; set; }
        public string SecretKeyCssClass { get; set; }
        public string SystemAccessCodeCssClass { get; set; }
        public string LockLoginPasswordCssClass { get; set; }
        public string NewPasswordLengthCssClass { get; set; }
        public string DataBaseNameCssClass { get; set; }
        public string ConectionStringCssClass { get; set; }
        public string UserSecureValueSizeCssClass { get; set; }
        public string NewRandomTextValueCountCssClass { get; set; }
        public string CaptchaNoiseCssClass { get; set; }
        public string CaptchaCharacterCountFromCssClass { get; set; }
        public string CaptchaCharacterCountToCssClass { get; set; }
        public string CaptchaCharacterCssClass { get; set; }
        public string CaptchaFontCssClass { get; set; }
        public string CaptchaFontSizeCssClass { get; set; }
        public string CaptchaRotateTransformCssClass { get; set; }
        public string CaptchaWidthCssClass { get; set; }
        public string CaptchaHeightCssClass { get; set; }
        public string CaptchaRepeatTimeCssClass { get; set; }
        public string CaptchaAdminReleaseCountCssClass { get; set; }
        public string CaptchaMemberReleaseCountCssClass { get; set; }
        public string CaptchaGuestReleaseCountCssClass { get; set; }
        public string RobotDetectionIpBlockDurationCssClass { get; set; }
        public string RobotDetectionResetTimeDurationCssClass { get; set; }
        public string RobotDetectionAdminRequestCountCssClass { get; set; }
        public string RobotDetectionMemberRequestCountCssClass { get; set; }
        public string RobotDetectionGuestRequestCountCssClass { get; set; }
        public string RobotDetectionAdminRequestAfterShowCaptchaCountCssClass { get; set; }
        public string RobotDetectionMemberRequestAfterShowCaptchaCountCssClass { get; set; }
        public string RobotDetectionGuestRequestAfterShowCaptchaCountCssClass { get; set; }
        public string AdminLifeTimeCssClass { get; set; }
        public string MemberLifeTimeCssClass { get; set; }
        public string GuestLifeTimeCssClass { get; set; }
        public string SessionLifeTimeCssClass { get; set; }
        public string CookieLifeTimeCssClass { get; set; }
        public string EmailHostCssClass { get; set; }
        public string EmailPortCssClass { get; set; }
        public string EmailUserNameCssClass { get; set; }
        public string EmailPasswordCssClass { get; set; }
        public string EmailSenderCssClass { get; set; }
        public string TextBeforeEmailSubjectCssClass { get; set; }
        public string TextAfterEmailSubjectCssClass { get; set; }
        public string TextBeforeEmailBodyCssClass { get; set; }
        public string TextAfterEmailBodyCssClass { get; set; }
        public string DateFormatCssClass { get; set; }
        public string TimeFormatCssClass { get; set; }
        public string DayDifferenceCssClass { get; set; }
        public string TimeHoursDifferenceCssClass { get; set; }
        public string TimeMinutesDifferenceCssClass { get; set; }
        public string MaximumSizeForBackupCssClass { get; set; }
        public string MaximumSizeForUploadCssClass { get; set; }
        public string MaximumSizeForAttachmentCssClass { get; set; }
        public string MaximumSizeForPluginCssClass { get; set; }
        public string MaximumSizeForModuleCssClass { get; set; }
        public string MaximumSizeForComponentCssClass { get; set; }
        public string MaximumSizeForExtraHelperCssClass { get; set; }
        public string MaximumSizeForEditorTemplateCssClass { get; set; }
        public string MaximumSizeForPatchCssClass { get; set; }
        public string MaximumSizeForFetchCssClass { get; set; }
        public string MaximumSizeForSiteTemplateCssClass { get; set; }
        public string MaximumSizeForSiteStyleCssClass { get; set; }
        public string MaximumSizeForAdminTemplateCssClass { get; set; }
        public string MaximumSizeForAdminStyleCssClass { get; set; }
        public string MaximumSizeForCommentCssClass { get; set; }
        public string MaximumSizeForContactCssClass { get; set; }
        public string MaximumSizeForPageCssClass { get; set; }
        public string MaximumSizeForLanguageCssClass { get; set; }
        public string MaximumSizeForContentAvatarCssClass { get; set; }
        public string MaximumSizeForUserAvatarCssClass { get; set; }
        public string MaximumSizeForUserUploadCssClass { get; set; }
        public string ThumbnailImageHeightCssClass { get; set; }
        public string ThumbnailImageWidthCssClass { get; set; }
        public string SiteMainCacheParametersCssClass { get; set; }
        public string AdminMainCacheParametersCssClass { get; set; }
        public string AdminRoleCacheCssClass { get; set; }
        public string MemberRoleCacheCssClass { get; set; }
        public string GuestRoleCacheCssClass { get; set; }
        public string ClientCacheForDynamicPageCacheCssClass { get; set; }
        public string ClientCacheForStaticPageCacheCssClass { get; set; }
        public string TextCreatorCacheTypeCssClass { get; set; }
        public string TextCreatorServerCacheDurationCssClass { get; set; }
        public string TextCreatorClientCacheDurationCssClass { get; set; }
        public string MainDelayCssClass { get; set; }
        public string SignUpDelayCssClass { get; set; }
        public string LoginDelayCssClass { get; set; }
        public string LockLoginPageDelayCssClass { get; set; }
        public string CaptchaDelayCssClass { get; set; }
        public string ShowProtectionContentDelayCssClass { get; set; }
        public string ShowProtectionAttachmentDelayCssClass { get; set; }
        public string DefaultGroupCssClass { get; set; }
        public string GuestGroupCssClass { get; set; }
        public string CalendarCssClass { get; set; }
        public string FirstDayOfWeekCssClass { get; set; }
        public string TimeZoneCssClass { get; set; }
        public string AdminRoleCacheTypeCssClass { get; set; }
        public string MemberRoleCacheTypeCssClass { get; set; }
        public string GuestRoleCacheTypeCssClass { get; set; }
        
        public string AdminDirectoryPathAttribute { get; set; }
        public string LockLoginDirectoryPathAttribute { get; set; }
        public string SecretKeyAttribute { get; set; }
        public string SystemAccessCodeAttribute { get; set; }
        public string LockLoginPasswordAttribute { get; set; }
        public string NewPasswordLengthAttribute { get; set; }
        public string DataBaseNameAttribute { get; set; }
        public string ConectionStringAttribute { get; set; }
        public string UserSecureValueSizeAttribute { get; set; }
        public string NewRandomTextValueCountAttribute { get; set; }
        public string CaptchaNoiseAttribute { get; set; }
        public string CaptchaCharacterCountFromAttribute { get; set; }
        public string CaptchaCharacterCountToAttribute { get; set; }
        public string CaptchaCharacterAttribute { get; set; }
        public string CaptchaFontAttribute { get; set; }
        public string CaptchaFontSizeAttribute { get; set; }
        public string CaptchaRotateTransformAttribute { get; set; }
        public string CaptchaWidthAttribute { get; set; }
        public string CaptchaHeightAttribute { get; set; }
        public string CaptchaRepeatTimeAttribute { get; set; }
        public string CaptchaAdminReleaseCountAttribute { get; set; }
        public string CaptchaMemberReleaseCountAttribute { get; set; }
        public string CaptchaGuestReleaseCountAttribute { get; set; }
        public string RobotDetectionIpBlockDurationAttribute { get; set; }
        public string RobotDetectionResetTimeDurationAttribute { get; set; }
        public string RobotDetectionAdminRequestCountAttribute { get; set; }
        public string RobotDetectionMemberRequestCountAttribute { get; set; }
        public string RobotDetectionGuestRequestCountAttribute { get; set; }
        public string RobotDetectionAdminRequestAfterShowCaptchaCountAttribute { get; set; }
        public string RobotDetectionMemberRequestAfterShowCaptchaCountAttribute { get; set; }
        public string RobotDetectionGuestRequestAfterShowCaptchaCountAttribute { get; set; }
        public string AdminLifeTimeAttribute { get; set; }
        public string MemberLifeTimeAttribute { get; set; }
        public string GuestLifeTimeAttribute { get; set; }
        public string SessionLifeTimeAttribute { get; set; }
        public string CookieLifeTimeAttribute { get; set; }
        public string EmailHostAttribute { get; set; }
        public string EmailPortAttribute { get; set; }
        public string EmailUserNameAttribute { get; set; }
        public string EmailPasswordAttribute { get; set; }
        public string EmailSenderAttribute { get; set; }
        public string TextBeforeEmailSubjectAttribute { get; set; }
        public string TextAfterEmailSubjectAttribute { get; set; }
        public string TextBeforeEmailBodyAttribute { get; set; }
        public string TextAfterEmailBodyAttribute { get; set; }
        public string DateFormatAttribute { get; set; }
        public string TimeFormatAttribute { get; set; }
        public string DayDifferenceAttribute { get; set; }
        public string TimeHoursDifferenceAttribute { get; set; }
        public string TimeMinutesDifferenceAttribute { get; set; }
        public string MaximumSizeForBackupAttribute { get; set; }
        public string MaximumSizeForUploadAttribute { get; set; }
        public string MaximumSizeForAttachmentAttribute { get; set; }
        public string MaximumSizeForPluginAttribute { get; set; }
        public string MaximumSizeForModuleAttribute { get; set; }
        public string MaximumSizeForComponentAttribute { get; set; }
        public string MaximumSizeForExtraHelperAttribute { get; set; }
        public string MaximumSizeForEditorTemplateAttribute { get; set; }
        public string MaximumSizeForPatchAttribute { get; set; }
        public string MaximumSizeForFetchAttribute { get; set; }
        public string MaximumSizeForSiteTemplateAttribute { get; set; }
        public string MaximumSizeForSiteStyleAttribute { get; set; }
        public string MaximumSizeForAdminTemplateAttribute { get; set; }
        public string MaximumSizeForAdminStyleAttribute { get; set; }
        public string MaximumSizeForCommentAttribute { get; set; }
        public string MaximumSizeForContactAttribute { get; set; }
        public string MaximumSizeForPageAttribute { get; set; }
        public string MaximumSizeForLanguageAttribute { get; set; }
        public string MaximumSizeForContentAvatarAttribute { get; set; }
        public string MaximumSizeForUserAvatarAttribute { get; set; }
        public string MaximumSizeForUserUploadAttribute { get; set; }
        public string ThumbnailImageHeightAttribute { get; set; }
        public string ThumbnailImageWidthAttribute { get; set; }
        public string SiteMainCacheParametersAttribute { get; set; }
        public string AdminMainCacheParametersAttribute { get; set; }
        public string AdminRoleCacheAttribute { get; set; }
        public string MemberRoleCacheAttribute { get; set; }
        public string GuestRoleCacheAttribute { get; set; }
        public string ClientCacheForDynamicPageCacheAttribute { get; set; }
        public string ClientCacheForStaticPageCacheAttribute { get; set; }
        public string TextCreatorCacheTypeAttribute { get; set; }
        public string TextCreatorServerCacheDurationAttribute { get; set; }
        public string TextCreatorClientCacheDurationAttribute { get; set; }
        public string MainDelayAttribute { get; set; }
        public string SignUpDelayAttribute { get; set; }
        public string LoginDelayAttribute { get; set; }
        public string LockLoginPageDelayAttribute { get; set; }
        public string CaptchaDelayAttribute { get; set; }
        public string ShowProtectionContentDelayAttribute { get; set; }
        public string ShowProtectionAttachmentDelayAttribute { get; set; }
        public string DefaultGroupAttribute { get; set; }
        public string GuestGroupAttribute { get; set; }
        public string CalendarAttribute { get; set; }
        public string FirstDayOfWeekAttribute { get; set; }
        public string TimeZoneAttribute { get; set; }
        public string AdminRoleCacheTypeAttribute { get; set; }
        public string MemberRoleCacheTypeAttribute { get; set; }
        public string GuestRoleCacheTypeAttribute { get; set; }

        public List<string> SecurityEvaluateErrorList;
        public List<string> EmailEvaluateErrorList;
        public List<string> DateAndTimeEvaluateErrorList;
        public List<string> FileAndDirectoryEvaluateErrorList;
        public List<string> DelayEvaluateErrorList;
        public List<string> CacheEvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindSecurityEvaluateError = false;
        public bool FindEmailEvaluateError = false;
        public bool FindDateAndTimeEvaluateError = false;
        public bool FindFileAndDirectoryEvaluateError = false;
        public bool FindDelayEvaluateError = false;
        public bool FindCacheEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/");
            OptionsLanguage = aol.GetAddOnsLanguage("options");
            SaveActiveLanguage = aol.GetAddOnsLanguage("save_active");
            SaveCacheLanguage = aol.GetAddOnsLanguage("save_cache");
            SaveDateAndTimeLanguage = aol.GetAddOnsLanguage("save_date_and_time");
            SaveDebugLanguage = aol.GetAddOnsLanguage("save_debug");
            SaveDelayLanguage = aol.GetAddOnsLanguage("save_delay");
            SaveEmailLanguage = aol.GetAddOnsLanguage("save_email");
            SaveFileAndDirectoryLanguage = aol.GetAddOnsLanguage("save_file_and_directory");
            SaveSecurityLanguage = aol.GetAddOnsLanguage("save_security");
            AddCommentLanguage = aol.GetAddOnsLanguage("add_comment");
            AutoCreateThumbnailImageLanguage = aol.GetAddOnsLanguage("auto_create_thumbnail_image");
            CheckLastModifiedLanguage = aol.GetAddOnsLanguage("check_last_modified");
            CheckServerCacheLanguage = aol.GetAddOnsLanguage("check_server_cache");
            EmailUseHttpsLanguage = aol.GetAddOnsLanguage("email_use_https");
            InactiveSiteLanguage = aol.GetAddOnsLanguage("inactive_site");
            JustUseHttpsLanguage = aol.GetAddOnsLanguage("just_use_https");
            JustUseHttpsForAdminLanguage = aol.GetAddOnsLanguage("just_use_https_for_admin");
            JustUseHttpsForLoginPageLanguage = aol.GetAddOnsLanguage("just_use_https_for_login_page");
            JustUseHttpsForSiteLanguage = aol.GetAddOnsLanguage("just_use_https_for_site");
            LockLoginForFirstLoginLanguage = aol.GetAddOnsLanguage("lock_login_for_first_login");
            LoginActiveLanguage = aol.GetAddOnsLanguage("login_active");
            SaveLogsErrorLanguage = aol.GetAddOnsLanguage("save_logs_error");
            SensitivityCaseCaptchaLanguage = aol.GetAddOnsLanguage("use_sensitivity_case_captcha");
            SignUpActiveLanguage = aol.GetAddOnsLanguage("sign_up_active");
            UseAdminActivationLanguage = aol.GetAddOnsLanguage("use_admin_activation");
            UseClientCacheForDynamicPageLanguage = aol.GetAddOnsLanguage("use_client_cache_for_dynamic_page");
            UseClientCacheForStaticPageLanguage = aol.GetAddOnsLanguage("use_client_cache_for_static_page");
            UseEmailActivationLanguage = aol.GetAddOnsLanguage("use_email_activation");
            UseSecretKeyForLoginLanguage = aol.GetAddOnsLanguage("use_secret_key_for_login");
            UseSensitivityCaseCaptchaLanguage = aol.GetAddOnsLanguage("use_sensitivity_case_captcha");
            UseVariantDebugLanguage = aol.GetAddOnsLanguage("use_variant_debug");
            WriteLogsErrorLanguage = aol.GetAddOnsLanguage("write_logs_error");
            UseSiteMainCacheLanguage = aol.GetAddOnsLanguage("use_site_main_cache");
            UseAdminMainCacheLanguage = aol.GetAddOnsLanguage("use_admin_main_cache");
            ActiveLanguage = aol.GetAddOnsLanguage("active");
            AdminDirectoryPathLanguage = aol.GetAddOnsLanguage("admin_directory_path");
            AdminLifeTimeLanguage = aol.GetAddOnsLanguage("admin_life_time");
            AdminRoleCacheLanguage = aol.GetAddOnsLanguage("admin_role_cache");
            AdminRoleCacheTypeLanguage = aol.GetAddOnsLanguage("admin_role_cache_type");
            SiteMainCacheParametersLanguage = aol.GetAddOnsLanguage("site_main_cache_parameters");
            AdminMainCacheParametersLanguage = aol.GetAddOnsLanguage("admin_main_cache_parameters");
            CacheLanguage = aol.GetAddOnsLanguage("cache");
            CalendarLanguage = aol.GetAddOnsLanguage("calendar");
            CaptchaCharacterLanguage = aol.GetAddOnsLanguage("captcha_character");
            CaptchaCharacterCountFromLanguage = aol.GetAddOnsLanguage("captcha_character_count_from");
            CaptchaCharacterCountToLanguage = aol.GetAddOnsLanguage("captcha_character_count_to");
            CaptchaDelayLanguage = aol.GetAddOnsLanguage("captcha_delay");
            CaptchaFontLanguage = aol.GetAddOnsLanguage("captcha_font");
            CaptchaFontSizeLanguage = aol.GetAddOnsLanguage("captcha_font_size");
            CaptchaHeightLanguage = aol.GetAddOnsLanguage("captcha_height");
            CaptchaNoiseLanguage = aol.GetAddOnsLanguage("captcha_noise");
            CaptchaRepeatTimeLanguage = aol.GetAddOnsLanguage("captcha_repeat_time");
            CaptchaRotateTransformLanguage = aol.GetAddOnsLanguage("captcha_rotate_transform");
            CaptchaWidthLanguage = aol.GetAddOnsLanguage("captcha_width");
            CaptchaAdminReleaseCountLanguage = aol.GetAddOnsLanguage("captcha_admin_release_count");
            CaptchaMemberReleaseCountLanguage = aol.GetAddOnsLanguage("captcha_member_release_count");
            CaptchaGuestReleaseCountLanguage = aol.GetAddOnsLanguage("captcha_guest_release_count");
            RobotDetectionIpBlockDurationLanguage = aol.GetAddOnsLanguage("robot_detection_ip_block_duration");
            RobotDetectionResetTimeDurationLanguage = aol.GetAddOnsLanguage("robot_detection_reset_time_duration");
            RobotDetectionAdminRequestCountLanguage = aol.GetAddOnsLanguage("robot_detection_admin_request_count");
            RobotDetectionMemberRequestCountLanguage = aol.GetAddOnsLanguage("robot_detection_member_request_count");
            RobotDetectionGuestRequestCountLanguage = aol.GetAddOnsLanguage("robot_detection_guest_request_count");
            RobotDetectionAdminRequestAfterShowCaptchaCountLanguage = aol.GetAddOnsLanguage("robot_detection_admin_request_after_show_captcha_count");
            RobotDetectionMemberRequestAfterShowCaptchaCountLanguage = aol.GetAddOnsLanguage("robot_detection_member_request_after_show_captcha_count");
            RobotDetectionGuestRequestAfterShowCaptchaCountLanguage = aol.GetAddOnsLanguage("robot_detection_guest_request_after_show_captcha_count");
            ClientCacheForDynamicPageCacheLanguage = aol.GetAddOnsLanguage("use_client_cache_for_dynamic_page_cache");
            ClientCacheForStaticPageCacheLanguage = aol.GetAddOnsLanguage("use_client_cache_for_static_page_cache");
            TextCreatorUseServerCacheLanguage = aol.GetAddOnsLanguage("text_creator_use_server_cache");
            TextCreatorUseClientCacheLanguage = aol.GetAddOnsLanguage("text_creator_use_client_cache");
            TextCreatorCacheTypeLanguage = aol.GetAddOnsLanguage("text_creator_cache_type");
            TextCreatorServerCacheDurationLanguage = aol.GetAddOnsLanguage("text_creator_server_cache_duration");
            TextCreatorClientCacheDurationLanguage = aol.GetAddOnsLanguage("text_creator_client_cache_duration");
            ConectionStringLanguage = aol.GetAddOnsLanguage("conection_string");
            CookieLifeTimeLanguage = aol.GetAddOnsLanguage("cookie_life_time");
            DataBaseNameLanguage = aol.GetAddOnsLanguage("database_name");
            DateAndTimeLanguage = aol.GetAddOnsLanguage("date_and_time");
            DateFormatLanguage = aol.GetAddOnsLanguage("date_format");
            DayDifferenceLanguage = aol.GetAddOnsLanguage("day_difference");
            DebugLanguage = aol.GetAddOnsLanguage("debug");
            DefaultGroupLanguage = aol.GetAddOnsLanguage("default_group");
            DelayLanguage = aol.GetAddOnsLanguage("delay");
            EmailHostLanguage = aol.GetAddOnsLanguage("email_host");
            EmailPasswordLanguage = aol.GetAddOnsLanguage("email_password");
            EmailPortLanguage = aol.GetAddOnsLanguage("email_port");
            EmailSenderLanguage = aol.GetAddOnsLanguage("email_sender");
            EmailLanguage = aol.GetAddOnsLanguage("email");
            EmailUserNameLanguage = aol.GetAddOnsLanguage("email_user_name");
            FileAndDirectoryLanguage = aol.GetAddOnsLanguage("file_and_directory");
            FirstDayOfWeekLanguage = aol.GetAddOnsLanguage("first_day_of_week");
            GuestLifeTimeLanguage = aol.GetAddOnsLanguage("guest_life_time");
            GuestGroupLanguage = aol.GetAddOnsLanguage("guest_group");
            GuestRoleCacheLanguage = aol.GetAddOnsLanguage("guest_role_cache");
            GuestRoleCacheTypeLanguage = aol.GetAddOnsLanguage("guest_role_cache_type");
            LockLoginDirectoryPathLanguage = aol.GetAddOnsLanguage("lock_login_directory_path");
            LockLoginPageDelayLanguage = aol.GetAddOnsLanguage("lock_login_page_delay");
            LockLoginPasswordLanguage = aol.GetAddOnsLanguage("lock_login_password");
            LoginDelayLanguage = aol.GetAddOnsLanguage("login_delay");
            MainDelayLanguage = aol.GetAddOnsLanguage("main_delay");
            MaximumSizeForAdminStyleLanguage = aol.GetAddOnsLanguage("maximum_size_for_admin_style");
            MaximumSizeForAdminTemplateLanguage = aol.GetAddOnsLanguage("maximum_size_for_admin_template");
            MaximumSizeForAttachmentLanguage = aol.GetAddOnsLanguage("maximum_size_for_attachment");
            MaximumSizeForBackupLanguage = aol.GetAddOnsLanguage("maximum_size_for_backup");
            MaximumSizeForCommentLanguage = aol.GetAddOnsLanguage("maximum_size_for_comment");
            MaximumSizeForComponentLanguage = aol.GetAddOnsLanguage("maximum_size_for_component");
            MaximumSizeForContactLanguage = aol.GetAddOnsLanguage("maximum_size_for_contact");
            MaximumSizeForContentAvatarLanguage = aol.GetAddOnsLanguage("maximum_size_for_content_avatar");
            MaximumSizeForEditorTemplateLanguage = aol.GetAddOnsLanguage("maximum_size_for_editor_template");
            MaximumSizeForExtraHelperLanguage = aol.GetAddOnsLanguage("maximum_size_for_extra_helper");
            MaximumSizeForFetchLanguage = aol.GetAddOnsLanguage("maximum_size_for_fetch");
            MaximumSizeForLanguageLanguage = aol.GetAddOnsLanguage("maximum_size_for_language");
            MaximumSizeForModuleLanguage = aol.GetAddOnsLanguage("maximum_size_for_module");
            MaximumSizeForPageLanguage = aol.GetAddOnsLanguage("maximum_size_for_page");
            MaximumSizeForPatchLanguage = aol.GetAddOnsLanguage("maximum_size_for_patch");
            MaximumSizeForPluginLanguage = aol.GetAddOnsLanguage("maximum_size_for_plugin");
            MaximumSizeForSiteStyleLanguage = aol.GetAddOnsLanguage("maximum_size_for_site_style");
            MaximumSizeForSiteTemplateLanguage = aol.GetAddOnsLanguage("maximum_size_for_site_template");
            MaximumSizeForUploadLanguage = aol.GetAddOnsLanguage("maximum_size_for_upload");
            MaximumSizeForUserAvatarLanguage = aol.GetAddOnsLanguage("maximum_size_for_user_avatar");
            MaximumSizeForUserUploadLanguage = aol.GetAddOnsLanguage("maximum_size_for_user_upload");
            MemberLifeTimeLanguage = aol.GetAddOnsLanguage("member_life_time");
            MemberRoleCacheLanguage = aol.GetAddOnsLanguage("member_role_cache");
            MemberRoleCacheTypeLanguage = aol.GetAddOnsLanguage("member_role_cache_type");
            NewPasswordLengthLanguage = aol.GetAddOnsLanguage("new_password_length");
            NewRandomTextValueCountLanguage = aol.GetAddOnsLanguage("new_random_text_value_count");
            SecretKeyLanguage = aol.GetAddOnsLanguage("secret_key");
            SecurityLanguage = aol.GetAddOnsLanguage("security");
            SessionLifeTimeLanguage = aol.GetAddOnsLanguage("session_life_time");
            SystemAccessCodeLanguage = aol.GetAddOnsLanguage("system_access_code");
            ShowProtectionAttachmentDelayLanguage = aol.GetAddOnsLanguage("show_protection_attachment_delay");
            ShowProtectionContentDelayLanguage = aol.GetAddOnsLanguage("show_protection_content_delay");
            SignUpDelayLanguage = aol.GetAddOnsLanguage("sign_up_delay");
            TextAfterEmailBodyLanguage = aol.GetAddOnsLanguage("text_after_email_body");
            TextAfterEmailSubjectLanguage = aol.GetAddOnsLanguage("text_after_email_subject");
            TextBeforeEmailBodyLanguage = aol.GetAddOnsLanguage("text_before_email_body");
            TextBeforeEmailSubjectLanguage = aol.GetAddOnsLanguage("text_before_email_subject");
            ThumbnailImageHeightLanguage = aol.GetAddOnsLanguage("thumbnail_image_height");
            ThumbnailImageWidthLanguage = aol.GetAddOnsLanguage("thumbnail_image_width");
            TimeFormatLanguage = aol.GetAddOnsLanguage("time_format");
            TimeHoursDifferenceLanguage = aol.GetAddOnsLanguage("time_hours_difference");
            TimeMinutesDifferenceLanguage = aol.GetAddOnsLanguage("time_minutes_difference");
            TimeZoneLanguage = aol.GetAddOnsLanguage("time_zone");
            UseRobotDetectionLanguage = aol.GetAddOnsLanguage("use_robot_detection");
            UserSecureValueSizeLanguage = aol.GetAddOnsLanguage("user_secure_value_size");


            // Set Current Value
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            XmlNode node = doc.SelectSingleNode("elanat_root/security");

            InactiveSiteValue = node["inactive_site"].Attributes["active"].Value.TrueFalseToBoolean();
            JustUseHttpsValue = node["just_use_https"].Attributes["active"].Value.TrueFalseToBoolean();
            JustUseHttpsForAdminValue = node["just_use_https_in_admin"].Attributes["active"].Value.TrueFalseToBoolean();
            JustUseHttpsForSiteValue = node["just_use_https_in_site"].Attributes["active"].Value.TrueFalseToBoolean();
            JustUseHttpsForLoginPageValue = node["just_use_https_in_login_page"].Attributes["active"].Value.TrueFalseToBoolean();
            SaveLogsErrorValue = node["save_logs_error"].Attributes["active"].Value.TrueFalseToBoolean();
            UseRobotDetectionValue = node["robot_detection"].Attributes["active"].Value.TrueFalseToBoolean();
            UseSecretKeyForLoginValue = node["use_secret_key_for_login"].Attributes["active"].Value.TrueFalseToBoolean();
            UseAdminActivationValue = node["use_admin_activation"].Attributes["active"].Value.TrueFalseToBoolean();
            UseEmailActivationValue = node["registered_user_after_accept_active_email"].Attributes["active"].Value.TrueFalseToBoolean();
            CaptchaNoiseValue = node["captcha_noise"].Attributes["value"].Value;
            CaptchaCharacterCountFromValue = node["captcha_character_count"].Attributes["from"].Value;
            CaptchaCharacterCountToValue = node["captcha_character_count"].Attributes["to"].Value;
            CaptchaCharacterValue = node["captcha_character"].InnerText;
            CaptchaFontValue = node["captcha_font"].Attributes["value"].Value;
            CaptchaFontSizeValue = node["captcha_font_size"].Attributes["value"].Value;
            CaptchaRotateTransformValue = node["captcha_rotate_transform"].Attributes["value"].Value;
            CaptchaWidthValue = node["captcha_width"].Attributes["value"].Value;
            CaptchaHeightValue = node["captcha_height"].Attributes["value"].Value;
            CaptchaRepeatTimeValue = node["captcha_repeat_time"].Attributes["value"].Value;
            CaptchaAdminReleaseCountValue = node["captcha_admin_release_count"].Attributes["value"].Value;
            CaptchaMemberReleaseCountValue = node["captcha_member_release_count"].Attributes["value"].Value;
            CaptchaGuestReleaseCountValue = node["captcha_guest_release_count"].Attributes["value"].Value;
            RobotDetectionIpBlockDurationValue = node["robot_detection_ip_block_duration"].Attributes["value"].Value;
            RobotDetectionResetTimeDurationValue = node["robot_detection_reset_time_duration"].Attributes["value"].Value;
            RobotDetectionAdminRequestCountValue = node["robot_detection_admin_request"].Attributes["count"].Value;
            RobotDetectionMemberRequestCountValue = node["robot_detection_member_request"].Attributes["count"].Value;
            RobotDetectionGuestRequestCountValue = node["robot_detection_guest_request"].Attributes["count"].Value;
            RobotDetectionAdminRequestAfterShowCaptchaCountValue = node["robot_detection_admin_request"].Attributes["after_show_captcha_count"].Value;
            RobotDetectionMemberRequestAfterShowCaptchaCountValue = node["robot_detection_member_request"].Attributes["after_show_captcha_count"].Value;
            RobotDetectionGuestRequestAfterShowCaptchaCountValue = node["robot_detection_guest_request"].Attributes["after_show_captcha_count"].Value;
            UseSensitivityCaseCaptchaValue = (node["use_sensitivity_case_captcha"].Attributes["active"].Value == "true");
            SessionLifeTimeValue = node["session_life_time"].Attributes["value"].Value;
            CookieLifeTimeValue = node["cookie_life_time"].Attributes["value"].Value;
            UserSecureValueSizeValue = node["user_secure_value_size"].Attributes["value"].Value;

            DataUse.Group dug = new DataUse.Group();
            DefaultGroupOptionListSelectedValue = dug.GetGroupIdByGroupName(node["default_group"].Attributes["value"].Value);

            AdminLifeTimeValue = node["admin_life_time"].Attributes["value"].Value;
            MemberLifeTimeValue = node["member_life_time"].Attributes["value"].Value;
            GuestLifeTimeValue = node["guest_life_time"].Attributes["value"].Value;

            GuestGroupOptionListSelectedValue = dug.GetGroupIdByGroupName(node["guest_group"].Attributes["value"].Value);

            DataBaseNameValue = node["database_name"].Attributes["value"].Value;
            NewPasswordLengthValue = node["new_password_length"].Attributes["value"].Value;
            NewRandomTextValueCountValue = node["new_random_text_value_count"].Attributes["value"].Value;
            LockLoginForFirstLoginValue = (node["lock_login_for_first_login"].Attributes["active"].Value == "true");

            node = doc.SelectSingleNode("elanat_root/debug");

            UseVariantDebugValue = (node["use_variant_debug"].Attributes["active"].Value == "true");
            WriteLogsErrorValue = (node["write_logs_error"].Attributes["active"].Value == "true");

            node = doc.SelectSingleNode("elanat_root/active");

            LoginActiveValue = (node["login_active"].Attributes["active"].Value == "true");
            SignUpActiveValue = (node["sign_up_active"].Attributes["active"].Value == "true");
            AddCommentValue = (node["add_comment"].Attributes["active"].Value == "true");

            node = doc.SelectSingleNode("elanat_root/email");

            EmailHostValue = node["host"].InnerText;
            EmailPortValue = node["port"].InnerText;
            EmailUserNameValue = node["username"].InnerText;
            EmailSenderValue = node["sender"].InnerText;
            TextBeforeEmailSubjectValue = node["text_before_email_subject"].InnerText;
            TextAfterEmailSubjectValue = node["text_after_email_subject"].InnerText;
            TextBeforeEmailBodyValue = node["text_before_email_body"].InnerText;
            TextAfterEmailBodyValue = node["text_after_email_body"].InnerText;
            EmailUseHttpsValue = (node["use_https"].Attributes["active"].Value == "true");

            node = doc.SelectSingleNode("elanat_root/date_and_time");

            DateFormatValue = node["date_format"].InnerText;
            TimeFormatValue = node["time_format"].InnerText;
            DayDifferenceValue = node["day_difference"].Attributes["value"].Value;
            TimeHoursDifferenceValue = node["time_difference_hours"].Attributes["value"].Value;
            TimeMinutesDifferenceValue = node["time_difference_minutes"].Attributes["value"].Value;
            FirstDayOfWeekOptionListSelectedValue = node["first_day_of_week"].Attributes["value"].Value;
            CalendarOptionListSelectedValue = node["default_calendar"].Attributes["value"].Value;
            TimeZoneOptionListSelectedValue = node["time_zone"].Attributes["value"].Value;

            node = doc.SelectSingleNode("elanat_root/file_and_directory");

            MaximumSizeForUserUploadValue = node["maximum_size_for_user_upload"].Attributes["value"].Value;
            MaximumSizeForUserAvatarValue = node["maximum_size_for_user_avatar"].Attributes["value"].Value;
            MaximumSizeForContentAvatarValue = node["maximum_size_for_content_avatar"].Attributes["value"].Value;
            MaximumSizeForLanguageValue = node["maximum_size_for_language"].Attributes["value"].Value;
            MaximumSizeForPageValue = node["maximum_size_for_page"].Attributes["value"].Value;
            MaximumSizeForPatchValue = node["maximum_size_for_patch"].Attributes["value"].Value;
            MaximumSizeForContactValue = node["maximum_size_for_contact"].Attributes["value"].Value;
            MaximumSizeForCommentValue = node["maximum_size_for_comment"].Attributes["value"].Value;
            MaximumSizeForAdminStyleValue = node["maximum_size_for_admin_style"].Attributes["value"].Value;
            MaximumSizeForAdminTemplateValue = node["maximum_size_for_admin_template"].Attributes["value"].Value;
            MaximumSizeForSiteStyleValue = node["maximum_size_for_site_style"].Attributes["value"].Value;
            MaximumSizeForSiteTemplateValue = node["maximum_size_for_site_template"].Attributes["value"].Value;
            MaximumSizeForEditorTemplateValue = node["maximum_size_for_editor_template"].Attributes["value"].Value;
            MaximumSizeForExtraHelperValue = node["maximum_size_for_extra_helper"].Attributes["value"].Value;
            MaximumSizeForFetchValue = node["maximum_size_for_fetch"].Attributes["value"].Value;
            MaximumSizeForComponentValue = node["maximum_size_for_component"].Attributes["value"].Value;
            MaximumSizeForModuleValue = node["maximum_size_for_module"].Attributes["value"].Value;
            MaximumSizeForPluginValue = node["maximum_size_for_plugin"].Attributes["value"].Value;
            MaximumSizeForAttachmentValue = node["maximum_size_for_attachment"].Attributes["value"].Value;
            MaximumSizeForUploadValue = node["maximum_size_for_upload"].Attributes["value"].Value;
            MaximumSizeForBackupValue = node["maximum_size_for_backup"].Attributes["value"].Value;
            ThumbnailImageHeightValue = node["thumbnail_image_height"].Attributes["value"].Value;
            ThumbnailImageWidthValue = node["thumbnail_image_width"].Attributes["value"].Value;
            AutoCreateThumbnailImageValue = (node["auto_create_thumbnail_image"].Attributes["active"].Value == "true");

            node = doc.SelectSingleNode("elanat_root/delay");

            MainDelayValue = node["main"].Attributes["value"].Value;
            SignUpDelayValue = node["sign_up"].Attributes["value"].Value;
            LoginDelayValue = node["login"].Attributes["value"].Value;
            LockLoginPageDelayValue = node["lock_login_page"].Attributes["value"].Value;
            CaptchaDelayValue = node["captcha"].Attributes["value"].Value;
            ShowProtectionContentDelayValue = node["show_protection_content"].Attributes["value"].Value;
            ShowProtectionAttachmentDelayValue = node["show_protection_attachment"].Attributes["value"].Value;

            node = doc.SelectSingleNode("elanat_root/cache");

            UseSiteMainCacheValue = (node["site_main"].Attributes["active"].Value == "true");
            SiteMainCacheParametersValue = node["site_main"].Attributes["cache_parameters"].Value;

            UseAdminMainCacheValue = (node["admin_main"].Attributes["active"].Value == "true");
            AdminMainCacheParametersValue = node["admin_main"].Attributes["cache_parameters"].Value;

            AdminRoleCacheTypeOptionListSelectedValue = node["admin_role"].Attributes["cache_type"].Value;
            AdminRoleCacheValue = node["admin_role"].Attributes["value"].Value;

            MemberRoleCacheTypeOptionListSelectedValue = node["member_role"].Attributes["cache_type"].Value;
            MemberRoleCacheValue = node["member_role"].Attributes["value"].Value;

            GuestRoleCacheTypeOptionListSelectedValue = node["guest_role"].Attributes["cache_type"].Value;
            GuestRoleCacheValue = node["guest_role"].Attributes["value"].Value;

            ClientCacheForDynamicPageCacheValue = node["use_client_cache_for_dynamic_page"].Attributes["value"].Value;
            UseClientCacheForDynamicPageValue = (node["use_client_cache_for_dynamic_page"].Attributes["active"].Value == "true");
            CheckServerCacheValue = (node["use_client_cache_for_dynamic_page"].Attributes["check_server_cache"].Value == "true");

            ClientCacheForStaticPageCacheValue = node["use_client_cache_for_static_page"].Attributes["value"].Value;
            UseClientCacheForStaticPageValue = (node["use_client_cache_for_static_page"].Attributes["active"].Value == "true");
            CheckLastModifiedValue = (node["use_client_cache_for_static_page"].Attributes["check_last_modified"].Value == "true");

            TextCreatorServerCacheDurationValue = node["text_creator_cache"].Attributes["server_value"].Value;
            TextCreatorClientCacheDurationValue = node["text_creator_cache"].Attributes["client_value"].Value;
            TextCreatorUseServerCacheValue = (node["text_creator_cache"].Attributes["use_server_cache"].Value == "true");
            TextCreatorUseClientCacheValue = (node["text_creator_cache"].Attributes["use_client_cache"].Value == "true");
            TextCreatorCacheTypeOptionListSelectedValue = node["text_creator_cache"].Attributes["cache_type"].Value;


            // Set User Group Item
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserGroupListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            DefaultGroupOptionListValue += lcu.UserGroupListItem.HtmlInputToOptionTag(DefaultGroupOptionListSelectedValue);
            GuestGroupOptionListValue += lcu.UserGroupListItem.HtmlInputToOptionTag(GuestGroupOptionListSelectedValue);

            ListClass.DateAndTime lcdat = new ListClass.DateAndTime();

            // Set Time Zone Item
            lcdat.FillTimeZoneListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            TimeZoneOptionListValue = TimeZoneOptionListValue.HtmlInputAddOptionTag("", "0");
            TimeZoneOptionListValue += lcdat.TimeZoneListItem.HtmlInputToOptionTag(TimeZoneOptionListSelectedValue);

            // Set Calendar Item
            lcdat.FillCalendarListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            CalendarOptionListValue += lcdat.CalendarListItem.HtmlInputToOptionTag(CalendarOptionListSelectedValue, true);

            // Set Day Of Weak Item
            lcdat.FillDayOfWeakListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            FirstDayOfWeekOptionListValue = FirstDayOfWeekOptionListValue.HtmlInputAddOptionTag("", "0");
            FirstDayOfWeekOptionListValue += lcdat.DayOfWeakListItem.HtmlInputToOptionTag(FirstDayOfWeekOptionListSelectedValue);

            // Set Role Cache Type Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleCacheTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            AdminRoleCacheTypeOptionListValue += lcr.RoleCacheTypeListItem.HtmlInputToOptionTag(AdminRoleCacheTypeOptionListSelectedValue);
            MemberRoleCacheTypeOptionListValue += lcr.RoleCacheTypeListItem.HtmlInputToOptionTag(MemberRoleCacheTypeOptionListSelectedValue);
            GuestRoleCacheTypeOptionListValue += lcr.RoleCacheTypeListItem.HtmlInputToOptionTag(GuestRoleCacheTypeOptionListSelectedValue);
            TextCreatorCacheTypeOptionListValue += lcr.RoleCacheTypeListItem.HtmlInputToOptionTag(TextCreatorCacheTypeOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_AdminDirectoryPath", "");
            InputRequest.Add("txt_LockLoginDirectoryPath", "");
            InputRequest.Add("txt_SecretKey", "");
            InputRequest.Add("txt_SystemAccessCode", "");
            InputRequest.Add("txt_LockLoginPassword", "");
            InputRequest.Add("txt_NewPasswordLength", "");
            InputRequest.Add("txt_DataBaseName", "");
            InputRequest.Add("txt_ConectionString", "");
            InputRequest.Add("txt_UserSecureValueSize", "");
            InputRequest.Add("txt_NewRandomTextValueCount", "");
            InputRequest.Add("txt_CaptchaNoise", "");
            InputRequest.Add("txt_CaptchaCharacterCountFrom", "");
            InputRequest.Add("txt_CaptchaCharacterCountTo", "");
            InputRequest.Add("txt_CaptchaCharacter", "");
            InputRequest.Add("txt_CaptchaFont", "");
            InputRequest.Add("txt_CaptchaFontSize", "");
            InputRequest.Add("txt_CaptchaRotateTransform", "");
            InputRequest.Add("txt_CaptchaWidth", "");
            InputRequest.Add("txt_CaptchaHeight", "");
            InputRequest.Add("txt_CaptchaRepeatTime", "");
            InputRequest.Add("txt_CaptchaAdminReleaseCount", "");
            InputRequest.Add("txt_CaptchaMemberReleaseCount", "");
            InputRequest.Add("txt_CaptchaGuestReleaseCount", "");
            InputRequest.Add("txt_RobotDetectionIpBlockDuration", "");
            InputRequest.Add("txt_RobotDetectionResetTimeDuration", "");
            InputRequest.Add("txt_RobotDetectionAdminRequestCount", "");
            InputRequest.Add("txt_RobotDetectionMemberRequestCount", "");
            InputRequest.Add("txt_RobotDetectionGuestRequestCount", "");
            InputRequest.Add("txt_RobotDetectionAdminRequestCount", "");
            InputRequest.Add("txt_RobotDetectionMemberRequestCount", "");
            InputRequest.Add("txt_RobotDetectionGuestRequestCount", "");
            InputRequest.Add("txt_AdminLifeTime", "");
            InputRequest.Add("txt_MemberLifeTime", "");
            InputRequest.Add("txt_GuestLifeTime", "");
            InputRequest.Add("txt_SessionLifeTime", "");
            InputRequest.Add("txt_CookieLifeTime", "");
            InputRequest.Add("txt_EmailHost", "");
            InputRequest.Add("txt_EmailPort", "");
            InputRequest.Add("txt_EmailUserName", "");
            InputRequest.Add("txt_EmailPassword", "");
            InputRequest.Add("txt_EmailSender", "");
            InputRequest.Add("txt_TextBeforeEmailSubject", "");
            InputRequest.Add("txt_TextAfterEmailSubject", "");
            InputRequest.Add("txt_TextBeforeEmailBody", "");
            InputRequest.Add("txt_TextAfterEmailBody", "");
            InputRequest.Add("txt_DateFormat", "");
            InputRequest.Add("txt_TimeFormat", "");
            InputRequest.Add("txt_DayDifference", "");
            InputRequest.Add("txt_TimeHoursDifference", "");
            InputRequest.Add("txt_TimeMinutesDifference", "");
            InputRequest.Add("txt_MaximumSizeForBackup", "");
            InputRequest.Add("txt_MaximumSizeForUpload", "");
            InputRequest.Add("txt_MaximumSizeForAttachment", "");
            InputRequest.Add("txt_MaximumSizeForPlugin", "");
            InputRequest.Add("txt_MaximumSizeForModule", "");
            InputRequest.Add("txt_MaximumSizeForComponent", "");
            InputRequest.Add("txt_MaximumSizeForExtraHelper", "");
            InputRequest.Add("txt_MaximumSizeForEditorTemplate", "");
            InputRequest.Add("txt_MaximumSizeForPatch", "");
            InputRequest.Add("txt_MaximumSizeForFetch", "");
            InputRequest.Add("txt_MaximumSizeForSiteTemplate", "");
            InputRequest.Add("txt_MaximumSizeForSiteStyle", "");
            InputRequest.Add("txt_MaximumSizeForAdminTemplate", "");
            InputRequest.Add("txt_MaximumSizeForAdminStyle", "");
            InputRequest.Add("txt_MaximumSizeForComment", "");
            InputRequest.Add("txt_MaximumSizeForContact", "");
            InputRequest.Add("txt_MaximumSizeForPage", "");
            InputRequest.Add("txt_MaximumSizeForLanguage", "");
            InputRequest.Add("txt_MaximumSizeForContentAvatar", "");
            InputRequest.Add("txt_MaximumSizeForUserAvatar", "");
            InputRequest.Add("txt_MaximumSizeForUserUpload", "");
            InputRequest.Add("txt_ThumbnailImageHeight", "");
            InputRequest.Add("txt_ThumbnailImageWidth", "");
            InputRequest.Add("txt_SiteMainCacheParameters", "");
            InputRequest.Add("txt_AdminMainCacheParameters", "");
            InputRequest.Add("txt_AdminRoleCache", "");
            InputRequest.Add("txt_MemberRoleCache", "");
            InputRequest.Add("txt_GuestRoleCache", "");
            InputRequest.Add("txt_ClientCacheForDynamicPageCache", "");
            InputRequest.Add("txt_ClientCacheForStaticPageCache", "");
            InputRequest.Add("txt_TextCreatorServerCacheDuration", "");
            InputRequest.Add("txt_TextCreatorClientCacheDuration", "");
            InputRequest.Add("txt_MainDelay", "");
            InputRequest.Add("txt_SignUpDelay", "");
            InputRequest.Add("txt_LoginDelay", "");
            InputRequest.Add("txt_LockLoginPageDelay", "");
            InputRequest.Add("txt_CaptchaDelay", "");
            InputRequest.Add("txt_ShowProtectionContentDelay", "");
            InputRequest.Add("txt_ShowProtectionAttachmentDelayValue", "");
            InputRequest.Add("ddlst_DefaultGroup", DefaultGroupOptionListValue);
            InputRequest.Add("ddlst_GuestGroup", GuestGroupOptionListValue);
            InputRequest.Add("ddlst_Calendar", CalendarOptionListValue);
            InputRequest.Add("ddlst_FirstDayOfWeek", FirstDayOfWeekOptionListValue);
            InputRequest.Add("ddlst_TimeZone", TimeZoneOptionListValue);
            InputRequest.Add("ddlst_AdminRoleCacheType", AdminRoleCacheTypeOptionListValue);
            InputRequest.Add("ddlst_MemberRoleCacheType", MemberRoleCacheTypeOptionListValue);
            InputRequest.Add("ddlst_GuestRoleCacheType", GuestRoleCacheTypeOptionListValue);
            InputRequest.Add("ddlst_TextCreatorCacheType", TextCreatorCacheTypeOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/options/", "*");

            AdminDirectoryPathAttribute += vc.ImportantInputAttribute.GetValue("txt_AdminDirectoryPath");
            LockLoginDirectoryPathAttribute += vc.ImportantInputAttribute.GetValue("txt_LockLoginDirectoryPath");
            SecretKeyAttribute += vc.ImportantInputAttribute.GetValue("txt_SecretKey");
            SystemAccessCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_SystemAccessCode");
            LockLoginPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_LockLoginPassword");
            NewPasswordLengthAttribute += vc.ImportantInputAttribute.GetValue("txt_NewPasswordLength");
            DataBaseNameAttribute += vc.ImportantInputAttribute.GetValue("txt_DataBaseName");
            ConectionStringAttribute += vc.ImportantInputAttribute.GetValue("txt_ConectionString");
            UserSecureValueSizeAttribute += vc.ImportantInputAttribute.GetValue("txt_UserSecureValueSize");
            NewRandomTextValueCountAttribute += vc.ImportantInputAttribute.GetValue("txt_NewRandomTextValueCount");
            CaptchaNoiseAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaNoise");
            CaptchaCharacterCountFromAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaCharacterCountFrom");
            CaptchaCharacterCountToAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaCharacterCountTo");
            CaptchaCharacterAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaCharacter");
            CaptchaFontAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaFont");
            CaptchaFontSizeAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaFontSize");
            CaptchaRotateTransformAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaRotateTransform");
            CaptchaWidthAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaWidth");
            CaptchaHeightAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaHeight");
            CaptchaRepeatTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaRepeatTime");
            CaptchaAdminReleaseCountAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaAdminReleaseCount");
            CaptchaMemberReleaseCountAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaMemberReleaseCount");
            CaptchaGuestReleaseCountAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaGuestReleaseCount");
            RobotDetectionIpBlockDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionIpBlockDuration");
            RobotDetectionResetTimeDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionResetTimeDuration");
            RobotDetectionAdminRequestCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionAdminRequestCount");
            RobotDetectionMemberRequestCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionMemberRequestCount");
            RobotDetectionGuestRequestCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionGuestRequestCount");
            RobotDetectionAdminRequestAfterShowCaptchaCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionAdminRequestAfterShowCaptchaCount");
            RobotDetectionMemberRequestAfterShowCaptchaCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionMemberRequestAfterShowCaptchaCount");
            RobotDetectionGuestRequestAfterShowCaptchaCountAttribute += vc.ImportantInputAttribute.GetValue("txt_RobotDetectionGuestRequestAfterShowCaptchaCount");
            AdminLifeTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_AdminLifeTime");
            MemberLifeTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_MemberLifeTime");
            GuestLifeTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_GuestLifeTime");
            SessionLifeTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_SessionLifeTime");
            CookieLifeTimeAttribute += vc.ImportantInputAttribute.GetValue("txt_CookieLifeTime");
            EmailHostAttribute += vc.ImportantInputAttribute.GetValue("txt_EmailHost");
            EmailPortAttribute += vc.ImportantInputAttribute.GetValue("txt_EmailPort");
            EmailUserNameAttribute += vc.ImportantInputAttribute.GetValue("txt_EmailUserName");
            EmailPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_EmailPassword");
            EmailSenderAttribute += vc.ImportantInputAttribute.GetValue("txt_EmailSender");
            TextBeforeEmailSubjectAttribute += vc.ImportantInputAttribute.GetValue("txt_TextBeforeEmailSubject");
            TextAfterEmailSubjectAttribute += vc.ImportantInputAttribute.GetValue("txt_TextAfterEmailSubject");
            TextBeforeEmailBodyAttribute += vc.ImportantInputAttribute.GetValue("txt_TextBeforeEmailBody");
            TextAfterEmailBodyAttribute += vc.ImportantInputAttribute.GetValue("txt_TextAfterEmailBody");
            DateFormatAttribute += vc.ImportantInputAttribute.GetValue("txt_DateFormat");
            TimeFormatAttribute += vc.ImportantInputAttribute.GetValue("txt_TimeFormat");
            DayDifferenceAttribute += vc.ImportantInputAttribute.GetValue("txt_DayDifference");
            TimeHoursDifferenceAttribute += vc.ImportantInputAttribute.GetValue("txt_TimeHoursDifference");
            TimeMinutesDifferenceAttribute += vc.ImportantInputAttribute.GetValue("txt_TimeMinutesDifference");
            MaximumSizeForBackupAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForBackup");
            MaximumSizeForUploadAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForUpload");
            MaximumSizeForAttachmentAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForAttachment");
            MaximumSizeForPluginAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForPlugin");
            MaximumSizeForModuleAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForModule");
            MaximumSizeForComponentAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForComponent");
            MaximumSizeForExtraHelperAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForExtraHelper");
            MaximumSizeForEditorTemplateAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForEditorTemplate");
            MaximumSizeForPatchAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForPatch");
            MaximumSizeForFetchAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForFetch");
            MaximumSizeForSiteTemplateAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForSiteTemplate");
            MaximumSizeForSiteStyleAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForSiteStyle");
            MaximumSizeForAdminTemplateAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForAdminTemplate");
            MaximumSizeForAdminStyleAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForAdminStyle");
            MaximumSizeForCommentAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForComment");
            MaximumSizeForContactAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForContact");
            MaximumSizeForPageAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForPage");
            MaximumSizeForLanguageAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForLanguage");
            MaximumSizeForContentAvatarAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForContentAvatar");
            MaximumSizeForUserAvatarAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForUserAvatar");
            MaximumSizeForUserUploadAttribute += vc.ImportantInputAttribute.GetValue("txt_MaximumSizeForUserUpload");
            ThumbnailImageHeightAttribute += vc.ImportantInputAttribute.GetValue("txt_ThumbnailImageHeight");
            ThumbnailImageWidthAttribute += vc.ImportantInputAttribute.GetValue("txt_ThumbnailImageWidth");
            SiteMainCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteMainCacheParameters");
            AdminMainCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_AdminMainCacheParameters");
            AdminRoleCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_AdminRoleCache");
            MemberRoleCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_MemberRoleCache");
            GuestRoleCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_GuestRoleCache");
            ClientCacheForDynamicPageCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_ClientCacheForDynamicPageCache");
            ClientCacheForStaticPageCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_ClientCacheForStaticPageCache");
            TextCreatorServerCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_TextCreatorServerCacheDuration");
            TextCreatorClientCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_TextCreatorClientCacheDuration");
            MainDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_MainDelay");
            SignUpDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_SignUpDelay");
            LoginDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_LoginDelay");
            LockLoginPageDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_LockLoginPageDelay");
            CaptchaDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_CaptchaDelay");
            ShowProtectionContentDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_ShowProtectionContentDelay");
            ShowProtectionAttachmentDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_ShowProtectionAttachmentDelay");
            DefaultGroupAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultGroup");
            GuestGroupAttribute += vc.ImportantInputAttribute.GetValue("ddlst_GuestGroup");
            CalendarAttribute += vc.ImportantInputAttribute.GetValue("ddlst_Calendar");
            FirstDayOfWeekAttribute += vc.ImportantInputAttribute.GetValue("ddlst_FirstDayOfWeek");
            TimeZoneAttribute += vc.ImportantInputAttribute.GetValue("ddlst_TimeZone");
            AdminRoleCacheTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_AdminRoleCacheType");
            MemberRoleCacheTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_MemberRoleCacheType");
            GuestRoleCacheTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_GuestRoleCacheType");
            TextCreatorCacheTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_TextCreatorCacheType");

            AdminDirectoryPathCssClass = AdminDirectoryPathCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AdminDirectoryPath"));
            LockLoginDirectoryPathCssClass = LockLoginDirectoryPathCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LockLoginDirectoryPath"));
            SecretKeyCssClass = SecretKeyCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SecretKey"));
            SystemAccessCodeCssClass = SystemAccessCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SystemAccessCode"));
            LockLoginPasswordCssClass = LockLoginPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LockLoginPassword"));
            NewPasswordLengthCssClass = NewPasswordLengthCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_NewPasswordLength"));
            DataBaseNameCssClass = DataBaseNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_DataBaseName"));
            ConectionStringCssClass = ConectionStringCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ConectionString"));
            UserSecureValueSizeCssClass = UserSecureValueSizeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserSecureValueSize"));
            NewRandomTextValueCountCssClass = NewRandomTextValueCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_NewRandomTextValueCount"));
            CaptchaNoiseCssClass = CaptchaNoiseCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaNoise"));
            CaptchaCharacterCountFromCssClass = CaptchaCharacterCountFromCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaCharacterCountFrom"));
            CaptchaCharacterCountToCssClass = CaptchaCharacterCountToCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaCharacterCountTo"));
            CaptchaCharacterCssClass = CaptchaCharacterCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaCharacter"));
            CaptchaFontCssClass = CaptchaFontCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaFont"));
            CaptchaFontSizeCssClass = CaptchaFontSizeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaFontSize"));
            CaptchaRotateTransformCssClass = CaptchaRotateTransformCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaRotateTransform"));
            CaptchaWidthCssClass = CaptchaWidthCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaWidth"));
            CaptchaHeightCssClass = CaptchaHeightCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaHeight"));
            CaptchaRepeatTimeCssClass = CaptchaRepeatTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaRepeatTime"));
            CaptchaAdminReleaseCountCssClass = CaptchaAdminReleaseCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaAdminReleaseCount"));
            CaptchaMemberReleaseCountCssClass = CaptchaMemberReleaseCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaMemberReleaseCount"));
            CaptchaGuestReleaseCountCssClass = CaptchaGuestReleaseCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaGuestReleaseCount"));
            RobotDetectionIpBlockDurationCssClass = RobotDetectionIpBlockDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionIpBlockDuration"));
            RobotDetectionResetTimeDurationCssClass = RobotDetectionResetTimeDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionResetTimeDuration"));
            RobotDetectionAdminRequestCountCssClass = RobotDetectionAdminRequestCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionAdminRequestCount"));
            RobotDetectionMemberRequestCountCssClass = RobotDetectionMemberRequestCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionMemberRequestCount"));
            RobotDetectionGuestRequestCountCssClass = RobotDetectionGuestRequestCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionGuestRequestCount"));
            RobotDetectionAdminRequestAfterShowCaptchaCountCssClass = RobotDetectionAdminRequestAfterShowCaptchaCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionAdminRequestAfterShowCaptchaCount"));
            RobotDetectionMemberRequestAfterShowCaptchaCountCssClass = RobotDetectionMemberRequestAfterShowCaptchaCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionMemberRequestAfterShowCaptchaCount"));
            RobotDetectionGuestRequestAfterShowCaptchaCountCssClass = RobotDetectionGuestRequestAfterShowCaptchaCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RobotDetectionGuestRequestAfterShowCaptchaCount"));
            AdminLifeTimeCssClass = AdminLifeTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AdminLifeTime"));
            MemberLifeTimeCssClass = MemberLifeTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MemberLifeTime"));
            GuestLifeTimeCssClass = GuestLifeTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_GuestLifeTime"));
            SessionLifeTimeCssClass = SessionLifeTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SessionLifeTime"));
            CookieLifeTimeCssClass = CookieLifeTimeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CookieLifeTime"));
            EmailHostCssClass = EmailHostCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EmailHost"));
            EmailPortCssClass = EmailPortCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EmailPort"));
            EmailUserNameCssClass = EmailUserNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EmailUserName"));
            EmailPasswordCssClass = EmailPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EmailPassword"));
            EmailSenderCssClass = EmailSenderCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EmailSender"));
            TextBeforeEmailSubjectCssClass = TextBeforeEmailSubjectCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextBeforeEmailSubject"));
            TextAfterEmailSubjectCssClass = TextAfterEmailSubjectCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextAfterEmailSubject"));
            TextBeforeEmailBodyCssClass = TextBeforeEmailBodyCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextBeforeEmailBody"));
            TextAfterEmailBodyCssClass = TextAfterEmailBodyCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextAfterEmailBody"));
            DateFormatCssClass = DateFormatCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_DateFormat"));
            TimeFormatCssClass = TimeFormatCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TimeFormat"));
            DayDifferenceCssClass = DayDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_DayDifference"));
            TimeHoursDifferenceCssClass = TimeHoursDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TimeHoursDifference"));
            TimeMinutesDifferenceCssClass = TimeMinutesDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TimeMinutesDifference"));
            MaximumSizeForBackupCssClass = MaximumSizeForBackupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForBackup"));
            MaximumSizeForUploadCssClass = MaximumSizeForUploadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForUpload"));
            MaximumSizeForAttachmentCssClass = MaximumSizeForAttachmentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForAttachment"));
            MaximumSizeForPluginCssClass = MaximumSizeForPluginCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForPlugin"));
            MaximumSizeForModuleCssClass = MaximumSizeForModuleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForModule"));
            MaximumSizeForComponentCssClass = MaximumSizeForComponentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForComponent"));
            MaximumSizeForExtraHelperCssClass = MaximumSizeForExtraHelperCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForExtraHelper"));
            MaximumSizeForEditorTemplateCssClass = MaximumSizeForEditorTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForEditorTemplate"));
            MaximumSizeForPatchCssClass = MaximumSizeForPatchCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForPatch"));
            MaximumSizeForFetchCssClass = MaximumSizeForFetchCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForFetch"));
            MaximumSizeForSiteTemplateCssClass = MaximumSizeForSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForSiteTemplate"));
            MaximumSizeForSiteStyleCssClass = MaximumSizeForSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForSiteStyle"));
            MaximumSizeForAdminTemplateCssClass = MaximumSizeForAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForAdminTemplate"));
            MaximumSizeForAdminStyleCssClass = MaximumSizeForAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForAdminStyle"));
            MaximumSizeForCommentCssClass = MaximumSizeForCommentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForComment"));
            MaximumSizeForContactCssClass = MaximumSizeForContactCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForContact"));
            MaximumSizeForPageCssClass = MaximumSizeForPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForPage"));
            MaximumSizeForLanguageCssClass = MaximumSizeForLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForLanguage"));
            MaximumSizeForContentAvatarCssClass = MaximumSizeForContentAvatarCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForContentAvatar"));
            MaximumSizeForUserAvatarCssClass = MaximumSizeForUserAvatarCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForUserAvatar"));
            MaximumSizeForUserUploadCssClass = MaximumSizeForUserUploadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MaximumSizeForUserUpload"));
            ThumbnailImageHeightCssClass = ThumbnailImageHeightCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ThumbnailImageHeight"));
            ThumbnailImageWidthCssClass = ThumbnailImageWidthCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ThumbnailImageWidth"));
            SiteMainCacheParametersCssClass = SiteMainCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteMainCacheParameters"));
            AdminMainCacheParametersCssClass = AdminMainCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AdminMainCacheParameters"));
            AdminRoleCacheCssClass = AdminRoleCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AdminRoleCache"));
            MemberRoleCacheCssClass = MemberRoleCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MemberRoleCache"));
            GuestRoleCacheCssClass = GuestRoleCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_GuestRoleCache"));
            ClientCacheForDynamicPageCacheCssClass = ClientCacheForDynamicPageCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ClientCacheForDynamicPageCache"));
            ClientCacheForStaticPageCacheCssClass = ClientCacheForStaticPageCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ClientCacheForStaticPageCache"));
            TextCreatorServerCacheDurationCssClass = TextCreatorServerCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextCreatorServerCacheDuration"));
            TextCreatorClientCacheDurationCssClass = TextCreatorClientCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_TextCreatorClientCacheDuration"));
            MainDelayCssClass = MainDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MainDelay"));
            SignUpDelayCssClass = SignUpDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SignUpDelay"));
            LoginDelayCssClass = LoginDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LoginDelay"));
            LockLoginPageDelayCssClass = LockLoginPageDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LockLoginPageDelay"));
            CaptchaDelayCssClass = CaptchaDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CaptchaDelay"));
            ShowProtectionContentDelayCssClass = ShowProtectionContentDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ShowProtectionContentDelay"));
            ShowProtectionAttachmentDelayCssClass = ShowProtectionAttachmentDelayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ShowProtectionAttachmentDelay"));
            DefaultGroupCssClass = DefaultGroupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultGroup"));
            GuestGroupCssClass = GuestGroupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_GuestGroup"));
            CalendarCssClass = CalendarCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_Calendar"));
            FirstDayOfWeekCssClass = FirstDayOfWeekCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_FirstDayOfWeek"));
            TimeZoneCssClass = TimeZoneCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_TimeZone"));
            AdminRoleCacheTypeCssClass = AdminRoleCacheTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_AdminRoleCacheType"));
            MemberRoleCacheTypeCssClass = MemberRoleCacheTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_MemberRoleCacheType"));
            GuestRoleCacheTypeCssClass = GuestRoleCacheTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_GuestRoleCacheType"));
            TextCreatorCacheTypeCssClass = TextCreatorCacheTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_TextCreatorCacheType"));
        }

        public void SecurityEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "security", StaticObject.AdminPath + "/options/");

            SecurityEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSecurityEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void EmailEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "email", StaticObject.AdminPath + "/options/");

            EmailEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEmailEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void DateAndTimeEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "date_and_time", StaticObject.AdminPath + "/options/");

            DateAndTimeEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindDateAndTimeEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void FileAndDirectoryEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "file_and_directory", StaticObject.AdminPath + "/options/");

            FileAndDirectoryEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindFileAndDirectoryEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void DelayEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "delay", StaticObject.AdminPath + "/options/");

            DelayEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindDelayEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void CacheEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "cache", StaticObject.AdminPath + "/options/");

            CacheEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindCacheEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveSecurity()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/security/inactive_site").Attributes["active"].Value = InactiveSiteValue ? "true" : "false";

            if (!string.IsNullOrEmpty(AdminDirectoryPathValue))
                Security.SetCodeIni("admin_directory_path", AdminDirectoryPathValue);

            if (!string.IsNullOrEmpty(LockLoginDirectoryPathValue))
                Security.SetCodeIni("lock_login_directory_path", LockLoginDirectoryPathValue);

            if (!string.IsNullOrEmpty(LockLoginPasswordValue))
                Security.SetCodeIni("lock_login_password_value", LockLoginPasswordValue);

            if (!string.IsNullOrEmpty(ConectionStringValue))
                Security.SetCodeIni("connection_string", ConectionStringValue);

            if (!string.IsNullOrEmpty(SecretKeyValue))
                Security.SetCodeIni("secret_key", SecretKeyValue);

            if (!string.IsNullOrEmpty(SystemAccessCodeValue))
                Security.SetCodeIni("system_access_code", SystemAccessCodeValue);

            DataUse.Group dug = new DataUse.Group();
            

            doc.SelectSingleNode("elanat_root/security/just_use_https").Attributes["active"].Value = JustUseHttpsValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/just_use_https_in_admin").Attributes["active"].Value = JustUseHttpsForAdminValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/just_use_https_in_site").Attributes["active"].Value = JustUseHttpsForSiteValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/just_use_https_in_login_page").Attributes["active"].Value = JustUseHttpsForLoginPageValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/save_logs_error").Attributes["active"].Value = SaveLogsErrorValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/use_secret_key_for_login").Attributes["active"].Value = UseSecretKeyForLoginValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/use_admin_activation").Attributes["active"].Value = UseAdminActivationValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/registered_user_after_accept_active_email").Attributes["active"].Value = UseEmailActivationValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/captcha_noise").Attributes["value"].Value = CaptchaNoiseValue;
            doc.SelectSingleNode("elanat_root/security/captcha_character_count").Attributes["from"].Value = CaptchaCharacterCountFromValue;
            doc.SelectSingleNode("elanat_root/security/captcha_character_count").Attributes["to"].Value = CaptchaCharacterCountToValue;
            doc.SelectSingleNode("elanat_root/security/captcha_character").InnerText = CaptchaCharacterValue;
            doc.SelectSingleNode("elanat_root/security/captcha_font").Attributes["value"].Value = CaptchaFontValue;
            doc.SelectSingleNode("elanat_root/security/captcha_font_size").Attributes["value"].Value = CaptchaFontSizeValue;
            doc.SelectSingleNode("elanat_root/security/captcha_rotate_transform").Attributes["value"].Value = CaptchaRotateTransformValue;
            doc.SelectSingleNode("elanat_root/security/captcha_width").Attributes["value"].Value = CaptchaWidthValue;
            doc.SelectSingleNode("elanat_root/security/captcha_height").Attributes["value"].Value = CaptchaHeightValue;
            doc.SelectSingleNode("elanat_root/security/captcha_repeat_time").Attributes["value"].Value = CaptchaRepeatTimeValue;
            doc.SelectSingleNode("elanat_root/security/captcha_admin_release_count").Attributes["value"].Value = CaptchaAdminReleaseCountValue;
            doc.SelectSingleNode("elanat_root/security/captcha_member_release_count").Attributes["value"].Value = CaptchaMemberReleaseCountValue;
            doc.SelectSingleNode("elanat_root/security/captcha_guest_release_count").Attributes["value"].Value = CaptchaGuestReleaseCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection").Attributes["active"].Value = UseRobotDetectionValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/robot_detection_ip_block_duration").Attributes["value"].Value = RobotDetectionIpBlockDurationValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_reset_time_duration").Attributes["value"].Value = RobotDetectionResetTimeDurationValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_admin_request").Attributes["count"].Value = RobotDetectionAdminRequestCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_member_request").Attributes["count"].Value = RobotDetectionMemberRequestCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_guest_request").Attributes["count"].Value = RobotDetectionGuestRequestCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_admin_request").Attributes["after_show_captcha_count"].Value = RobotDetectionAdminRequestAfterShowCaptchaCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_member_request").Attributes["after_show_captcha_count"].Value = RobotDetectionMemberRequestAfterShowCaptchaCountValue;
            doc.SelectSingleNode("elanat_root/security/robot_detection_guest_request").Attributes["after_show_captcha_count"].Value = RobotDetectionGuestRequestAfterShowCaptchaCountValue;
            doc.SelectSingleNode("elanat_root/security/use_sensitivity_case_captcha").Attributes["active"].Value = UseSensitivityCaseCaptchaValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/session_life_time").Attributes["value"].Value = SessionLifeTimeValue;
            doc.SelectSingleNode("elanat_root/security/cookie_life_time").Attributes["value"].Value = CookieLifeTimeValue;
            doc.SelectSingleNode("elanat_root/security/default_group").Attributes["value"].Value = dug.GetGroupName(DefaultGroupOptionListSelectedValue);
            doc.SelectSingleNode("elanat_root/security/admin_life_time").Attributes["value"].Value = AdminLifeTimeValue;
            doc.SelectSingleNode("elanat_root/security/member_life_time").Attributes["value"].Value = MemberLifeTimeValue;
            doc.SelectSingleNode("elanat_root/security/guest_life_time").Attributes["value"].Value = GuestLifeTimeValue;
            doc.SelectSingleNode("elanat_root/security/guest_group").Attributes["value"].Value = dug.GetGroupName(GuestGroupOptionListSelectedValue);
            doc.SelectSingleNode("elanat_root/security/database_name").Attributes["value"].Value = DataBaseNameValue;
            doc.SelectSingleNode("elanat_root/security/new_password_length").Attributes["value"].Value = NewPasswordLengthValue;
            doc.SelectSingleNode("elanat_root/security/new_random_text_value_count").Attributes["value"].Value = NewRandomTextValueCountValue;
            doc.SelectSingleNode("elanat_root/security/lock_login_for_first_login").Attributes["active"].Value = LockLoginForFirstLoginValue ? "true" : "false";
            doc.SelectSingleNode("elanat_root/security/user_secure_value_size").Attributes["value"].Value = UserSecureValueSizeValue;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_security", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("security_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveDebug()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/debug/write_logs_error").Attributes["active"].Value = WriteLogsErrorValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/debug/use_variant_debug").Attributes["active"].Value = UseVariantDebugValue.BooleanToTrueFalse();

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_debug", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("debug_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveActive()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/active/login_active").Attributes["active"].Value = LoginActiveValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/active/sign_up_active").Attributes["active"].Value = SignUpActiveValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/active/add_comment").Attributes["active"].Value = AddCommentValue.BooleanToTrueFalse();

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_active", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("active_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveEmail()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            if (!string.IsNullOrEmpty(EmailPasswordValue))
                Security.SetCodeIni("mail_password", EmailPasswordValue);

            doc.SelectSingleNode("elanat_root/email/host").InnerText = EmailHostValue;
            doc.SelectSingleNode("elanat_root/email/port").InnerText = EmailPortValue;
            doc.SelectSingleNode("elanat_root/email/username").InnerText = EmailUserNameValue;
            doc.SelectSingleNode("elanat_root/email/sender").InnerText = EmailSenderValue.ToLower();
            doc.SelectSingleNode("elanat_root/email/text_before_email_subject").InnerText = TextBeforeEmailSubjectValue;
            doc.SelectSingleNode("elanat_root/email/text_after_email_subject").InnerText = TextAfterEmailSubjectValue;
            doc.SelectSingleNode("elanat_root/email/text_before_email_body").InnerText = TextBeforeEmailBodyValue;
            doc.SelectSingleNode("elanat_root/email/text_after_email_body").InnerText = TextAfterEmailBodyValue;
            doc.SelectSingleNode("elanat_root/email/use_https").Attributes["active"].Value = EmailUseHttpsValue ? "true" : "false";

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_email", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveDateAndTime()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/date_and_time/date_format").InnerText = DateFormatValue;
            doc.SelectSingleNode("elanat_root/date_and_time/time_format").InnerText = TimeFormatValue;
            doc.SelectSingleNode("elanat_root/date_and_time/day_difference").Attributes["value"].Value = DayDifferenceValue;
            doc.SelectSingleNode("elanat_root/date_and_time/time_difference_hours").Attributes["value"].Value = TimeHoursDifferenceValue;
            doc.SelectSingleNode("elanat_root/date_and_time/time_difference_minutes").Attributes["value"].Value = TimeMinutesDifferenceValue;
            doc.SelectSingleNode("elanat_root/date_and_time/default_calendar").Attributes["value"].Value = CalendarOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/date_and_time/first_day_of_week").Attributes["value"].Value = FirstDayOfWeekOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/date_and_time/time_zone").Attributes["value"].Value = TimeZoneOptionListSelectedValue;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_date_and_time", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("date_and_time_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveFileAndDirectory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_user_upload").Attributes["value"].Value = MaximumSizeForUserUploadValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_user_avatar").Attributes["value"].Value = MaximumSizeForUserAvatarValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_content_avatar").Attributes["value"].Value = MaximumSizeForContentAvatarValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_language").Attributes["value"].Value = MaximumSizeForLanguageValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_page").Attributes["value"].Value = MaximumSizeForPageValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_patch").Attributes["value"].Value = MaximumSizeForPatchValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_contact").Attributes["value"].Value = MaximumSizeForContactValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_comment").Attributes["value"].Value = MaximumSizeForCommentValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_admin_style").Attributes["value"].Value = MaximumSizeForAdminStyleValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_admin_template").Attributes["value"].Value = MaximumSizeForAdminTemplateValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_site_style").Attributes["value"].Value = MaximumSizeForSiteStyleValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_site_template").Attributes["value"].Value = MaximumSizeForSiteTemplateValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_editor_template").Attributes["value"].Value = MaximumSizeForEditorTemplateValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_extra_helper").Attributes["value"].Value = MaximumSizeForExtraHelperValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_fetch").Attributes["value"].Value = MaximumSizeForFetchValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_component").Attributes["value"].Value = MaximumSizeForComponentValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_module").Attributes["value"].Value = MaximumSizeForModuleValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_plugin").Attributes["value"].Value = MaximumSizeForPluginValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_attachment").Attributes["value"].Value = MaximumSizeForAttachmentValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_upload").Attributes["value"].Value = MaximumSizeForUploadValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/maximum_size_for_backup").Attributes["value"].Value = MaximumSizeForBackupValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/thumbnail_image_width").Attributes["value"].Value = ThumbnailImageWidthValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/thumbnail_image_height").Attributes["value"].Value = ThumbnailImageHeightValue;
            doc.SelectSingleNode("elanat_root/file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value = (AutoCreateThumbnailImageValue) ? "true" : "false";

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_file_and_directory", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("file_and_directory_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveCache()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/cache/site_main").Attributes["active"].Value = UseSiteMainCacheValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/site_main").Attributes["cache_parameters"].Value = SiteMainCacheParametersValue;
            doc.SelectSingleNode("elanat_root/cache/admin_main").Attributes["active"].Value = UseAdminMainCacheValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/admin_main").Attributes["cache_parameters"].Value = AdminMainCacheParametersValue;
            doc.SelectSingleNode("elanat_root/cache/admin_role").Attributes["cache_type"].Value = AdminRoleCacheTypeOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/cache/admin_role").Attributes["value"].Value = AdminRoleCacheValue;
            doc.SelectSingleNode("elanat_root/cache/member_role").Attributes["cache_type"].Value = MemberRoleCacheTypeOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/cache/member_role").Attributes["value"].Value = MemberRoleCacheValue;
            doc.SelectSingleNode("elanat_root/cache/guest_role").Attributes["cache_type"].Value = GuestRoleCacheTypeOptionListSelectedValue;
            doc.SelectSingleNode("elanat_root/cache/guest_role").Attributes["value"].Value = GuestRoleCacheValue;
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_dynamic_page").Attributes["value"].Value = ClientCacheForDynamicPageCacheValue;
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_dynamic_page").Attributes["active"].Value = UseClientCacheForDynamicPageValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_dynamic_page").Attributes["check_server_cache"].Value = CheckServerCacheValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_static_page").Attributes["value"].Value = ClientCacheForStaticPageCacheValue;
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_static_page").Attributes["active"].Value = UseClientCacheForStaticPageValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/use_client_cache_for_static_page").Attributes["check_last_modified"].Value = CheckLastModifiedValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/text_creator_cache").Attributes["server_value"].Value = TextCreatorServerCacheDurationValue;
            doc.SelectSingleNode("elanat_root/cache/text_creator_cache").Attributes["client_value"].Value = TextCreatorClientCacheDurationValue;
            doc.SelectSingleNode("elanat_root/cache/text_creator_cache").Attributes["use_server_cache"].Value = TextCreatorUseServerCacheValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/text_creator_cache").Attributes["use_client_cache"].Value = TextCreatorUseClientCacheValue.BooleanToTrueFalse();
            doc.SelectSingleNode("elanat_root/cache/text_creator_cache").Attributes["cache_type"].Value = TextCreatorCacheTypeOptionListSelectedValue;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_cache", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("cache_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }

        public void SaveDelay()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            doc.SelectSingleNode("elanat_root/delay/main").Attributes["value"].Value = MainDelayValue;
            doc.SelectSingleNode("elanat_root/delay/sign_up").Attributes["value"].Value = SignUpDelayValue;
            doc.SelectSingleNode("elanat_root/delay/login").Attributes["value"].Value = LoginDelayValue;
            doc.SelectSingleNode("elanat_root/delay/lock_login_page").Attributes["value"].Value = LockLoginPageDelayValue;
            doc.SelectSingleNode("elanat_root/delay/captcha").Attributes["value"].Value = CaptchaDelayValue;
            doc.SelectSingleNode("elanat_root/delay/show_protection_content").Attributes["value"].Value = ShowProtectionContentDelayValue;
            doc.SelectSingleNode("elanat_root/delay/show_protection_attachment").Attributes["value"].Value = ShowProtectionAttachmentDelayValue;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));


            // Set Run Time Update
            StaticObject.SetConfigValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_delay", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("delay_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/options/"), "success");
        }
    }
}