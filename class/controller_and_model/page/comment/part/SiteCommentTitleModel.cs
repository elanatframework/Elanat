using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentTitleModel : CodeBehindModel
    {
        public string TitleLanguage { get; set; }

        public string TitleValue { get; set; }

        public string TitleCssClass { get; set; }

        public string TitleAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            TitleLanguage = Language.GetAddOnsLanguage("title", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_CommentTitle", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            TitleAttribute += vc.ImportantInputAttribute.GetValue("txt_CommentTitle");

            TitleCssClass = TitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CommentTitle"));
        }
    }
}