namespace Elanat.ListClass
{
    public class EditorTemplate
    {
        // Get EditorT emplate Access Show List Item
        public List<ListItem> EditorTemplateAccessShowListItem = new List<ListItem>();
        public void FillEditorTemplateAccessShowListItem(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_editor_template_access_show", "@editor_template_id", EditorTemplateId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["editor_template_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    EditorTemplateAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}