using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminTemplateViewMoreModel : CodeBehindModel
    {
        public string GetViewMore(string AdminTemplateId)
        {
            string ViewMore = Template.GetAdminTemplate("box_load/view_more/box");
            string ViewMoreItem = Template.GetAdminTemplate("box_load/view_more/list_item");
            string SumViewMoreItem = "";
            string TmpViewMoreItem = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_admin_template", "@admin_template_id", AdminTemplateId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();
                List<string> ViewMoreList = GlobalClass.GetItemViewMoreList(StaticObject.AdminPath + "/admin_template/");
                AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/");

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