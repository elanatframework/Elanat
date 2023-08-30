using CodeBehind;

namespace Elanat
{
    public partial class ActionGetLanguageViewMoreModel : CodeBehindModel
    {
        public string GetViewMore(string LanguageId, string Path = null)
        {
            string ViewMore = Template.GetAdminTemplate("box_load/view_more/box");
            string ViewMoreItem = Template.GetAdminTemplate("box_load/view_more/list_item");
            string SumViewMoreItem = "";
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_language", "@language_id", LanguageId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();
                List<string> ViewMoreList = GlobalClass.GetItemViewMoreList(Path);
                AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), Path);

                foreach (string Text in ViewMoreList)
                {
                    SumViewMoreItem += ViewMoreItem.Replace("$_asp item_value;", dbdr.dr[Text].ToString()).Replace("$_asp item_title;", aol.GetAddOnsLanguage(Text));
                }
            }

            db.Close();

            return ViewMore.Replace("$_asp item;", SumViewMoreItem);
        }
    }
}