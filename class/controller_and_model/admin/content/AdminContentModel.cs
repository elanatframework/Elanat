using CodeBehind;

namespace Elanat
{
    public partial class AdminContentModel : CodeBehindModel
    {
        public string ContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/content/");
            ContentLanguage = aol.GetAddOnsLanguage("content");


            // Set Content Page List
            ActionGetContentListModel lm = new ActionGetContentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}