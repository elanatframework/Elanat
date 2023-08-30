using System.Xml;

namespace Elanat.ListClass
{
    public class ContentReply
    {
        // Get Content Reply Type List Item
        public List<ListItem> ContentReplyTypeListItem = new List<ListItem>();
        public void FillContentReplyTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/content_reply").ChildNodes;

            foreach (XmlNode node in NodeList)
                ContentReplyTypeListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value);
        }

        public static List<List<string>> GetContentReplyTypeListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectNodes("type_root/type_list/content_reply/type");

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