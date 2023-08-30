using System.Xml;

namespace Elanat.ListClass
{
    public class Icon
    {
        // Get Icon List Item
        public List<ListItem> IconListItem = new List<ListItem>();
        public void FillIconListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("icon_root/icon_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                IconListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }
    }
}