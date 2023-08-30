namespace Elanat.ListClass
{
    public class Plugin
    {
        // Get Plugin Menu List Item
        public List<ListItem> PluginMenuListItem = new List<ListItem>();
        public List<ListItem> PluginMenuQueryStringListItem = new List<ListItem>();
        public void FillPluginMenuListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_menu", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginMenuListItem.Add(TmpListItem);

                    PluginMenuQueryStringListItem.Add(dbdr.dr["menu_plugin_query_string"].ToString(), dbdr.dr["menu_id"].ToString());
                }

            db.Close();
        }

        // Get Plugin Access Show List Item
        public List<ListItem> PluginAccessShowListItem = new List<ListItem>();
        public void FillPluginAccessShowListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_show", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Plugin Access Add List Item
        public List<ListItem> PluginAccessAddListItem = new List<ListItem>();
        public void FillPluginAccessAddListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_add", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessAddListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Plugin Access Delete Own List Item
        public List<ListItem> PluginAccessDeleteOwnListItem = new List<ListItem>();
        public void FillPluginAccessDeleteOwnListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_delete_own", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessDeleteOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Plugin Access Delete All List Item
        public List<ListItem> PluginAccessDeleteAllListItem = new List<ListItem>();
        public void FillPluginAccessDeleteAllListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_delete_all", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessDeleteAllListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Plugin Access Edit Own List Item
        public List<ListItem> PluginAccessEditOwnListItem = new List<ListItem>();
        public void FillPluginAccessEditOwnListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_edit_own", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessEditOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Plugin Access Edit All List Item
        public List<ListItem> PluginAccessEditAllListItem = new List<ListItem>();
        public void FillPluginAccessEditAllListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_plugin_access_edit_all", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PluginAccessEditAllListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}