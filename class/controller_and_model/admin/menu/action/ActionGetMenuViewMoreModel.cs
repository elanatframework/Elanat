using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetMenuViewMoreModel : CodeBehindModel
    {
        public string GetViewMore(string MenuId)
        {
            string ViewMore = Template.GetAdminTemplate("box_load/view_more/box");
            string ViewMoreItem = Template.GetAdminTemplate("box_load/view_more/list_item");
            string SumViewMoreItem = "";
            string TmpViewMoreItem = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_menu", "@menu_id", MenuId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();
                List<string> ViewMoreList = GlobalClass.GetItemViewMoreList(StaticObject.AdminPath + "/menu/");
                AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/menu/");

                foreach (string Text in ViewMoreList)
                {
                    TmpViewMoreItem = ViewMoreItem;
                    TmpViewMoreItem = TmpViewMoreItem.Replace("$_asp item_title;", aol.GetAddOnsLanguage(Text));
                    TmpViewMoreItem = TmpViewMoreItem.Replace("$_asp item_value;", dbdr.dr[Text].ToString());
                    SumViewMoreItem += TmpViewMoreItem;
                }
            }

            db.Close();

            return ViewMore.Replace("$_asp item;", SumViewMoreItem);
        }
    }
}