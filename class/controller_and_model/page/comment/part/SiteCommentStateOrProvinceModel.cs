using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentStateOrProvinceModel : CodeBehindModel
    {
        public string StateOrProvinceLanguage { get; set; }

        public string StateOrProvinceValue { get; set; }

        public string StateOrProvinceCssClass { get; set; }

        public string StateOrProvinceAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            StateOrProvinceLanguage = Language.GetAddOnsLanguage("state_or_province", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_StateOrProvince", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            StateOrProvinceAttribute += vc.ImportantInputAttribute.GetValue("txt_StateOrProvince");

            StateOrProvinceCssClass = StateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_StateOrProvince"));
        }
    }
}