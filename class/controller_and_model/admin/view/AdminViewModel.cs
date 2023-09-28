using CodeBehind;

namespace Elanat
{
    public partial class AdminViewModel : CodeBehindModel
    {
        public string ViewLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddViewLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string ViewNameLanguage { get; set; }
        public string ViewQueryStringLanguage { get; set; }
        public string ViewActiveLanguage { get; set; }
        public string ViewBackgroundColorLanguage { get; set; }
        public string ViewFontSizeLanguage { get; set; }
        public string ViewFillAfterContentLanguage { get; set; }
        public string ViewFillAfterHeaderLanguage { get; set; }
        public string ViewFillBeforeFooterLanguage { get; set; }
        public string ViewFillBeforeContentLanguage { get; set; }
        public string ViewFillFooter1Language { get; set; }
        public string ViewFillFooter2Language { get; set; }
        public string ViewFillFooterBarBoxLanguage { get; set; }
        public string ViewFillFooterBarLeftLanguage { get; set; }
        public string ViewFillFooterBarRightLanguage { get; set; }
        public string ViewFillFooterMenuLanguage { get; set; }
        public string ViewFillHeader1Language { get; set; }
        public string ViewFillHeader2Language { get; set; }
        public string ViewFillHeaderBarBoxLanguage { get; set; }
        public string ViewFillHeaderBarLeftLanguage { get; set; }
        public string ViewFillHeaderBarRightLanguage { get; set; }
        public string ViewFillHeaderMenuLanguage { get; set; }
        public string ViewFillLeftMenuLanguage { get; set; }
        public string ViewFillMenuLanguage { get; set; }
        public string ViewFillRightMenuLanguage { get; set; }
        public string ViewIncludeFooterBarPartLanguage { get; set; }
        public string ViewIncludeFooterPartLanguage { get; set; }
        public string ViewIncludeHeaderBarPartLanguage { get; set; }
        public string ViewIncludeHeaderPartLanguage { get; set; }
        public string ViewIncludeMainPartLanguage { get; set; }
        public string ViewIncludeMenuPartLanguage { get; set; }
        public string ViewShowAfterContentLanguage { get; set; }
        public string ViewShowAfterHeaderLanguage { get; set; }
        public string ViewShowBeforeFooterLanguage { get; set; }
        public string ViewShowBeforeContentLanguage { get; set; }
        public string ViewShowFooter1Language { get; set; }
        public string ViewShowFooter2Language { get; set; }
        public string ViewShowFooterBarBoxLanguage { get; set; }
        public string ViewShowFooterBarLeftLanguage { get; set; }
        public string ViewShowFooterBarRightLanguage { get; set; }
        public string ViewShowFooterMenuLanguage { get; set; }
        public string ViewShowHeader1Language { get; set; }
        public string ViewShowHeader2Language { get; set; }
        public string ViewShowHeaderBarBoxLanguage { get; set; }
        public string ViewShowHeaderBarLeftLanguage { get; set; }
        public string ViewShowHeaderBarRightLanguage { get; set; }
        public string ViewShowHeaderMenuLanguage { get; set; }
        public string ViewShowLeftMenuLanguage { get; set; }
        public string ViewShowMenuLanguage { get; set; }
        public string ViewShowRightMenuLanguage { get; set; }
        public string ViewCommonDarkBackgroundColorLanguage { get; set; }
        public string ViewCommonDarkTextColorLanguage { get; set; }
        public string ViewCommonLightBackgroundColorLanguage { get; set; }
        public string ViewCommonLightTextColorLanguage { get; set; }
        public string ViewCommonMiddleBackgroundColorLanguage { get; set; }
        public string ViewCommonMiddleTextColorLanguage { get; set; }
        public string ViewMatchTypeLanguage { get; set; }
        public string ViewNaturalDarkBackgroundColorLanguage { get; set; }
        public string ViewNaturalDarkTextColorLanguage { get; set; }
        public string ViewNaturalLightBackgroundColorLanguage { get; set; }
        public string ViewNaturalLightTextColorLanguage { get; set; }
        public string ViewNaturalMiddleBackgroundColorLanguage { get; set; }
        public string ViewNaturalMiddleTextColorLanguage { get; set; }
        public string ViewStaticHeadLanguage { get; set; }
        public string ViewSiteStyleLanguage { get; set; }
        public string ViewSiteTemplateLanguage { get; set; }

        public bool ViewIncludeHeaderBarPartValue { get; set; } = true;
        public bool ViewShowHeaderBarLeftValue { get; set; } = true;
        public bool ViewShowHeaderBarRightValue { get; set; } = true;
        public bool ViewShowHeaderBarBoxValue { get; set; } = true;
        public bool ViewFillHeaderBarLeftValue { get; set; } = true;
        public bool ViewFillHeaderBarRightValue { get; set; } = true;
        public bool ViewFillHeaderBarBoxValue { get; set; } = true;
        public bool ViewIncludeHeaderPartValue { get; set; } = true;
        public bool ViewShowHeaderMenuValue { get; set; } = true;
        public bool ViewShowHeader1Value { get; set; } = true;
        public bool ViewShowHeader2Value { get; set; } = true;
        public bool ViewFillHeaderMenuValue { get; set; } = true;
        public bool ViewFillHeader1Value { get; set; } = true;
        public bool ViewFillHeader2Value { get; set; } = true;
        public bool ViewIncludeMenuPartValue { get; set; } = true;
        public bool ViewShowMenuValue { get; set; } = true;
        public bool ViewFillMenuValue { get; set; } = true;
        public bool ViewIncludeMainPartValue { get; set; } = true;
        public bool ViewShowAfterHeaderValue { get; set; } = true;
        public bool ViewShowBeforeContentValue { get; set; } = true;
        public bool ViewShowAfterContentValue { get; set; } = true;
        public bool ViewShowLeftMenuValue { get; set; } = true;
        public bool ViewShowRightMenuValue { get; set; } = true;
        public bool ViewShowBeforeFooterValue { get; set; } = true;
        public bool ViewFillAfterHeaderValue { get; set; } = true;
        public bool ViewFillBeforeContentValue { get; set; } = true;
        public bool ViewFillAfterContentValue { get; set; } = true;
        public bool ViewFillLeftMenuValue { get; set; } = true;
        public bool ViewFillRightMenuValue { get; set; } = true;
        public bool ViewFillBeforeFooterValue { get; set; } = true;
        public bool ViewIncludeFooterPartValue { get; set; } = true;
        public bool ViewShowFooterMenuValue { get; set; } = true;
        public bool ViewShowFooter1Value { get; set; } = true;
        public bool ViewShowFooter2Value { get; set; } = true;
        public bool ViewFillFooterMenuValue { get; set; } = true;
        public bool ViewFillFooter1Value { get; set; } = true;
        public bool ViewFillFooter2Value { get; set; } = true;
        public bool ViewIncludeFooterBarPartValue { get; set; } = true;
        public bool ViewShowFooterBarLeftValue { get; set; } = true;
        public bool ViewShowFooterBarRightValue { get; set; } = true;
        public bool ViewShowFooterBarBoxValue { get; set; } = true;
        public bool ViewFillFooterBarLeftValue { get; set; } = true;
        public bool ViewFillFooterBarRightValue { get; set; } = true;
        public bool ViewFillFooterBarBoxValue { get; set; } = true;
        public bool ViewActiveValue { get; set; } = false;

        public string ViewMatchTypeOptionListValue { get; set; }
        public string ViewMatchTypeOptionListSelectedValue { get; set; }
        public string ViewSiteStyleOptionListValue { get; set; }
        public string ViewSiteStyleOptionListSelectedValue { get; set; }
        public string ViewSiteTemplateOptionListValue { get; set; }
        public string ViewSiteTemplateOptionListSelectedValue { get; set; }

        public string ViewNameValue { get; set; } = "";
        public string ViewQueryStringValue { get; set; } = "";
        public string ViewBackgroundColorValue { get; set; } = "";
        public string ViewFontSizeValue { get; set; } = "";
        public string ViewCommonLightTextColorValue { get; set; } = "";
        public string ViewCommonMiddleTextColorValue { get; set; } = "";
        public string ViewCommonDarkTextColorValue { get; set; } = "";
        public string ViewNaturalLightTextColorValue { get; set; } = "";
        public string ViewNaturalMiddleTextColorValue { get; set; } = "";
        public string ViewNaturalDarkTextColorValue { get; set; } = "";
        public string ViewCommonLightBackgroundColorValue { get; set; } = "";
        public string ViewCommonMiddleBackgroundColorValue { get; set; } = "";
        public string ViewCommonDarkBackgroundColorValue { get; set; } = "";
        public string ViewNaturalLightBackgroundColorValue { get; set; } = "";
        public string ViewNaturalMiddleBackgroundColorValue { get; set; } = "";
        public string ViewNaturalDarkBackgroundColorValue { get; set; } = "";
        public string ViewStaticHeadValue { get; set; } = "";

        public string ViewNameCssClass { get; set; }
        public string ViewQueryStringCssClass { get; set; }
        public string ViewBackgroundColorCssClass { get; set; }
        public string ViewFontSizeCssClass { get; set; }
        public string ViewCommonLightTextColorCssClass { get; set; }
        public string ViewCommonMiddleTextColorCssClass { get; set; }
        public string ViewCommonDarkTextColorCssClass { get; set; }
        public string ViewNaturalLightTextColorCssClass { get; set; }
        public string ViewNaturalMiddleTextColorCssClass { get; set; }
        public string ViewNaturalDarkTextColorCssClass { get; set; }
        public string ViewCommonLightBackgroundColorCssClass { get; set; }
        public string ViewCommonMiddleBackgroundColorCssClass { get; set; }
        public string ViewCommonDarkBackgroundColorCssClass { get; set; }
        public string ViewNaturalLightBackgroundColorCssClass { get; set; }
        public string ViewNaturalMiddleBackgroundColorCssClass { get; set; }
        public string ViewNaturalDarkBackgroundColorCssClass { get; set; }
        public string ViewStaticHeadCssClass { get; set; }
        public string ViewMatchTypeCssClass { get; set; }
        public string ViewSiteStyleCssClass { get; set; }
        public string ViewSiteTemplateCssClass { get; set; }

        public string ViewNameAttribute { get; set; }
        public string ViewQueryStringAttribute { get; set; }
        public string ViewBackgroundColorAttribute { get; set; }
        public string ViewFontSizeAttribute { get; set; }
        public string ViewCommonLightTextColorAttribute { get; set; }
        public string ViewCommonMiddleTextColorAttribute { get; set; }
        public string ViewCommonDarkTextColorAttribute { get; set; }
        public string ViewNaturalLightTextColorAttribute { get; set; }
        public string ViewNaturalMiddleTextColorAttribute { get; set; }
        public string ViewNaturalDarkTextColorAttribute { get; set; }
        public string ViewCommonLightBackgroundColorAttribute { get; set; }
        public string ViewCommonMiddleBackgroundColorAttribute { get; set; }
        public string ViewCommonDarkBackgroundColorAttribute { get; set; }
        public string ViewNaturalLightBackgroundColorAttribute { get; set; }
        public string ViewNaturalMiddleBackgroundColorAttribute { get; set; }
        public string ViewNaturalDarkBackgroundColorAttribute { get; set; }
        public string ViewStaticHeadAttribute { get; set; }
        public string ViewMatchTypeAttribute { get; set; }
        public string ViewSiteStyleAttribute { get; set; }
        public string ViewSiteTemplateAttribute { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/view/");
            ViewLanguage = aol.GetAddOnsLanguage("view");
            AddLanguage = aol.GetAddOnsLanguage("add");
            AddViewLanguage = aol.GetAddOnsLanguage("add_view");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());
            ViewNameLanguage = aol.GetAddOnsLanguage("view_name");
            ViewQueryStringLanguage = aol.GetAddOnsLanguage("view_query_string");
            ViewActiveLanguage = aol.GetAddOnsLanguage("view_active");
            ViewBackgroundColorLanguage = aol.GetAddOnsLanguage("view_background_color");
            ViewFontSizeLanguage = aol.GetAddOnsLanguage("view_font_size");
            ViewFillAfterContentLanguage = aol.GetAddOnsLanguage("view_fill_after_content");
            ViewFillAfterHeaderLanguage = aol.GetAddOnsLanguage("view_fill_after_header");
            ViewFillBeforeFooterLanguage = aol.GetAddOnsLanguage("view_fill_before_footer");
            ViewFillBeforeContentLanguage = aol.GetAddOnsLanguage("view_fill_before_content");
            ViewFillFooter1Language = aol.GetAddOnsLanguage("view_fill_footer1");
            ViewFillFooter2Language = aol.GetAddOnsLanguage("view_fill_footer2");
            ViewFillFooterBarBoxLanguage = aol.GetAddOnsLanguage("view_fill_footer_bar_box");
            ViewFillFooterBarLeftLanguage = aol.GetAddOnsLanguage("view_fill_footer_bar_left");
            ViewFillFooterBarRightLanguage = aol.GetAddOnsLanguage("view_fill_footer_bar_right");
            ViewFillFooterMenuLanguage = aol.GetAddOnsLanguage("view_fill_footer_menu");
            ViewFillHeader1Language = aol.GetAddOnsLanguage("view_fill_header1");
            ViewFillHeader2Language = aol.GetAddOnsLanguage("view_fill_header2");
            ViewFillHeaderBarBoxLanguage = aol.GetAddOnsLanguage("view_fill_header_bar_box");
            ViewFillHeaderBarLeftLanguage = aol.GetAddOnsLanguage("view_fill_header_bar_left");
            ViewFillHeaderBarRightLanguage = aol.GetAddOnsLanguage("view_fill_header_bar_right");
            ViewFillHeaderMenuLanguage = aol.GetAddOnsLanguage("view_fill_header_menu");
            ViewFillLeftMenuLanguage = aol.GetAddOnsLanguage("view_fill_left_menu");
            ViewFillMenuLanguage = aol.GetAddOnsLanguage("view_fill_menu");
            ViewFillRightMenuLanguage = aol.GetAddOnsLanguage("view_fill_right_menu");
            ViewIncludeFooterBarPartLanguage = aol.GetAddOnsLanguage("view_include_footer_bar_part");
            ViewIncludeFooterPartLanguage = aol.GetAddOnsLanguage("view_include_footer_part");
            ViewIncludeHeaderBarPartLanguage = aol.GetAddOnsLanguage("view_include_header_bar_part");
            ViewIncludeHeaderPartLanguage = aol.GetAddOnsLanguage("view_include_header_part");
            ViewIncludeMainPartLanguage = aol.GetAddOnsLanguage("view_include_main_part");
            ViewIncludeMenuPartLanguage = aol.GetAddOnsLanguage("view_include_menu_part");
            ViewShowAfterContentLanguage = aol.GetAddOnsLanguage("view_show_after_content");
            ViewShowAfterHeaderLanguage = aol.GetAddOnsLanguage("view_show_after_header");
            ViewShowBeforeFooterLanguage = aol.GetAddOnsLanguage("view_show_before_footer");
            ViewShowBeforeContentLanguage = aol.GetAddOnsLanguage("view_show_before_content");
            ViewShowFooter1Language = aol.GetAddOnsLanguage("view_show_footer1");
            ViewShowFooter2Language = aol.GetAddOnsLanguage("view_show_footer2");
            ViewShowFooterBarBoxLanguage = aol.GetAddOnsLanguage("view_show_footer_bar_box");
            ViewShowFooterBarLeftLanguage = aol.GetAddOnsLanguage("view_show_footer_bar_left");
            ViewShowFooterBarRightLanguage = aol.GetAddOnsLanguage("view_show_footer_bar_right");
            ViewShowFooterMenuLanguage = aol.GetAddOnsLanguage("view_show_footer_menu");
            ViewShowHeader1Language = aol.GetAddOnsLanguage("view_show_header1");
            ViewShowHeader2Language = aol.GetAddOnsLanguage("view_show_header2");
            ViewShowHeaderBarBoxLanguage = aol.GetAddOnsLanguage("view_show_header_bar_box");
            ViewShowHeaderBarLeftLanguage = aol.GetAddOnsLanguage("view_show_header_bar_left");
            ViewShowHeaderBarRightLanguage = aol.GetAddOnsLanguage("view_show_header_bar_right");
            ViewShowHeaderMenuLanguage = aol.GetAddOnsLanguage("view_show_header_menu");
            ViewShowLeftMenuLanguage = aol.GetAddOnsLanguage("view_show_left_menu");
            ViewShowMenuLanguage = aol.GetAddOnsLanguage("view_show_menu");
            ViewShowRightMenuLanguage = aol.GetAddOnsLanguage("view_show_right_menu");
            ViewCommonDarkBackgroundColorLanguage = aol.GetAddOnsLanguage("view_common_dark_background_color");
            ViewCommonDarkTextColorLanguage = aol.GetAddOnsLanguage("view_common_dark_text_color");
            ViewCommonLightBackgroundColorLanguage = aol.GetAddOnsLanguage("view_common_light_background_color");
            ViewCommonLightTextColorLanguage = aol.GetAddOnsLanguage("view_common_light_text_color");
            ViewCommonMiddleBackgroundColorLanguage = aol.GetAddOnsLanguage("view_common_middle_background_color");
            ViewCommonMiddleTextColorLanguage = aol.GetAddOnsLanguage("view_common_middle_text_color");
            ViewMatchTypeLanguage = aol.GetAddOnsLanguage("view_match_type");
            ViewNaturalDarkBackgroundColorLanguage = aol.GetAddOnsLanguage("view_natural_dark_background_color");
            ViewNaturalDarkTextColorLanguage = aol.GetAddOnsLanguage("view_natural_dark_text_color");
            ViewNaturalLightBackgroundColorLanguage = aol.GetAddOnsLanguage("view_natural_light_background_color");
            ViewNaturalLightTextColorLanguage = aol.GetAddOnsLanguage("view_natural_light_text_color");
            ViewNaturalMiddleBackgroundColorLanguage = aol.GetAddOnsLanguage("view_natural_middle_background_color");
            ViewNaturalMiddleTextColorLanguage = aol.GetAddOnsLanguage("view_natural_middle_text_color");
            ViewStaticHeadLanguage = aol.GetAddOnsLanguage("view_static_head");
            ViewSiteStyleLanguage = aol.GetAddOnsLanguage("view_site_style");
            ViewSiteTemplateLanguage = aol.GetAddOnsLanguage("view_site_template");


            // Set View Match Type Item
            ListClass.View lcv = new ListClass.View();
            lcv.FillViewMatchTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ViewMatchTypeOptionListValue += lcv.ViewMatchTypeListItem.HtmlInputToOptionTag(ViewMatchTypeOptionListSelectedValue);

            // Set Site Style Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleListItem();
            ViewSiteStyleOptionListValue += ViewSiteStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            ViewSiteStyleOptionListValue += lcss.SiteStyleListItem.HtmlInputToOptionTag(ViewSiteStyleOptionListSelectedValue);

            // Set Site Template Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateListItem();
            ViewSiteTemplateOptionListValue += ViewSiteTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            ViewSiteTemplateOptionListValue += lcst.SiteTemplateListItem.HtmlInputToOptionTag(ViewSiteTemplateOptionListSelectedValue);


            ViewFontSizeValue = "99";


            // Set View Page List
            ActionGetViewListModel lm = new ActionGetViewListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ViewName", "");
            InputRequest.Add("txt_ViewQueryString", "");
            InputRequest.Add("txt_ViewBackgroundColor", "");
            InputRequest.Add("txt_ViewFontSize", "");
            InputRequest.Add("txt_ViewCommonLightTextColor", "");
            InputRequest.Add("txt_ViewCommonMiddleTextColor", "");
            InputRequest.Add("txt_ViewCommonDarkTextColor", "");
            InputRequest.Add("txt_ViewNaturalLightTextColor", "");
            InputRequest.Add("txt_ViewNaturalMiddleTextColor", "");
            InputRequest.Add("txt_ViewNaturalDarkTextColor", "");
            InputRequest.Add("txt_ViewCommonLightBackgroundColor", "");
            InputRequest.Add("txt_ViewCommonMiddleBackgroundColor", "");
            InputRequest.Add("txt_ViewCommonDarkBackgroundColor", "");
            InputRequest.Add("txt_ViewNaturalLightBackgroundColor", "");
            InputRequest.Add("txt_ViewNaturalMiddleBackgroundColor", "");
            InputRequest.Add("txt_ViewNaturalDarkBackgroundColor", "");
            InputRequest.Add("txt_ViewStaticHead", "");
            InputRequest.Add("ddlst_ViewMatchType", ViewMatchTypeOptionListValue);
            InputRequest.Add("ddlst_ViewSiteStyle", ViewSiteStyleOptionListValue);
            InputRequest.Add("ddlst_ViewSiteTemplate", ViewSiteTemplateOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/view/");

            ViewNameAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewName");
            ViewQueryStringAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewQueryString");
            ViewBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewBackgroundColor");
            ViewFontSizeAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewFontSize");
            ViewCommonLightTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonLightTextColor");
            ViewCommonMiddleTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonMiddleTextColor");
            ViewCommonDarkTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonDarkTextColor");
            ViewNaturalLightTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalLightTextColor");
            ViewNaturalMiddleTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalMiddleTextColor");
            ViewNaturalDarkTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalDarkTextColor");
            ViewCommonLightBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonLightBackgroundColor");
            ViewCommonMiddleBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonMiddleBackgroundColor");
            ViewCommonDarkBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewCommonDarkBackgroundColor");
            ViewNaturalLightBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalLightBackgroundColor");
            ViewNaturalMiddleBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalMiddleBackgroundColor");
            ViewNaturalDarkBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewNaturalDarkBackgroundColor");
            ViewStaticHeadAttribute += vc.ImportantInputAttribute.GetValue("txt_ViewStaticHead");
            ViewMatchTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ViewMatchType");
            ViewSiteStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ViewSiteStyle");
            ViewSiteTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ViewSiteTemplate");

            ViewNameCssClass = ViewNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewName"));
            ViewQueryStringCssClass = ViewQueryStringCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewQueryString"));
            ViewBackgroundColorCssClass = ViewBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewBackgroundColor"));
            ViewFontSizeCssClass = ViewFontSizeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewFontSize"));
            ViewCommonLightTextColorCssClass = ViewCommonLightTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonLightTextColor"));
            ViewCommonMiddleTextColorCssClass = ViewCommonMiddleTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonMiddleTextColor"));
            ViewCommonDarkTextColorCssClass = ViewCommonDarkTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonDarkTextColor"));
            ViewNaturalLightTextColorCssClass = ViewNaturalLightTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalLightTextColor"));
            ViewNaturalMiddleTextColorCssClass = ViewNaturalMiddleTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalMiddleTextColor"));
            ViewNaturalDarkTextColorCssClass = ViewNaturalDarkTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalDarkTextColor"));
            ViewCommonLightBackgroundColorCssClass = ViewCommonLightBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonLightBackgroundColor"));
            ViewCommonMiddleBackgroundColorCssClass = ViewCommonMiddleBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonMiddleBackgroundColor"));
            ViewCommonDarkBackgroundColorCssClass = ViewCommonDarkBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewCommonDarkBackgroundColor"));
            ViewNaturalLightBackgroundColorCssClass = ViewNaturalLightBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalLightBackgroundColor"));
            ViewNaturalMiddleBackgroundColorCssClass = ViewNaturalMiddleBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalMiddleBackgroundColor"));
            ViewNaturalDarkBackgroundColorCssClass = ViewNaturalDarkBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewNaturalDarkBackgroundColor"));
            ViewStaticHeadCssClass = ViewStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ViewStaticHead"));
            ViewMatchTypeCssClass = ViewMatchTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ViewMatchType"));
            ViewSiteStyleCssClass = ViewSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ViewSiteStyle"));
            ViewSiteTemplateCssClass = ViewSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ViewSiteTemplate"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/view/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddView()
        {
            // Add Data To Database
            DataUse.View duv = new DataUse.View();

            duv.ViewName = ViewNameValue;
            duv.ViewFillAfterContent = ViewFillAfterContentValue.BooleanToZeroOne();
            duv.ViewFillAfterHeader = ViewFillAfterHeaderValue.BooleanToZeroOne();
            duv.ViewFillBeforeFooter = ViewFillBeforeFooterValue.BooleanToZeroOne();
            duv.ViewFillBeforeContent = ViewFillBeforeContentValue.BooleanToZeroOne();
            duv.ViewFillFooter1 = ViewFillFooter1Value.BooleanToZeroOne();
            duv.ViewFillFooter2 = ViewFillFooter2Value.BooleanToZeroOne();
            duv.ViewFillFooterBarBox = ViewFillFooterBarBoxValue.BooleanToZeroOne();
            duv.ViewFillFooterBarLeft = ViewFillFooterBarLeftValue.BooleanToZeroOne();
            duv.ViewFillFooterBarRight = ViewFillFooterBarRightValue.BooleanToZeroOne();
            duv.ViewFillFooterMenu = ViewFillFooterMenuValue.BooleanToZeroOne();
            duv.ViewFillHeader1 = ViewFillHeader1Value.BooleanToZeroOne();
            duv.ViewFillHeader2 = ViewFillHeader2Value.BooleanToZeroOne();
            duv.ViewFillHeaderBarBox = ViewFillHeaderBarBoxValue.BooleanToZeroOne();
            duv.ViewFillHeaderBarLeft = ViewFillHeaderBarLeftValue.BooleanToZeroOne();
            duv.ViewFillHeaderBarRight = ViewFillHeaderBarRightValue.BooleanToZeroOne();
            duv.ViewFillHeaderMenu = ViewFillHeaderMenuValue.BooleanToZeroOne();
            duv.ViewFillLeftMenu = ViewFillLeftMenuValue.BooleanToZeroOne();
            duv.ViewFillMenu = ViewFillMenuValue.BooleanToZeroOne();
            duv.ViewFillRightMenu = ViewFillRightMenuValue.BooleanToZeroOne();
            duv.ViewIncludeFooterBarPart = ViewIncludeFooterBarPartValue.BooleanToZeroOne();
            duv.ViewIncludeFooterPart = ViewIncludeFooterPartValue.BooleanToZeroOne();
            duv.ViewIncludeHeaderBarPart = ViewIncludeHeaderBarPartValue.BooleanToZeroOne();
            duv.ViewIncludeHeaderPart = ViewIncludeHeaderPartValue.BooleanToZeroOne();
            duv.ViewIncludeMainPart = ViewIncludeMainPartValue.BooleanToZeroOne();
            duv.ViewIncludeMenuPart = ViewIncludeMenuPartValue.BooleanToZeroOne();
            duv.ViewShowAfterContent = ViewShowAfterContentValue.BooleanToZeroOne();
            duv.ViewShowAfterHeader = ViewShowAfterHeaderValue.BooleanToZeroOne();
            duv.ViewShowBeforeFooter = ViewShowBeforeFooterValue.BooleanToZeroOne();
            duv.ViewShowBeforeContent = ViewShowBeforeContentValue.BooleanToZeroOne();
            duv.ViewShowFooter1 = ViewShowFooter1Value.BooleanToZeroOne();
            duv.ViewShowFooter2 = ViewShowFooter2Value.BooleanToZeroOne();
            duv.ViewShowFooterBarBox = ViewShowFooterBarBoxValue.BooleanToZeroOne();
            duv.ViewShowFooterBarLeft = ViewShowFooterBarLeftValue.BooleanToZeroOne();
            duv.ViewShowFooterBarRight = ViewShowFooterBarRightValue.BooleanToZeroOne();
            duv.ViewShowFooterMenu = ViewShowFooterMenuValue.BooleanToZeroOne();
            duv.ViewShowHeader1 = ViewShowHeader1Value.BooleanToZeroOne();
            duv.ViewShowHeader2 = ViewShowHeader2Value.BooleanToZeroOne();
            duv.ViewShowHeaderBarBox = ViewShowHeaderBarBoxValue.BooleanToZeroOne();
            duv.ViewShowHeaderBarLeft = ViewShowHeaderBarLeftValue.BooleanToZeroOne();
            duv.ViewShowHeaderBarRight = ViewShowHeaderBarRightValue.BooleanToZeroOne();
            duv.ViewShowHeaderMenu = ViewShowHeaderMenuValue.BooleanToZeroOne();
            duv.ViewShowLeftMenu = ViewShowLeftMenuValue.BooleanToZeroOne();
            duv.ViewShowMenu = ViewShowMenuValue.BooleanToZeroOne();
            duv.ViewShowRightMenu = ViewShowRightMenuValue.BooleanToZeroOne();
            duv.ViewCommonDarkBackgroundColor = ViewCommonDarkBackgroundColorValue;
            duv.ViewCommonDarkTextColor = ViewCommonDarkTextColorValue;
            duv.ViewCommonLightBackgroundColor = ViewCommonLightBackgroundColorValue;
            duv.ViewCommonLightTextColor = ViewCommonLightTextColorValue;
            duv.ViewCommonMiddleBackgroundColor = ViewCommonMiddleBackgroundColorValue;
            duv.ViewCommonMiddleTextColor = ViewCommonMiddleTextColorValue;
            duv.ViewNaturalDarkBackgroundColor = ViewNaturalDarkBackgroundColorValue;
            duv.ViewNaturalDarkTextColor = ViewNaturalDarkTextColorValue;
            duv.ViewNaturalLightBackgroundColor = ViewNaturalLightBackgroundColorValue;
            duv.ViewNaturalLightTextColor = ViewNaturalLightTextColorValue;
            duv.ViewNaturalMiddleBackgroundColor = ViewNaturalMiddleBackgroundColorValue;
            duv.ViewNaturalMiddleTextColor = ViewNaturalMiddleTextColorValue;
            duv.ViewBackgroundColor = ViewBackgroundColorValue;
            duv.ViewFontSize = ViewFontSizeValue;
            duv.ViewStaticHead = ViewStaticHeadValue;
            duv.SiteStyleId = ViewSiteStyleOptionListSelectedValue;
            duv.SiteTemplateId = ViewSiteTemplateOptionListSelectedValue;
            duv.ViewMatchType = ViewMatchTypeOptionListSelectedValue;
            duv.ViewActive = ViewActiveValue.BooleanToZeroOne();

            // Add View
            duv.AddWithFillReturnDr();

            // Add View Query String
            if (ViewMatchTypeOptionListSelectedValue == "none_query" || ViewMatchTypeOptionListSelectedValue == "all_query")
                ViewQueryStringValue = ViewMatchTypeOptionListSelectedValue;

            string ViewQueryStringy = ViewQueryStringValue;
            if (ViewQueryStringy.Length > 0)
                if (ViewQueryStringy[0] == '?')
                    ViewQueryStringy.Remove(0, 1);
            string[] ViewQueryStringList = ViewQueryStringy.Split('&');
            duv.AddViewQueryString(duv.ViewId, ViewQueryStringList);


            try { duv.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_view", duv.ViewId);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("view_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/view/"), "success", false, StaticObject.AdminPath + "/view/action/ViewNewRow.aspx?view_id=" + duv.ViewId, "div_TableBox");
        }
    }
}