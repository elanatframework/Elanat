using System.Xml;

namespace Elanat.ListClass
{
    public class Site
    {
        // Get Site Access Show List Item
        public List<ListItem> SiteAccessShowListItem = new List<ListItem>();
        public void FillSiteAccessShowListItem(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_access_show", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["site_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    SiteAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        // Get Site List Item
        public List<ListItem> SiteListItem = new List<ListItem>();
        public void FillSiteListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteListItem.Add(dbdr.dr["site_global_name"].ToString() + "(" + dbdr.dr["site_name"].ToString() + ")", dbdr.dr["site_id"].ToString());

            db.Close();
        }

        // Get Site Name List Item
        public List<ListItem> SiteNameListItem = new List<ListItem>();
        public void FillSiteNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteNameListItem.Add(dbdr.dr["site_name"].ToString(), dbdr.dr["site_global_name"].ToString());

            db.Close();
        }

        // Get Site Global Name List Item
        public List<ListItem> SiteGlobalNameListItem = new List<ListItem>();
        public void FillSiteGlobalNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_site_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SiteGlobalNameListItem.Add(dbdr.dr["site_global_name"].ToString(), dbdr.dr["site_id"].ToString());

            db.Close();
        }

        // Get Site Page Name List Item
        public List<ListItem> SitePageNameListItem = new List<ListItem>();
        public void FillSitePageNameListItem(string SiteId, string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_all_page_list_by_site_id", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    SitePageNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString());

            db.Close();
        }

        // Get Site Page Name Show In Site List Item
        public List<ListItem> SitePageNameShowInSiteListItem = new List<ListItem>();
        public void FillSitePageNameShowInSiteListItem(string SiteId, string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_all_page_list_by_site_id", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    if (dbdr.dr["page_show_link_in_site"].ToString().TrueFalseToBoolean())
                        SitePageNameShowInSiteListItem.Add(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString());
                }

            db.Close();
        }

        // Get Site Birthday List Item
        public List<ListItem> SiteBirthdayDayListItem = new List<ListItem>();
        public List<ListItem> SiteBirthdayMountListItem = new List<ListItem>();
        public List<ListItem> SiteBirthdayYearListItem = new List<ListItem>();
        public void FillSiteBirthdayListItem(string GlobalLanguage)
        {
            for (int i = 0; i < 31; i++)
                SiteBirthdayDayListItem.Add((i + 1).ToString("00"), (i + 1).ToString("00"));

            for (int i = 0; i < 12; i++)
                SiteBirthdayMountListItem.Add((i + 1).ToString("00"), (i + 1).ToString("00"));

            int CurrentYear = DateTime.Now.Year;
            string SiteBirthday = ElanatConfig.GetNode("date_and_time/site_birthday").InnerText;

            string SiteBirthdayDay = SiteBirthday.Substring(8, 2);
            string SiteBirthdayMount = SiteBirthday.Substring(5, 2);
            string SiteBirthdayYear = SiteBirthday.Substring(0, 4);

            for (int i = int.Parse(SiteBirthdayYear); i <= CurrentYear; i++)
                SiteBirthdayYearListItem.Add(i.ToString(), i.ToString());
        }
    }
}