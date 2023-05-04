using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionEditLanguageModel
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

            ListClass lc = new ListClass();

            // Set Language Name Item
            lc.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Set Site Item
            lc.FillSiteListItem();
            LanguageDefaultSiteOptionListValue += LanguageDefaultSiteOptionListValue.HtmlInputAddOptionTag("", "0");
            LanguageDefaultSiteOptionListValue += lc.SiteListItem.HtmlInputToOptionTag(LanguageDefaultSiteOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_LanguageDefaultSite", LanguageDefaultSiteOptionListValue);
            InputRequest.Add("hdn_LanguageId", LanguageIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "edit_language");

            LanguageDefaultSiteAttribute += vc.ImportantInputAttribute["ddlst_LanguageDefaultSite"];

            LanguageDefaultSiteCssClass = LanguageDefaultSiteCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_LanguageDefaultSite"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_language", StaticObject.AdminPath + "/language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");
                
                //LanguageDefaultSiteCssClass = LanguageDefaultSiteCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_LanguageDefaultSite"]);
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
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/language/action/SuccessMessage.aspx");
        }
    }
}