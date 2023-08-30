using System.Xml;

namespace Elanat.ListClass
{
    public class Extension
    {
        public static List<string> GetAuthorizedExtensionList()
        {
            XmlNodeList NodeList = StaticObject.AuthorizedExtensionDocument.SelectNodes("authorized_extension_root/authorized_extension_list/authorized_extension");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
            {
                list.Add(node.InnerText);
            }
            return list;
        }

        public static List<string> GetUnauthorizedExtensionList()
        {
            XmlNodeList NodeList = StaticObject.AuthorizedExtensionDocument.SelectNodes("authorized_extension_root/authorized_extension_list/unauthorized_extension");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
            {
                list.Add(node.InnerText);
            }
            return list;
        }
    }
}