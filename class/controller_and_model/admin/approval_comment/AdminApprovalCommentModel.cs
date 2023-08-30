using CodeBehind;

namespace Elanat
{
    public partial class AdminApprovalCommentModel : CodeBehindModel
    {
        public string ApprovalCommentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/approval_comment/");
            ApprovalCommentLanguage = aol.GetAddOnsLanguage("approval_comment");


            // Set Approval Comment Page List
            ActionGetInactiveCommentListModel lm = new ActionGetInactiveCommentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}