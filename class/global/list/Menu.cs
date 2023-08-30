using System.Xml;

namespace Elanat.ListClass
{
    public class Menu
    {
        // Get Menu Access Show List Item
        public List<ListItem> MenuAccessShowListItem = new List<ListItem>();
        public void FillMenuAccessShowListItem(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_menu_access_show", "@menu_id", MenuId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    MenuAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Menu List Item
        public List<ListItem> MenuListItem = new List<ListItem>();
        public void FillMenuListItem(string SiteId)
        {
            // Get Menu Name And Menu Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_menu_list_by_site_id", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    MenuListItem.Add(dbdr.dr["menu_name"].ToString(), dbdr.dr["menu_id"].ToString());

            db.Close();
        }

        // Get Menu Location List Item
        public List<ListItem> MenuLocationListItem = new List<ListItem>();
        public void FillMenuLocationListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/page_location_list/page_location.xml"));

            XmlNodeList PageLocation = doc.SelectSingleNode("page_location_root/page_location_list").ChildNodes;

            foreach (XmlNode node in PageLocation)
            {
                string Value = node.Attributes["value"].Value;
                string Name = Language.GetHandheldLanguage(Value, StaticObject.GetCurrentAdminGlobalLanguage());

                MenuLocationListItem.Add(Name, Value);
            }
        }
    }
}