using CodeBehind;

namespace Elanat
{
    public partial class SiteContactStateOrProvinceModel : CodeBehindModel
    {
        public string StateOrProvinceLanguage { get; set; }

        public string StateOrProvinceValue { get; set; }

        public string StateOrProvinceCssClass { get; set; }

        public string StateOrProvinceAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            StateOrProvinceLanguage = Language.GetAddOnsLanguage("state_or_province", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_StateOrProvince", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            StateOrProvinceAttribute += vc.ImportantInputAttribute.GetValue("txt_StateOrProvince");

            StateOrProvinceCssClass = StateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_StateOrProvince"));
        }
    }
}