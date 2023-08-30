using System.Xml;

namespace Elanat.ListClass
{
    public class Page
    {
        // Get Page Access Show List Item
        public List<ListItem> PageAccessShowListItem = new List<ListItem>();
        public void FillPageAccessShowListItem(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_page_access_show", "@page_id", PageId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["page_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    PageAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Page Site List Item
        public List<ListItem> PageSiteListItem = new List<ListItem>();
        public void FillPageSiteListItem(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_page_site", "@page_id", PageId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["page_id"].ToString();
                    TmpListItem.Value = dbdr.dr["site_id"].ToString();
                    TmpListItem.Selected = true;

                    PageSiteListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Page List Item
        public List<ListItem> PageListItem = new List<ListItem>();
        public void FillPageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_page_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    PageListItem.Add(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_id"].ToString());

            db.Close();
        }

        // Get Page Name List Item
        public List<ListItem> PageNameListItem = new List<ListItem>();
        public void FillPageNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_page_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    PageNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString());

            db.Close();
        }

        public static List<List<string>> GetPagePartListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/page_location_list/page_location.xml"));
            XmlNodeList NodeList = doc.SelectNodes("page_location_root/page_location_list/page_location");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                ValueList.Add(node.Attributes["value"].InnerText);
                NameList.Add(Language.GetLanguage(node.Attributes["value"].InnerText, GlobalLanguage));
            }
            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }
    }
}