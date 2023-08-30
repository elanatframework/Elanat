using CodeBehind;

namespace Elanat
{
    public partial class AdminApprovalContentModel : CodeBehindModel
    {
        public string ApprovalContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/approval_content/");
            ApprovalContentLanguage = aol.GetAddOnsLanguage("approval_content");


            // Set Approval Content Page List
            ActionGetInactiveContentListModel lm = new ActionGetInactiveContentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}