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
                        string Path = node.Attributes["path"].Value;
                        PageLoader.LoadPathInSystemStart(Path);
                    }
                    catch (Exception ex)
                    {
                        Security.SetLogError(ex);
                    }
                }
        }
    }
}