namespace Elanat.ListClass
{
    public class Group
    {
        // Get Group Role List Item
        public List<ListItem> GroupRoleListItem = new List<ListItem>();
        public void FillGroupRoleListItem(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_group_role", "@group_id", GroupId);


            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["group_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    GroupRoleListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}