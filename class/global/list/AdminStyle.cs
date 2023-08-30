using System.Xml;

namespace Elanat.ListClass
{
    public class AdminStyle
    {
        // Get Admin Style List Item
        public List<ListItem> AdminStyleListItem = new List<ListItem>();
        public void FillAdminStyleListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_admin_style_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    AdminStyleListItem.Add(dbdr.dr["admin_style_name"].ToString(), dbdr.dr["admin_style_id"].ToString());

            db.Close();
        }

        // Get Admin Style Name List Item
        public List<ListItem> AdminStyleNameListItem = new List<ListItem>();
        public void FillAdminStyleNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_admin_style_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    AdminStyleNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["admin_style_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()), dbdr.dr["admin_style_name"].ToString());

            db.Close();
        }
    }
}