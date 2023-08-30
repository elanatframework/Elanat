using System.Xml;

namespace Elanat.XmlData
{
    public class Calendar
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("calendar_root/calendar_list").AppendChild(Tag);

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_calendar_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = File.OpenText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</calendar_list>", FullTag + Environment.NewLine + "</calendar_list>");

            File.WriteAllText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"), XmlText);


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_calendar_xml", FullTag);
        }
    }
}