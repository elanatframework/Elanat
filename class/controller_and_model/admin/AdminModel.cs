using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminModel : CodeBehindModel
    {
        public string CurrentTitle = "";
        public string CurrentDynamicHead = "";
        public string CurrentStaticHead = "";
        public string CurrentLoadTag = "";
        public string CurrentComponentContent = "";
        string CurrentComponentId = "0";
        string CurrentStyleId = "0";
        string CurrentTemplateId = "0";
        string CurrentLanguageId = "0";
        string CurrentQueryString = "";
        string CurrentDateFormat = "";
        string CurrentTimeFormat = "";
        string CurrentCalendar = "";
        string CurrentFirstDayOfWeek = "";
        string CurrentTimeZone = "";
        string CurrentDayDifference = "";
        string CurrentTimeHoursDifference = "";
        string CurrentTimeMinutesDifference = "";
        string CurrentSiteGlobalName = "";
        string CurrentLanguageGlobalName = "";
        string CurrentComponentName = "";
        string CurrentTemplateName = "";
        string CurrentStyleName = "";
        string CurrentAdminStylePhysicalPath = "";
        string CurrentAdminTemplatePhysicalPath = "";
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
        public string CurrentLanguageDirection = "";
        public string ClientVariant = "";

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

        public void SetValue(HttpContext context)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            // Set Cache Key
            string AdminMainCacheKey = "";
            foreach (string key in (StaticObject.AdminMainCacheParameters.Split(',')))
                if (!string.IsNullOrEmpty(context.Request.Query[key]))
                    AdminMainCacheKey += ":" + context.Request.Query[key].ToString();


            // Get Cache
            if (cc.Exist(CacheType, "el_admin_main_cache_current_page_content" + AdminMainCacheKey))
            {
                CurrentLanguageDirection = cc.GetValue(CacheType, "el_admin_main_cache_current_language_direction" + AdminMainCacheKey);
                CurrentTitle = cc.GetValue(CacheType, "el_admin_main_cache_current_title" + AdminMainCacheKey);
                ClientVariant = cc.GetValue(CacheType, "el_admin_main_cache_client_variant" + AdminMainCacheKey);
                CurrentStaticHead = cc.GetValue(CacheType, "el_admin_main_cache_current_static_head" + AdminMainCacheKey);
                CurrentDynamicHead = cc.GetValue(CacheType, "el_admin_main_cache_current_dynamic_head" + AdminMainCacheKey);
                HeaderBarLeftLocation = cc.GetValue(CacheType, "el_admin_main_cache_header_bar_left_location" + AdminMainCacheKey);
                HeaderBarRightLocation = cc.GetValue(CacheType, "el_admin_main_cache_header_bar_right_location" + AdminMainCacheKey);
                HeaderBarBoxLocation = cc.GetValue(CacheType, "el_admin_main_cache_header_bar_box_location" + AdminMainCacheKey);
                Header1Location = cc.GetValue(CacheType, "el_admin_main_cache_header_1_location" + AdminMainCacheKey);
                Header2Location = cc.GetValue(CacheType, "el_admin_main_cache_header_2_location" + AdminMainCacheKey);
                HeaderMenuLocation = cc.GetValue(CacheType, "el_admin_main_cache_header_menu_location" + AdminMainCacheKey);
                MenuLocation = cc.GetValue(CacheType, "el_admin_main_cache_menu_location" + AdminMainCacheKey);
                AfterHeaderLocation = cc.GetValue(CacheType, "el_admin_main_cache_after_header_location" + AdminMainCacheKey);
                LeftMenuLocation = cc.GetValue(CacheType, "el_admin_main_cache_left_menu_location" + AdminMainCacheKey);
                CurrentComponentContent = cc.GetValue(CacheType, "el_admin_main_cache_current_component_content" + AdminMainCacheKey);
                RightMenuLocation = cc.GetValue(CacheType, "el_admin_main_cache_right_menu_location" + AdminMainCacheKey);
                BeforeFooterLocation = cc.GetValue(CacheType, "el_admin_main_cache_before_footer_location" + AdminMainCacheKey);
                FooterMenuLocation = cc.GetValue(CacheType, "el_admin_main_cache_footer_menu_location" + AdminMainCacheKey);
                Footer1Location = cc.GetValue(CacheType, "el_admin_main_cache_footer_1_location" + AdminMainCacheKey);
                Footer2Location = cc.GetValue(CacheType, "el_admin_main_cache_footer_2_location" + AdminMainCacheKey);
                FooterBarLeftLocation = cc.GetValue(CacheType, "el_admin_main_cache_footer_bar_left_location" + AdminMainCacheKey);
                FooterBarRightLocation = cc.GetValue(CacheType, "el_admin_main_cache_footer_bar_right_location" + AdminMainCacheKey);
                FooterBarBoxLocation = cc.GetValue(CacheType, "el_admin_main_cache_footer_bar_box_location" + AdminMainCacheKey);
                CurrentLoadTag = cc.GetValue(CacheType, "el_admin_main_cache_current_load_tag" + AdminMainCacheKey);

                return;
            }


            // Delete Page Value Transfer
            PageValueTransfer transfer = new PageValueTransfer();
            transfer.Delete();


            // Set Common Value
            CurrentQueryString += context.Request.QueryString.ToString();


            // Set Elanat Value
            string ElanatSiteGlobalName = StaticObject.DefaultSite;
            string ElanatLanguageGlobalName = StaticObject.DefaultAdminLanguage;
            string ElanatComponent = ElanatConfig.GetNode("properties/default_component").Attributes["value"].Value;
            string ElanatTemplate = StaticObject.DefaultAdminTemplate;
            string ElanatStyle = StaticObject.DefaultAdminStyle;
            string ElanatCalendar = StaticObject.DefaultSiteCalendar;
            string ElanatDateFormat = StaticObject.DefaultDateFormat;
            string ElanatTimeFormat = StaticObject.DefaulttimeFormat;
            string ElanatTimeZone = StaticObject.DefaultTimeZone;
            string ElanatFirstDayOfWeek = StaticObject.DefaultFirstDayOfWeek;
            string ElanatDayDifference = StaticObject.DefaultDayDifference;
            string ElanatTimeHoursDifference = StaticObject.DefaultTimeDifferenceHours;
            string ElanatTimeMinutesDifference = StaticObject.DefaultTimeDifferenceMinutes;

            CurrentSiteGlobalName = ElanatSiteGlobalName;
            CurrentLanguageGlobalName = ElanatLanguageGlobalName;
            CurrentComponentName = ElanatComponent;
            CurrentTemplateName = ElanatTemplate;
            CurrentStyleName = ElanatStyle;
            CurrentCalendar = ElanatCalendar;
            CurrentDateFormat = ElanatDateFormat;
            CurrentTimeFormat = ElanatTimeFormat;
            CurrentTimeZone = ElanatTimeZone;
            CurrentFirstDayOfWeek = ElanatFirstDayOfWeek;
            CurrentDayDifference = ElanatDayDifference;
            CurrentTimeHoursDifference = ElanatTimeHoursDifference;
            CurrentTimeMinutesDifference = ElanatTimeMinutesDifference;


            // Set Priority Value
            bool PriorityLanguage = false;

            DataUse.Language dul = new DataUse.Language();

            if (!string.IsNullOrEmpty(context.Request.Query["language"]))
            {
                CurrentLanguageGlobalName = context.Request.Query["language"].ToString().ProtectSqlInjection();
                CurrentLanguageId = dul.GetLanguageIdByLanguageGlobalName(CurrentLanguageGlobalName);

                dul.FillCurrentLanguage(CurrentLanguageId);

                if (string.IsNullOrEmpty(dul.LanguageId))
                {
                    Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("language_is_not_existed", CurrentLanguageGlobalName)));
                    return;
                }

                if (!dul.LanguageActive.ZeroOneToBoolean())
                {
                    Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("language_is_inactive", CurrentLanguageGlobalName)));
                    return;
                }

                ccoc.AdminLanguageId = dul.LanguageId;
                ccoc.AdminLanguageGlobalName = dul.LanguageGlobalName;
                ccoc.AdminLanguageIsRightToLeft = dul.LanguageIsRightToLeft;

                PriorityLanguage = true;
            }

            // Set Site Value
            CurrentSiteGlobalName = (!string.IsNullOrEmpty(context.Request.Query["site"])) ? context.Request.Query["site"].ToString().ProtectSqlInjection() : StaticObject.ConfigDocument.SelectSingleNode("elanat_root/properties/default_site").Attributes["value"].Value;
            DataUse.Site dus = new DataUse.Site();
            string CurrentSiteId = dus.GetSiteIdBySiteGlobalName(CurrentSiteGlobalName);

            dus.FillCurrentSite(CurrentSiteId);

            if (string.IsNullOrEmpty(dus.SiteId))
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_is_not_existed", CurrentLanguageGlobalName)));
                return;
            }

            if (!dus.SiteActive.ZeroOneToBoolean())
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_is_inactive", CurrentLanguageGlobalName)));
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

            if (dus.LanguageId != "0" && !PriorityLanguage)
                CurrentLanguageId = dus.LanguageId;

            if (dus.AdminStyleId != "0")
                CurrentStyleId = dus.AdminStyleId;

            if (dus.AdminTemplateId != "0")
                CurrentTemplateId = dus.AdminTemplateId;


            // Set Language Value

            if (CurrentLanguageId == "0")
            {
                CurrentLanguageGlobalName = (!string.IsNullOrEmpty(context.Request.Query["language"])) ? context.Request.Query["language"].ToString().ProtectSqlInjection() : StaticObject.DefaultAdminLanguage;

                CurrentLanguageId = dul.GetLanguageIdByLanguageGlobalName(CurrentLanguageGlobalName);
            }

            dul.FillCurrentLanguage(CurrentLanguageId);

            if (string.IsNullOrEmpty(dul.LanguageId))
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("language_is_not_existed", CurrentLanguageGlobalName)));
                return;
            }

            if (!dul.LanguageActive.ZeroOneToBoolean())
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("language_is_inactive", CurrentLanguageGlobalName)));
                return;
            }

            CurrentLanguageDirection = (dul.LanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";


            // Set User
            if (StaticObject.GetCurrentUserId() != "0")
            {
                DataUse.User duu = new DataUse.User();

                duu.FillCurrentUser(StaticObject.GetCurrentUserId());

                if (string.IsNullOrEmpty(duu.UserId))
                {
                    Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("user_is_not_existed", CurrentLanguageGlobalName)));
                    return;
                }

                if (!duu.UserActive.ZeroOneToBoolean())
                {
                    Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("user_is_inactive", CurrentLanguageGlobalName)));
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

                if (ccoc.AdminStyleId != "0")
                    CurrentStyleId = ccoc.AdminStyleId;
                
                if (ccoc.AdminTemplateId != "0")
                    CurrentTemplateId = ccoc.AdminTemplateId;

                if (!PriorityLanguage)
                {
                    if (ccoc.AdminLanguageId != "0")
                    {
                        CurrentLanguageId = ccoc.AdminLanguageId;
                        CurrentLanguageGlobalName = ccoc.AdminLanguageGlobalName;
                        CurrentLanguageDirection = (ccoc.AdminLanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";
                    }
                }
            }


            // Set Admin Template Value
            DataUse.AdminTemplate duat = new DataUse.AdminTemplate();

            if (CurrentTemplateId == "0")
                CurrentTemplateId = duat.GetAdminTemplateIdByAdminTemplateName(ElanatTemplate);

            duat.FillCurrentAdminTemplate(CurrentTemplateId);

            if (string.IsNullOrEmpty(duat.AdminTemplateId))
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("admin_template_is_not_existed", CurrentLanguageGlobalName)));
                return;
            }

            if (!duat.AdminTemplateActive.ZeroOneToBoolean())
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("admin_template_is_inactive", CurrentLanguageGlobalName)));
                return;
            }

            CurrentAdminTemplatePhysicalPath = duat.AdminTemplateDirectoryPath + "/" + duat.AdminTemplatePhysicalName;

            CurrentLoadTag += duat.AdminTemplateLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);

            CurrentStaticHead += duat.AdminTemplateStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);


            // Set Admin Style Value
            DataUse.AdminStyle duas = new DataUse.AdminStyle();

            if (CurrentStyleId == "0")
                CurrentStyleId = duas.GetAdminStyleIdByAdminStyleName(ElanatStyle);

            duas.FillCurrentAdminStyle(CurrentStyleId);

            if (string.IsNullOrEmpty(duas.AdminStyleId))
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("admin_style_is_not_existed", CurrentLanguageGlobalName)));
                return;
            }

            if (!duas.AdminStyleActive.ZeroOneToBoolean())
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("admin_style_is_inactive", CurrentLanguageGlobalName)));
                return;
            }

            CurrentAdminStylePhysicalPath = duas.AdminStyleDirectoryPath + "/" + duas.AdminStylePhysicalName;

            CurrentLoadTag += duas.AdminStyleLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);

            CurrentStaticHead += duas.AdminStyleStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);


            // Set Component Value
            CurrentComponentName = (!string.IsNullOrEmpty(context.Request.Query["component_name"])) ? context.Request.Query["component_name"].ToString().ProtectSqlInjection() : ElanatComponent;
            DataUse.Component duc = new DataUse.Component();
            CurrentComponentId = duc.GetComponentIdByComponentName(CurrentComponentName);

            duc.FillCurrentComponent(CurrentComponentId);

            if (string.IsNullOrEmpty(duc.ComponentId))
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("component_is_not_existed", CurrentLanguageGlobalName)));
                return;
            }

            if (!duc.ComponentActive.ZeroOneToBoolean())
            {
                Write(Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("component_is_inactive", CurrentLanguageGlobalName)));
                return;
            }

            // Load Component Catalog
            XmlDocument ComponentCatalogDocument = new XmlDocument();
            ComponentCatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath + "/catalog.xml"));

            CurrentStaticHead += ComponentCatalogDocument.SelectSingleNode("component_catalog_root/component_static_head").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp admin_path;", StaticObject.AdminPath);

            CurrentLoadTag += ComponentCatalogDocument.SelectSingleNode("component_catalog_root/component_load_tag").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp admin_path;", StaticObject.AdminPath);


            // Set Cache Key
            string ComponentCacheKey = "";
            foreach (string key in (duc.ComponentCacheParameters.Split(',')))
                if (!string.IsNullOrEmpty(context.Request.Query[key]))
                    ComponentCacheKey += ":" + context.Request.Query[key].ToString();

            // Get Cache
            if (cc.Exist(CacheType, "el_component_load_in_admin_" + duc.ComponentId + ComponentCacheKey))
            {
                string TmpCurrentComponentContent = cc.GetValue(CacheType, "el_component_load_in_admin_" + duc.ComponentId + ComponentCacheKey);
                CurrentComponentContent = TmpCurrentComponentContent;
            }


            // Load Component
            CurrentComponentContent = PageLoader.LoadPage(duc.ComponentLoadType, StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath + "/" + duc.ComponentPhysicalName + (!string.IsNullOrEmpty(CurrentQueryString) ? CurrentQueryString : ""));


            // Set Replace Value
            AttributeReader ar = new AttributeReader();

            if (duc.ComponentLoadType != "iframe" && duc.ComponentLoadType != "ajax")
            {
                if (duc.ComponentUseLanguage.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadLanguage(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUseModule.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadModule(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUsePlugin.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadPlugin(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUseReplacePart.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadReplacePart(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUseFetch.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadFetch(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUseItem.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadItem(CurrentComponentContent, CurrentLanguageGlobalName);

                if (duc.ComponentUseElanat.ZeroOneToBoolean())
                    CurrentComponentContent = ar.ReadElanat(CurrentComponentContent, CurrentLanguageGlobalName);


                // Set Cache
                cc.Insert(CacheType, "el_component_load_in_admin_" + duc.ComponentId + ComponentCacheKey, CurrentComponentContent, int.Parse(duc.ComponentCacheDuration));
            }


            // Set Title
            CurrentTitle = Language.GetLanguage("admin", CurrentLanguageGlobalName) + " - " + Language.GetHandheldLanguage(duc.ComponentName, CurrentLanguageGlobalName);


            // Set Page Value Transfer
            CurrentStaticHead += transfer.Head;


            // Set Current Client Object
            ccoc.SiteId = dus.SiteId;
            ccoc.AdminStyleId = duas.AdminStyleId;
            ccoc.AdminStylePhysicalPath = duas.AdminStyleDirectoryPath + "/" + duas.AdminStylePhysicalName;
            ccoc.AdminTemplateId = duat.AdminTemplateId;
            ccoc.AdminTemplatePhysicalPath = duat.AdminTemplateDirectoryPath + "/" + duat.AdminTemplatePhysicalName;

            
            // Set Box Head
            IncludeClass ic = new IncludeClass();
            string BoxStaticHead = ic.GetBoxHead(dus.SiteGlobalName);


            MenuClass mc = new MenuClass();

            // Get Header Bar Part Template
            HeaderBarLeftLocation = mc.GetAdminMenu("header_bar_left");
            HeaderBarRightLocation = mc.GetAdminMenu("header_bar_right");
            HeaderBarBoxLocation = mc.GetAdminMenu("header_bar_box");

            // Get Header Part Template
            HeaderMenuLocation = mc.GetAdminMenu("header_menu");
            Header1Location = mc.GetAdminMenu("header_1");
            Header2Location = mc.GetAdminMenu("header_2");

            // Get Menu Part Template
            MenuLocation = mc.GetAdminMenu("menu");

            // Get Main Part Template
            AfterHeaderLocation = mc.GetAdminMenu("after_header");
            LeftMenuLocation = mc.GetAdminMenu("left_menu");
            RightMenuLocation = mc.GetAdminMenu("right_menu");
            BeforeFooterLocation = mc.GetAdminMenu("before_footer");

            // Get Footer Part Template
            FooterMenuLocation = mc.GetAdminMenu("footer_menu");
            Footer1Location = mc.GetAdminMenu("footer_1");
            Footer2Location = mc.GetAdminMenu("footer_2");

            // Get Footer Bar Part Template
            FooterBarLeftLocation = mc.GetAdminMenu("footer_bar_left");
            FooterBarRightLocation = mc.GetAdminMenu("footer_bar_right");
            FooterBarBoxLocation = mc.GetAdminMenu("footer_bar_box");


            // Get Admin Static Head
            Head.AdminStaticHead hash = new Head.AdminStaticHead();
            CurrentStaticHead += hash.Get();

            // Get Admin Dynamic Head
            Head.AdminDynamicHead hadh = new Head.AdminDynamicHead();

            hadh.DynamicMetaLanguageValue = CurrentLanguageGlobalName;
            hadh.DynamicStyleValue = CurrentAdminStylePhysicalPath;
            hadh.DynamicBoxHeadValue = BoxStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);

            CurrentDynamicHead = hadh.Get();


            // Get Client Variant
            ClientVariantClass cvc = new ClientVariantClass();
            ClientVariant = cvc.GetAdminClientVariant() + cvc.GetAdminClientLanguageVariant(StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Cache
            if (StaticObject.UseAdminMainCache)
            {
                int CacheDuration = StaticObject.GetCurrentCacheDuration(ccoc.RoleDominantType);

                cc.Insert(CacheType, "el_admin_main_cache_current_language_direction" + AdminMainCacheKey, CurrentLanguageDirection, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_current_title" + AdminMainCacheKey, CurrentTitle, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_client_variant" + AdminMainCacheKey, ClientVariant, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_current_static_head" + AdminMainCacheKey, CurrentStaticHead, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_current_dynamic_head" + AdminMainCacheKey, CurrentDynamicHead, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_bar_left_location" + AdminMainCacheKey, HeaderBarLeftLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_bar_right_location" + AdminMainCacheKey, HeaderBarRightLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_bar_box_location" + AdminMainCacheKey, HeaderBarBoxLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_1_location" + AdminMainCacheKey, Header1Location, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_2_location" + AdminMainCacheKey, Header2Location, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_header_menu_location" + AdminMainCacheKey, HeaderMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_menu_location" + AdminMainCacheKey, MenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_after_header_location" + AdminMainCacheKey, AfterHeaderLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_left_menu_location" + AdminMainCacheKey, LeftMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_current_component_content" + AdminMainCacheKey, CurrentComponentContent, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_right_menu_location" + AdminMainCacheKey, RightMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_before_footer_location" + AdminMainCacheKey, BeforeFooterLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_menu_location" + AdminMainCacheKey, FooterMenuLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_1_location" + AdminMainCacheKey, Footer1Location, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_2_location" + AdminMainCacheKey, Footer2Location, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_bar_left_location" + AdminMainCacheKey, FooterBarLeftLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_bar_right_location" + AdminMainCacheKey, FooterBarRightLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_footer_bar_box_location" + AdminMainCacheKey, FooterBarBoxLocation, CacheDuration);
                cc.Insert(CacheType, "el_admin_main_cache_current_load_tag" + AdminMainCacheKey, CurrentLoadTag, CacheDuration);
            }
        }
    }
}