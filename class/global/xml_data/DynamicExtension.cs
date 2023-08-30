﻿using System.Xml;

namespace Elanat.XmlData
{
    public class DynamicExtension
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"));

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("dynamic_extension_root/dynamic_extension_list").AppendChild(Tag);

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"));


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_dynamic_extension_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = File.OpenText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</dynamic_extension_list>", FullTag + Environment.NewLine + "</dynamic_extension_list>");

            File.WriteAllText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"), XmlText);


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_dynamic_extension_xml", FullTag);
        }
    }
}