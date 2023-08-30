using System.Xml;

namespace Elanat.ListClass
{
    public class System
    {
        // Get System List Item
        public List<ListItem> SystemListItem = new List<ListItem>();
        public void FillSystemListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_system_list");


            // Get System List Document
            XmlDocument SystemListDocument = new XmlDocument();
            SystemListDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/system_list/system.xml"));
            XmlNodeList System = SystemListDocument.SelectSingleNode("system_root/system_list").ChildNodes;


            foreach (XmlNode node in System)
                SystemListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage).ToUpperFirstChar(), node.Attributes["name"].Value);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    foreach (XmlNode node in System)
                        if ((dbdr.dr["system_name"].ToString() == node.Attributes["name"].Value) || string.IsNullOrEmpty(dbdr.dr["system_name"].ToString()))
                            goto WhileContinue;

                    SystemListItem.Add(Language.GetHandheldLanguage(dbdr.dr["system_name"].ToString(), GlobalLanguage).ToUpperFirstChar(), dbdr.dr["system_name"].ToString());

                WhileContinue:
                    continue;
                }

            db.Close();
        }
    }
}