﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat.XmlData
{
    public class ScriptExtension
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/script_extension_list/script_extension.xml"));
            XmlNode NodeList = doc.SelectSingleNode("script_extension_root/script_extension_list");

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("script_extension_root/script_extension_list").AppendChild(Tag);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/script_extension_list/script_extension.xml"));


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_script_extension_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/script_extension_list/script_extension.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</script_extension_list>", FullTag + Environment.NewLine + "</script_extension_list>");

            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/script_extension_list/script_extension.xml"), XmlText);


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_script_extension_xml", FullTag);
        }
    }
}