using CodeBehind;

namespace Elanat
{
    public class SiteCommentMobileNumberModel : CodeBehindModel
    {
        public string MobileNumberLanguage { get; set; }

        public string MobileNumberValue { get; set; }

        public string MobileNumberCssClass { get; set; }

        public string MobileNumberAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            MobileNumberLanguage = Language.GetAddOnsLanguage("mobile_number", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_MobileNumber", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            MobileNumberAttribute += vc.ImportantInputAttribute.GetValue("txt_MobileNumber");

            MobileNumberCssClass = MobileNumberCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MobileNumber"));
        }
    }
}