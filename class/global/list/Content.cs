using System.Xml;

namespace Elanat.ListClass
{
    public class Content
    {
        // Get Content Access Show List Item
        public List<ListItem> ContentAccessShowListItem = new List<ListItem>();
        public void FillContentAccessShowListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_content_access_show", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ContentAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Content Meta Keywords List Item
        public List<ListItem> ContentMetaKeywordsListItem = new List<ListItem>();
        public void FillContentMetaKeywordsListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_content_keywords", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_keywords_text"].ToString();
                    TmpListItem.Value = dbdr.dr["content_id"].ToString();
                    TmpListItem.Selected = true;

                    ContentMetaKeywordsListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Content Meta Keywords List Item
        public List<ListItem> ContentSourceListItem = new List<ListItem>();
        public void FillContentSourceListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_content_source", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_source_text"].ToString();
                    TmpListItem.Value = dbdr.dr["content_id"].ToString();
                    TmpListItem.Selected = true;

                    ContentSourceListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Content Status List Item
        public List<ListItem> ContentStatusListItem = new List<ListItem>();
        public void FillContentStatusListItem(string GlobalLanguage)
        {
            ContentStatusListItem.Add(Language.GetLanguage("active", GlobalLanguage), "active");
            ContentStatusListItem.Add(Language.GetLanguage("inactive", GlobalLanguage), "inactive");
            ContentStatusListItem.Add(Language.GetLanguage("draft", GlobalLanguage), "draft");
            ContentStatusListItem.Add(Language.GetLanguage("trash", GlobalLanguage), "trash");
            ContentStatusListItem.Add(Language.GetLanguage("delay", GlobalLanguage), "delay");
            ContentStatusListItem.Add(Language.GetLanguage("admin_note", GlobalLanguage), "admin_note");
        }

        // Get Content Type List Item
        public List<ListItem> ContentTypeListItem = new List<ListItem>();
        public void FillContentTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/content").ChildNodes;

            foreach (XmlNode node in NodeList)
                ContentTypeListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value);
        }

        // Get Read More Status List Item
        public List<ListItem> ReadMoreStatusListItem = new List<ListItem>();
        public void FillReadMoreStatusListItem(string GlobalLanguage)
        {
            ReadMoreStatusListItem.Add(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            ReadMoreStatusListItem.Add(Language.GetLanguage("save", GlobalLanguage), "save");
            ReadMoreStatusListItem.Add(Language.GetLanguage("new_page", GlobalLanguage), "new_page");
        }

        // Get Content Page Number Location List Item
        public List<ListItem> ContentPageNumberLocationListItem = new List<ListItem>();
        public void FillContentPageNumberLocationListItem(string GlobalLanguage)
        {
            ContentPageNumberLocationListItem.Add(Language.GetLanguage("before", GlobalLanguage), "before");
            ContentPageNumberLocationListItem.Add(Language.GetLanguage("after", GlobalLanguage), "after");
            ContentPageNumberLocationListItem.Add(Language.GetLanguage("both", GlobalLanguage), "both");
        }
    }
}