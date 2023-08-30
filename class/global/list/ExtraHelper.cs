namespace Elanat.ListClass
{
    public class ExtraHelper
    {
        // Get ExtraHelper Access Show List Item
        public List<ListItem> ExtraHelperAccessShowListItem = new List<ListItem>();
        public void FillExtraHelperAccessShowListItem(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_extra_helper_access_show", "@extra_helper_id", ExtraHelperId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["extra_helper_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ExtraHelperAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}