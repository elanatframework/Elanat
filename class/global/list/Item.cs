namespace Elanat.ListClass
{
    public class Item
    {
        // Get Item Menu List Item
        public List<ListItem> ItemMenuListItem = new List<ListItem>();
        public void FillItemMenuListItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_item_menu", "@item_id", ItemId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["item_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ItemMenuListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Item Access Show List Item
        public List<ListItem> ItemAccessShowListItem = new List<ListItem>();
        public void FillItemAccessShowListItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_item_access_show", "@item_id", ItemId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["item_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ItemAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}