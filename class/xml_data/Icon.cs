﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat.XmlData
{
    public class Icon
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"));
            XmlNode NodeList = doc.SelectSingleNode("icon_root/icon_list");

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("icon_root/icon_list").AppendChild(Tag);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"));


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_icon_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</icon_list>", FullTag + Environment.NewLine + "</icon_list>");

            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"), XmlText);


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_icon_xml", FullTag);
        }
    }
}