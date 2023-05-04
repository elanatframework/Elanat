using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Xml;

namespace elanat
{
    public partial class AdminOptions : System.Web.UI.Page
    {
        public AdminOptionsModel model = new AdminOptionsModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveSecurity"]))
                btn_SaveSecurity_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveDebug"]))
                btn_SaveDebug_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveActive"]))
                btn_SaveActive_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveEmail"]))
                btn_SaveEmail_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveDateAndTime"]))
                btn_SaveDateAndTime_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveFileAndDirectory"]))
                btn_SaveFileAndDirectory_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveCache"]))
                btn_SaveCache_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveDelay"]))
                btn_SaveDelay_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveSecurity_Click(object sender, EventArgs e)
        {
            model.AdminDirectoryPathValue = Request.Form["txt_AdminDirectoryPath"];
            model.LockLoginDirectoryPathValue = Request.Form["txt_LockLoginDirectoryPath"];
            model.SecretKeyValue = Request.Form["txt_SecretKey"];
            model.SystemAccessCodeValue = Request.Form["txt_SystemAccessCode"];
            model.LockLoginPasswordValue = Request.Form["txt_LockLoginPassword"];
            model.NewPasswordLengthValue = Request.Form["txt_NewPasswordLength"];
            model.DataBaseNameValue = Request.Form["txt_DataBaseName"];
            model.ConectionStringValue = Request.Form["txt_ConectionString"];
            model.UserSecureValueSizeValue = Request.Form["txt_UserSecureValueSize"];
            model.NewRandomTextValueCountValue = Request.Form["txt_NewRandomTextValueCount"];
            model.CaptchaNoiseValue = Request.Form["txt_CaptchaNoise"];
            model.CaptchaCharacterCountFromValue = Request.Form["txt_CaptchaCharacterCountFrom"];
            model.CaptchaCharacterCountToValue = Request.Form["txt_CaptchaCharacterCountTo"];
            model.CaptchaCharacterValue = Request.Form["txt_CaptchaCharacter"];
            model.CaptchaFontValue = Request.Form["txt_CaptchaFont"];
            model.CaptchaFontSizeValue = Request.Form["txt_CaptchaFontSize"];
            model.CaptchaRotateTransformValue = Request.Form["txt_CaptchaRotateTransform"];
            model.CaptchaWidthValue = Request.Form["txt_CaptchaWidth"];
            model.CaptchaHeightValue = Request.Form["txt_CaptchaHeight"];
            model.CaptchaRepeatTimeValue = Request.Form["txt_CaptchaRepeatTime"];
            model.CaptchaAdminReleaseCountValue = Request.Form["txt_CaptchaAdminReleaseCount"];
            model.CaptchaMemberReleaseCountValue = Request.Form["txt_CaptchaMemberReleaseCount"];
            model.CaptchaGuestReleaseCountValue = Request.Form["txt_CaptchaGuestReleaseCount"];
            model.RobotDetectionIpBlockDurationValue = Request.Form["txt_RobotDetectionIpBlockDuration"];
            model.RobotDetectionResetTimeDurationValue = Request.Form["txt_RobotDetectionResetTimeDuration"];
            model.RobotDetectionAdminRequestCountValue = Request.Form["txt_RobotDetectionAdminRequestCount"];
            model.RobotDetectionMemberRequestCountValue = Request.Form["txt_RobotDetectionMemberRequestCount"];
            model.RobotDetectionGuestRequestCountValue = Request.Form["txt_RobotDetectionGuestRequestCount"];
            model.RobotDetectionAdminRequestAfterShowCaptchaCountValue = Request.Form["txt_RobotDetectionAdminRequestAfterShowCaptchaCount"];
            model.RobotDetectionMemberRequestAfterShowCaptchaCountValue = Request.Form["txt_RobotDetectionMemberRequestAfterShowCaptchaCount"];
            model.RobotDetectionGuestRequestAfterShowCaptchaCountValue = Request.Form["txt_RobotDetectionGuestRequestAfterShowCaptchaCount"];
            model.AdminLifeTimeValue = Request.Form["txt_AdminLifeTime"];
            model.MemberLifeTimeValue = Request.Form["txt_MemberLifeTime"];
            model.GuestLifeTimeValue = Request.Form["txt_GuestLifeTime"];
            model.SessionLifeTimeValue = Request.Form["txt_SessionLifeTime"];
            model.CookieLifeTimeValue = Request.Form["txt_CookieLifeTime"];
            model.DefaultGroupOptionListSelectedValue = Request.Form["ddlst_DefaultGroup"];
            model.GuestGroupOptionListSelectedValue = Request.Form["ddlst_GuestGroup"];
            model.InactiveSiteValue = Request.Form["cbx_InactiveSite"] == "on";
            model.JustUseHttpsForSiteValue = Request.Form["cbx_JustUseHttpsForSite"] == "on";
            model.JustUseHttpsForAdminValue = Request.Form["cbx_JustUseHttpsForAdmin"] == "on";
            model.JustUseHttpsForLoginPageValue = Request.Form["cbx_JustUseHttpsForLoginPage"] == "on";
            model.UseHttpOnlyForSessionIdValue = Request.Form["cbx_UseHttpOnlyForSessionId"] == "on";
            model.LockLoginForFirstLoginValue = Request.Form["cbx_LockLoginForFirstLogin"] == "on";
            model.UseSensitivityCaseCaptchaValue = Request.Form["cbx_UseSensitivityCaseCaptcha"] == "on";
            model.JustUseHttpsValue = Request.Form["cbx_JustUseHttps"] == "on";
            model.SaveLogsErrorValue = Request.Form["cbx_SaveLogsError"] == "on";
            model.UseEmailActivationValue = Request.Form["cbx_UseEmailActivation"] == "on";
            model.UseAdminActivationValue = Request.Form["cbx_UseAdminActivation"] == "on";
            model.UseSecretKeyForLoginValue = Request.Form["cbx_UseSecretKeyForLogin"] == "on";
            model.UseRobotDetectionValue = Request.Form["cbx_UseRobotDetection"] == "on";


            // Evaluate Field Check
            model.SecurityEvaluateField(Request.Form);
            if (model.FindSecurityEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SecurityEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveSecurity();
        }

        protected void btn_SaveDebug_Click(object sender, EventArgs e)
        {
            model.WriteLogsErrorValue = Request.Form["cbx_WriteLogsError"] == "on";
            model.UseVariantDebugValue = Request.Form["cbx_UseVariantDebug"] == "on";


            model.SaveDebug();
        }

        protected void btn_SaveActive_Click(object sender, EventArgs e)
        {
            model.LoginActiveValue = Request.Form["cbx_LoginActive"] == "on";
            model.SignUpActiveValue = Request.Form["cbx_SignUpActive"] == "on";
            model.AddCommentValue = Request.Form["cbx_AddComment"] == "on";


            model.SaveActive();
        }

        protected void btn_SaveEmail_Click(object sender, EventArgs e)
        {
            model.EmailUseHttpsValue = Request.Form["cbx_EmailUseHttps"] == "on";
            model.EmailHostValue = Request.Form["txt_EmailHost"];
            model.EmailPortValue = Request.Form["txt_EmailPort"];
            model.EmailUserNameValue = Request.Form["txt_EmailUserName"];
            model.EmailPasswordValue = Request.Form["txt_EmailPassword"];
            model.EmailSenderValue = Request.Form["txt_EmailSender"];
            model.TextBeforeEmailSubjectValue = Request.Form["txt_TextBeforeEmailSubject"];
            model.TextAfterEmailSubjectValue = Request.Form["txt_TextAfterEmailSubject"];
            model.TextBeforeEmailBodyValue = Request.Form["txt_TextBeforeEmailBody"];
            model.TextAfterEmailBodyValue = Request.Form["txt_TextAfterEmailBody"];


            // Evaluate Field Check
            model.EmailEvaluateField(Request.Form);
            if (model.FindEmailEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EmailEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveEmail();
        }

        protected void btn_SaveDateAndTime_Click(object sender, EventArgs e)
        {
            model.DateFormatValue = Request.Form["txt_DateFormat"];
            model.TimeFormatValue = Request.Form["txt_TimeFormat"];
            model.DayDifferenceValue = Request.Form["txt_DayDifference"];
            model.TimeHoursDifferenceValue = Request.Form["txt_TimeHoursDifference"];
            model.TimeMinutesDifferenceValue = Request.Form["txt_TimeMinutesDifference"];
            model.CalendarOptionListSelectedValue = Request.Form["ddlst_Calendar"];
            model.FirstDayOfWeekOptionListSelectedValue = Request.Form["ddlst_FirstDayOfWeek"];
            model.TimeZoneOptionListSelectedValue = Request.Form["ddlst_TimeZone"];


            // Evaluate Field Check
            model.DateAndTimeEvaluateField(Request.Form);
            if (model.FindDateAndTimeEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DateAndTimeEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveDateAndTime();
        }

        protected void btn_SaveFileAndDirectory_Click(object sender, EventArgs e)
        {
            model.AutoCreateThumbnailImageValue = Request.Form["cbx_AutoCreateThumbnailImage"] == "on";
            model.MaximumSizeForBackupValue = Request.Form["txt_MaximumSizeForBackup"];
            model.MaximumSizeForUploadValue = Request.Form["txt_MaximumSizeForUpload"];
            model.MaximumSizeForAttachmentValue = Request.Form["txt_MaximumSizeForAttachment"];
            model.MaximumSizeForPluginValue = Request.Form["txt_MaximumSizeForPlugin"];
            model.MaximumSizeForModuleValue = Request.Form["txt_MaximumSizeForModule"];
            model.MaximumSizeForComponentValue = Request.Form["txt_MaximumSizeForComponent"];
            model.MaximumSizeForExtraHelperValue = Request.Form["txt_MaximumSizeForExtraHelper"];
            model.MaximumSizeForEditorTemplateValue = Request.Form["txt_MaximumSizeForEditorTemplate"];
            model.MaximumSizeForPatchValue = Request.Form["txt_MaximumSizeForPatch"];
            model.MaximumSizeForFetchValue = Request.Form["txt_MaximumSizeForFetch"];
            model.MaximumSizeForSiteTemplateValue = Request.Form["txt_MaximumSizeForSiteTemplate"];
            model.MaximumSizeForSiteStyleValue = Request.Form["txt_MaximumSizeForSiteStyle"];
            model.MaximumSizeForAdminTemplateValue = Request.Form["txt_MaximumSizeForAdminTemplate"];
            model.MaximumSizeForAdminStyleValue = Request.Form["txt_MaximumSizeForAdminStyle"];
            model.MaximumSizeForCommentValue = Request.Form["txt_MaximumSizeForComment"];
            model.MaximumSizeForContactValue = Request.Form["txt_MaximumSizeForContact"];
            model.MaximumSizeForPageValue = Request.Form["txt_MaximumSizeForPage"];
            model.MaximumSizeForLanguageValue = Request.Form["txt_MaximumSizeForLanguage"];
            model.MaximumSizeForContentAvatarValue = Request.Form["txt_MaximumSizeForContentAvatar"];
            model.MaximumSizeForUserAvatarValue = Request.Form["txt_MaximumSizeForUserAvatar"];
            model.MaximumSizeForUserUploadValue = Request.Form["txt_MaximumSizeForUserUpload"];
            model.ThumbnailImageHeightValue = Request.Form["txt_ThumbnailImageHeight"];
            model.ThumbnailImageWidthValue = Request.Form["txt_ThumbnailImageWidth"];


            // Evaluate Field Check
            model.FileAndDirectoryEvaluateField(Request.Form);
            if (model.FindFileAndDirectoryEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.FileAndDirectoryEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveFileAndDirectory();
        }

        protected void btn_SaveCache_Click(object sender, EventArgs e)
        {
            model.SiteMainCacheParametersValue = Request.Form["txt_SiteMainCacheParameters"];
            model.AdminMainCacheParametersValue = Request.Form["txt_AdminMainCacheParameters"];
            model.AdminRoleCacheValue = Request.Form["txt_AdminRoleCache"];
            model.MemberRoleCacheValue = Request.Form["txt_MemberRoleCache"];
            model.GuestRoleCacheValue = Request.Form["txt_GuestRoleCache"];
            model.ClientCacheForDynamicPageCacheValue = Request.Form["txt_ClientCacheForDynamicPageCache"];
            model.ClientCacheForStaticPageCacheValue = Request.Form["txt_ClientCacheForStaticPageCache"];
            model.AdminRoleCacheTypeOptionListSelectedValue = Request.Form["ddlst_AdminRoleCacheType"];
            model.MemberRoleCacheTypeOptionListSelectedValue = Request.Form["ddlst_MemberRoleCacheType"];
            model.GuestRoleCacheTypeOptionListSelectedValue = Request.Form["ddlst_GuestRoleCacheType"];
            model.UseSiteMainCacheValue = Request.Form["cbx_UseSiteMainCache"] == "on";
            model.UseAdminMainCacheValue = Request.Form["cbx_UseAdminMainCache"] == "on";
            model.UseClientCacheForDynamicPageValue = Request.Form["cbx_UseClientCacheForDynamicPage"] == "on";
            model.CheckServerCacheValue = Request.Form["cbx_CheckServerCache"] == "on";
            model.UseClientCacheForStaticPageValue = Request.Form["cbx_UseClientCacheForStaticPage"] == "on";
            model.CheckLastModifiedValue = Request.Form["cbx_CheckLastModified"] == "on";
            model.TextCreatorUseServerCacheValue = Request.Form["cbx_TextCreatorUseServerCache"] == "on";
            model.TextCreatorUseClientCacheValue = Request.Form["cbx_TextCreatorUseClientCache"] == "on";
            model.TextCreatorCacheTypeOptionListSelectedValue = Request.Form["ddlst_GuestRoleCacheType"];
            model.TextCreatorServerCacheDurationValue = Request.Form["txt_TextCreatorServerCacheDuration"];
            model.TextCreatorClientCacheDurationValue = Request.Form["txt_TextCreatorClientCacheDuration"];
           

            // Evaluate Field Check
            model.CacheEvaluateField(Request.Form);
            if (model.FindCacheEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CacheEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveCache();
        }

        protected void btn_SaveDelay_Click(object sender, EventArgs e)
        {
            model.MainDelayValue = Request.Form["txt_MainDelay"];
            model.SignUpDelayValue = Request.Form["txt_SignUpDelay"];
            model.LoginDelayValue = Request.Form["txt_LoginDelay"];
            model.LockLoginPageDelayValue = Request.Form["txt_LockLoginPageDelay"];
            model.CaptchaDelayValue = Request.Form["txt_CaptchaDelay"];
            model.ShowProtectionContentDelayValue = Request.Form["txt_ShowProtectionContentDelay"];
            model.ShowProtectionAttachmentDelayValue = Request.Form["txt_ShowProtectionAttachmentDelay"];


            // Evaluate Field Check
            model.DelayEvaluateField(Request.Form);
            if (model.FindDelayEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DelayEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveDelay();
        }
    }
}