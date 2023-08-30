namespace Elanat.ListClass
{
    public class Attachment
    {
        // Get Attachment Access Show List Item
        public List<ListItem> AttachmentAccessShowListItem = new List<ListItem>();
        public void FillAttachmentAccessShowListItem(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_attachment_access_show", "@attachment_id", AttachmentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["attachment_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    AttachmentAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Attachment Content List Item
        public List<ListItem> AttachmentContentListItem = new List<ListItem>();
        public void FillAttachmentContentListItem(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_attachment_content", "@attachment_id", AttachmentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_id"].ToString();
                    TmpListItem.Value = dbdr.dr["attachment_id"].ToString();
                    TmpListItem.Selected = true;

                    AttachmentContentListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}