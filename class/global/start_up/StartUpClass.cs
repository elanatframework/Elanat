using System.Xml;

namespace Elanat
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
                        string Path = node.Attributes["path"].Value;
                        string SystemAccessCodeQueryString = (Path.Contains("?")) ? "&el_system_access_code=" + StaticObject.SystemAccessCode : "?el_system_access_code=" + StaticObject.SystemAccessCode;
                        PageLoader.LoadPath(Path + SystemAccessCodeQueryString, false);
                    }
                    catch (Exception ex)
                    {
                        Security.SetLogError(ex);
                    }
                }
        }
    }
}