namespace Elanat.ListClass
{
    public class SiteTemplate
    {
        // Get Site Template List Item
        public List<ListItem> SiteTemplateListItem = new List<ListItem>();
        public void FillSiteTemplateListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_template_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteTemplateListItem.Add(dbdr.dr["site_template_name"].ToString(), dbdr.dr["site_template_id"].ToString());

            db.Close();
        }

        // Get Site Template Name List Item
        public List<ListItem> SiteTemplateNameListItem = new List<ListItem>();
        public void FillSiteTemplateNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_template_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteTemplateNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["site_template_name"].ToString(), GlobalLanguage), dbdr.dr["site_template_name"].ToString());

            db.Close();
        }
        public static List<string> GetTemplateList()
        {
            List<string> list = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(StaticObject.ServerMapPath(@StaticObject.SitePath + "template/site/"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
            list.Add(null);
            foreach (FileInfo fi in fileInfo)
            {
                list.Add(fi.Name.ToString());
            }
            return list;
        }
    }
}