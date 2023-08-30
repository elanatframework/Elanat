using CodeBehind;

namespace Elanat
{
    public partial class SiteContactBirthdayModel : CodeBehindModel
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
            BirthdayLanguage = Language.GetAddOnsLanguage("birthday", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");


            // Set Birthday Item
            ListClass.DateAndTime lcdat = new ListClass.DateAndTime();
            lcdat.FillBirthdayListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            BirthdayDayOptionListValue += BirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            BirthdayDayOptionListValue += lcdat.BirthdayDayListItem.HtmlInputToOptionTag(BirthdayDayOptionListSelectedValue);
            BirthdayMountOptionListValue += BirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            BirthdayMountOptionListValue += lcdat.BirthdayMountListItem.HtmlInputToOptionTag(BirthdayMountOptionListSelectedValue);
            BirthdayYearOptionListValue += BirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            BirthdayYearOptionListValue += lcdat.BirthdayYearListItem.HtmlInputToOptionTag(BirthdayYearOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayYearOptionListSelectedValue))
                BirthdayYearOptionListValue = BirthdayYearOptionListValue.HtmlInputSetSelectValue(BirthdayYearOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayMountOptionListSelectedValue))
                BirthdayMountOptionListValue = BirthdayMountOptionListValue.HtmlInputSetSelectValue(BirthdayMountOptionListSelectedValue);

            if (!string.IsNullOrEmpty(BirthdayDayOptionListSelectedValue))
                BirthdayDayOptionListValue = BirthdayDayOptionListValue.HtmlInputSetSelectValue(BirthdayDayOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_BirthdayYear", BirthdayYearOptionListValue);
            InputRequest.Add("ddlst_BirthdayMount", BirthdayMountOptionListValue);
            InputRequest.Add("ddlst_BirthdayDay", BirthdayDayOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");
            
            BirthdayYearAttribute += vc.ImportantInputAttribute.GetValue("ddlst_BirthdayYear");
            BirthdayMountAttribute += vc.ImportantInputAttribute.GetValue("ddlst_BirthdayMount");
            BirthdayDayAttribute += vc.ImportantInputAttribute.GetValue("ddlst_BirthdayDay");

            BirthdayYearCssClass = BirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_BirthdayYear"));
            BirthdayMountCssClass = BirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_BirthdayMount"));
            BirthdayDayCssClass = BirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_BirthdayDay"));
        }
    }
}