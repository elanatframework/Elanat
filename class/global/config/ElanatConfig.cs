using System.Xml;

namespace Elanat
{
    public class ElanatConfig
    {
        public static XmlNode GetNode(string TagPath)
        {
            XmlNodeList NodeList = StaticObject.ConfigDocument.SelectNodes("elanat_root/" + TagPath);

            return NodeList[0];
        }

        public static XmlNode GetNode(string TagPath, int Item)
        {
            XmlNodeList NodeList = StaticObject.ConfigDocument.SelectNodes("elanat_root/" + TagPath);

            return NodeList[Item];
        }

        public static string GetElanatConfig(string TagPath, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList = StaticObject.ConfigDocument.SelectNodes("elanat_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerText;

            return CurentTemplate;
        }

        // OVerload
        public static string GetElanatConfig(string TagPath)
        {
            return GetElanatConfig(TagPath, 0, null);
        }

        // OVerload
        public static string GetElanatConfig(string TagPath, int Item)
        {
            return GetElanatConfig(TagPath, Item, null);
        }

        // OVerload
        public static string GetElanatConfig(string TagPath, string Attr)
        {
            return GetElanatConfig(TagPath, 0, Attr);
        }

        public static void SetElanatConfig(string value, string TagName, int Item = 0, string Attr = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            if (Attr != null)
                doc.SelectSingleNode("elanat_root/" + TagName + "[" + (Item + 1).ToString() + "]").Attributes[Attr].Value = value;
            else
                doc.SelectSingleNode("elanat_root/" + TagName + "[" + (Item + 1).ToString() + "]").InnerText = value;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));
        }

        // Overload
        public static void SetElanatConfig(string value, string TagName)
        {
            SetElanatConfig(value, TagName, 0, null);
        }

        // Overload
        public static void SetElanatConfig(string value, string TagName, int Item)
        {
            SetElanatConfig(value, TagName, Item, null);
        }

        // Overload
        public static void SetElanatConfig(string value, string TagName, string Attr)
        {
            SetElanatConfig(value, TagName, 0, Attr);
        }
    }
}