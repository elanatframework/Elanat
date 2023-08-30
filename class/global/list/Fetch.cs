namespace Elanat.ListClass
{
    public class Fetch
    {
        // Get Fetch Menu List Item
        public List<ListItem> FetchMenuListItem = new List<ListItem>();
        public void FillFetchMenuListItem(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_fetch_menu", "@fetch_id", FetchId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["fetch_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    FetchMenuListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Fetch Access Show List Item
        public List<ListItem> FetchAccessShowListItem = new List<ListItem>();
        public void FillFetchAccessShowListItem(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_fetch_access_show", "@fetch_id", FetchId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["fetch_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    FetchAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}