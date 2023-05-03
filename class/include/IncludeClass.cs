using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class IncludeClass
    {
        public string GetBoxHead(string SiteGlobalName)
        {
            string DefaultBoxPath = StaticObject.DefaultBoxPath;

            XmlDocument BoxDocument = new XmlDocument();
            BoxDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "include/box/" + DefaultBoxPath + "/catalog.xml"));

            string BoxHead = BoxDocument.SelectSingleNode("box_catalog_root/box_head").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
            BoxHead = BoxHead.Replace("$_asp site_path;", StaticObject.SitePath);
                
            return BoxHead;
        }
    }
}