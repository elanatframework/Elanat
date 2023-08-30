using System.Xml;

namespace Elanat.ListClass
{
    public class Comment
    {
        // Get Comment Type List Item
        public List<ListItem> CommentTypeListItem = new List<ListItem>();
        public void FillCommentTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/comment").ChildNodes;

            foreach (XmlNode node in NodeList)
                CommentTypeListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value);
        }
    }
}