using CodeBehind;

namespace Elanat
{
    public partial class AdminRecycleBinModel : CodeBehindModel
    {
        public string ContentLanguage { get; set; }
        public string RecycleBinLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/recycle_bin/");
            RecycleBinLanguage = aol.GetAddOnsLanguage("recycle_bin");
            ContentLanguage = aol.GetAddOnsLanguage("content");


            // Set Recycle Bin Page List
            ActionGetTrashContentListModel lm = new ActionGetTrashContentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}