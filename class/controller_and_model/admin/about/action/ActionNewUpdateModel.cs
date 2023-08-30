using CodeBehind;

namespace Elanat
{
    public partial class ActionNewUpdateModel : CodeBehindModel
    {
        public string BreakSupportCheckLanguage { get; set; }
        public string UpdateLanguage { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/");
            UpdateLanguage = aol.GetAddOnsLanguage("update");
            BreakSupportCheckLanguage = aol.GetAddOnsLanguage("break_support_check");
        }
    }
}