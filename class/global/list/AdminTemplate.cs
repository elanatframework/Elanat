using System.Xml;

namespace Elanat.ListClass
{
    public class AdminTemplate
    {
        // Get Admin Template List Item
        public List<ListItem> AdminTemplateListItem = new List<ListItem>();
        public void FillAdminTemplateListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_admin_template_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    AdminTemplateListItem.Add(dbdr.dr["admin_template_name"].ToString(), dbdr.dr["admin_template_id"].ToString());

            db.Close();
        }

        // Get Admin Template Name List Item
        public List<ListItem> AdminTemplateNameListItem = new List<ListItem>();
        public void FillAdminTemplateNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_admin_template_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    AdminTemplateNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["admin_template_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()), dbdr.dr["admin_template_name"].ToString());

            db.Close();
        }
    }
}