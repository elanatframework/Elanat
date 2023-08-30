using CodeBehind;

namespace Elanat
{
    public partial class SiteContactAddressModel : CodeBehindModel
    {
        public string AddressLanguage { get; set; }

        public string AddressValue { get; set; }

        public string AddressCssClass { get; set; }

        public string AddressAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            AddressLanguage = Language.GetAddOnsLanguage("address", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Address", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            AddressAttribute += vc.ImportantInputAttribute.GetValue("txt_Address");

            AddressCssClass = AddressCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Address"));
        }
    }
}