using CodeBehind;

namespace Elanat
{
    public partial class ActionEditSiteModel : CodeBehindModel
    {
        public string EditSiteLanguage { get; set; }
        public string SiteAdminStyleLanguage { get; set; }
        public string SiteAdminTemplateLanguage { get; set; }
        public string SiteActivitiesLanguage { get; set; }
        public string SiteAddressLanguage { get; set; }
        public string SiteDefaultPageLanguage { get; set; }
        public string SiteDescriptionMetaLanguage { get; set; }
        public string SiteEmailLanguage { get; set; }
        public string SiteGlobalNameLanguage { get; set; }
        public string SiteKeywordsMetaLanguage { get; set; }
        public string SiteLanguageLanguage { get; set; }
        public string SiteNameLanguage { get; set; }
        public string SiteOtherInfoLanguage { get; set; }
        public string SitePhoneNumberLanguage { get; set; }
        public string SiteRevisitAfterMetaLanguage { get; set; }
        public string SiteRightsMetaLanguage { get; set; }
        public string SiteAccessShowLanguage { get; set; }
        public string SiteSloganNameLanguage { get; set; }
        public string SiteStaticHeadLanguage { get; set; }
        public string SiteSiteStyleLanguage { get; set; }
        public string SiteSiteTemplateeLanguage { get; set; }
        public string SiteTitleLanguage { get; set; }
        public string SiteClassificationMetaLanguage { get; set; }
        public string SiteCalendarLanguage { get; set; }
        public string SiteFirstDayOfWeekLanguage { get; set; }
        public string SiteDateFormatLanguage { get; set; }
        public string SiteTimeFormatLanguage { get; set; }
        public string SiteTimeZoneLanguage { get; set; }
        public string SiteUseClassificationMetaLanguage { get; set; }
        public string SiteActiveLanguage { get; set; }
        public string SiteShowLinkInSiteLanguage { get; set; }
        public string SiteUseDescriptionMetaLanguage { get; set; }
        public string SiteUseKeywordsMetaLanguage { get; set; }
        public string SiteUseRevisitAfterMetaLanguage { get; set; }
        public string SiteUseRightsMetaLanguage { get; set; }
        public string SiteDateCreateLanguage { get; set; }
        public string SiteTimeCreateLanguage { get; set; }
        public string SiteVisitLanguage { get; set; }
        public string SitePublicAccessShowLanguage { get; set; }
        public string SaveSiteLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string SiteIdValue { get; set; }

        public bool SiteActiveValue { get; set; } = false;
        public bool SiteShowLinkInSiteValue { get; set; } = false;
        public bool SiteUseDescriptionMetaValue { get; set; } = false;
        public bool SiteUseRightsMetaValue { get; set; } = false;
        public bool SiteUseKeywordsMetaValue { get; set; } = false;
        public bool SiteUseClassificationMetaValue { get; set; } = false;
        public bool SiteUseRevisitAfterMetaValue { get; set; } = false;
        public bool SitePublicAccessShowValue { get; set; } = false;

        public string SiteLanguageOptionListValue { get; set; }
        public string SiteLanguageOptionListSelectedValue { get; set; }
        public string SiteDefaultPageOptionListValue { get; set; }
        public string SiteDefaultPageOptionListSelectedValue { get; set; }
        public string SiteSiteStyleOptionListValue { get; set; }
        public string SiteSiteStyleOptionListSelectedValue { get; set; }
        public string SiteSiteTemplateOptionListValue { get; set; }
        public string SiteSiteTemplateOptionListSelectedValue { get; set; }
        public string SiteAdminStyleOptionListValue { get; set; }
        public string SiteAdminStyleOptionListSelectedValue { get; set; }
        public string SiteAdminTemplateOptionListValue { get; set; }
        public string SiteAdminTemplateOptionListSelectedValue { get; set; }
        public string SiteCalendarOptionListValue { get; set; }
        public string SiteCalendarOptionListSelectedValue { get; set; }
        public string SiteFirstDayOfWeekOptionListValue { get; set; }
        public string SiteFirstDayOfWeekOptionListSelectedValue { get; set; }
        public string SiteTimeZoneOptionListValue { get; set; }
        public string SiteTimeZoneOptionListSelectedValue { get; set; }

        public string SiteNameValue { get; set; }
        public string SiteGlobalNameValue { get; set; }
        public string SiteSloganNameValue { get; set; }
        public string SiteTitleValue { get; set; }
        public string SiteDateFormatValue { get; set; }
        public string SiteTimeFormatValue { get; set; }
        public string SiteAddressValue { get; set; }
        public string SitePhoneNumberValue { get; set; }
        public string SiteEmailValue { get; set; }
        public string SiteActivitiesValue { get; set; }
        public string SiteOtherInfoValue { get; set; }
        public string SiteStaticHeadValue { get; set; }
        public string SiteDescriptionMetaValue { get; set; }
        public string SiteRightsMetaValue { get; set; }
        public string SiteKeywordsMetaValue { get; set; }
        public string SiteClassificationMetaValue { get; set; }
        public string SiteRevisitAfterMetaValue { get; set; }
        public string SiteDateCreateValue { get; set; }
        public string SiteTimeCreateValue { get; set; }
        public string SiteVisitValue { get; set; }

        public string SiteNameAttribute { get; set; }
        public string SiteGlobalNameAttribute { get; set; }
        public string SiteSloganNameAttribute { get; set; }
        public string SiteTitleAttribute { get; set; }
        public string SiteDateFormatAttribute { get; set; }
        public string SiteTimeFormatAttribute { get; set; }
        public string SiteAddressAttribute { get; set; }
        public string SitePhoneNumberAttribute { get; set; }
        public string SiteEmailAttribute { get; set; }
        public string SiteActivitiesAttribute { get; set; }
        public string SiteOtherInfoAttribute { get; set; }
        public string SiteStaticHeadAttribute { get; set; }
        public string SiteDescriptionMetaAttribute { get; set; }
        public string SiteRightsMetaAttribute { get; set; }
        public string SiteKeywordsMetaAttribute { get; set; }
        public string SiteClassificationMetaAttribute { get; set; }
        public string SiteRevisitAfterMetaAttribute { get; set; }
        public string SiteLanguageAttribute { get; set; }
        public string SiteDefaultPageAttribute { get; set; }
        public string SiteSiteStyleAttribute { get; set; }
        public string SiteSiteTemplateAttribute { get; set; }
        public string SiteAdminStyleAttribute { get; set; }
        public string SiteAdminTemplateAttribute { get; set; }
        public string SiteCalendarAttribute { get; set; }
        public string SiteFirstDayOfWeekAttribute { get; set; }
        public string SiteTimeZoneAttribute { get; set; }
        public string SiteDateCreateAttribute { get; set; }
        public string SiteTimeCreateAttribute { get; set; }
        public string SiteVisitAttribute { get; set; }

        public string SiteNameCssClass { get; set; }
        public string SiteGlobalNameCssClass { get; set; }
        public string SiteSloganNameCssClass { get; set; }
        public string SiteTitleCssClass { get; set; }
        public string SiteDateFormatCssClass { get; set; }
        public string SiteTimeFormatCssClass { get; set; }
        public string SiteAddressCssClass { get; set; }
        public string SitePhoneNumberCssClass { get; set; }
        public string SiteEmailCssClass { get; set; }
        public string SiteActivitiesCssClass { get; set; }
        public string SiteOtherInfoCssClass { get; set; }
        public string SiteStaticHeadCssClass { get; set; }
        public string SiteDescriptionMetaCssClass { get; set; }
        public string SiteRightsMetaCssClass { get; set; }
        public string SiteKeywordsMetaCssClass { get; set; }
        public string SiteClassificationMetaCssClass { get; set; }
        public string SiteRevisitAfterMetaCssClass { get; set; }
        public string SiteLanguageCssClass { get; set; }
        public string SiteDefaultPageCssClass { get; set; }
        public string SiteSiteStyleCssClass { get; set; }
        public string SiteSiteTemplateCssClass { get; set; }
        public string SiteAdminStyleCssClass { get; set; }
        public string SiteAdminTemplateCssClass { get; set; }
        public string SiteCalendarCssClass { get; set; }
        public string SiteFirstDayOfWeekCssClass { get; set; }
        public string SiteTimeZoneCssClass { get; set; }
        public string SiteDateCreateCssClass { get; set; }
        public string SiteTimeCreateCssClass { get; set; }
        public string SiteVisitCssClass { get; set; }

        public List<ListItem> SiteAccessShowListItem = new List<ListItem>();
        public string SiteAccessShowListValue { get; set; }
        public string SiteAccessShowTemplateValue { get; set; }

        public string SiteAccessShowAttribute { get; set; }
        public string SiteAccessShowCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/");
            SaveSiteLanguage = aol.GetAddOnsLanguage("save_site");
            EditSiteLanguage = aol.GetAddOnsLanguage("edit_site");
            SiteAdminStyleLanguage = aol.GetAddOnsLanguage("site_admin_style");
            SiteAdminTemplateLanguage = aol.GetAddOnsLanguage("site_admin_template");
            SiteActivitiesLanguage = aol.GetAddOnsLanguage("site_activities");
            SiteAddressLanguage = aol.GetAddOnsLanguage("site_address");
            SiteDefaultPageLanguage = aol.GetAddOnsLanguage("site_default_page");
            SiteDescriptionMetaLanguage = aol.GetAddOnsLanguage("site_description_meta");
            SiteEmailLanguage = aol.GetAddOnsLanguage("site_email");
            SiteGlobalNameLanguage = aol.GetAddOnsLanguage("site_global_name");
            SiteKeywordsMetaLanguage = aol.GetAddOnsLanguage("site_keywords_meta");
            SiteLanguageLanguage = aol.GetAddOnsLanguage("site_language");
            SiteNameLanguage = aol.GetAddOnsLanguage("site_name");
            SiteOtherInfoLanguage = aol.GetAddOnsLanguage("site_other_info");
            SitePhoneNumberLanguage = aol.GetAddOnsLanguage("site_phone_number");
            SiteRevisitAfterMetaLanguage = aol.GetAddOnsLanguage("site_revisit_after_meta");
            SiteRightsMetaLanguage = aol.GetAddOnsLanguage("site_rights_meta");
            SiteAccessShowLanguage = aol.GetAddOnsLanguage("site_access_show");
            SiteSloganNameLanguage = aol.GetAddOnsLanguage("site_slogan_name");
            SiteStaticHeadLanguage = aol.GetAddOnsLanguage("static_head");
            SiteSiteStyleLanguage = aol.GetAddOnsLanguage("site_style");
            SiteSiteTemplateeLanguage = aol.GetAddOnsLanguage("site_template");
            SiteTitleLanguage = aol.GetAddOnsLanguage("site_title");
            SiteClassificationMetaLanguage = aol.GetAddOnsLanguage("site_classification_meta");
            SiteCalendarLanguage = aol.GetAddOnsLanguage("site_calendar");
            SiteFirstDayOfWeekLanguage = aol.GetAddOnsLanguage("site_first_day_of_week");
            SiteDateFormatLanguage = aol.GetAddOnsLanguage("site_date_format");
            SiteTimeFormatLanguage = aol.GetAddOnsLanguage("site_time_format");
            SiteTimeZoneLanguage = aol.GetAddOnsLanguage("site_time_zone");
            SiteUseClassificationMetaLanguage = aol.GetAddOnsLanguage("site_use_classification_meta");
            SiteActiveLanguage = aol.GetAddOnsLanguage("site_active");
            SiteShowLinkInSiteLanguage = aol.GetAddOnsLanguage("site_show_link_in_site");
            SiteUseDescriptionMetaLanguage = aol.GetAddOnsLanguage("site_use_description_meta");
            SiteUseKeywordsMetaLanguage = aol.GetAddOnsLanguage("site_use_keywords_meta");
            SiteUseRevisitAfterMetaLanguage = aol.GetAddOnsLanguage("site_use_revisit_after_meta");
            SiteUseRightsMetaLanguage = aol.GetAddOnsLanguage("site_use_rights_meta");
            SitePublicAccessShowLanguage = aol.GetAddOnsLanguage("site_public_access_show");
            SiteDateCreateLanguage = aol.GetAddOnsLanguage("site_date_create");
            SiteTimeCreateLanguage = aol.GetAddOnsLanguage("site_time_create");
            SiteVisitLanguage = aol.GetAddOnsLanguage("site_visit");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Site dus = new DataUse.Site();
                dus.FillCurrentSite(SiteIdValue);

                SiteNameValue = dus.SiteName;
                SiteGlobalNameValue = dus.SiteGlobalName;
                SiteSloganNameValue = dus.SiteSloganName;
                SiteLanguageOptionListSelectedValue = dus.LanguageId;
                SiteDefaultPageOptionListSelectedValue = dus.PageId;
                SiteTitleValue = dus.SiteTitle;
                SiteActiveValue = dus.SiteActive.ZeroOneToBoolean();
                SiteShowLinkInSiteValue = dus.SiteShowLinkInSite.ZeroOneToBoolean();
                SiteSiteStyleOptionListSelectedValue = dus.SiteStyleId;
                SiteSiteTemplateOptionListSelectedValue = dus.SiteTemplateId;
                SiteAdminStyleOptionListSelectedValue = dus.AdminStyleId;
                SiteAdminTemplateOptionListSelectedValue = dus.AdminTemplateId;
                SiteCalendarOptionListSelectedValue = dus.SiteCalendar;
                SiteFirstDayOfWeekOptionListSelectedValue = dus.SiteFirstDayOfWeek;
                SiteDateFormatValue = dus.SiteDateFormat;
                SiteTimeFormatValue = dus.SiteTimeFormat;
                SiteTimeZoneOptionListSelectedValue = (float.Parse(dus.SiteTimeZone) > 0) ? "+" + dus.SiteTimeZone : dus.SiteTimeZone;
                SiteActivitiesValue = dus.SiteSiteActivities;
                SiteAddressValue = dus.SiteAddress;
                SitePhoneNumberValue = dus.SitePhoneNumber;
                SiteEmailValue = dus.SiteEmail;
                SiteOtherInfoValue = dus.SiteOtherInfo;
                SiteStaticHeadValue = dus.SiteStaticHead;
                SiteUseDescriptionMetaValue = dus.SiteUseDescriptionMeta.ZeroOneToBoolean();
                SiteDescriptionMetaValue = dus.SiteDescriptionMeta;
                SiteUseRevisitAfterMetaValue = dus.SiteUseRevisitAfterMeta.ZeroOneToBoolean();
                SiteRevisitAfterMetaValue = dus.SiteRevisitAfterMeta;
                SiteUseRightsMetaValue = dus.SiteUseRightsMeta.ZeroOneToBoolean();
                SiteRightsMetaValue = dus.SiteRightsMeta;
                SiteUseKeywordsMetaValue = dus.SiteUseKeywordsMeta.ZeroOneToBoolean();
                SiteKeywordsMetaValue = dus.SiteKeywordsMeta;
                SiteUseClassificationMetaValue = dus.SiteUseClassificationMeta.ZeroOneToBoolean();
                SiteClassificationMetaValue = dus.SiteClassificationMeta;
                SitePublicAccessShowValue = dus.SitePublicAccessShow.ZeroOneToBoolean();
                SiteDateCreateValue = dus.SiteDateCreate;
                SiteTimeCreateValue = dus.SiteTimeCreate;
                SiteVisitValue = dus.SiteVisit;
            }

            // Set Language Item
            ListClass.LanguageList lcll = new ListClass.LanguageList();
            lcll.FillLanguageListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteLanguageOptionListValue += SiteLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteLanguageOptionListValue += lcll.LanguageListItem.HtmlInputToOptionTag(SiteLanguageOptionListSelectedValue);

            // Set Page Item
            ListClass.Page lcp = new ListClass.Page();
            lcp.FillPageListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteDefaultPageOptionListValue += SiteDefaultPageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteDefaultPageOptionListValue += lcp.PageListItem.HtmlInputToOptionTag(SiteDefaultPageOptionListSelectedValue);

            // Set Site Style Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleListItem();
            SiteSiteStyleOptionListValue += SiteSiteStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteSiteStyleOptionListValue += lcss.SiteStyleListItem.HtmlInputToOptionTag(SiteSiteStyleOptionListSelectedValue);

            // Set Site Template Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateListItem();
            SiteSiteTemplateOptionListValue += SiteSiteTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteSiteTemplateOptionListValue += lcst.SiteTemplateListItem.HtmlInputToOptionTag(SiteSiteTemplateOptionListSelectedValue);

            // Set Admin Style Item
            ListClass.AdminStyle lcas = new ListClass.AdminStyle();
            lcas.FillAdminStyleListItem();
            SiteAdminStyleOptionListValue += SiteAdminStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteAdminStyleOptionListValue += lcas.AdminStyleListItem.HtmlInputToOptionTag(SiteAdminStyleOptionListSelectedValue);

            // Set Admin Template Item
            ListClass.AdminTemplate lcat = new ListClass.AdminTemplate();
            lcat.FillAdminTemplateListItem();
            SiteAdminTemplateOptionListValue += SiteAdminTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteAdminTemplateOptionListValue += lcat.AdminTemplateListItem.HtmlInputToOptionTag(SiteAdminTemplateOptionListSelectedValue);

            ListClass.DateAndTime lcdat = new ListClass.DateAndTime();

            // Set Time Zone Item
            lcdat.FillTimeZoneListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteTimeZoneOptionListValue = SiteTimeZoneOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteTimeZoneOptionListValue += lcdat.TimeZoneListItem.HtmlInputToOptionTag(SiteTimeZoneOptionListSelectedValue);

            // Set Calendar Item
            lcdat.FillCalendarListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteCalendarOptionListValue += lcdat.CalendarListItem.HtmlInputToOptionTag(SiteCalendarOptionListSelectedValue, true);

            // Set Day Of Weak Item
            lcdat.FillDayOfWeakListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteFirstDayOfWeekOptionListValue = SiteFirstDayOfWeekOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteFirstDayOfWeekOptionListValue += lcdat.DayOfWeakListItem.HtmlInputToOptionTag(SiteFirstDayOfWeekOptionListSelectedValue);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Site Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/site/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_SiteAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            SiteAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            SiteAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.Replace("$_asp attribute;", SiteAccessShowAttribute);
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.Replace("$_asp css_class;", SiteAccessShowCssClass);
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(SiteAccessShowListItem);

            // Set Site Access Show Selected Value
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteAccessShowListItem(SiteIdValue);
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcs.SiteAccessShowListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_SiteName", "");
            InputRequest.Add("txt_SiteGlobalName", "");
            InputRequest.Add("txt_SiteSloganName", "");
            InputRequest.Add("txt_SiteTitle", "");
            InputRequest.Add("txt_SiteDateFormat", "");
            InputRequest.Add("txt_SiteTimeFormat", "");
            InputRequest.Add("txt_SiteAddress", "");
            InputRequest.Add("txt_SitePhoneNumber", "");
            InputRequest.Add("txt_SiteEmail", "");
            InputRequest.Add("txt_SiteActivities", "");
            InputRequest.Add("txt_SiteOtherInfo", "");
            InputRequest.Add("txt_SiteStaticHead", "");
            InputRequest.Add("txt_SiteDescriptionMeta", "");
            InputRequest.Add("txt_SiteRightsMeta", "");
            InputRequest.Add("txt_SiteKeywordsMeta", "");
            InputRequest.Add("txt_SiteClassificationMeta", "");
            InputRequest.Add("txt_SiteRevisitAfterMeta", "");
            InputRequest.Add("txt_SiteDateCreate", "");
            InputRequest.Add("txt_SiteTimeCreate", "");
            InputRequest.Add("txt_SiteVisit", "");
            InputRequest.Add("ddlst_SiteLanguage", SiteLanguageOptionListValue);
            InputRequest.Add("ddlst_SiteDefaultPage", SiteDefaultPageOptionListValue);
            InputRequest.Add("ddlst_SiteSiteStyle", SiteSiteStyleOptionListValue);
            InputRequest.Add("ddlst_SiteSiteTemplate", SiteSiteTemplateOptionListValue);
            InputRequest.Add("ddlst_SiteAdminStyle", SiteAdminStyleOptionListValue);
            InputRequest.Add("ddlst_SiteAdminTemplate", SiteAdminTemplateOptionListValue);
            InputRequest.Add("ddlst_SiteCalendar", SiteCalendarOptionListValue);
            InputRequest.Add("ddlst_SiteFirstDayOfWeek", SiteFirstDayOfWeekOptionListValue);
            InputRequest.Add("ddlst_SiteTimeZone", SiteTimeZoneOptionListValue);
            InputRequest.Add("cbxlst_SiteAccessShow", SiteAccessShowListValue);
            InputRequest.Add("cbxlst_SiteAccessShow", SiteAccessShowListValue);
            InputRequest.Add("hdn_SiteId", SiteIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/site/", "edit");

            SiteNameAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteName");
            SiteGlobalNameAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteGlobalName");
            SiteSloganNameAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteSloganName");
            SiteTitleAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteTitle");
            SiteDateFormatAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteDateFormat");
            SiteTimeFormatAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteTimeFormat");
            SiteAddressAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteAddress");
            SitePhoneNumberAttribute += vc.ImportantInputAttribute.GetValue("txt_SitePhoneNumber");
            SiteEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteEmail");
            SiteActivitiesAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteActivities");
            SiteOtherInfoAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteOtherInfo");
            SiteStaticHeadAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteStaticHead");
            SiteDescriptionMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteDescriptionMeta");
            SiteRightsMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteRightsMeta");
            SiteKeywordsMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteKeywordsMeta");
            SiteClassificationMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteClassificationMeta");
            SiteRevisitAfterMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteRevisitAfterMeta");
            SiteDateCreateAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteDateCreate");
            SiteTimeCreateAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteTimeCreate");
            SiteVisitAttribute += vc.ImportantInputAttribute.GetValue("txt_SiteVisit");
            SiteLanguageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteLanguage");
            SiteDefaultPageAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteDefaultPage");
            SiteSiteStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteSiteStyle");
            SiteSiteTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteSiteTemplate");
            SiteAdminStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteAdminStyle");
            SiteAdminTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteAdminTemplate");
            SiteCalendarAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteCalendar");
            SiteFirstDayOfWeekAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteFirstDayOfWeek");
            SiteTimeZoneAttribute += vc.ImportantInputAttribute.GetValue("ddlst_SiteTimeZone");
            SiteAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_SiteAccessShow");

            SiteNameCssClass = SiteNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteName"));
            SiteGlobalNameCssClass = SiteGlobalNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteGlobalName"));
            SiteSloganNameCssClass = SiteSloganNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteSloganName"));
            SiteTitleCssClass = SiteTitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteTitle"));
            SiteDateFormatCssClass = SiteDateFormatCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteDateFormat"));
            SiteTimeFormatCssClass = SiteTimeFormatCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteTimeFormat"));
            SiteAddressCssClass = SiteAddressCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteAddress"));
            SitePhoneNumberCssClass = SitePhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SitePhoneNumber"));
            SiteEmailCssClass = SiteEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteEmail"));
            SiteActivitiesCssClass = SiteActivitiesCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteActivities"));
            SiteOtherInfoCssClass = SiteOtherInfoCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteOtherInfo"));
            SiteStaticHeadCssClass = SiteStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteStaticHead"));
            SiteDescriptionMetaCssClass = SiteDescriptionMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteDescriptionMeta"));
            SiteRightsMetaCssClass = SiteRightsMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteRightsMeta"));
            SiteKeywordsMetaCssClass = SiteKeywordsMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteKeywordsMeta"));
            SiteClassificationMetaCssClass = SiteClassificationMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteClassificationMeta"));
            SiteRevisitAfterMetaCssClass = SiteRevisitAfterMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteRevisitAfterMeta"));
            SiteDateCreateCssClass = SiteDateCreateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteDateCreate"));
            SiteTimeCreateCssClass = SiteTimeCreateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteTimeCreate"));
            SiteVisitCssClass = SiteVisitCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SiteVisit"));
            SiteLanguageCssClass = SiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteLanguage"));
            SiteDefaultPageCssClass = SiteDefaultPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteDefaultPage"));
            SiteSiteStyleCssClass = SiteSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteSiteStyle"));
            SiteSiteTemplateCssClass = SiteSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteSiteTemplate"));
            SiteAdminStyleCssClass = SiteAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteAdminStyle"));
            SiteAdminTemplateCssClass = SiteAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteAdminTemplate"));
            SiteCalendarCssClass = SiteCalendarCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteCalendar"));
            SiteFirstDayOfWeekCssClass = SiteFirstDayOfWeekCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteFirstDayOfWeek"));
            SiteTimeZoneCssClass = SiteTimeZoneCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_SiteTimeZone"));
            SiteAccessShowCssClass = SiteAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_SiteAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/site/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveSite()
        {
            DataUse.Site dus = new DataUse.Site();

            // Set Current Value
            dus.FillCurrentSite(SiteIdValue);

            string CurrentSiteGlobalName = dus.SiteGlobalName;


            // Change Database Data
            dus.SiteId = SiteIdValue;
            dus.SiteName = SiteNameValue;
            dus.SiteGlobalName = SiteGlobalNameValue;
            dus.SiteSloganName = SiteSloganNameValue;
            dus.LanguageId = SiteLanguageOptionListSelectedValue;
            dus.PageId = SiteDefaultPageOptionListSelectedValue;
            dus.SiteTitle = SiteTitleValue;
            dus.SiteActive = SiteActiveValue.BooleanToZeroOne();
            dus.SiteShowLinkInSite = SiteShowLinkInSiteValue.BooleanToZeroOne();
            dus.SiteStyleId = SiteSiteStyleOptionListSelectedValue;
            dus.SiteTemplateId = SiteSiteTemplateOptionListSelectedValue;
            dus.AdminStyleId = SiteAdminStyleOptionListSelectedValue;
            dus.AdminTemplateId = SiteAdminTemplateOptionListSelectedValue;
            dus.SiteCalendar = SiteCalendarOptionListSelectedValue;
            dus.SiteFirstDayOfWeek = SiteFirstDayOfWeekOptionListSelectedValue;
            dus.SiteDateFormat = SiteDateFormatValue;
            dus.SiteTimeFormat = SiteTimeFormatValue;
            dus.SiteTimeZone = SiteTimeZoneOptionListSelectedValue;
            dus.SiteSiteActivities = SiteActivitiesValue;
            dus.SiteAddress = SiteAddressValue;
            dus.SitePhoneNumber = SitePhoneNumberValue;
            dus.SiteEmail = SiteEmailValue.ToLower();
            dus.SiteOtherInfo = SiteOtherInfoValue;
            dus.SiteStaticHead = SiteStaticHeadValue;
            dus.SiteUseDescriptionMeta = SiteUseDescriptionMetaValue.BooleanToZeroOne();
            dus.SiteDescriptionMeta = SiteDescriptionMetaValue;
            dus.SiteUseRevisitAfterMeta = SiteUseRevisitAfterMetaValue.BooleanToZeroOne();
            dus.SiteRevisitAfterMeta = SiteRevisitAfterMetaValue;
            dus.SiteUseRightsMeta = SiteUseRightsMetaValue.BooleanToZeroOne();
            dus.SiteRightsMeta = SiteRightsMetaValue;
            dus.SiteUseKeywordsMeta = SiteUseKeywordsMetaValue.BooleanToZeroOne();
            dus.SiteKeywordsMeta = SiteKeywordsMetaValue;
            dus.SiteUseClassificationMeta = SiteUseClassificationMetaValue.BooleanToZeroOne();
            dus.SiteClassificationMeta = SiteClassificationMetaValue;
            dus.SitePublicAccessShow = SitePublicAccessShowValue.BooleanToZeroOne();
            dus.SiteDateCreate = SiteDateCreateValue;
            dus.SiteTimeCreate = SiteTimeCreateValue;
            dus.SiteVisit = SiteVisitValue;

            // Edit Site
            dus.Edit();

            // Delete Site Access Show
            dus.DeleteSiteAccessShow(dus.SiteId);

            // Set Site Access Show
            dus.SetSiteAccessShow(dus.SiteId, SiteAccessShowListItem);


            // Change Site Data
            if (CurrentSiteGlobalName != dus.SiteGlobalName)
                Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + CurrentSiteGlobalName + "/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + dus.SiteGlobalName + "/"));

            if (ElanatConfig.GetElanatConfig("properties/default_site") == CurrentSiteGlobalName)
                ElanatConfig.SetElanatConfig(dus.SiteGlobalName, "properties/default_site", 0, "value");

            StaticObject.ApplicationStart();

            if (CurrentSiteGlobalName == "default")
            {
                if (dus.SiteGlobalName != "default")
                    File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/default.png"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + dus.SiteGlobalName + ".png"));
            }
            else
                File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + CurrentSiteGlobalName + ".png"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + dus.SiteGlobalName + ".png"));

            
            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_site", dus.SiteName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/site/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnSiteGlobalNameErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("site_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/")), "problem");
        }

        public void ExistValueToColumnSiteNameErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("site_global_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/")), "problem");
        }
    }
}