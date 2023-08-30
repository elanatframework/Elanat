namespace Elanat.ListClass
{
    public class User
    {
        // Get User Group List Item
        public List<ListItem> UserGroupListItem = new List<ListItem>();
        public void FillUserGroupListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_group_list");

            string GuestGroupName = StaticObject.GuestGroup;

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    UserGroupListItem.Add(Language.GetHandheldLanguage(dbdr.dr["group_name"].ToString(), GlobalLanguage), dbdr.dr["group_id"].ToString());

            db.Close();
        }

        // Get User Role List Item
        public List<ListItem> UserRoleListItem = new List<ListItem>();
        public void FillUserRoleListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_role_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    UserRoleListItem.Add(Language.GetHandheldLanguage(dbdr.dr["role_name"].ToString(), GlobalLanguage), dbdr.dr["role_id"].ToString());

            db.Close();
        }

        // Get User Group List Item Without Guest Group
        public List<ListItem> UserGroupListItemWithoutGuestGroup = new List<ListItem>();
        public void FillUserGroupListItemWithoutGuestGroup(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_group_list");

            string GuestGroupName = StaticObject.GuestGroup;

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    if (dbdr.dr["group_name"].ToString() != GuestGroupName)
                        UserGroupListItemWithoutGuestGroup.Add(Language.GetHandheldLanguage(dbdr.dr["group_name"].ToString(), GlobalLanguage), dbdr.dr["group_id"].ToString());

            db.Close();
        }

        public static List<string> GetUserRoleWithValue()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_role_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    list.Add(dbdr.dr["role_name"].ToString());
                    list.Add(dbdr.dr["role_id"].ToString());
                }

            db.Close();
            return list;
        }
    }
}