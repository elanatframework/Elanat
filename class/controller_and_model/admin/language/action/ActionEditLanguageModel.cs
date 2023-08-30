using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLanguageModel : CodeBehindModel
    {
        public string SaveLanguageLanguage { get; set; }
        public string EditLanguageLanguage { get; set; }
        public string LanguageDefaultSiteLanguage { get; set; }
        public string LanguageActiveLanguage { get; set; }
        public string ShowLinkInSiteLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string LanguageIdValue { get; set; }

        public bool LanguageActiveValue { get; set; } = false;
        public bool UseLanguagePathValue { get; set; } = false;
        public bool ShowLinkInSiteValue { get; set; } = false;

        public string LanguageDefaultSiteOptionListValue { get; set; }
        public string LanguageDefaultSiteOptionListSelectedValue { get; set; }

        public string LanguageDefaultSiteAttribute { get; set; }
        public string LanguageDefaultSiteCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            SaveLanguageLanguage = aol.GetAddOnsLanguage("save_language");
            EditLanguageLanguage = aol.GetAddOnsLanguage("edit_language");
            LanguageDefaultSiteLanguage = aol.GetAddOnsLanguage("language_default_site");
            LanguageActiveLanguage = aol.GetAddOnsLanguage("language_is_active");
            ShowLinkInSiteLanguage = aol.GetAddOnsLanguage("show_link_in_site");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Language dul = new DataUse.Language();
                dul.FillCurrentLanguage(LanguageIdValue);

                ShowLinkInSiteValue = dul.LanguageShowLinkInSite.ZeroOneToBoolean();
                LanguageActiveValue = dul.LanguageActive.ZeroOneToBoolean();
                LanguageDefaultSiteOptionListSelectedValue = dul.SiteId;
            }

            // Set Language Name Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Set Site Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteListItem();
            LanguageDefaultSiteOptionListValue += LanguageDefaultSiteOptionListValue.HtmlInputAddOptionTag("", "0");
            LanguageDefaultSiteOptionListValue += lcs.SiteListItem.HtmlInputToOptionTag(LanguageDefaultSiteOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_LanguageDefaultSite", LanguageDefaultSiteOptionListValue);
            InputRequest.Add("hdn_LanguageId", LanguageIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "edit_language");

            LanguageDefaultSiteAttribute += vc.ImportantInputAttribute.GetValue("ddlst_LanguageDefaultSite");

            LanguageDefaultSiteCssClass = LanguageDefaultSiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_LanguageDefaultSite"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_language", StaticObject.AdminPath + "/language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveLanguage()
        {
            // Change Database Data
            DataUse.Language dul = new DataUse.Language();

            dul.LanguageId = LanguageIdValue;
            dul.LanguageShowLinkInSite = ShowLinkInSiteValue.BooleanToZeroOne();
            dul.LanguageActive = LanguageActiveValue.BooleanToZeroOne();
            dul.SiteId = LanguageDefaultSiteOptionListSelectedValue;

            // Edit Language
            dul.Edit();


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_language", dul.LanguageName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/language/action/SuccessMessage.aspx");
        }
    }
}