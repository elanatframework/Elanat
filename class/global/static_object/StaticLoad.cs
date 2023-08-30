using System.Xml;

namespace Elanat
{
    public class StaticLoad
    {
        public static string GetSessionLifeTime()
        {
            // Set Value
            XmlDocument ConfigDocument = new XmlDocument();
            ConfigDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/config/config.xml"));

            return ConfigDocument.SelectSingleNode("elanat_root/security/session_life_time").Attributes["value"].Value;
        }
    }
}
