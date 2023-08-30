using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentAboutModel : CodeBehindModel
    {
        public string AboutLanguage { get; set; }

        public string AboutValue { get; set; }

        public string AboutCssClass { get; set; }

        public string AboutAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            AboutLanguage = Language.GetAddOnsLanguage("about", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_About", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            AboutAttribute += vc.ImportantInputAttribute.GetValue("txt_About");

            AboutCssClass = AboutCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_About"));
        }
    }
}