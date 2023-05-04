using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminSiteModel
    {
        public string AddLanguage { get; set; }
        public string SiteLanguage { get; set; }
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
        public string SitePublicAccessShowLanguage { get; set; }
        public string AddSiteLanguage { get; set; }
        public string RefreshLanguage { get; set; }

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

        public ListItemCollection SiteAccessShowListItem = new ListItemCollection();
        public string SiteAccessShowListValue { get; set; }
        public string SiteAccessShowTemplateValue { get; set; }

        public string SiteAccessShowAttribute { get; set; }
        public string SiteAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            SiteLanguage = aol.GetAddOnsLanguage("site");
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
            SiteAccessShowLanguage = aol.GetAddOnsLanguage("site_access_show");
            AddSiteLanguage = aol.GetAddOnsLanguage("add_site");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Language Item
            lc.FillLanguageListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteLanguageOptionListValue += SiteLanguageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteLanguageOptionListValue += lc.LanguageListItem.HtmlInputToOptionTag(SiteLanguageOptionListSelectedValue);

            // Set Page Item
            lc.FillPageListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteDefaultPageOptionListValue += SiteDefaultPageOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteDefaultPageOptionListValue += lc.PageListItem.HtmlInputToOptionTag(SiteDefaultPageOptionListSelectedValue);

            // Set Site Style Item
            lc.FillSiteStyleListItem();
            SiteSiteStyleOptionListValue += SiteSiteStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteSiteStyleOptionListValue += lc.SiteStyleListItem.HtmlInputToOptionTag(SiteSiteStyleOptionListSelectedValue);

            // Set Site Template Item
            lc.FillSiteTemplateListItem();
            SiteSiteTemplateOptionListValue += SiteSiteTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteSiteTemplateOptionListValue += lc.SiteTemplateListItem.HtmlInputToOptionTag(SiteSiteTemplateOptionListSelectedValue);

            // Set Admin Style Item
            lc.FillAdminStyleListItem();
            SiteAdminStyleOptionListValue += SiteAdminStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteAdminStyleOptionListValue += lc.AdminStyleListItem.HtmlInputToOptionTag(SiteAdminStyleOptionListSelectedValue);

            // Set Admin Template Item
            lc.FillAdminTemplateListItem();
            SiteAdminTemplateOptionListValue += SiteAdminTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteAdminTemplateOptionListValue += lc.AdminTemplateListItem.HtmlInputToOptionTag(SiteAdminTemplateOptionListSelectedValue);

            // Set Time Zone Item
            lc.FillTimeZoneListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteTimeZoneOptionListValue = SiteTimeZoneOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteTimeZoneOptionListValue += lc.TimeZoneListItem.HtmlInputToOptionTag(SiteTimeZoneOptionListSelectedValue);

            // Set Calendar Item
            lc.FillCalendarListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteCalendarOptionListValue += lc.CalendarListItem.HtmlInputToOptionTag(SiteCalendarOptionListSelectedValue, true);

            // Set Day Of Weak Item
            lc.FillDayOfWeakListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            SiteFirstDayOfWeekOptionListValue = SiteFirstDayOfWeekOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteFirstDayOfWeekOptionListValue += lc.DayOfWeakListItem.HtmlInputToOptionTag(SiteFirstDayOfWeekOptionListSelectedValue);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Site Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/site/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_SiteAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            SiteAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            SiteAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.Replace("$_asp attribute;", SiteAccessShowAttribute);
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.Replace("$_asp css_class;", SiteAccessShowCssClass);
            SiteAccessShowTemplateValue = SiteAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(SiteAccessShowListItem);


            // Set Site Page List
            ActionGetSiteListModel lm = new ActionGetSiteListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

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


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/site/");

            SiteNameAttribute += vc.ImportantInputAttribute["txt_SiteName"];
            SiteGlobalNameAttribute += vc.ImportantInputAttribute["txt_SiteGlobalName"];
            SiteSloganNameAttribute += vc.ImportantInputAttribute["txt_SiteSloganName"];
            SiteTitleAttribute += vc.ImportantInputAttribute["txt_SiteTitle"];
            SiteDateFormatAttribute += vc.ImportantInputAttribute["txt_SiteDateFormat"];
            SiteTimeFormatAttribute += vc.ImportantInputAttribute["txt_SiteTimeFormat"];
            SiteAddressAttribute += vc.ImportantInputAttribute["txt_SiteAddress"];
            SitePhoneNumberAttribute += vc.ImportantInputAttribute["txt_SitePhoneNumber"];
            SiteEmailAttribute += vc.ImportantInputAttribute["txt_SiteEmail"];
            SiteActivitiesAttribute += vc.ImportantInputAttribute["txt_SiteActivities"];
            SiteOtherInfoAttribute += vc.ImportantInputAttribute["txt_SiteOtherInfo"];
            SiteStaticHeadAttribute += vc.ImportantInputAttribute["txt_SiteStaticHead"];
            SiteDescriptionMetaAttribute += vc.ImportantInputAttribute["txt_SiteDescriptionMeta"];
            SiteRightsMetaAttribute += vc.ImportantInputAttribute["txt_SiteRightsMeta"];
            SiteKeywordsMetaAttribute += vc.ImportantInputAttribute["txt_SiteKeywordsMeta"];
            SiteClassificationMetaAttribute += vc.ImportantInputAttribute["txt_SiteClassificationMeta"];
            SiteRevisitAfterMetaAttribute += vc.ImportantInputAttribute["txt_SiteRevisitAfterMeta"];
            SiteLanguageAttribute += vc.ImportantInputAttribute["ddlst_SiteLanguage"];
            SiteDefaultPageAttribute += vc.ImportantInputAttribute["ddlst_SiteDefaultPage"];
            SiteSiteStyleAttribute += vc.ImportantInputAttribute["ddlst_SiteSiteStyle"];
            SiteSiteTemplateAttribute += vc.ImportantInputAttribute["ddlst_SiteSiteTemplate"];
            SiteAdminStyleAttribute += vc.ImportantInputAttribute["ddlst_SiteAdminStyle"];
            SiteAdminTemplateAttribute += vc.ImportantInputAttribute["ddlst_SiteAdminTemplate"];
            SiteCalendarAttribute += vc.ImportantInputAttribute["ddlst_SiteCalendar"];
            SiteFirstDayOfWeekAttribute += vc.ImportantInputAttribute["ddlst_SiteFirstDayOfWeek"];
            SiteTimeZoneAttribute += vc.ImportantInputAttribute["ddlst_SiteTimeZone"];
            SiteAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_SiteAccessShow"];

            SiteNameCssClass = SiteNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteName"]);
            SiteGlobalNameCssClass = SiteGlobalNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteGlobalName"]);
            SiteSloganNameCssClass = SiteSloganNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteSloganName"]);
            SiteTitleCssClass = SiteTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteTitle"]);
            SiteDateFormatCssClass = SiteDateFormatCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteDateFormat"]);
            SiteTimeFormatCssClass = SiteTimeFormatCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteTimeFormat"]);
            SiteAddressCssClass = SiteAddressCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteAddress"]);
            SitePhoneNumberCssClass = SitePhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SitePhoneNumber"]);
            SiteEmailCssClass = SiteEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteEmail"]);
            SiteActivitiesCssClass = SiteActivitiesCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteActivities"]);
            SiteOtherInfoCssClass = SiteOtherInfoCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteOtherInfo"]);
            SiteStaticHeadCssClass = SiteStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteStaticHead"]);
            SiteDescriptionMetaCssClass = SiteDescriptionMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteDescriptionMeta"]);
            SiteRightsMetaCssClass = SiteRightsMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteRightsMeta"]);
            SiteKeywordsMetaCssClass = SiteKeywordsMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteKeywordsMeta"]);
            SiteClassificationMetaCssClass = SiteClassificationMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteClassificationMeta"]);
            SiteRevisitAfterMetaCssClass = SiteRevisitAfterMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SiteRevisitAfterMeta"]);
            SiteLanguageCssClass = SiteLanguageCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteLanguage"]);
            SiteDefaultPageCssClass = SiteDefaultPageCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteDefaultPage"]);
            SiteSiteStyleCssClass = SiteSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteSiteStyle"]);
            SiteSiteTemplateCssClass = SiteSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteSiteTemplate"]);
            SiteAdminStyleCssClass = SiteAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteAdminStyle"]);
            SiteAdminTemplateCssClass = SiteAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteAdminTemplate"]);
            SiteCalendarCssClass = SiteCalendarCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteCalendar"]);
            SiteFirstDayOfWeekCssClass = SiteFirstDayOfWeekCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteFirstDayOfWeek"]);
            SiteTimeZoneCssClass = SiteTimeZoneCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SiteTimeZone"]);
            SiteAccessShowCssClass = SiteAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_SiteAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/site/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //SiteNameCssClass = SiteNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteName"]);
                //SiteGlobalNameCssClass = SiteGlobalNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteGlobalName"]);
                //SiteSloganNameCssClass = SiteSloganNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteSloganName"]);
                //SiteTitleCssClass = SiteTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteTitle"]);
                //SiteDateFormatCssClass = SiteDateFormatCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteDateFormat"]);
                //SiteTimeFormatCssClass = SiteTimeFormatCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteTimeFormat"]);
                //SiteAddressCssClass = SiteAddressCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteAddress"]);
                //SitePhoneNumberCssClass = SitePhoneNumberCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SitePhoneNumber"]);
                //SiteEmailCssClass = SiteEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteEmail"]);
                //SiteActivitiesCssClass = SiteActivitiesCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteActivities"]);
                //SiteOtherInfoCssClass = SiteOtherInfoCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteOtherInfo"]);
                //SiteStaticHeadCssClass = SiteStaticHeadCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteStaticHead"]);
                //SiteDescriptionMetaCssClass = SiteDescriptionMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteDescriptionMeta"]);
                //SiteRightsMetaCssClass = SiteRightsMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteRightsMeta"]);
                //SiteKeywordsMetaCssClass = SiteKeywordsMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteKeywordsMeta"]);
                //SiteClassificationMetaCssClass = SiteClassificationMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteClassificationMeta"]);
                //SiteRevisitAfterMetaCssClass = SiteRevisitAfterMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SiteRevisitAfterMeta"]);
                //SiteLanguageCssClass = SiteLanguageCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteLanguage"]);
                //SiteDefaultPageCssClass = SiteDefaultPageCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteDefaultPage"]);
                //SiteSiteStyleCssClass = SiteSiteStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteSiteStyle"]);
                //SiteSiteTemplateCssClass = SiteSiteTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteSiteTemplate"]);
                //SiteAdminStyleCssClass = SiteAdminStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteAdminStyle"]);
                //SiteAdminTemplateCssClass = SiteAdminTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteAdminTemplate"]);
                //SiteCalendarCssClass = SiteCalendarCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteCalendar"]);
                //SiteFirstDayOfWeekCssClass = SiteFirstDayOfWeekCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteFirstDayOfWeek"]);
                //SiteTimeZoneCssClass = SiteTimeZoneCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SiteTimeZone"]);
                //SiteAccessShowCssClass = SiteAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_SiteAccessShow"]);
            }
        }

        public void AddSite()
        {
            // Add Data To Database
            DataUse.Site dus = new DataUse.Site();

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
            dus.SiteDateCreate = DateAndTime.GetDate("yyyy/MM/dd");
            dus.SiteTimeCreate = DateAndTime.GetTime("HH:mm:ss");
            dus.SiteVisit = "0";

            // Add Site
            dus.AddWithFillReturnDr();

            // Set Site Access Show
            dus.SetSiteAccessShow(dus.SiteId, SiteAccessShowListItem);


            // Create Site Data
            FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/site_data/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + dus.SiteGlobalName + "/"), true);

            System.IO.File.Copy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/image/site_logo/default.png"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/image/site_logo/" + dus.SiteGlobalName + ".png"));


            try { dus.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_site", dus.SiteGlobalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("site_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site/"), "success", false, StaticObject.AdminPath + "/site/action/SiteNewRow.aspx?site_id=" + dus.SiteId, "div_TableBox");
        }
    }
}