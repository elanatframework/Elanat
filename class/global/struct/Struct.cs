using System.Xml;

namespace Elanat
{
    public class Struct
    {
        public static XmlNode GetNode(string TagPath)
        {
            XmlNodeList NodeList = StaticObject.StructDocument.SelectNodes("struct_root/" + TagPath);

            return NodeList[0];
        }

        public static XmlNode GetNode(string TagPath, int Item)
        {
            XmlNodeList NodeList = StaticObject.StructDocument.SelectNodes("struct_root/" + TagPath);

            return NodeList[Item];
        }

        public static void SetStruct(string value, string TagName, int Item = 0, string Attr = null)
        {
            XmlDocument StructDocument = new XmlDocument();
            StructDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/struct/struct.xml"));

            if (Attr != null)
                StructDocument.SelectSingleNode("struct_root/" + TagName + "[" + (Item + 1).ToString() + "]").Attributes[Attr].Value = value;
            else
                StructDocument.SelectSingleNode("struct_root/" + TagName + "[" + (Item + 1).ToString() + "]").InnerText = value;

            StructDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/struct/struct.xml"));
        }
    }
}