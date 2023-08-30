using CodeBehind;

namespace Elanat
{
    public partial class AdminFootPrintModel : CodeBehindModel
    {
        public string FootPrintLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/foot_print/");
            FootPrintLanguage = aol.GetAddOnsLanguage("foot_print");


            // Set Foot Print Page List
            ActionGetFootPrintListModel lm = new ActionGetFootPrintListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}