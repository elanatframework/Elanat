using CodeBehind;

namespace Elanat
{
    public partial class SiteContactCountryModel : CodeBehindModel
    {
        public string CountryLanguage { get; set; }

        public string CountryValue { get; set; }

        public string CountryCssClass { get; set; }

        public string CountryAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            CountryLanguage = Language.GetAddOnsLanguage("country", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Country", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            CountryAttribute += vc.ImportantInputAttribute.GetValue("txt_Country");

            CountryCssClass = CountryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Country"));
        }
    }
}