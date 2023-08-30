namespace Elanat.ListClass
{
    public class Module
    {
        // Get Module Menu List Item
        public List<ListItem> ModuleMenuListItem = new List<ListItem>();
        public List<ListItem> ModuleMenuQueryStringListItem = new List<ListItem>();
        public void FillModuleMenuListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_menu", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleMenuListItem.Add(TmpListItem);

                    ModuleMenuQueryStringListItem.Add(dbdr.dr["menu_module_query_string"].ToString(), dbdr.dr["menu_id"].ToString());
                }

            db.Close();
        }

        // Get Module Access Show List Item
        public List<ListItem> ModuleAccessShowListItem = new List<ListItem>();
        public void FillModuleAccessShowListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_show", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Module Access Add List Item
        public List<ListItem> ModuleAccessAddListItem = new List<ListItem>();
        public void FillModuleAccessAddListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_add", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessAddListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Module Access Delete Own List Item
        public List<ListItem> ModuleAccessDeleteOwnListItem = new List<ListItem>();
        public void FillModuleAccessDeleteOwnListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_delete_own", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessDeleteOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Module Access Delete All List Item
        public List<ListItem> ModuleAccessDeleteAllListItem = new List<ListItem>();
        public void FillModuleAccessDeleteAllListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_delete_all", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessDeleteAllListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Module Access Edit Own List Item
        public List<ListItem> ModuleAccessEditOwnListItem = new List<ListItem>();
        public void FillModuleAccessEditOwnListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_edit_own", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessEditOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Module Access Edit All List Item
        public List<ListItem> ModuleAccessEditAllListItem = new List<ListItem>();
        public void FillModuleAccessEditAllListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_module_access_edit_all", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ModuleAccessEditAllListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}