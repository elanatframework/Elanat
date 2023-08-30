namespace Elanat.ListClass
{
    public class View
    {
        // Get View Match Type List Item
        public List<ListItem> ViewMatchTypeListItem = new List<ListItem>();
        public void FillViewMatchTypeListItem(string GlobalLanguage)
        {
            ViewMatchTypeListItem.Add(Language.GetLanguage("full_match", GlobalLanguage), "full_match");
            ViewMatchTypeListItem.Add(Language.GetLanguage("none_query", GlobalLanguage), "none_query");
            ViewMatchTypeListItem.Add(Language.GetLanguage("all_query", GlobalLanguage), "all_query");
            ViewMatchTypeListItem.Add(Language.GetLanguage("exist", GlobalLanguage), "exist");
            ViewMatchTypeListItem.Add(Language.GetLanguage("start_by", GlobalLanguage), "start_by");
            ViewMatchTypeListItem.Add(Language.GetLanguage("end_by", GlobalLanguage), "end_by");
            ViewMatchTypeListItem.Add(Language.GetLanguage("regex", GlobalLanguage), "regex");
        }

        // Get View Query String List Item
        public List<ListItem> ViewQueryStringListItem = new List<ListItem>();
        public void FillViewQueryStringListItem(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_current_view_query_string", "@view_id", ViewId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["view_query_string"].ToString();
                    TmpListItem.Value = dbdr.dr["view_id"].ToString();
                    TmpListItem.Selected = true;

                    ViewQueryStringListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}