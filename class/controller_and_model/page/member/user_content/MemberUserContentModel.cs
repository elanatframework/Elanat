using CodeBehind;

namespace Elanat
{
    public partial class MemberUserContentModel : CodeBehindModel
    {
        public string MembeLanguage { get; set; }
        public string UserContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_content/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserContentLanguage = aol.GetAddOnsLanguage("user_content");


            // Set Content Page List
            ActionGetUserContentListModel lm = new ActionGetUserContentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue;
        }
    }
}