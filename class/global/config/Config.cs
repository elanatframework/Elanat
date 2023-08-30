using System.Xml;

namespace Elanat
{
    public class WebConfig
    {
        public static XmlNode GetNode(string TagPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "Web.config.xml"));

            XmlNodeList NodeList = doc.SelectNodes("configuration/" + TagPath);

            return NodeList[0];
        }

        public static XmlNode GetNode(string TagPath, int Item)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "Web.config.xml"));

            XmlNodeList NodeList = doc.SelectNodes("configuration/" + TagPath);

            return NodeList[Item];
        }

        public static string GetWebConfig(string TagPath, int Item = 0, string Attr = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "Web.config.xml"));
            XmlNodeList NodeList = doc.SelectNodes("configuration/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerText;

            return CurentTemplate;
        }

        public static void SetWebConfig(string value, string TagName, int Item = 0, string Attr = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "Web.config.xml"));

            if (Attr != null)
                doc.SelectSingleNode("configuration/" + TagName + "[" + (Item + 1).ToString() + "]").Attributes[Attr].Value = value;
            else
                doc.SelectSingleNode("configuration/" + TagName + "[" + (Item + 1).ToString() + "]").InnerText = value;

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "Web.config.xml"));
        }
    }
}