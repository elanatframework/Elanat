using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginShowAdminSystemMenuModel
    {
        public void SetValue()
        {
            string BoxTemplate = Template.GetAdminTemplate("part/system_menu/box");
            string ListItemTemplate = Template.GetAdminTemplate("part/system_menu/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            // Set Current Value
            ListClass lc = new ListClass();
            lc.FillSystemListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lc.SystemListItem)
            {
                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp system_local_name;", item.Text);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db system_name;", item.Value);

                SumListItemTemplate += TmpListItemTemplate;
            }

            BoxTemplate = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);

            HttpContext.Current.Response.Write(BoxTemplate);
        }
    }
}