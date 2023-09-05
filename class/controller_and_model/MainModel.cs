using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class MainModel : CodeBehindModel
    {
        public bool IgnoreViewAndModel = false;

        public string CurrentTitle = "";
        public string CurrentStaticHead = "";
        public string CurrentDynamicHead = "";
        public string CurrentLoadTag = "";
        public string CurrentPageContent = "";
        string CurrentGroupId = "0";
        string CurrentPageId = "0";
        string CurrentStyleId = "0";
        string CurrentTemplateId = "0";
        string CurrentLanguageId = "0";
        string CurrentQueryString = "";
        string CurrentDateFormat = "";
        string CurrentTimeFormat = "";
        string CurrentCalendar = "";
        string CurrentFirstDayOfWeek = "";
        string CurrentTimeZone = "";
        string CurrentUseDescriptionMeta = "";
        string CurrentUseRevisitAfterMeta = "";
        string CurrentUseRightsMeta = "";
        string CurrentUseClassificationMeta = "";
        string CurrentUseKeywordsMeta = "";
        string CurrentDescriptionMeta = "";
        string CurrentRevisitAfterMeta = "";
        string CurrentRightsMeta = "";
        string CurrentClassificationMeta = "";
        string CurrentKeywordsMeta = "";
        string CurrentMetaGenerator = "";
        string CurrentMetaAapplicationName = "";
        string CurrentUseCopyrightMeta = "";
        string CurrentUseLanguageMeta = "";
        string CurrentUseRobotsMeta = "";
        string CurrentUseApplicationName = "";
        string CurrentCopyrightMeta = "";
        string CurrentRobotsMeta = "";
        string CurrentUseGeneratorMeta = "";
        string CurrentUseJavascriptInactiveRefreshMeta = "";
        string CurrentDayDifference = "";
        string CurrentTimeHoursDifference = "";
        string CurrentTimeMinutesDifference = "";
        string CurrentCommonLightBackgroundColor = "";
        string CurrentCommonLightTextColor = "";
        string CurrentCommonMiddleBackgroundColor = "";
        string CurrentCommonMiddleTextColor = "";
        string CurrentCommonDarkBackgroundColor = "";
        string CurrentCommonDarkTextColor = "";
        string CurrentNaturalLightBackgroundColor = "";
        string CurrentNaturalLightTextColor = "";
        string CurrentNaturalMiddleBackgroundColor = "";
        string CurrentNaturalMiddleTextColor = "";
        string CurrentNaturalDarkBackgroundColor = "";
        string CurrentNaturalDarkTextColor = "";
        string CurrentBackgroundColor = "";
        string CurrentFontSize = "";
        string CurrentSiteGlobalName = "";
        string CurrentLanguageGlobalName = "";
        string CurrentPageGlobalName = "";
        string CurrentTemplateName = "";
        string CurrentStyleName = "";
        string CurrentSiteStylePhysicalPath = "";
        string CurrentSiteTemplatePhysicalPath = "";
        public string CurrentLanguageDirection = "";
        public string ClientVariant = "";

        bool CurrentFillAfterContent = true;
        bool CurrentFillAfterHeader = true;
        bool CurrentFillBeforeFooter = true;
        bool CurrentFillBeforeContent = true;
        bool CurrentFillFooter1 = true;
        bool CurrentFillFooter2 = true;
        bool CurrentFillFooterBarBox = true;
        bool CurrentFillFooterBarLeft = true;
        bool CurrentFillFooterBarRight = true;
        bool CurrentFillFooterMenu = true;
        bool CurrentFillHeader1 = true;
        bool CurrentFillHeader2 = true;
        bool CurrentFillHeaderBarBox = true;
        bool CurrentFillHeaderBarLeft = true;
        bool CurrentFillHeaderBarRight = true;
        bool CurrentFillHeaderMenu = true;
        bool CurrentFillLeftMenu = true;
        bool CurrentFillMenu = true;
        bool CurrentFillRightMenu = true;
        bool CurrentIncludeFooterBarPart = true;
        bool CurrentIncludeFooterPart = true;
        bool CurrentIncludeHeaderBarPart = true;
        bool CurrentIncludeHeaderPart = true;
        bool CurrentIncludeMainPart = true;
        bool CurrentIncludeMenuPart = true;
        bool CurrentShowAfterContent = true;
        bool CurrentShowAfterHeader = true;
        bool CurrentShowBeforeFooter = true;
        bool CurrentShowBeforeContent = true;
        bool CurrentShowFooter1 = true;
        bool CurrentShowFooter2 = true;
        bool CurrentShowFooterBarBox = true;
        bool CurrentShowFooterBarLeft = true;
        bool CurrentShowFooterBarRight = true;
        bool CurrentShowFooterMenu = true;
        bool CurrentShowHeader1 = true;
        bool CurrentShowHeader2 = true;
        bool CurrentShowHeaderBarBox = true;
        bool CurrentShowHeaderBarLeft = true;
        bool CurrentShowHeaderBarRight = true;
        bool CurrentShowHeaderMenu = true;
        bool CurrentShowLeftMenu = true;
        bool CurrentShowMenu = true;
        bool CurrentShowRightMenu = true;

        public string HeaderBarLeftLocation = "";
        public string HeaderBarRightLocation = "";
        public string HeaderBarBoxLocation = "";
        public string Header1Location = "";
        public string Header2Location = "";
        public string HeaderMenuLocation = "";
        public string MenuLocation = "";
        public string AfterHeaderLocation = "";
        public string LeftMenuLocation = "";
        public string RightMenuLocation = "";
        public string BeforeFooterLocation = "";
        public string Footer1Location = "";
        public string Footer2Location = "";
        public string FooterMenuLocation = "";
        public string FooterBarLeftLocation = "";
        public string FooterBarRightLocation = "";
        public string FooterBarBoxLocation = "";

        public string ExistContentValue = "";
        public string ExistLeftMenuValue = "";
        public string ExistRightMenuValue = "";

        public void SetValue(HttpContext context)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);
            int CacheDuration = StaticObject.GetCurrentCacheDuration(ccoc.RoleDominantType);


            // Set Cache Key
            string SiteMainCacheKey = "";
            foreach (string key in (StaticObject.SiteMainCacheParameters.Split(',')))
                if (!string.IsNullOrEmpty(context.Request.Query[key]))
                    SiteMainCacheKey += ":" + context.Request.Query[key].ToString();


            // Get Cache
            if (cc.Exist(CacheType, "el_site_main_cache_current_page_content" + SiteMainCacheKey))
            {
                CurrentLanguageDirection = cc.GetValue(CacheType, "el_site_main_cache_current_language_direction" + SiteMainCacheKey);
                CurrentTitle = cc.GetValue(CacheType, "el_site_main_cache_current_title" + SiteMainCacheKey);
                ClientVariant = cc.GetValue(CacheType, "el_site_main_cache_client_variant" + SiteMainCacheKey);
                CurrentStaticHead = cc.GetValue(CacheType, "el_site_main_cache_current_static_head" + SiteMainCacheKey);
                CurrentDynamicHead = cc.GetValue(CacheType, "el_site_main_cache_current_dynamic_head" + SiteMainCacheKey);
                HeaderBarLeftLocation = cc.GetValue(CacheType, "el_site_main_cache_header_bar_left_location" + SiteMainCacheKey);
                HeaderBarRightLocation = cc.GetValue(CacheType, "el_site_main_cache_header_bar_right_location" + SiteMainCacheKey);
                HeaderBarBoxLocation = cc.GetValue(CacheType, "el_site_main_cache_header_bar_box_location" + SiteMainCacheKey);
                Header1Location = cc.GetValue(CacheType, "el_site_main_cache_header_1_location" + SiteMainCacheKey);
                Header2Location = cc.GetValue(CacheType, "el_site_main_cache_header_2_location" + SiteMainCacheKey);
                HeaderMenuLocation = cc.GetValue(CacheType, "el_site_main_cache_header_menu_location" + SiteMainCacheKey);
                MenuLocation = cc.GetValue(CacheType, "el_site_main_cache_menu_location" + SiteMainCacheKey);
                ExistContentValue = cc.GetValue(CacheType, "el_site_main_cache_exist_content_value" + SiteMainCacheKey);
                ExistLeftMenuValue = cc.GetValue(CacheType, "el_site_main_cache_exist_left_menu_value" + SiteMainCacheKey);
                ExistRightMenuValue = cc.GetValue(CacheType, "el_site_main_cache_exist_right_menu_value" + SiteMainCacheKey);
                AfterHeaderLocation = cc.GetValue(CacheType, "el_site_main_cache_after_header_location" + SiteMainCacheKey);
                LeftMenuLocation = cc.GetValue(CacheType, "el_site_main_cache_left_menu_location" + SiteMainCacheKey);
                CurrentPageContent = cc.GetValue(CacheType, "el_site_main_cache_current_page_content" + SiteMainCacheKey);
                RightMenuLocation = cc.GetValue(CacheType, "el_site_main_cache_right_menu_location" + SiteMainCacheKey);
                BeforeFooterLocation = cc.GetValue(CacheType, "el_site_main_cache_before_footer_location" + SiteMainCacheKey);
                FooterMenuLocation = cc.GetValue(CacheType, "el_site_main_cache_footer_menu_location" + SiteMainCacheKey);
                Footer1Location = cc.GetValue(CacheType, "el_site_main_cache_footer_1_location" + SiteMainCacheKey);
                Footer2Location = cc.GetValue(CacheType, "el_site_main_cache_footer_2_location" + SiteMainCacheKey);
                FooterBarLeftLocation = cc.GetValue(CacheType, "el_site_main_cache_footer_bar_left_location" + SiteMainCacheKey);
                FooterBarRightLocation = cc.GetValue(CacheType, "el_site_main_cache_footer_bar_right_location" + SiteMainCacheKey);
                FooterBarBoxLocation = cc.GetValue(CacheType, "el_site_main_cache_footer_bar_box_location" + SiteMainCacheKey);
                CurrentLoadTag = cc.GetValue(CacheType, "el_site_main_cache_current_load_tag" + SiteMainCacheKey);

                return;
            }


            // Delete Page Value Transfer
            PageValueTransfer transfer = new PageValueTransfer();
            transfer.Delete();


            // Set Common Value
            CurrentQueryString += context.Request.QueryString.ToString();

            if (!string.IsNullOrEmpty(CurrentQueryString))
                if (CurrentQueryString[0] == '?')
                    CurrentQueryString = CurrentQueryString.Remove(0, 1);


            CurrentGroupId = StaticObject.GetCurrentGroupId();

            // Set Elanat Value
            CurrentMetaGenerator = StaticObject.ApplicationName;
            CurrentMetaAapplicationName = StaticObject.ApplicationName;
            CurrentSiteGlobalName = StaticObject.DefaultSite;
            CurrentLanguageGlobalName = StaticObject.DefaultSiteLanguage;
            CurrentPageGlobalName = StaticObject.DefaultPage;
            CurrentTemplateName = StaticObject.DefaultSiteTemplate;
            CurrentStyleName = StaticObject.DefaultSiteStyle;
            CurrentCalendar = StaticObject.DefaultSiteCalendar;
            CurrentDateFormat = StaticObject.DefaultDateFormat;
            CurrentTimeFormat = StaticObject.DefaulttimeFormat;
            CurrentTimeZone = StaticObject.DefaultTimeZone;
            CurrentFirstDayOfWeek = StaticObject.DefaultFirstDayOfWeek;
            CurrentDayDifference = StaticObject.DefaultDayDifference;
            CurrentTimeHoursDifference = StaticObject.DefaultTimeDifferenceHours;
            CurrentTimeMinutesDifference = StaticObject.DefaultTimeDifferenceMinutes;


            // Set Priority Value
            bool PriorityLanguage = false;

            // Set Last Language Change Value
            if (ccoc.SiteLanguageId != "0")
            {
                CurrentLanguageGlobalName = ccoc.SiteLanguageGlobalName;
                CurrentLanguageId = ccoc.SiteLanguageId;
                CurrentLanguageDirection = (ccoc.SiteLanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";

                PriorityLanguage = true;
            }


            DataUse.Language dul = new DataUse.Language();

            if (!string.IsNullOrEmpty(context.Request.Query["language"]))
            {
                CurrentLanguageGlobalName = context.Request.Query["language"].ToString().ProtectSqlInjection();
                CurrentLanguageId = dul.GetLanguageIdByLanguageGlobalName(CurrentLanguageGlobalName);

                dul.FillCurrentLanguage(CurrentLanguageId);

                if (string.IsNullOrEmpty(dul.LanguageId))
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/language_is_not_existed");
                    return;
                }

                if (!dul.LanguageActive.ZeroOneToBoolean())
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/language_is_inactive");
                    return;
                }

                CurrentLanguageDirection = (dul.LanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";

                ccoc.SiteLanguageId = dul.LanguageId;
                ccoc.SiteLanguageGlobalName = dul.LanguageGlobalName;
                ccoc.SiteLanguageIsRightToLeft = dul.LanguageIsRightToLeft;

                PriorityLanguage = true;
            }


            // Set Site Value
            CurrentSiteGlobalName = (!string.IsNullOrEmpty(context.Request.Query["site"])) ? context.Request.Query["site"].ToString().ProtectSqlInjection() : StaticObject.ConfigDocument.SelectSingleNode("elanat_root/properties/default_site").Attributes["value"].Value;
            DataUse.Site dus = new DataUse.Site();
            string CurrentSiteId = dus.GetSiteIdBySiteGlobalName(CurrentSiteGlobalName);

            dus.FillCurrentSite(CurrentSiteId);

            if (string.IsNullOrEmpty(dus.SiteId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_is_not_existed");
                return;
            }

            if (!dus.SiteActive.ZeroOneToBoolean())
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_is_inactive");
                return;
            }


            // Check Access Show
            if (!dus.SitePublicAccessShow.ZeroOneToBoolean())
                if (!dus.GetSiteAccessShowCheck(CurrentSiteId))
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/you_do_not_access_to_site");
                    return;
                }


            CurrentStaticHead += dus.SiteStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

            if (!string.IsNullOrEmpty(dus.SiteTitle))
                CurrentTitle = dus.SiteTitle;

            if (!string.IsNullOrEmpty(dus.SiteDateFormat))
                CurrentDateFormat = dus.SiteDateFormat;

            if (!string.IsNullOrEmpty(dus.SiteTimeFormat))
                CurrentTimeFormat = dus.SiteTimeFormat;

            if (!string.IsNullOrEmpty(dus.SiteCalendar))
                CurrentCalendar = dus.SiteCalendar;


            if (!string.IsNullOrEmpty(dus.SiteTimeZone))
                CurrentTimeZone = dus.SiteTimeZone;

            if (!string.IsNullOrEmpty(dus.SiteFirstDayOfWeek))
                CurrentFirstDayOfWeek = dus.SiteFirstDayOfWeek;

            if (dus.SiteUseDescriptionMeta.ZeroOneToBoolean())
            {
                CurrentUseDescriptionMeta = dus.SiteUseDescriptionMeta;
                CurrentDescriptionMeta = dus.SiteDescriptionMeta;
            }

            if (dus.SiteUseKeywordsMeta.ZeroOneToBoolean())
            {
                CurrentUseKeywordsMeta = dus.SiteUseKeywordsMeta;
                CurrentKeywordsMeta += dus.SiteKeywordsMeta;
            }

            if (dus.SiteUseRightsMeta.ZeroOneToBoolean())
            {
                CurrentUseRightsMeta = dus.SiteUseRightsMeta;
                CurrentRightsMeta = dus.SiteRightsMeta;
            }

            if (dus.SiteUseRevisitAfterMeta.ZeroOneToBoolean())
            {
                CurrentUseRevisitAfterMeta = dus.SiteUseRevisitAfterMeta;
                CurrentRevisitAfterMeta = dus.SiteRevisitAfterMeta;
            }

            if (dus.SiteUseClassificationMeta.ZeroOneToBoolean())
            {
                CurrentUseClassificationMeta = dus.SiteUseClassificationMeta;
                CurrentClassificationMeta = dus.SiteClassificationMeta;
            }

            if (dus.LanguageId != "0" && !PriorityLanguage)
                CurrentLanguageId = dus.LanguageId;

            if (dus.PageId != "0")
                CurrentPageId = dus.PageId;

            if (dus.SiteStyleId != "0")
                CurrentStyleId = dus.SiteStyleId;

            if (dus.SiteTemplateId != "0")
                CurrentTemplateId = dus.SiteTemplateId;

            if (StaticObject.RoleSubmitVisitCheck())
                dus.IncreaseVisit(dus.SiteId);


            // Set Language Value

            if (CurrentLanguageId == "0")
            {
                CurrentLanguageGlobalName = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/properties/default_site_language").Attributes["value"].Value;

                CurrentLanguageId = dul.GetLanguageIdByLanguageGlobalName(CurrentLanguageGlobalName);
            }

            if (!PriorityLanguage)
            {
                dul.FillCurrentLanguage(CurrentLanguageId);

                if (string.IsNullOrEmpty(dul.LanguageId))
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/language_is_not_existed");
                    return;
                }

                if (!dul.LanguageActive.ZeroOneToBoolean())
                {
                    Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_style_is_inactive", CurrentLanguageGlobalName)));
                    return;
                }
            }

            if (!string.IsNullOrEmpty(dul.LanguageId))
                CurrentLanguageDirection = (dul.LanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";


            // Set Page Value
            DataUse.Page dup = new DataUse.Page();


            if (!string.IsNullOrEmpty(context.Request.Query["page_content"]))
            {
                CurrentPageGlobalName = context.Request.Query["page_content"].ToString().ProtectSqlInjection();
                CurrentPageId = dup.GetPageIdByPageGlobalName(CurrentPageGlobalName);

                CurrentPageId = "0";
            }


            if (CurrentPageId == "0")
                CurrentPageId = dup.GetPageIdByPageGlobalName(CurrentPageGlobalName);

            dup.FillCurrentPage(CurrentPageId);

            if (string.IsNullOrEmpty(dup.PageId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/page_is_not_existed");
                return;
            }

            if (!dup.PageActive.ZeroOneToBoolean())
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/page_is_inactive");
                return;
            }

            if (!string.IsNullOrEmpty(dup.PageQueryString))
                if (!string.IsNullOrEmpty(dup.PageQueryString))
                    CurrentQueryString += "&" + dup.PageQueryString;
                else
                    CurrentQueryString = dup.PageQueryString;

            if (dup.PageUseStaticHead.ZeroOneToBoolean())
                CurrentStaticHead += dup.PageStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

            if (dup.PageUseLoadTag.ZeroOneToBoolean())
                CurrentLoadTag += dup.PageLoadTag;

            if (dup.PageUseDescriptionMeta.ZeroOneToBoolean())
            {
                CurrentUseDescriptionMeta = dup.PageUseDescriptionMeta;
                CurrentDescriptionMeta = dup.PageDescriptionMeta;
            }

            if (dup.PageUseKeywordsMeta.ZeroOneToBoolean())
            {
                CurrentUseKeywordsMeta = dup.PageUseKeywordsMeta;
                CurrentKeywordsMeta += dup.PageKeywordsMeta;
            }

            if (dup.PageUseRightsMeta.ZeroOneToBoolean())
            {
                CurrentUseRightsMeta = dup.PageUseRightsMeta;
                CurrentRightsMeta = dup.PageRightsMeta;
            }

            if (dup.PageUseRevisitAfterMeta.ZeroOneToBoolean())
            {
                CurrentUseRevisitAfterMeta = dup.PageUseRevisitAfterMeta;
                CurrentRevisitAfterMeta = dup.PageRevisitAfterMeta;
            }

            if (dup.PageUseClassificationMeta.ZeroOneToBoolean())
            {
                CurrentUseClassificationMeta = dup.PageUseClassificationMeta;
                CurrentClassificationMeta = dup.PageClassificationMeta;
            }

            if (dup.PageUseCopyrightMeta.ZeroOneToBoolean())
            {
                CurrentUseCopyrightMeta = dup.PageUseCopyrightMeta;
                CurrentCopyrightMeta = dup.PageCopyrightMeta;
            }

            if (dup.PageUseLanguageMeta.ZeroOneToBoolean())
                CurrentUseLanguageMeta = dup.PageUseLanguageMeta;

            if (dup.PageUseRobotsMeta.ZeroOneToBoolean())
            {
                CurrentUseRobotsMeta = dup.PageUseRobotsMeta;
                CurrentRobotsMeta = dup.PageRobotsMeta;

            }

            if (dup.PageUseApplicationNameMeta.ZeroOneToBoolean())
                CurrentUseApplicationName = dup.PageUseApplicationNameMeta;

            if (dup.PageUseGeneratorMeta.ZeroOneToBoolean())
                CurrentUseGeneratorMeta = dup.PageUseGeneratorMeta;

            if (dup.PageUseJavascriptInactiveRefreshMeta.ZeroOneToBoolean())
                CurrentUseJavascriptInactiveRefreshMeta = dup.PageUseJavascriptInactiveRefreshMeta;

            if (dup.SiteStyleId != "0")
                CurrentStyleId = dup.SiteStyleId;

            if (dup.SiteTemplateId != "0")
                CurrentTemplateId = dup.SiteTemplateId;


            // Set User
            if (StaticObject.GetCurrentUserId() != "0")
            {
                DataUse.User duu = new DataUse.User();

                duu.FillCurrentUser(StaticObject.GetCurrentUserId());

                if (string.IsNullOrEmpty(duu.UserId))
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/user_is_not_existed");
                    return;
                }

                if (!duu.UserActive.ZeroOneToBoolean())
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/error/" + Language.GetLanguage("user_is_inactive", CurrentLanguageGlobalName));
                    return;
                }

                if (!string.IsNullOrEmpty(duu.UserCalendar))
                    CurrentCalendar = duu.UserCalendar;

                if (!string.IsNullOrEmpty(duu.UserFirstDayOfWeek))
                    CurrentFirstDayOfWeek = duu.UserFirstDayOfWeek;

                if (!string.IsNullOrEmpty(duu.UserTimeZone))
                    CurrentTimeZone = duu.UserTimeZone;

                if (!string.IsNullOrEmpty(duu.UserDateFormat))
                    CurrentDateFormat = duu.UserDateFormat;

                if (!string.IsNullOrEmpty(duu.UserTimeFormat))
                    CurrentTimeFormat = duu.UserTimeFormat;

                if (!string.IsNullOrEmpty(duu.UserDayDifference))
                    CurrentDayDifference = duu.UserDayDifference;

                if (!string.IsNullOrEmpty(duu.UserTimeHoursDifference))
                    CurrentTimeHoursDifference = duu.UserTimeHoursDifference;

                if (!string.IsNullOrEmpty(duu.UserTimeMinutesDifference))
                    CurrentTimeMinutesDifference = duu.UserTimeMinutesDifference;

                if (!string.IsNullOrEmpty(duu.UserCommonLightBackgroundColor))
                    CurrentCommonLightBackgroundColor = duu.UserCommonLightBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserCommonLightTextColor))
                    CurrentCommonLightTextColor = duu.UserCommonLightTextColor;

                if (!string.IsNullOrEmpty(duu.UserCommonMiddleBackgroundColor))
                    CurrentCommonMiddleBackgroundColor = duu.UserCommonMiddleBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserCommonMiddleTextColor))
                    CurrentCommonMiddleTextColor = duu.UserCommonMiddleTextColor;

                if (!string.IsNullOrEmpty(duu.UserCommonDarkBackgroundColor))
                    CurrentCommonDarkBackgroundColor = duu.UserCommonDarkBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserCommonDarkTextColor))
                    CurrentCommonDarkTextColor = duu.UserCommonDarkTextColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalLightBackgroundColor))
                    CurrentNaturalLightBackgroundColor = duu.UserNaturalLightBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalLightTextColor))
                    CurrentNaturalLightTextColor = duu.UserNaturalLightTextColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalMiddleBackgroundColor))
                    CurrentNaturalMiddleBackgroundColor = duu.UserNaturalMiddleBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalMiddleTextColor))
                    CurrentNaturalMiddleTextColor = duu.UserNaturalMiddleTextColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalDarkBackgroundColor))
                    CurrentNaturalDarkBackgroundColor = duu.UserNaturalDarkBackgroundColor;

                if (!string.IsNullOrEmpty(duu.UserNaturalDarkTextColor))
                    CurrentNaturalDarkTextColor = duu.UserNaturalDarkTextColor;

                if (!string.IsNullOrEmpty(duu.UserBackgroundColor))
                    CurrentBackgroundColor = duu.UserBackgroundColor;

                if (duu.UserFontSize != "0")
                    CurrentFontSize = duu.UserFontSize;

                if (ccoc.SiteStyleId != "0")
                    CurrentStyleId = ccoc.SiteStyleId;

                if (ccoc.SiteTemplateId != "0")
                    CurrentTemplateId = ccoc.SiteTemplateId;
            }


            // Set View Value
            DataUse.View duv = new DataUse.View();

            string ViewId = duv.GetViewIdByQueryString(context.Request.QueryString.ToString());

            if (ViewId != "0")
            {
                duv.FillCurrentView(ViewId);
                if (duv.ViewActive.ZeroOneToBoolean())
                {
                    CurrentStaticHead += duv.ViewStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

                    CurrentFillAfterContent = duv.ViewFillAfterContent.ZeroOneToBoolean();

                    CurrentFillAfterHeader = duv.ViewFillAfterHeader.ZeroOneToBoolean();

                    CurrentFillBeforeFooter = duv.ViewFillBeforeFooter.ZeroOneToBoolean();

                    CurrentFillBeforeContent = duv.ViewFillBeforeContent.ZeroOneToBoolean();

                    CurrentFillFooter1 = duv.ViewFillFooter1.ZeroOneToBoolean();

                    CurrentFillFooter2 = duv.ViewFillFooter2.ZeroOneToBoolean();

                    CurrentFillFooterBarBox = duv.ViewFillFooterBarBox.ZeroOneToBoolean();

                    CurrentFillFooterBarLeft = duv.ViewFillFooterBarLeft.ZeroOneToBoolean();

                    CurrentFillFooterBarRight = duv.ViewFillFooterBarRight.ZeroOneToBoolean();

                    CurrentFillFooterMenu = duv.ViewFillFooterMenu.ZeroOneToBoolean();

                    CurrentFillHeader1 = duv.ViewFillHeader1.ZeroOneToBoolean();

                    CurrentFillHeader2 = duv.ViewFillHeader2.ZeroOneToBoolean();

                    CurrentFillHeaderBarBox = duv.ViewFillHeaderBarBox.ZeroOneToBoolean();

                    CurrentFillHeaderBarLeft = duv.ViewFillHeaderBarLeft.ZeroOneToBoolean();

                    CurrentFillHeaderBarRight = duv.ViewFillHeaderBarRight.ZeroOneToBoolean();

                    CurrentFillHeaderMenu = duv.ViewFillHeaderMenu.ZeroOneToBoolean();

                    CurrentFillLeftMenu = duv.ViewFillLeftMenu.ZeroOneToBoolean();

                    CurrentFillMenu = duv.ViewFillMenu.ZeroOneToBoolean();

                    CurrentFillRightMenu = duv.ViewFillRightMenu.ZeroOneToBoolean();

                    CurrentIncludeFooterBarPart = duv.ViewIncludeFooterBarPart.ZeroOneToBoolean();

                    CurrentIncludeFooterPart = duv.ViewIncludeFooterPart.ZeroOneToBoolean();

                    CurrentIncludeHeaderBarPart = duv.ViewIncludeHeaderBarPart.ZeroOneToBoolean();

                    CurrentIncludeHeaderPart = duv.ViewIncludeHeaderPart.ZeroOneToBoolean();

                    CurrentIncludeMainPart = duv.ViewIncludeMainPart.ZeroOneToBoolean();

                    CurrentIncludeMenuPart = duv.ViewIncludeMenuPart.ZeroOneToBoolean();

                    CurrentShowAfterContent = duv.ViewShowAfterContent.ZeroOneToBoolean();

                    CurrentShowAfterHeader = duv.ViewShowAfterHeader.ZeroOneToBoolean();

                    CurrentShowBeforeFooter = duv.ViewShowBeforeFooter.ZeroOneToBoolean();

                    CurrentShowBeforeContent = duv.ViewShowBeforeContent.ZeroOneToBoolean();

                    CurrentShowFooter1 = duv.ViewShowFooter1.ZeroOneToBoolean();

                    CurrentShowFooter2 = duv.ViewShowFooter2.ZeroOneToBoolean();

                    CurrentShowFooterBarBox = duv.ViewShowFooterBarBox.ZeroOneToBoolean();

                    CurrentShowFooterBarLeft = duv.ViewShowFooterBarLeft.ZeroOneToBoolean();

                    CurrentShowFooterBarRight = duv.ViewShowFooterBarRight.ZeroOneToBoolean();

                    CurrentShowFooterMenu = duv.ViewShowFooterMenu.ZeroOneToBoolean();

                    CurrentShowHeader1 = duv.ViewShowHeader1.ZeroOneToBoolean();

                    CurrentShowHeader2 = duv.ViewShowHeader2.ZeroOneToBoolean();

                    CurrentShowHeaderBarBox = duv.ViewShowHeaderBarBox.ZeroOneToBoolean();

                    CurrentShowHeaderBarLeft = duv.ViewShowHeaderBarLeft.ZeroOneToBoolean();

                    CurrentShowHeaderBarRight = duv.ViewShowHeaderBarRight.ZeroOneToBoolean();

                    CurrentShowHeaderMenu = duv.ViewShowHeaderMenu.ZeroOneToBoolean();

                    CurrentShowLeftMenu = duv.ViewShowLeftMenu.ZeroOneToBoolean();

                    CurrentShowMenu = duv.ViewShowMenu.ZeroOneToBoolean();

                    CurrentShowRightMenu = duv.ViewShowRightMenu.ZeroOneToBoolean();

                    if (!string.IsNullOrEmpty(duv.ViewCommonDarkBackgroundColor))
                        CurrentCommonDarkBackgroundColor = duv.ViewCommonDarkBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewCommonDarkTextColor))
                        CurrentCommonDarkTextColor = duv.ViewCommonDarkTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewCommonLightBackgroundColor))
                        CurrentCommonLightBackgroundColor = duv.ViewCommonLightBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewCommonLightTextColor))
                        CurrentCommonLightTextColor = duv.ViewCommonLightTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewCommonMiddleBackgroundColor))
                        CurrentCommonMiddleBackgroundColor = duv.ViewCommonMiddleBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewCommonMiddleTextColor))
                        CurrentCommonMiddleTextColor = duv.ViewCommonMiddleTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalDarkBackgroundColor))
                        CurrentNaturalDarkBackgroundColor = duv.ViewNaturalDarkBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalDarkTextColor))
                        CurrentNaturalDarkTextColor = duv.ViewNaturalDarkTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalLightBackgroundColor))
                        CurrentNaturalLightBackgroundColor = duv.ViewNaturalLightBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalLightTextColor))
                        CurrentNaturalLightTextColor = duv.ViewNaturalLightTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalMiddleBackgroundColor))
                        CurrentNaturalMiddleBackgroundColor = duv.ViewNaturalMiddleBackgroundColor;

                    if (!string.IsNullOrEmpty(duv.ViewNaturalMiddleTextColor))
                        CurrentNaturalMiddleTextColor = duv.ViewNaturalMiddleTextColor;

                    if (!string.IsNullOrEmpty(duv.ViewBackgroundColor))
                        CurrentBackgroundColor = duv.ViewBackgroundColor;

                    if (duv.ViewFontSize != "0")
                        CurrentFontSize = duv.ViewFontSize;

                    if (duv.SiteStyleId != "0")
                        CurrentStyleId = duv.SiteStyleId;

                    if (duv.SiteTemplateId != "0")
                        CurrentTemplateId = duv.SiteTemplateId;
                }
            }


            // Set Site Template Value
            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();

            if (CurrentTemplateId == "0")
                CurrentTemplateId = dust.GetSiteTemplateIdBySiteTemplateName(StaticObject.DefaultSiteTemplate);

            dust.FillCurrentSiteTemplate(CurrentTemplateId);

            if (string.IsNullOrEmpty(dust.SiteTemplateId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_template_is_not_existed");
                return;
            }

            if (!dust.SiteTemplateActive.ZeroOneToBoolean())
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_template_is_inactive");
                return;
            }

            CurrentSiteTemplatePhysicalPath = dust.SiteTemplateDirectoryPath + "/" + dust.SiteTemplatePhysicalName;
            // Set dust.SiteTemplateLoadTag And dust.SiteTemplateStaticHead After Category Template Check

            // Set Site Style Value
            DataUse.SiteStyle duss = new DataUse.SiteStyle();

            if (CurrentStyleId == "0")
                CurrentStyleId = duss.GetSiteStyleIdBySiteStyleName(StaticObject.DefaultSiteStyle);

            duss.FillCurrentSiteStyle(CurrentStyleId);

            if (string.IsNullOrEmpty(duss.SiteStyleId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_style_is_not_existed");
                return;
            }

            if (!duss.SiteStyleActive.ZeroOneToBoolean())
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/site_style_is_inactive");
                return;
            }

            CurrentSiteStylePhysicalPath = duss.SiteStyleDirectoryPath + "/" + duss.SiteStylePhysicalName;
            // Set dust.SiteStyleLoadTag And dust.SiteStyleStaticHead After Category Template Check


            // Set Extra Page Title Value
            ExtraValue evc = new ExtraValue();


            // Set Cache Key
            string PageCacheKey = "";
            foreach (string key in (dup.PageCacheParameters.Split(',')))
                if (!string.IsNullOrEmpty(context.Request.Query[key]))
                    PageCacheKey += ":" + context.Request.Query[key].ToString();

            // Get Cache
            if (cc.Exist(CacheType, "el_page_load_in_default_" + dup.PageId + PageCacheKey))
            {
                string TmpCurrentPageContent = cc.GetValue(CacheType, "el_page_load_in_default_" + dup.PageId + PageCacheKey);
                CurrentPageContent = TmpCurrentPageContent;
            }


            // Load Page
            if (dup.PageLoadAlone.ZeroOneToBoolean())
            {
                if (dup.PageUseHtml.ZeroOneToBoolean())
                {
                    CreateHtmlForPartPage chfpp = new CreateHtmlForPartPage();
                    CurrentPageContent = chfpp.GetValue(dup.PageId, context.Request.QueryString.ToListItems());
                }
                else
                    CurrentPageContent = PageLoader.LoadPath(StaticObject.SitePath + "page/" + dup.PageDirectoryPath + "/" + dup.PagePhysicalName + (!string.IsNullOrEmpty(CurrentQueryString) ? "?" + CurrentQueryString : ""));
            }
            else
                CurrentPageContent = PageLoader.LoadPage(dup.PageLoadType, StaticObject.SitePath + "page/" + dup.PageDirectoryPath + "/" + dup.PagePhysicalName + (!string.IsNullOrEmpty(CurrentQueryString) ? "?" + CurrentQueryString : ""));


            // Set Replace Value
            AttributeReader ar = new AttributeReader();

            if (dup.PageLoadType != "iframe" && dup.PageLoadType != "ajax")
            {
                if (dup.PageUseLanguage.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadLanguage(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUseModule.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadModule(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUsePlugin.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadPlugin(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUseReplacePart.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadReplacePart(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUseFetch.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadFetch(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUseItem.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadItem(CurrentPageContent, CurrentLanguageGlobalName);

                if (dup.PageUseElanat.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadElanat(CurrentPageContent, CurrentLanguageGlobalName);


                // Set Cache
                cc.Insert(CacheType, "el_page_load_in_default_" + dup.PageId + PageCacheKey, CurrentPageContent, int.Parse(dup.PageCacheDuration));
            }


            evc.SiteGlobalName = dus.SiteGlobalName;
            evc.SiteName = dus.SiteName;
            evc.PageId = dup.PageId;
            evc.PageTitle = dup.PageTitle;
            evc.PageGlobalName = dup.PageGlobalName;
            evc.PageName = dup.PageName;

            CurrentTitle = evc.GetPageTitleValue();


            bool CategoryTemplateIsSet = false;
            bool CategoryStyleIsSet = false;

            if (dup.PageGlobalName == "main")
                if (!string.IsNullOrEmpty(context.Request.Query["category"]))
                {
                    string CategoryName = context.Request.Query["category"];

                    DataUse.Category duc = new DataUse.Category();

                    string CategoryId = duc.GetCategoryIdByCategoryName(CategoryName);

                    if (!string.IsNullOrEmpty(CategoryId))
                    {
                        evc.CategoryId = CategoryId;

                        CategoryClass cc2 = new CategoryClass();

                        evc.ParrentCategory = cc2.GetParentCategory(CurrentSiteGlobalName, CategoryId);

                        evc.CategoryName = cc2.CategoryName;

                        CurrentTitle = evc.GetCategoryTitleValue();

                        // Set Style And Template
                        bool CategoryTemplatePriority = false;
                        bool CategoryStylePriority = false;

                        if (StaticObject.GetCurrentUserId() != "0")
                        {
                            if (ccoc.SiteTemplateId != "0")
                                CategoryTemplatePriority = true;

                            if (ccoc.SiteStyleId != "0")
                                CategoryStylePriority = true;
                        }

                        if (ViewId != "0")
                            if (duv.ViewActive.ZeroOneToBoolean())
                            {
                                if (duv.SiteTemplateId == "0")
                                    CategoryTemplatePriority = true;

                                if (duv.SiteStyleId == "0")
                                    CategoryStylePriority = true;
                            }

                        duc.FillCurrentCategory(CategoryId);

                        if (duc.SiteTemplateId != "0" && CategoryTemplatePriority)
                        {
                            CurrentTemplateId = duc.SiteTemplateId;

                            // Set Site Template Value
                            dust.FillCurrentSiteTemplate(CurrentTemplateId);

                            if (string.IsNullOrEmpty(dust.SiteTemplateId))
                            {
                                context.Response.Redirect(StaticObject.SitePath + "page/error/site_template_is_not_existed");
                                return;
                            }

                            if (!dust.SiteTemplateActive.ZeroOneToBoolean())
                            {
                                context.Response.Redirect(StaticObject.SitePath + "page/error/site_template_is_inactive");
                                return;
                            }

                            CurrentSiteTemplatePhysicalPath = dust.SiteTemplateDirectoryPath + "/" + dust.SiteTemplatePhysicalName;

                            CurrentLoadTag += dust.SiteTemplateLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);

                            CurrentStaticHead += dust.SiteTemplateStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

                            CategoryTemplateIsSet = true;
                        }

                        if (duc.SiteStyleId != "0" && CategoryStylePriority)
                        {
                            CurrentStyleId = duc.SiteStyleId;

                            // Set Site Style Value
                            duss.FillCurrentSiteStyle(CurrentStyleId);

                            if (string.IsNullOrEmpty(duss.SiteStyleId))
                            {
                                context.Response.Redirect(StaticObject.SitePath + "page/error/site_style_is_not_existed");
                                return;
                            }

                            if (!duss.SiteStyleActive.ZeroOneToBoolean())
                            {
                                context.Response.Redirect(StaticObject.SitePath + "page/error/site_style_is_inactive");
                                return;
                            }

                            CurrentSiteStylePhysicalPath = duss.SiteStyleDirectoryPath + "/" + duss.SiteStylePhysicalName;

                            CurrentLoadTag += duss.SiteStyleLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);

                            CurrentStaticHead += duss.SiteStyleStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

                            CategoryStyleIsSet = true;
                        }
                    }
                }


            if (!CategoryTemplateIsSet)
            {
                CurrentLoadTag += dust.SiteTemplateLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);
                CurrentStaticHead += dust.SiteTemplateStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);
            }

            if (!CategoryStyleIsSet)
            {
                CurrentLoadTag += duss.SiteStyleLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);
                CurrentStaticHead += duss.SiteStyleStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);
            }

            if (dup.PageGlobalName == "content")
                if (!string.IsNullOrEmpty(context.Request.Query["content_id"]))
                    if (context.Request.Query["content_id"].ToString().IsNumber())
                    {
                        string ContentId = context.Request.Query["content_id"];
                        evc.ContentId = ContentId;

                        string CategoryId = "";

                        if (dup.PageLoadType != "iframe" && dup.PageLoadType != "ajax")
                        {
                            DataUse.Content duc = new DataUse.Content();
                            duc.FillCurrentContent(ContentId);

                            evc.ContentTitle = duc.ContentTitle;
                            CategoryId = duc.CategoryId;
                        }

                        if (!string.IsNullOrEmpty(CategoryId))
                        {
                            evc.CategoryId = CategoryId;

                            CategoryClass cc2 = new CategoryClass();

                            evc.ParrentCategory = cc2.GetParentCategory(CurrentSiteGlobalName, CategoryId);

                            evc.CategoryName = cc2.CategoryName;

                            CurrentTitle = evc.GetContentTitleValue();
                        }
                    }


            if (dup.PageGlobalName == "main")
                if (!string.IsNullOrEmpty(context.Request.Query["tag"]))
                {
                    string TagName = context.Request.Query["tag"].ToString().Replace("_", " ");

                    evc.TagName = TagName;

                    CurrentTitle = evc.GetTagTitleValue();
                }


            if (!string.IsNullOrEmpty(context.Request.Query["page"]))
            {
                CurrentTitle += " - " + Language.GetLanguage("page", CurrentLanguageGlobalName) + " " + context.Request.Query["page"].ToString();
            }


            if (StaticObject.RoleSubmitVisitCheck())
            dup.IncreaseVisit(dup.PageId);

            if (dup.PageLoadAlone.ZeroOneToBoolean())
            {
                IgnoreViewAndModel = true;

                return;
            }


            // Set Current Client Object
            ccoc.SiteId = dus.SiteId;
            ccoc.SiteStyleId = duss.SiteStyleId;
            ccoc.SiteStylePhysicalPath = duss.SiteStyleDirectoryPath + "/" + duss.SiteStylePhysicalName;
            ccoc.SiteTemplateId = dust.SiteTemplateId;
            ccoc.SiteTemplatePhysicalPath = dust.SiteTemplateDirectoryPath + "/" + dust.SiteTemplatePhysicalName;

            if (!PriorityLanguage)
            {
                ccoc.SiteLanguageId = dul.LanguageId;
                ccoc.SiteLanguageGlobalName = dul.LanguageGlobalName;
            }


            // Set Box Head
            IncludeClass ic = new IncludeClass();
            string BoxStaticHead = ic.GetBoxHead(dus.SiteGlobalName);

            // Get Site Static Head
            Head.SiteStaticHead hssh = new Head.SiteStaticHead();
            string SiteStaticHead = hssh.Get();
            CurrentStaticHead += SiteStaticHead;

            // Write Page
            XmlDocument SiteTemplateDocument = StaticObject.CurrentSiteTemplateDocument();

            // Set Menu Value
            MenuClass mc = new MenuClass();

            // Get Header Bar Part Template
            if (CurrentIncludeHeaderBarPart)
            {
                HeaderBarLeftLocation = (CurrentFillHeaderBarLeft) ? mc.GetSiteMenu("header_bar_left", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeaderBarLeft)
                    HeaderBarLeftLocation = HeaderBarLeftLocation.AddParentHiddenTag();

                HeaderBarRightLocation = (CurrentFillHeaderBarRight) ? mc.GetSiteMenu("header_bar_right", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeaderBarRight)
                    HeaderBarRightLocation = HeaderBarRightLocation.AddParentHiddenTag();

                HeaderBarBoxLocation = (CurrentFillHeaderBarBox) ? mc.GetSiteMenu("header_bar_box", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeaderBarBox)
                    HeaderBarBoxLocation = HeaderBarBoxLocation.AddParentHiddenTag();
            }

            // Get Header Part Template
            if (CurrentIncludeHeaderPart)
            {
                Header1Location = (CurrentFillHeader1) ? mc.GetSiteMenu("header_1", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeader1)
                    Header1Location = Header1Location.AddParentHiddenTag();

                Header2Location = (CurrentFillHeader2) ? mc.GetSiteMenu("header_2", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeader2)
                    Header2Location = Header2Location.AddParentHiddenTag();

                HeaderMenuLocation = (CurrentFillHeaderMenu) ? mc.GetSiteMenu("header_menu", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowHeaderMenu)
                    HeaderMenuLocation = HeaderMenuLocation.AddParentHiddenTag();
            }

            // Get Menu Part Template
            if (CurrentIncludeMenuPart)
            {
                MenuLocation = (CurrentFillMenu) ? mc.GetSiteMenu("menu", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowMenu)
                    MenuLocation = MenuLocation.AddParentHiddenTag();
            }

            // Get Main Part Template
            if (CurrentIncludeMainPart)
            {
                AfterHeaderLocation = (CurrentFillAfterHeader) ? mc.GetSiteMenu("after_header", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowAfterHeader)
                    AfterHeaderLocation = AfterHeaderLocation.AddParentHiddenTag();

                LeftMenuLocation = (CurrentFillLeftMenu) ? mc.GetSiteMenu("left_menu", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowLeftMenu)
                    LeftMenuLocation = LeftMenuLocation.AddParentHiddenTag();

                RightMenuLocation = (CurrentFillRightMenu) ? mc.GetSiteMenu("right_menu", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowRightMenu)
                    RightMenuLocation = RightMenuLocation.AddParentHiddenTag();

                BeforeFooterLocation = (CurrentFillBeforeFooter) ? mc.GetSiteMenu("before_footer", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowBeforeFooter)
                    BeforeFooterLocation = BeforeFooterLocation.AddParentHiddenTag();

                // Set Main Fill
                ExistContentValue = (!string.IsNullOrEmpty(CurrentPageContent)) ? "" : " el_not_exist_content";
                ExistLeftMenuValue = ((CurrentFillLeftMenu || CurrentShowLeftMenu) && !string.IsNullOrEmpty(LeftMenuLocation)) ? "" : " el_not_exist_left_menu";
                ExistRightMenuValue = ((CurrentFillRightMenu || CurrentShowRightMenu) && !string.IsNullOrEmpty(RightMenuLocation)) ? "" : " el_not_exist_right_menu";
            }

            // Get Footer Part Template
            if (CurrentIncludeFooterPart)
            {
                Footer1Location = (CurrentFillFooter1) ? mc.GetSiteMenu("footer_1", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooter1)
                    Footer1Location = Footer1Location.AddParentHiddenTag();

                Footer2Location = (CurrentFillFooter2) ? mc.GetSiteMenu("footer_2", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooter2)
                    Footer2Location = Footer2Location.AddParentHiddenTag();

                FooterMenuLocation = (CurrentFillFooterMenu) ? mc.GetSiteMenu("footer_menu", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooterMenu)
                    FooterMenuLocation = FooterMenuLocation.AddParentHiddenTag();
            }

            // Get Footer Bar Part Template
            if (CurrentIncludeFooterBarPart)
            {
                FooterBarLeftLocation = (CurrentFillFooterBarLeft) ? mc.GetSiteMenu("footer_bar_left", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooterBarLeft)
                    FooterBarLeftLocation = FooterBarLeftLocation.AddParentHiddenTag();

                FooterBarRightLocation = (CurrentFillFooterBarRight) ? mc.GetSiteMenu("footer_bar_right", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooterBarRight)
                    FooterBarRightLocation = FooterBarRightLocation.AddParentHiddenTag();

                FooterBarBoxLocation = (CurrentFillFooterBarBox) ? mc.GetSiteMenu("footer_bar_box", CurrentGroupId, CurrentLanguageGlobalName, CurrentQueryString) : "";
                if (!CurrentShowFooterBarBox)
                    FooterBarBoxLocation = FooterBarBoxLocation.AddParentHiddenTag();
            }


            // Set Page Value Transfer
            CurrentStaticHead += transfer.Head;
            CurrentLoadTag += transfer.LoadTag;


            // Set Page Dynamic Head
            Head.SiteDynamicHead hsdh = new Head.SiteDynamicHead();
            hsdh.ShowDynamicMetaAapplicationName = dup.PageUseApplicationNameMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaAuthor = dup.PageUseAuthorMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaClassification = dup.PageUseClassificationMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaCopyright = dup.PageUseCopyrightMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaDescription = dup.PageUseDescriptionMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaGenerator = dup.PageUseGeneratorMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaJavascriptInactiveRefresh = dup.PageUseJavascriptInactiveRefreshMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaKeywords = dup.PageUseKeywordsMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaLanguage = dup.PageUseLanguageMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRevisitAfter = dup.PageUseRevisitAfterMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRight = dup.PageUseRightsMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRobots = dup.PageUseRobotsMeta.ZeroOneToBoolean();

            hsdh.DynamicMetaAapplicationNameValue = CurrentMetaAapplicationName;
            hsdh.DynamicMetaClassificationValue = CurrentClassificationMeta;
            hsdh.DynamicMetaCopyrightValue = CurrentCopyrightMeta;
            hsdh.DynamicMetaDescriptionValue = CurrentDescriptionMeta;
            hsdh.DynamicMetaGeneratorValue = CurrentMetaGenerator;
            hsdh.DynamicMetaKeywordsValue = CurrentKeywordsMeta;
            hsdh.DynamicMetaLanguageValue = CurrentLanguageGlobalName;
            hsdh.DynamicMetaRevisitAfterValue = CurrentRevisitAfterMeta;
            hsdh.DynamicMetaRightValue = CurrentRightsMeta;
            hsdh.DynamicMetaRobotsValue = CurrentRobotsMeta;
            hsdh.DynamicStyleValue = CurrentSiteStylePhysicalPath;
            hsdh.DynamicBoxHeadValue = BoxStaticHead;


            CurrentDynamicHead = hsdh.Get();

            ClientVariantClass cvc = new ClientVariantClass();
            ClientVariant = cvc.GetSiteClientVariant() + cvc.GetSiteClientLanguageVariant(StaticObject.GetCurrentSiteGlobalLanguage()) + ((ViewId != "0") ? cvc.GetCurrentViewStyle(CurrentStyleId, CurrentBackgroundColor, CurrentFontSize, CurrentCommonLightBackgroundColor, CurrentCommonLightTextColor, CurrentCommonMiddleBackgroundColor, CurrentCommonMiddleTextColor, CurrentCommonDarkBackgroundColor, CurrentCommonDarkTextColor, CurrentNaturalLightBackgroundColor, CurrentNaturalLightTextColor, CurrentNaturalMiddleBackgroundColor, CurrentNaturalMiddleTextColor, CurrentNaturalDarkBackgroundColor, CurrentNaturalDarkTextColor) : "");


            // Set Cache
            if (StaticObject.UseSiteMainCache)
            {
                cc.Insert(CacheType, "el_site_main_cache_current_language_direction" + SiteMainCacheKey, CurrentLanguageDirection, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_current_title" + SiteMainCacheKey, CurrentTitle, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_client_variant" + SiteMainCacheKey, ClientVariant, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_current_static_head" + SiteMainCacheKey, CurrentStaticHead, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_current_dynamic_head" + SiteMainCacheKey, CurrentDynamicHead, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_bar_left_location" + SiteMainCacheKey, HeaderBarLeftLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_bar_right_location" + SiteMainCacheKey, HeaderBarRightLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_bar_box_location" + SiteMainCacheKey, HeaderBarBoxLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_1_location" + SiteMainCacheKey, Header1Location, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_2_location" + SiteMainCacheKey, Header2Location, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_header_menu_location" + SiteMainCacheKey, HeaderMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_menu_location" + SiteMainCacheKey, MenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_exist_content_value" + SiteMainCacheKey, ExistContentValue, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_exist_left_menu_value" + SiteMainCacheKey, ExistLeftMenuValue, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_exist_right_menu_value" + SiteMainCacheKey, ExistRightMenuValue, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_after_header_location" + SiteMainCacheKey, AfterHeaderLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_left_menu_location" + SiteMainCacheKey, LeftMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_current_page_content" + SiteMainCacheKey, CurrentPageContent, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_right_menu_location" + SiteMainCacheKey, RightMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_before_footer_location" + SiteMainCacheKey, BeforeFooterLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_menu_location" + SiteMainCacheKey, FooterMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_1_location" + SiteMainCacheKey, Footer1Location, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_2_location" + SiteMainCacheKey, Footer2Location, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_bar_left_location" + SiteMainCacheKey, FooterBarLeftLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_bar_right_location" + SiteMainCacheKey, FooterBarRightLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_footer_bar_box_location" + SiteMainCacheKey, FooterBarBoxLocation, CacheDuration);
                cc.Insert(CacheType, "el_site_main_cache_current_load_tag" + SiteMainCacheKey, CurrentLoadTag, CacheDuration);
            }
        }
    }
}