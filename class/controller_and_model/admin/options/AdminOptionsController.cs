using CodeBehind;

namespace Elanat
{
    public partial class AdminOptionsController : CodeBehindController
    {
        public AdminOptionsModel model = new AdminOptionsModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveSecurity"]))
            {
                btn_SaveSecurity_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveDebug"]))
            {
                btn_SaveDebug_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveActive"]))
            {
                btn_SaveActive_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveEmail"]))
            {
                btn_SaveEmail_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveDateAndTime"]))
            {
                btn_SaveDateAndTime_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveFileAndDirectory"]))
            {
                btn_SaveFileAndDirectory_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveCache"]))
            {
                btn_SaveCache_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveDelay"]))
            {
                btn_SaveDelay_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveSecurity_Click(HttpContext context)
        {
            model.AdminDirectoryPathValue = context.Request.Form["txt_AdminDirectoryPath"];
            model.LockLoginDirectoryPathValue = context.Request.Form["txt_LockLoginDirectoryPath"];
            model.SecretKeyValue = context.Request.Form["txt_SecretKey"];
            model.SystemAccessCodeValue = context.Request.Form["txt_SystemAccessCode"];
            model.LockLoginPasswordValue = context.Request.Form["txt_LockLoginPassword"];
            model.NewPasswordLengthValue = context.Request.Form["txt_NewPasswordLength"];
            model.DataBaseNameValue = context.Request.Form["txt_DataBaseName"];
            model.ConectionStringValue = context.Request.Form["txt_ConectionString"];
            model.UserSecureValueSizeValue = context.Request.Form["txt_UserSecureValueSize"];
            model.NewRandomTextValueCountValue = context.Request.Form["txt_NewRandomTextValueCount"];
            model.CaptchaNoiseValue = context.Request.Form["txt_CaptchaNoise"];
            model.CaptchaCharacterCountFromValue = context.Request.Form["txt_CaptchaCharacterCountFrom"];
            model.CaptchaCharacterCountToValue = context.Request.Form["txt_CaptchaCharacterCountTo"];
            model.CaptchaCharacterValue = context.Request.Form["txt_CaptchaCharacter"];
            model.CaptchaFontValue = context.Request.Form["txt_CaptchaFont"];
            model.CaptchaFontSizeValue = context.Request.Form["txt_CaptchaFontSize"];
            model.CaptchaRotateTransformValue = context.Request.Form["txt_CaptchaRotateTransform"];
            model.CaptchaWidthValue = context.Request.Form["txt_CaptchaWidth"];
            model.CaptchaHeightValue = context.Request.Form["txt_CaptchaHeight"];
            model.CaptchaRepeatTimeValue = context.Request.Form["txt_CaptchaRepeatTime"];
            model.CaptchaAdminReleaseCountValue = context.Request.Form["txt_CaptchaAdminReleaseCount"];
            model.CaptchaMemberReleaseCountValue = context.Request.Form["txt_CaptchaMemberReleaseCount"];
            model.CaptchaGuestReleaseCountValue = context.Request.Form["txt_CaptchaGuestReleaseCount"];
            model.RobotDetectionIpBlockDurationValue = context.Request.Form["txt_RobotDetectionIpBlockDuration"];
            model.RobotDetectionResetTimeDurationValue = context.Request.Form["txt_RobotDetectionResetTimeDuration"];
            model.RobotDetectionAdminRequestCountValue = context.Request.Form["txt_RobotDetectionAdminRequestCount"];
            model.RobotDetectionMemberRequestCountValue = context.Request.Form["txt_RobotDetectionMemberRequestCount"];
            model.RobotDetectionGuestRequestCountValue = context.Request.Form["txt_RobotDetectionGuestRequestCount"];
            model.RobotDetectionAdminRequestAfterShowCaptchaCountValue = context.Request.Form["txt_RobotDetectionAdminRequestAfterShowCaptchaCount"];
            model.RobotDetectionMemberRequestAfterShowCaptchaCountValue = context.Request.Form["txt_RobotDetectionMemberRequestAfterShowCaptchaCount"];
            model.RobotDetectionGuestRequestAfterShowCaptchaCountValue = context.Request.Form["txt_RobotDetectionGuestRequestAfterShowCaptchaCount"];
            model.AdminLifeTimeValue = context.Request.Form["txt_AdminLifeTime"];
            model.MemberLifeTimeValue = context.Request.Form["txt_MemberLifeTime"];
            model.GuestLifeTimeValue = context.Request.Form["txt_GuestLifeTime"];
            model.SessionLifeTimeValue = context.Request.Form["txt_SessionLifeTime"];
            model.CookieLifeTimeValue = context.Request.Form["txt_CookieLifeTime"];
            model.DefaultGroupOptionListSelectedValue = context.Request.Form["ddlst_DefaultGroup"];
            model.GuestGroupOptionListSelectedValue = context.Request.Form["ddlst_GuestGroup"];
            model.InactiveSiteValue = context.Request.Form["cbx_InactiveSite"] == "on";
            model.JustUseHttpsForSiteValue = context.Request.Form["cbx_JustUseHttpsForSite"] == "on";
            model.JustUseHttpsForAdminValue = context.Request.Form["cbx_JustUseHttpsForAdmin"] == "on";
            model.JustUseHttpsForLoginPageValue = context.Request.Form["cbx_JustUseHttpsForLoginPage"] == "on";
            model.LockLoginForFirstLoginValue = context.Request.Form["cbx_LockLoginForFirstLogin"] == "on";
            model.UseSensitivityCaseCaptchaValue = context.Request.Form["cbx_UseSensitivityCaseCaptcha"] == "on";
            model.JustUseHttpsValue = context.Request.Form["cbx_JustUseHttps"] == "on";
            model.SaveLogsErrorValue = context.Request.Form["cbx_SaveLogsError"] == "on";
            model.UseEmailActivationValue = context.Request.Form["cbx_UseEmailActivation"] == "on";
            model.UseAdminActivationValue = context.Request.Form["cbx_UseAdminActivation"] == "on";
            model.UseSecretKeyForLoginValue = context.Request.Form["cbx_UseSecretKeyForLogin"] == "on";
            model.UseRobotDetectionValue = context.Request.Form["cbx_UseRobotDetection"] == "on";


            // Evaluate Field Check
            model.SecurityEvaluateField(context.Request.Form);
            if (model.FindSecurityEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SecurityEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");
                
                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return; 
            }


            model.SaveSecurity();

            View(model);
        }

        protected void btn_SaveDebug_Click(HttpContext context)
        {
            model.WriteLogsErrorValue = context.Request.Form["cbx_WriteLogsError"] == "on";
            model.UseVariantDebugValue = context.Request.Form["cbx_UseVariantDebug"] == "on";


            model.SaveDebug();

            View(model);
        }

        protected void btn_SaveActive_Click(HttpContext context)
        {
            model.LoginActiveValue = context.Request.Form["cbx_LoginActive"] == "on";
            model.SignUpActiveValue = context.Request.Form["cbx_SignUpActive"] == "on";
            model.AddCommentValue = context.Request.Form["cbx_AddComment"] == "on";


            model.SaveActive();

            View(model);
        }

        protected void btn_SaveEmail_Click(HttpContext context)
        {
            model.EmailUseHttpsValue = context.Request.Form["cbx_EmailUseHttps"] == "on";
            model.EmailHostValue = context.Request.Form["txt_EmailHost"];
            model.EmailPortValue = context.Request.Form["txt_EmailPort"];
            model.EmailUserNameValue = context.Request.Form["txt_EmailUserName"];
            model.EmailPasswordValue = context.Request.Form["txt_EmailPassword"];
            model.EmailSenderValue = context.Request.Form["txt_EmailSender"];
            model.TextBeforeEmailSubjectValue = context.Request.Form["txt_TextBeforeEmailSubject"];
            model.TextAfterEmailSubjectValue = context.Request.Form["txt_TextAfterEmailSubject"];
            model.TextBeforeEmailBodyValue = context.Request.Form["txt_TextBeforeEmailBody"];
            model.TextAfterEmailBodyValue = context.Request.Form["txt_TextAfterEmailBody"];


            // Evaluate Field Check
            model.EmailEvaluateField(context.Request.Form);
            if (model.FindEmailEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EmailEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveEmail();

            View(model);
        }

        protected void btn_SaveDateAndTime_Click(HttpContext context)
        {
            model.DateFormatValue = context.Request.Form["txt_DateFormat"];
            model.TimeFormatValue = context.Request.Form["txt_TimeFormat"];
            model.DayDifferenceValue = context.Request.Form["txt_DayDifference"];
            model.TimeHoursDifferenceValue = context.Request.Form["txt_TimeHoursDifference"];
            model.TimeMinutesDifferenceValue = context.Request.Form["txt_TimeMinutesDifference"];
            model.CalendarOptionListSelectedValue = context.Request.Form["ddlst_Calendar"];
            model.FirstDayOfWeekOptionListSelectedValue = context.Request.Form["ddlst_FirstDayOfWeek"];
            model.TimeZoneOptionListSelectedValue = context.Request.Form["ddlst_TimeZone"];


            // Evaluate Field Check
            model.DateAndTimeEvaluateField(context.Request.Form);
            if (model.FindDateAndTimeEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DateAndTimeEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveDateAndTime();

            View(model);
        }

        protected void btn_SaveFileAndDirectory_Click(HttpContext context)
        {
            model.AutoCreateThumbnailImageValue = context.Request.Form["cbx_AutoCreateThumbnailImage"] == "on";
            model.MaximumSizeForBackupValue = context.Request.Form["txt_MaximumSizeForBackup"];
            model.MaximumSizeForUploadValue = context.Request.Form["txt_MaximumSizeForUpload"];
            model.MaximumSizeForAttachmentValue = context.Request.Form["txt_MaximumSizeForAttachment"];
            model.MaximumSizeForPluginValue = context.Request.Form["txt_MaximumSizeForPlugin"];
            model.MaximumSizeForModuleValue = context.Request.Form["txt_MaximumSizeForModule"];
            model.MaximumSizeForComponentValue = context.Request.Form["txt_MaximumSizeForComponent"];
            model.MaximumSizeForExtraHelperValue = context.Request.Form["txt_MaximumSizeForExtraHelper"];
            model.MaximumSizeForEditorTemplateValue = context.Request.Form["txt_MaximumSizeForEditorTemplate"];
            model.MaximumSizeForPatchValue = context.Request.Form["txt_MaximumSizeForPatch"];
            model.MaximumSizeForFetchValue = context.Request.Form["txt_MaximumSizeForFetch"];
            model.MaximumSizeForSiteTemplateValue = context.Request.Form["txt_MaximumSizeForSiteTemplate"];
            model.MaximumSizeForSiteStyleValue = context.Request.Form["txt_MaximumSizeForSiteStyle"];
            model.MaximumSizeForAdminTemplateValue = context.Request.Form["txt_MaximumSizeForAdminTemplate"];
            model.MaximumSizeForAdminStyleValue = context.Request.Form["txt_MaximumSizeForAdminStyle"];
            model.MaximumSizeForCommentValue = context.Request.Form["txt_MaximumSizeForComment"];
            model.MaximumSizeForContactValue = context.Request.Form["txt_MaximumSizeForContact"];
            model.MaximumSizeForPageValue = context.Request.Form["txt_MaximumSizeForPage"];
            model.MaximumSizeForLanguageValue = context.Request.Form["txt_MaximumSizeForLanguage"];
            model.MaximumSizeForContentAvatarValue = context.Request.Form["txt_MaximumSizeForContentAvatar"];
            model.MaximumSizeForUserAvatarValue = context.Request.Form["txt_MaximumSizeForUserAvatar"];
            model.MaximumSizeForUserUploadValue = context.Request.Form["txt_MaximumSizeForUserUpload"];
            model.ThumbnailImageHeightValue = context.Request.Form["txt_ThumbnailImageHeight"];
            model.ThumbnailImageWidthValue = context.Request.Form["txt_ThumbnailImageWidth"];


            // Evaluate Field Check
            model.FileAndDirectoryEvaluateField(context.Request.Form);
            if (model.FindFileAndDirectoryEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.FileAndDirectoryEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveFileAndDirectory();

            View(model);
        }

        protected void btn_SaveCache_Click(HttpContext context)
        {
            model.SiteMainCacheParametersValue = context.Request.Form["txt_SiteMainCacheParameters"];
            model.AdminMainCacheParametersValue = context.Request.Form["txt_AdminMainCacheParameters"];
            model.AdminRoleCacheValue = context.Request.Form["txt_AdminRoleCache"];
            model.MemberRoleCacheValue = context.Request.Form["txt_MemberRoleCache"];
            model.GuestRoleCacheValue = context.Request.Form["txt_GuestRoleCache"];
            model.ClientCacheForDynamicPageCacheValue = context.Request.Form["txt_ClientCacheForDynamicPageCache"];
            model.ClientCacheForStaticPageCacheValue = context.Request.Form["txt_ClientCacheForStaticPageCache"];
            model.AdminRoleCacheTypeOptionListSelectedValue = context.Request.Form["ddlst_AdminRoleCacheType"];
            model.MemberRoleCacheTypeOptionListSelectedValue = context.Request.Form["ddlst_MemberRoleCacheType"];
            model.GuestRoleCacheTypeOptionListSelectedValue = context.Request.Form["ddlst_GuestRoleCacheType"];
            model.UseSiteMainCacheValue = context.Request.Form["cbx_UseSiteMainCache"] == "on";
            model.UseAdminMainCacheValue = context.Request.Form["cbx_UseAdminMainCache"] == "on";
            model.UseClientCacheForDynamicPageValue = context.Request.Form["cbx_UseClientCacheForDynamicPage"] == "on";
            model.CheckServerCacheValue = context.Request.Form["cbx_CheckServerCache"] == "on";
            model.UseClientCacheForStaticPageValue = context.Request.Form["cbx_UseClientCacheForStaticPage"] == "on";
            model.CheckLastModifiedValue = context.Request.Form["cbx_CheckLastModified"] == "on";
            model.TextCreatorUseServerCacheValue = context.Request.Form["cbx_TextCreatorUseServerCache"] == "on";
            model.TextCreatorUseClientCacheValue = context.Request.Form["cbx_TextCreatorUseClientCache"] == "on";
            model.TextCreatorCacheTypeOptionListSelectedValue = context.Request.Form["ddlst_GuestRoleCacheType"];
            model.TextCreatorServerCacheDurationValue = context.Request.Form["txt_TextCreatorServerCacheDuration"];
            model.TextCreatorClientCacheDurationValue = context.Request.Form["txt_TextCreatorClientCacheDuration"];
           

            // Evaluate Field Check
            model.CacheEvaluateField(context.Request.Form);
            if (model.FindCacheEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.CacheEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveCache();

            View(model);
        }

        protected void btn_SaveDelay_Click(HttpContext context)
        {
            model.MainDelayValue = context.Request.Form["txt_MainDelay"];
            model.SignUpDelayValue = context.Request.Form["txt_SignUpDelay"];
            model.LoginDelayValue = context.Request.Form["txt_LoginDelay"];
            model.LockLoginPageDelayValue = context.Request.Form["txt_LockLoginPageDelay"];
            model.CaptchaDelayValue = context.Request.Form["txt_CaptchaDelay"];
            model.ShowProtectionContentDelayValue = context.Request.Form["txt_ShowProtectionContentDelay"];
            model.ShowProtectionAttachmentDelayValue = context.Request.Form["txt_ShowProtectionAttachmentDelay"];


            // Evaluate Field Check
            model.DelayEvaluateField(context.Request.Form);
            if (model.FindDelayEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DelayEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveDelay();

            View(model);
        }
    }
}