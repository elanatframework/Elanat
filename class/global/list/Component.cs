using System.Xml;

namespace Elanat.ListClass
{
    public class Component
    {
        // Get Component Access Show List Item
        public List<ListItem> ComponentAccessShowListItem = new List<ListItem>();
        public void FillComponentAccessShowListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_show", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component Access Add List Item
        public List<ListItem> ComponentAccessAddListItem = new List<ListItem>();
        public void FillComponentAccessAddListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_add", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessAddListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component Access Delete Own List Item
        public List<ListItem> ComponentAccessDeleteOwnListItem = new List<ListItem>();
        public void FillComponentAccessDeleteOwnListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_delete_own", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessDeleteOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component Access Delete All List Item
        public List<ListItem> ComponentAccessDeleteAllListItem = new List<ListItem>();
        public void FillComponentAccessDeleteAllListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_delete_all", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessDeleteAllListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component Access Edit Own List Item
        public List<ListItem> ComponentAccessEditOwnListItem = new List<ListItem>();
        public void FillComponentAccessEditOwnListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_edit_own", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessEditOwnListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component Access Edit All List Item
        public List<ListItem> ComponentAccessEditAllListItem = new List<ListItem>();
        public void FillComponentAccessEditAllListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_access_edit_all", "@component_id", ComponentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ComponentAccessEditAllListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Component List Item
        public List<ListItem> ComponentListItem = new List<ListItem>();
        public void FillComponentListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ComponentListItem.Add(Language.GetHandheldLanguage(dbdr.dr["component_name"].ToString(), GlobalLanguage), dbdr.dr["component_id"].ToString());

            db.Close();
        }

        // Get Component Name List Item
        public List<ListItem> ComponentNameListItem = new List<ListItem>();
        public void FillComponentNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_component_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ComponentNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["component_name"].ToString(), GlobalLanguage), dbdr.dr["component_name"].ToString());

            db.Close();
        }
    }
}