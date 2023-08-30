using System.Xml;

namespace Elanat.ListClass
{
    public class Role
    {
        // Get Role List Item
        public List<ListItem> ActiveRoleNameListItem = new List<ListItem>();
        public void FillActiveRoleNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_active_role_list", new List<string>(), new List<string>(), false);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ActiveRoleNameListItem.Add(dbdr.dr["role_name"].ToString(), dbdr.dr["role_id"].ToString());

            db.Close();
        }

        // Get Role Bit Column Access List Item
        public List<ListItem> RoleBitColumnAccessListItem = new List<ListItem>();
        public void FillRoleBitColumnAccessListItem()
        {
            XmlNodeList NodeList = StaticObject.RoleBitColumnAccessNodeList;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    RoleBitColumnAccessListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, StaticObject.GetCurrentAdminGlobalLanguage()), node.Attributes["name"].Value);
        }

        // Get Role Bit Column Access List Item
        public List<ListItem> RoleBitColumnAccessWithoutLanguageListItem = new List<ListItem>();
        public void FillRoleBitColumnAccessWithoutLanguageListItem()
        {
            XmlNodeList NodeList = StaticObject.RoleBitColumnAccessNodeList;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    RoleBitColumnAccessListItem.Add(node.Attributes["name"].Value, node.Attributes["name"].Value);
        }

        // Get Role Type List Item
        public List<ListItem> RoleTypeListItem = new List<ListItem>();
        public void FillRoleTypeListItem(string GlobalLanguage)
        {
            RoleTypeListItem.Add(Language.GetLanguage("admin", GlobalLanguage), "admin");
            RoleTypeListItem.Add(Language.GetLanguage("member", GlobalLanguage), "member");
            RoleTypeListItem.Add(Language.GetLanguage("guest", GlobalLanguage), "guest");
        }

        // Get Role Cache Type List Item
        public List<ListItem> RoleCacheTypeListItem = new List<ListItem>();
        public void FillRoleCacheTypeListItem(string GlobalLanguage)
        {
            RoleTypeListItem.Add(Language.GetLanguage("memory", GlobalLanguage), "memory");
            RoleTypeListItem.Add(Language.GetLanguage("disk", GlobalLanguage), "disk");
        }
    }
}