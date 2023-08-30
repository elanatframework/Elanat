using System.Xml;

namespace Elanat.ListClass
{
    public class Contact
    {
        // Get Contact Type List Item
        public List<ListItem> ContactTypeListItem = new List<ListItem>();
        public void FillContactTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/contact").ChildNodes;

            foreach (XmlNode node in NodeList)
                ContactTypeListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value);
        }

        public static List<List<string>> GetContactTypeListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectNodes("type_root/type_list/contact/type");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                ValueList.Add(node.Attributes["value"].InnerText);
                NameList.Add(Language.GetHandheldLanguage(node.Attributes["name"].InnerText, GlobalLanguage));
            }
            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }
    }
}