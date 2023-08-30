using CodeBehind;

namespace Elanat
{
    public partial class AdminContactModel : CodeBehindModel
    {
        public string ContactLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/contact/");
            ContactLanguage = aol.GetAddOnsLanguage("contact");


            // Set Approval Comment Page List
            ActionGetContactListModel lm = new ActionGetContactListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}