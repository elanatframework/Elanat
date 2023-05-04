using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class StartUpClass
    {
        public void Start()
        {
            XmlNodeList NodeList = StaticObject.StartUpNodeList;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                {
                    try
                    {
                        Security.UseSystemAccess();
                        string Path = StaticObject.SitePath + node.Attributes["path"].Value;
                        string SystemAccessCodeQueryString = (Path.Contains("?")) ? "&el_system_access_code=" + StaticObject.SystemAccessCode : "?el_system_access_code=" + StaticObject.SystemAccessCode;
                        PageLoader.LoadWithServer(Path + SystemAccessCodeQueryString);
                    }
                    catch (Exception ex)
                    {
                        Security.SetLogError(ex);
                    }
                }
        }
    }
}