using CodeBehind;

namespace Elanat
{
    public partial class MemberUserFootPrintModel : CodeBehindModel
    {
        public string MembeLanguage { get; set; }
        public string UserFootPrintLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_foot_print/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserFootPrintLanguage = aol.GetAddOnsLanguage("user_foot_print");


            // Set Foot Print Page List
            ActionGetUserFootPrintListModel lm = new ActionGetUserFootPrintListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue;
        }
    }
}