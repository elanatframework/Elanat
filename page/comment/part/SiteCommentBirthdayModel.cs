using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteCommentBirthdayModel
    {
        public string BirthdayLanguage { get; set; }

        public string BirthdayYearOptionListValue { get; set; }
        public string BirthdayMountOptionListValue { get; set; }
        public string BirthdayDayOptionListValue { get; set; }
        public string BirthdayYearOptionListSelectedValue { get; set; }
        public string BirthdayMountOptionListSelectedValue { get; set; }
        public string BirthdayDayOptionListSelectedValue { get; set; }

        public string BirthdayYearAttribute { get; set; }
        public string BirthdayMountAttribute { get; set; }
        public string BirthdayDayAttribute { get; set; }

        public string BirthdayYearCssClass { get; set; }
        public string BirthdayMountCssClass { get; set; }
        public string BirthdayDayCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            BirthdayLanguage = Language.GetAddOnsLanguage("birthday", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");


            ListClass lc = new ListClass();

            // Set Birthday Item
            lc.FillBirthdayListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            BirthdayDayOptionListValue += BirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            BirthdayDayOptionListValue += lc.BirthdayDayListItem.HtmlInputToOptionTag(BirthdayDayOptionListSelectedValue);
            BirthdayMountOptionListValue += BirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            BirthdayMountOptionListValue += lc.BirthdayMountListItem.HtmlInputToOptionTag(BirthdayMountOptionListSelectedValue);
            BirthdayYearOptionListValue += BirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            BirthdayYearOptionListValue += lc.BirthdayYearListItem.HtmlInputToOptionTag(BirthdayYearOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayYearOptionListSelectedValue))
                BirthdayYearOptionListValue = BirthdayYearOptionListValue.HtmlInputSetSelectValue(BirthdayYearOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayMountOptionListSelectedValue))
                BirthdayMountOptionListValue = BirthdayMountOptionListValue.HtmlInputSetSelectValue(BirthdayMountOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayDayOptionListSelectedValue))
                BirthdayDayOptionListValue = BirthdayDayOptionListValue.HtmlInputSetSelectValue(BirthdayDayOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_BirthdayYear", BirthdayYearOptionListValue);
            InputRequest.Add("ddlst_BirthdayMount", BirthdayMountOptionListValue);
            InputRequest.Add("ddlst_BirthdayDay", BirthdayDayOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");
            
            BirthdayYearAttribute += vc.ImportantInputAttribute["ddlst_BirthdayYear"];
            BirthdayMountAttribute += vc.ImportantInputAttribute["ddlst_BirthdayMount"];
            BirthdayDayAttribute += vc.ImportantInputAttribute["ddlst_BirthdayDay"];

            BirthdayYearCssClass = BirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayYear"]);
            BirthdayMountCssClass = BirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayMount"]);
            BirthdayDayCssClass = BirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayDay"]);
        }
    }
}