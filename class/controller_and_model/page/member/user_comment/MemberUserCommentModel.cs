using CodeBehind;

namespace Elanat
{
    public partial class MemberUserCommentModel : CodeBehindModel
    {
        public string MembeLanguage { get; set; }
        public string UserCommentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_comment/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserCommentLanguage = aol.GetAddOnsLanguage("user_comment");


            // Set Comment Page List
            ActionGetUserCommentListModel lm = new ActionGetUserCommentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue;
        }
    }
}