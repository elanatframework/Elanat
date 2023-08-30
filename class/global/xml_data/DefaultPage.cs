﻿using System.Xml;

namespace Elanat.XmlData
{
    public class DefaultPage
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/default_page_list/default_page.xml"));

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("default_page_root/default_page_list").AppendChild(Tag);

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/default_page_list/default_page.xml"));


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_default_page_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = File.OpenText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/default_page_list/default_page.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</default_page_list>", FullTag + Environment.NewLine + "</default_page_list>");

            File.WriteAllText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/default_page_list/default_page.xml"), XmlText);


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_default_page_xml", FullTag);
        }
    }
}