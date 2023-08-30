using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentRealNameModel : CodeBehindModel
    {
        public string RealNameLanguage { get; set; }

        public string RealNameValue { get; set; }

        public string RealNameCssClass { get; set; }

        public string RealNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            RealNameLanguage = Language.GetAddOnsLanguage("real_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_RealName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            RealNameAttribute += vc.ImportantInputAttribute.GetValue("txt_RealName");

            RealNameCssClass = RealNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RealName"));
        }
    }
}