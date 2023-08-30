using CodeBehind;

namespace Elanat
{
    public partial class SiteContactTitleModel : CodeBehindModel
    {
        public string TitleLanguage { get; set; }

        public string TitleValue { get; set; }

        public string TitleCssClass { get; set; }

        public string TitleAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            TitleLanguage = Language.GetAddOnsLanguage("title", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ContactTitle", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            TitleAttribute += vc.ImportantInputAttribute.GetValue("txt_ContactTitle");

            TitleCssClass = TitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContactTitle"));
        }
    }
}