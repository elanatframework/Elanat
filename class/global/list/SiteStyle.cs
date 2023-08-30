namespace Elanat.ListClass
{
    public class SiteStyle
    {
        // Get Site Style List Item
        public List<ListItem> SiteStyleListItem = new List<ListItem>();
        public void FillSiteStyleListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_style_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteStyleListItem.Add(dbdr.dr["site_style_name"].ToString(), dbdr.dr["site_style_id"].ToString());

            db.Close();
        }

        // Get Site Style Name List Item
        public List<ListItem> SiteStyleNameListItem = new List<ListItem>();
        public void FillSiteStyleNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_style_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteStyleNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["site_style_name"].ToString(), GlobalLanguage), dbdr.dr["site_style_name"].ToString());

            db.Close();
        }
        public static List<string> GetStyleList()
        {
            List<string> list = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(StaticObject.ServerMapPath(@StaticObject.SitePath + "client/style/site/"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.css", SearchOption.TopDirectoryOnly);
            list.Add(null);
            foreach (FileInfo fi in fileInfo)
            {
                list.Add(fi.Name.ToString());
            }
            return list;
        }
    }
}