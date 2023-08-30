using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpAvatarPathModel : CodeBehindModel
    {
        public string AvatarPathLanguage { get; set; }
        public string UseAvatarPathLanguage { get; set; }

        public string AvatarPathTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
            AvatarPathLanguage = aol.GetAddOnsLanguage("avatar_path");
            UseAvatarPathLanguage = aol.GetAddOnsLanguage("use_avatar_path");
        }
    }
}