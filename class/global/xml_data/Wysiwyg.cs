using System.Xml;

namespace Elanat.XmlData
{
    public class Wysiwyg
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"));

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("wysiwyg_root/wysiwyg_list").AppendChild(Tag);

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"));


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_wysiwyg_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = File.OpenText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</wysiwyg_list>", FullTag + Environment.NewLine + "</wysiwyg_list>");

            File.WriteAllText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"), XmlText);


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_wysiwyg_xml", FullTag);
        }
    }
}