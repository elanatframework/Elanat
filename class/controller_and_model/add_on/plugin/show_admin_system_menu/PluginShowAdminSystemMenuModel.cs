using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminSystemMenuModel : CodeBehindModel
    {
        public void SetValue()
        {
            string BoxTemplate = Template.GetAdminTemplate("part/system_menu/box");
            string ListItemTemplate = Template.GetAdminTemplate("part/system_menu/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            // Set Current Value
            ListClass.System lcs = new ListClass.System();
            lcs.FillSystemListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcs.SystemListItem)
            {
                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp system_local_name;", item.Text);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db system_name;", item.Value);

                SumListItemTemplate += TmpListItemTemplate;
            }

            BoxTemplate = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);

            Write(BoxTemplate);
        }
    }
}