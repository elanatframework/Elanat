﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat.XmlData
{
    public class UrlRedirect
    {
        public void SetTagToList(string TagName, List<string> AttributeName = null, List<string> AttributeValue = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/url_redirect_list/url_redirect.xml"));
            XmlNode NodeList = doc.SelectSingleNode("url_redirect_root/url_redirect_list");

            XmlElement Tag = doc.CreateElement(TagName);
            for (int i = 0; i < AttributeName.Count; i++)
                Tag.SetAttribute(AttributeName[i], AttributeValue[i]);

            doc.SelectSingleNode("url_redirect_root/url_redirect_list").AppendChild(Tag);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/url_redirect_list/url_redirect.xml"));


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_url_redirect_xml", TagName);
        }

        public void SetTextTagToList(string FullTag)
        {
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/url_redirect_list/url_redirect.xml"));
            string XmlText = Lines.ReadToEnd();
            Lines.Close();

            XmlText = XmlText.Replace("</url_redirect_list>", FullTag + Environment.NewLine + "</url_redirect_list>");

            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/url_redirect_list/url_redirect.xml"), XmlText);


            // Set Static Object
            Global g = new Global();
            g.Application_Start(null, null);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_tag_to_url_redirect_xml", FullTag);
        }
    }
}