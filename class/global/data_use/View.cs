using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Elanat.DataUse
{
    public class View : IDisposable
    {
        public string ViewId = "";
        public string ViewName = "";
        public string ViewFillAfterContent = "";
        public string ViewFillAfterHeader = "";
        public string ViewFillBeforeFooter = "";
        public string ViewFillBeforeContent = "";
        public string ViewFillFooter1 = "";
        public string ViewFillFooter2 = "";
        public string ViewFillFooterBarBox = "";
        public string ViewFillFooterBarLeft = "";
        public string ViewFillFooterBarRight = "";
        public string ViewFillFooterMenu = "";
        public string ViewFillHeader1 = "";
        public string ViewFillHeader2 = "";
        public string ViewFillHeaderBarBox = "";
        public string ViewFillHeaderBarLeft = "";
        public string ViewFillHeaderBarRight = "";
        public string ViewFillHeaderMenu = "";
        public string ViewFillLeftMenu = "";
        public string ViewFillMenu = "";
        public string ViewFillRightMenu = "";
        public string ViewIncludeFooterBarPart = "";
        public string ViewIncludeFooterPart = "";
        public string ViewIncludeHeaderBarPart = "";
        public string ViewIncludeHeaderPart = "";
        public string ViewIncludeMainPart = "";
        public string ViewIncludeMenuPart = "";
        public string ViewShowAfterContent = "";
        public string ViewShowAfterHeader = "";
        public string ViewShowBeforeFooter = "";
        public string ViewShowBeforeContent = "";
        public string ViewShowFooter1 = "";
        public string ViewShowFooter2 = "";
        public string ViewShowFooterBarBox = "";
        public string ViewShowFooterBarLeft = "";
        public string ViewShowFooterBarRight = "";
        public string ViewShowFooterMenu = "";
        public string ViewShowHeader1 = "";
        public string ViewShowHeader2 = "";
        public string ViewShowHeaderBarBox = "";
        public string ViewShowHeaderBarLeft = "";
        public string ViewShowHeaderBarRight = "";
        public string ViewShowHeaderMenu = "";
        public string ViewShowLeftMenu = "";
        public string ViewShowMenu = "";
        public string ViewShowRightMenu = "";
        public string ViewCommonDarkBackgroundColor = "";
        public string ViewCommonDarkTextColor = "";
        public string ViewCommonLightBackgroundColor = "";
        public string ViewCommonLightTextColor = "";
        public string ViewCommonMiddleBackgroundColor = "";
        public string ViewCommonMiddleTextColor = "";
        public string ViewNaturalDarkBackgroundColor = "";
        public string ViewNaturalDarkTextColor = "";
        public string ViewNaturalLightBackgroundColor = "";
        public string ViewNaturalLightTextColor = "";
        public string ViewNaturalMiddleBackgroundColor = "";
        public string ViewNaturalMiddleTextColor = "";
        public string ViewBackgroundColor = "";
        public string ViewFontSize = "";
        public string ViewStaticHead = "";
        public string SiteStyleId = "";
        public string SiteTemplateId = "";
        public string ViewMatchType = "";
        public string ViewActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_view", "@view_id", ViewId);
        }

        public void Inactive(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_view", "@view_id", ViewId);
        }

        public void Delete(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_view", "@view_id", ViewId);

            // Delete View Query String
            DeleteViewQueryString(ViewId);
        }

        public void DeleteViewQueryString(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_view_query_string", "@view_id", ViewId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_view", new List<string>() { "@view_name", "@view_include_header_bar_part", "@view_show_header_bar_left", "@view_show_header_bar_right", "@view_show_header_bar_box", "@view_fill_header_bar_left", "@view_fill_header_bar_right", "@view_fill_header_bar_box", "@view_include_header_part", "@view_show_header_menu", "@view_show_header1", "@view_show_header2", "@view_fill_header_menu", "@view_fill_header1", "@view_fill_header2", "@view_include_menu_part", "@view_show_menu", "@view_fill_menu", "@view_include_main_part", "@view_show_after_header", "@view_show_before_content", "@view_show_after_content", "@view_show_right_menu", "@view_show_left_menu", "@view_show_before_footer", "@view_fill_after_header", "@view_fill_before_content", "@view_fill_after_content", "@view_fill_right_menu", "@view_fill_left_menu", "@view_fill_before_footer", "@view_include_footer_part", "@view_show_footer_menu", "@view_show_footer1", "@view_show_footer2", "@view_fill_footer_menu", "@view_fill_footer1", "@view_fill_footer2", "@view_include_footer_bar_part", "@view_show_footer_bar_left", "@view_show_footer_bar_right", "@view_show_footer_bar_box", "@view_fill_footer_bar_left", "@view_fill_footer_bar_right", "@view_fill_footer_bar_box", "@view_common_light_background_color", "@view_common_light_text_color", "@view_common_middle_background_color", "@view_common_middle_text_color", "@view_common_dark_background_color", "@view_common_dark_text_color", "@view_natural_light_background_color", "@view_natural_light_text_color", "@view_natural_middle_background_color", "@view_natural_middle_text_color", "@view_natural_dark_background_color", "@view_natural_dark_text_color", "@view_background_color", "@view_font_size", "@view_static_head", "@site_style_id", "@site_template_id", "@view_match_type", "@view_active" }, new List<string>() { ViewName, ViewIncludeHeaderBarPart, ViewShowHeaderBarLeft, ViewShowHeaderBarRight, ViewShowHeaderBarBox, ViewFillHeaderBarLeft, ViewFillHeaderBarRight, ViewFillHeaderBarBox, ViewIncludeHeaderPart, ViewShowHeaderMenu, ViewShowHeader1, ViewShowHeader2, ViewFillHeaderMenu, ViewFillHeader1, ViewFillHeader2, ViewIncludeMenuPart, ViewShowMenu, ViewFillMenu, ViewIncludeMainPart, ViewShowAfterHeader, ViewShowBeforeContent, ViewShowAfterContent, ViewShowRightMenu, ViewShowLeftMenu, ViewShowBeforeFooter, ViewFillAfterHeader, ViewFillBeforeContent, ViewFillAfterContent, ViewFillRightMenu, ViewFillLeftMenu, ViewFillBeforeFooter, ViewIncludeFooterPart, ViewShowFooterMenu, ViewShowFooter1, ViewShowFooter2, ViewFillFooterMenu, ViewFillFooter1, ViewFillFooter2, ViewIncludeFooterBarPart, ViewShowFooterBarLeft, ViewShowFooterBarRight, ViewShowFooterBarBox, ViewFillFooterBarLeft, ViewFillFooterBarRight, ViewFillFooterBarBox, ViewCommonLightBackgroundColor, ViewCommonLightTextColor, ViewCommonMiddleBackgroundColor, ViewCommonMiddleTextColor, ViewCommonDarkBackgroundColor, ViewCommonDarkTextColor, ViewNaturalLightBackgroundColor, ViewNaturalLightTextColor, ViewNaturalMiddleBackgroundColor, ViewNaturalMiddleTextColor, ViewNaturalDarkBackgroundColor, ViewNaturalDarkTextColor, ViewBackgroundColor, ViewFontSize, ViewStaticHead, SiteStyleId, SiteTemplateId, ViewMatchType, ViewActive });

            dbdr.dr.Read();

            ViewId = dbdr.dr["view_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_view", new List<string>() { "@view_name", "@view_include_header_bar_part", "@view_show_header_bar_left", "@view_show_header_bar_right", "@view_show_header_bar_box", "@view_fill_header_bar_left", "@view_fill_header_bar_right", "@view_fill_header_bar_box", "@view_include_header_part", "@view_show_header_menu", "@view_show_header1", "@view_show_header2", "@view_fill_header_menu", "@view_fill_header1", "@view_fill_header2", "@view_include_menu_part", "@view_show_menu", "@view_fill_menu", "@view_include_main_part", "@view_show_after_header", "@view_show_before_content", "@view_show_after_content", "@view_show_right_menu", "@view_show_left_menu", "@view_show_before_footer", "@view_fill_after_header", "@view_fill_before_content", "@view_fill_after_content", "@view_fill_right_menu", "@view_fill_left_menu", "@view_fill_before_footer", "@view_include_footer_part", "@view_show_footer_menu", "@view_show_footer1", "@view_show_footer2", "@view_fill_footer_menu", "@view_fill_footer1", "@view_fill_footer2", "@view_include_footer_bar_part", "@view_show_footer_bar_left", "@view_show_footer_bar_right", "@view_show_footer_bar_box", "@view_fill_footer_bar_left", "@view_fill_footer_bar_right", "@view_fill_footer_bar_box", "@view_common_light_background_color", "@view_common_light_text_color", "@view_common_middle_background_color", "@view_common_middle_text_color", "@view_common_dark_background_color", "@view_common_dark_text_color", "@view_natural_light_background_color", "@view_natural_light_text_color", "@view_natural_middle_background_color", "@view_natural_middle_text_color", "@view_natural_dark_background_color", "@view_natural_dark_text_color", "@view_background_color", "@view_font_size", "@view_static_head", "@site_style_id", "@site_template_id", "@view_match_type", "@view_active" }, new List<string>() { ViewName, ViewIncludeHeaderBarPart, ViewShowHeaderBarLeft, ViewShowHeaderBarRight, ViewShowHeaderBarBox, ViewFillHeaderBarLeft, ViewFillHeaderBarRight, ViewFillHeaderBarBox, ViewIncludeHeaderPart, ViewShowHeaderMenu, ViewShowHeader1, ViewShowHeader2, ViewFillHeaderMenu, ViewFillHeader1, ViewFillHeader2, ViewIncludeMenuPart, ViewShowMenu, ViewFillMenu, ViewIncludeMainPart, ViewShowAfterHeader, ViewShowBeforeContent, ViewShowAfterContent, ViewShowRightMenu, ViewShowLeftMenu, ViewShowBeforeFooter, ViewFillAfterHeader, ViewFillBeforeContent, ViewFillAfterContent, ViewFillRightMenu, ViewFillLeftMenu, ViewFillBeforeFooter, ViewIncludeFooterPart, ViewShowFooterMenu, ViewShowFooter1, ViewShowFooter2, ViewFillFooterMenu, ViewFillFooter1, ViewFillFooter2, ViewIncludeFooterBarPart, ViewShowFooterBarLeft, ViewShowFooterBarRight, ViewShowFooterBarBox, ViewFillFooterBarLeft, ViewFillFooterBarRight, ViewFillFooterBarBox, ViewCommonLightBackgroundColor, ViewCommonLightTextColor, ViewCommonMiddleBackgroundColor, ViewCommonMiddleTextColor, ViewCommonDarkBackgroundColor, ViewCommonDarkTextColor, ViewNaturalLightBackgroundColor, ViewNaturalLightTextColor, ViewNaturalMiddleBackgroundColor, ViewNaturalMiddleTextColor, ViewNaturalDarkBackgroundColor, ViewNaturalDarkTextColor, ViewBackgroundColor, ViewFontSize, ViewStaticHead, SiteStyleId, SiteTemplateId, ViewMatchType, ViewActive });

            ReturnDr.Read();

            ViewId = ReturnDr["view_id"].ToString();
        }

        public void AddViewQueryString(string ViewId, string[] ViewQueryStringList)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (string QueryString in ViewQueryStringList)
                if (!string.IsNullOrEmpty(QueryString))
                    db.SetProcedure("add_view_query_string", new List<string>() { "@view_id", "@view_query_string" }, new List<string>() { ViewId, QueryString });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_view", new List<string>() { "@view_id", "@view_name", "@view_include_header_bar_part", "@view_show_header_bar_left", "@view_show_header_bar_right", "@view_show_header_bar_box", "@view_fill_header_bar_left", "@view_fill_header_bar_right", "@view_fill_header_bar_box", "@view_include_header_part", "@view_show_header_menu", "@view_show_header1", "@view_show_header2", "@view_fill_header_menu", "@view_fill_header1", "@view_fill_header2", "@view_include_menu_part", "@view_show_menu", "@view_fill_menu", "@view_include_main_part", "@view_show_after_header", "@view_show_before_content", "@view_show_after_content", "@view_show_right_menu", "@view_show_left_menu", "@view_show_before_footer", "@view_fill_after_header", "@view_fill_before_content", "@view_fill_after_content", "@view_fill_right_menu", "@view_fill_left_menu", "@view_fill_before_footer", "@view_include_footer_part", "@view_show_footer_menu", "@view_show_footer1", "@view_show_footer2", "@view_fill_footer_menu", "@view_fill_footer1", "@view_fill_footer2", "@view_include_footer_bar_part", "@view_show_footer_bar_left", "@view_show_footer_bar_right", "@view_show_footer_bar_box", "@view_fill_footer_bar_left", "@view_fill_footer_bar_right", "@view_fill_footer_bar_box", "@view_common_light_background_color", "@view_common_light_text_color", "@view_common_middle_background_color", "@view_common_middle_text_color", "@view_common_dark_background_color", "@view_common_dark_text_color", "@view_natural_light_background_color", "@view_natural_light_text_color", "@view_natural_middle_background_color", "@view_natural_middle_text_color", "@view_natural_dark_background_color", "@view_natural_dark_text_color", "@view_background_color", "@view_font_size", "@view_static_head", "@site_style_id", "@site_template_id", "@view_match_type", "@view_active" }, new List<string>() { ViewId, ViewName, ViewIncludeHeaderBarPart, ViewShowHeaderBarLeft, ViewShowHeaderBarRight, ViewShowHeaderBarBox, ViewFillHeaderBarLeft, ViewFillHeaderBarRight, ViewFillHeaderBarBox, ViewIncludeHeaderPart, ViewShowHeaderMenu, ViewShowHeader1, ViewShowHeader2, ViewFillHeaderMenu, ViewFillHeader1, ViewFillHeader2, ViewIncludeMenuPart, ViewShowMenu, ViewFillMenu, ViewIncludeMainPart, ViewShowAfterHeader, ViewShowBeforeContent, ViewShowAfterContent, ViewShowRightMenu, ViewShowLeftMenu, ViewShowBeforeFooter, ViewFillAfterHeader, ViewFillBeforeContent, ViewFillAfterContent, ViewFillRightMenu, ViewFillLeftMenu, ViewFillBeforeFooter, ViewIncludeFooterPart, ViewShowFooterMenu, ViewShowFooter1, ViewShowFooter2, ViewFillFooterMenu, ViewFillFooter1, ViewFillFooter2, ViewIncludeFooterBarPart, ViewShowFooterBarLeft, ViewShowFooterBarRight, ViewShowFooterBarBox, ViewFillFooterBarLeft, ViewFillFooterBarRight, ViewFillFooterBarBox, ViewCommonLightBackgroundColor, ViewCommonLightTextColor, ViewCommonMiddleBackgroundColor, ViewCommonMiddleTextColor, ViewCommonDarkBackgroundColor, ViewCommonDarkTextColor, ViewNaturalLightBackgroundColor, ViewNaturalLightTextColor, ViewNaturalMiddleBackgroundColor, ViewNaturalMiddleTextColor, ViewNaturalDarkBackgroundColor, ViewNaturalDarkTextColor, ViewBackgroundColor, ViewFontSize, ViewStaticHead, SiteStyleId, SiteTemplateId, ViewMatchType, ViewActive });
        }

        public void FillCurrentView(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_view", "@view_id", ViewId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ViewId = dbdr.dr["view_id"].ToString();
            ViewName = dbdr.dr["view_name"].ToString();
            ViewFillAfterContent = dbdr.dr["view_fill_after_content"].ToString().TrueFalseToZeroOne();
            ViewFillAfterHeader = dbdr.dr["view_fill_after_header"].ToString().TrueFalseToZeroOne();
            ViewFillBeforeFooter = dbdr.dr["view_fill_before_footer"].ToString().TrueFalseToZeroOne();
            ViewFillBeforeContent = dbdr.dr["view_fill_before_content"].ToString().TrueFalseToZeroOne();
            ViewFillFooter1 = dbdr.dr["view_fill_footer1"].ToString().TrueFalseToZeroOne();
            ViewFillFooter2 = dbdr.dr["view_fill_footer2"].ToString().TrueFalseToZeroOne();
            ViewFillFooterBarBox = dbdr.dr["view_fill_footer_bar_box"].ToString().TrueFalseToZeroOne();
            ViewFillFooterBarLeft = dbdr.dr["view_fill_footer_bar_left"].ToString().TrueFalseToZeroOne();
            ViewFillFooterBarRight = dbdr.dr["view_fill_footer_bar_right"].ToString().TrueFalseToZeroOne();
            ViewFillFooterMenu = dbdr.dr["view_fill_footer_menu"].ToString().TrueFalseToZeroOne();
            ViewFillHeader1 = dbdr.dr["view_fill_header1"].ToString().TrueFalseToZeroOne();
            ViewFillHeader2 = dbdr.dr["view_fill_header2"].ToString().TrueFalseToZeroOne();
            ViewFillHeaderBarBox = dbdr.dr["view_fill_header_bar_box"].ToString().TrueFalseToZeroOne();
            ViewFillHeaderBarLeft = dbdr.dr["view_fill_header_bar_left"].ToString().TrueFalseToZeroOne();
            ViewFillHeaderBarRight = dbdr.dr["view_fill_header_bar_right"].ToString().TrueFalseToZeroOne();
            ViewFillHeaderMenu = dbdr.dr["view_fill_header_menu"].ToString().TrueFalseToZeroOne();
            ViewFillLeftMenu = dbdr.dr["view_fill_left_menu"].ToString().TrueFalseToZeroOne();
            ViewFillMenu = dbdr.dr["view_fill_menu"].ToString().TrueFalseToZeroOne();
            ViewFillRightMenu = dbdr.dr["view_fill_right_menu"].ToString().TrueFalseToZeroOne();
            ViewIncludeFooterBarPart = dbdr.dr["view_include_footer_bar_part"].ToString().TrueFalseToZeroOne();
            ViewIncludeFooterPart = dbdr.dr["view_include_footer_part"].ToString().TrueFalseToZeroOne();
            ViewIncludeHeaderBarPart = dbdr.dr["view_include_header_bar_part"].ToString().TrueFalseToZeroOne();
            ViewIncludeHeaderPart = dbdr.dr["view_include_header_part"].ToString().TrueFalseToZeroOne();
            ViewIncludeMainPart = dbdr.dr["view_include_main_part"].ToString().TrueFalseToZeroOne();
            ViewIncludeMenuPart = dbdr.dr["view_include_menu_part"].ToString().TrueFalseToZeroOne();
            ViewShowAfterContent = dbdr.dr["view_show_after_content"].ToString().TrueFalseToZeroOne();
            ViewShowAfterHeader = dbdr.dr["view_show_after_header"].ToString().TrueFalseToZeroOne();
            ViewShowBeforeFooter = dbdr.dr["view_show_before_footer"].ToString().TrueFalseToZeroOne();
            ViewShowBeforeContent = dbdr.dr["view_show_before_content"].ToString().TrueFalseToZeroOne();
            ViewShowFooter1 = dbdr.dr["view_show_footer1"].ToString().TrueFalseToZeroOne();
            ViewShowFooter2 = dbdr.dr["view_show_footer2"].ToString().TrueFalseToZeroOne();
            ViewShowFooterBarBox = dbdr.dr["view_show_footer_bar_box"].ToString().TrueFalseToZeroOne();
            ViewShowFooterBarLeft = dbdr.dr["view_show_footer_bar_left"].ToString().TrueFalseToZeroOne();
            ViewShowFooterBarRight = dbdr.dr["view_show_footer_bar_right"].ToString().TrueFalseToZeroOne();
            ViewShowFooterMenu = dbdr.dr["view_show_footer_menu"].ToString().TrueFalseToZeroOne();
            ViewShowHeader1 = dbdr.dr["view_show_header1"].ToString().TrueFalseToZeroOne();
            ViewShowHeader2 = dbdr.dr["view_show_header2"].ToString().TrueFalseToZeroOne();
            ViewShowHeaderBarBox = dbdr.dr["view_show_header_bar_box"].ToString().TrueFalseToZeroOne();
            ViewShowHeaderBarLeft = dbdr.dr["view_show_header_bar_left"].ToString().TrueFalseToZeroOne();
            ViewShowHeaderBarRight = dbdr.dr["view_show_header_bar_right"].ToString().TrueFalseToZeroOne();
            ViewShowHeaderMenu = dbdr.dr["view_show_header_menu"].ToString().TrueFalseToZeroOne();
            ViewShowLeftMenu = dbdr.dr["view_show_left_menu"].ToString().TrueFalseToZeroOne();
            ViewShowMenu = dbdr.dr["view_show_menu"].ToString().TrueFalseToZeroOne();
            ViewShowRightMenu = dbdr.dr["view_show_right_menu"].ToString().TrueFalseToZeroOne();
            ViewCommonDarkBackgroundColor = dbdr.dr["view_common_dark_background_color"].ToString();
            ViewCommonDarkTextColor = dbdr.dr["view_common_dark_text_color"].ToString();
            ViewCommonLightBackgroundColor = dbdr.dr["view_common_light_background_color"].ToString();
            ViewCommonLightTextColor = dbdr.dr["view_common_light_text_color"].ToString();
            ViewCommonMiddleBackgroundColor = dbdr.dr["view_common_middle_background_color"].ToString();
            ViewCommonMiddleTextColor = dbdr.dr["view_common_middle_text_color"].ToString();
            ViewNaturalDarkBackgroundColor = dbdr.dr["view_natural_dark_background_color"].ToString();
            ViewNaturalDarkTextColor = dbdr.dr["view_natural_dark_text_color"].ToString();
            ViewNaturalLightBackgroundColor = dbdr.dr["view_natural_light_background_color"].ToString();
            ViewNaturalLightTextColor = dbdr.dr["view_natural_light_text_color"].ToString();
            ViewNaturalMiddleBackgroundColor = dbdr.dr["view_natural_middle_background_color"].ToString();
            ViewNaturalMiddleTextColor = dbdr.dr["view_natural_middle_text_color"].ToString();
            ViewBackgroundColor = dbdr.dr["view_background_color"].ToString();
            ViewFontSize = dbdr.dr["view_font_size"].ToString();
            ViewStaticHead = dbdr.dr["view_static_head"].ToString();
            SiteStyleId = dbdr.dr["site_style_id"].ToString();
            SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            ViewMatchType = dbdr.dr["view_match_type"].ToString();
            ViewActive = dbdr.dr["view_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentViewWithReturnDr(string ViewId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_view", "@view_id", ViewId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }

        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "view_id": return ViewId;
                case "view_name": return ViewName;
                case "view_fill_after_content": return ViewFillAfterContent;
                case "view_fill_after_header": return ViewFillAfterHeader;
                case "view_fill_before_footer": return ViewFillBeforeFooter;
                case "view_fill_before_content": return ViewFillBeforeContent;
                case "view_fill_footer1": return ViewFillFooter1;
                case "view_fill_footer2": return ViewFillFooter2;
                case "view_fill_footer_bar_box": return ViewFillFooterBarBox;
                case "view_fill_footer_bar_left": return ViewFillFooterBarLeft;
                case "view_fill_footer_bar_right": return ViewFillFooterBarRight;
                case "view_fill_footer_menu": return ViewFillFooterMenu;
                case "view_fill_header1": return ViewFillHeader1;
                case "view_fill_header2": return ViewFillHeader2;
                case "view_fill_header_bar_box": return ViewFillHeaderBarBox;
                case "view_fill_header_bar_left": return ViewFillHeaderBarLeft;
                case "view_fill_header_bar_right": return ViewFillHeaderBarRight;
                case "view_fill_header_menu": return ViewFillHeaderMenu;
                case "view_fill_left_menu": return ViewFillLeftMenu;
                case "view_fill_menu": return ViewFillMenu;
                case "view_fill_right_menu": return ViewFillRightMenu;
                case "view_include_footer_bar_part": return ViewIncludeFooterBarPart;
                case "view_include_footer_part": return ViewIncludeFooterPart;
                case "view_include_header_bar_part": return ViewIncludeHeaderBarPart;
                case "view_include_header_part": return ViewIncludeHeaderPart;
                case "view_include_main_part": return ViewIncludeMainPart;
                case "view_include_menu_part": return ViewIncludeMenuPart;
                case "view_show_after_content": return ViewShowAfterContent;
                case "view_show_after_header": return ViewShowAfterHeader;
                case "view_show_before_footer": return ViewShowBeforeFooter;
                case "view_show_before_content": return ViewShowBeforeContent;
                case "view_show_footer1": return ViewShowFooter1;
                case "view_show_footer2": return ViewShowFooter2;
                case "view_show_footer_bar_box": return ViewShowFooterBarBox;
                case "view_show_footer_bar_left": return ViewShowFooterBarLeft;
                case "view_show_footer_bar_right": return ViewShowFooterBarRight;
                case "view_show_footer_menu": return ViewShowFooterMenu;
                case "view_show_header1": return ViewShowHeader1;
                case "view_show_header2": return ViewShowHeader2;
                case "view_show_header_bar_box": return ViewShowHeaderBarBox;
                case "view_show_header_bar_left": return ViewShowHeaderBarLeft;
                case "view_show_header_bar_right": return ViewShowHeaderBarRight;
                case "view_show_header_menu": return ViewShowHeaderMenu;
                case "view_show_left_menu": return ViewShowLeftMenu;
                case "view_show_menu": return ViewShowMenu;
                case "view_show_right_menu": return ViewShowRightMenu;
                case "view_common_dark_background_color": return ViewCommonDarkBackgroundColor;
                case "view_common_dark_text_color": return ViewCommonDarkTextColor;
                case "view_common_light_background_color": return ViewCommonLightBackgroundColor;
                case "view_common_light_text_color": return ViewCommonLightTextColor;
                case "view_common_middle_background_color": return ViewCommonMiddleBackgroundColor;
                case "view_common_middle_text_color": return ViewCommonMiddleTextColor;
                case "view_natural_dark_background_color": return ViewNaturalDarkBackgroundColor;
                case "view_natural_dark_text_color": return ViewNaturalDarkTextColor;
                case "view_natural_light_background_color": return ViewNaturalLightBackgroundColor;
                case "view_natural_light_text_color": return ViewNaturalLightTextColor;
                case "view_natural_middle_background_color": return ViewNaturalMiddleBackgroundColor;
                case "view_natural_middle_text_color": return ViewNaturalMiddleTextColor;
                case "view_background_color": return ViewBackgroundColor;
                case "view_font_size": return ViewFontSize;
                case "view_static_head": return ViewStaticHead;
                case "site_style_id": return SiteStyleId;
                case "site_template_id": return SiteTemplateId;
                case "view_match_type": return ViewMatchType;
                case "view_active": return ViewActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ViewId = "";
            ViewName = "";
            ViewFillAfterContent = "";
            ViewFillAfterHeader = "";
            ViewFillBeforeFooter = "";
            ViewFillBeforeContent = "";
            ViewFillFooter1 = "";
            ViewFillFooter2 = "";
            ViewFillFooterBarBox = "";
            ViewFillFooterBarLeft = "";
            ViewFillFooterBarRight = "";
            ViewFillFooterMenu = "";
            ViewFillHeader1 = "";
            ViewFillHeader2 = "";
            ViewFillHeaderBarBox = "";
            ViewFillHeaderBarLeft = "";
            ViewFillHeaderBarRight = "";
            ViewFillHeaderMenu = "";
            ViewFillLeftMenu = "";
            ViewFillMenu = "";
            ViewFillRightMenu = "";
            ViewIncludeFooterBarPart = "";
            ViewIncludeFooterPart = "";
            ViewIncludeHeaderBarPart = "";
            ViewIncludeHeaderPart = "";
            ViewIncludeMainPart = "";
            ViewIncludeMenuPart = "";
            ViewShowAfterContent = "";
            ViewShowAfterHeader = "";
            ViewShowBeforeFooter = "";
            ViewShowBeforeContent = "";
            ViewShowFooter1 = "";
            ViewShowFooter2 = "";
            ViewShowFooterBarBox = "";
            ViewShowFooterBarLeft = "";
            ViewShowFooterBarRight = "";
            ViewShowFooterMenu = "";
            ViewShowHeader1 = "";
            ViewShowHeader2 = "";
            ViewShowHeaderBarBox = "";
            ViewShowHeaderBarLeft = "";
            ViewShowHeaderBarRight = "";
            ViewShowHeaderMenu = "";
            ViewShowLeftMenu = "";
            ViewShowMenu = "";
            ViewShowRightMenu = "";
            ViewCommonDarkBackgroundColor = "";
            ViewCommonDarkTextColor = "";
            ViewCommonLightBackgroundColor = "";
            ViewCommonLightTextColor = "";
            ViewCommonMiddleBackgroundColor = "";
            ViewCommonMiddleTextColor = "";
            ViewNaturalDarkBackgroundColor = "";
            ViewNaturalDarkTextColor = "";
            ViewNaturalLightBackgroundColor = "";
            ViewNaturalLightTextColor = "";
            ViewNaturalMiddleBackgroundColor = "";
            ViewNaturalMiddleTextColor = "";
            ViewBackgroundColor = "";
            ViewFontSize = "";
            ViewStaticHead = "";
            SiteStyleId = "";
            SiteTemplateId = "";
            ViewMatchType = "";
            ViewActive = "";

            ReturnDr.Close();
        }

        public string GetViewIdByQueryString(string QueryString)
        {
            if (!string.IsNullOrEmpty(QueryString))
                if (QueryString[0] == '?')
                    QueryString = QueryString.Remove(0, 1);


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_view_query_string");

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return "0";
            }

            string CurrentViewId = "0";
            string CurrentQueryStringFind = "";

            while (dbdr.dr.Read())
            {
                if (dbdr.dr["view_match_type"].ToString() == "none_query" && string.IsNullOrEmpty(QueryString))
                {
                    CurrentViewId = dbdr.dr["view_id"].ToString();
                    CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();

                    break;
                }

                if (dbdr.dr["view_match_type"].ToString() == "exist")
                    if (QueryString.Contains(dbdr.dr["view_query_string"].ToString()))
                    {
                        CurrentViewId = dbdr.dr["view_id"].ToString();
                        CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();

                        break;
                    }

                if (dbdr.dr["view_match_type"].ToString() == "start_by")
                    if (QueryString.TextStartMathByValueCheck(dbdr.dr["view_query_string"].ToString()))
                    {
                        CurrentViewId = dbdr.dr["view_id"].ToString();
                        CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();

                        break;
                    }

                if (dbdr.dr["view_match_type"].ToString() == "end_by")
                    if (QueryString.TextEndMathByValueCheck(dbdr.dr["view_query_string"].ToString()))
                    {
                        CurrentViewId = dbdr.dr["view_id"].ToString();
                        CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();

                        break;
                    }

                if (dbdr.dr["view_match_type"].ToString() == "regex")
                {
                    Regex re = new Regex(dbdr.dr["view_query_string"].ToString(), RegexOptions.IgnoreCase);

                    if (re.IsMatch(QueryString))
                    {
                        CurrentViewId = dbdr.dr["view_id"].ToString();
                        CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();

                        break;
                    }
                }

                if (dbdr.dr["view_match_type"].ToString() == "all_query")
                {
                    CurrentViewId = dbdr.dr["view_id"].ToString();
                    CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();
                }

                if (dbdr.dr["view_match_type"].ToString() == "full_match")
                    if (QueryString.Contains(dbdr.dr["view_query_string"].ToString()))
                        if (dbdr.dr["view_query_string"].ToString().Length == CurrentQueryStringFind.Length)
                        {
                            CurrentViewId = dbdr.dr["view_id"].ToString();
                            CurrentQueryStringFind = dbdr.dr["view_query_string"].ToString();
                        }
            }

            db.Close();

            return CurrentViewId;
        }

        public string GetViewCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_view", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ViewCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ViewCount;
        }

        public string GetViewName(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_view_name", "@view_id", ViewId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ViewName = dbdr.dr["view_name"].ToString();

                db.Close();

                return ViewName;
            }

            db.Close();

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}