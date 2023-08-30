using CodeBehind;

namespace Elanat
{
    public partial class SiteContactTextModel : CodeBehindModel
    {
        public string TextLanguage { get; set; }

        public string TextValue { get; set; }

        public string TextCssClass { get; set; }

        public string TextAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            TextLanguage = Language.GetAddOnsLanguage("text", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Text", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            TextAttribute += vc.ImportantInputAttribute.GetValue("txt_Text");

            TextCssClass = TextCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Text"));
        }
    }
}