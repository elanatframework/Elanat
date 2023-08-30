using CodeBehind;

namespace Elanat
{
    public partial class SiteContactPostalCodeModel : CodeBehindModel
    {
        public string PostalCodeLanguage { get; set; }

        public string PostalCodeValue { get; set; }

        public string PostalCodeCssClass { get; set; }

        public string PostalCodeAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PostalCodeLanguage = Language.GetAddOnsLanguage("postal_code", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_PostalCode", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            PostalCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_PostalCode");

            PostalCodeCssClass = PostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PostalCode"));
        }
    }
}