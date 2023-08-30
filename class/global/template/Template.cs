using System.Xml;

namespace Elanat
{
	public class Template
	{
        public static string GetSiteTemplate(string TagPath, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentSiteTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentSiteTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.SiteGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());

            return CurentTemplate;
        }

        // Overload
        public static string GetSiteTemplate(string TagPath, bool BreakLanguage, int Item = 0)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentSiteTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentSiteTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.SiteGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage(), BreakLanguage);

            return CurentTemplate;
        }


        public static string GetSiteGlobalTemplate(string TagPath, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList = StaticObject.SiteGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage());

            return CurentTemplate;
        }

        // Overload
        public static string GetSiteGlobalTemplate(string TagPath, bool BreakLanguage, int Item = 0)
        {
            XmlNodeList NodeList = StaticObject.SiteGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage(), BreakLanguage);

            return CurentTemplate;
        }

        public static string GetAdminGlobalTemplate(string TagPath, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList = StaticObject.AdminGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            return CurentTemplate;
        }

        // Overload
        public static string GetAdminGlobalTemplate(string TagPath, bool BreakLanguage, int Item = 0)
        {
            XmlNodeList NodeList = StaticObject.AdminGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage(), BreakLanguage);

            return CurentTemplate;
        }

        public static XmlNode GetXmlNodeFromSiteTemplate(string TagPath, int Item = 0)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentSiteTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentSiteTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.SiteGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            return NodeList[Item];
        }

        public static string GetAdminTemplate(string TagPath, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentAdminTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentAdminTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.AdminGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            return CurentTemplate;
        }

        // Overload
        public static string GetAdminTemplate(string TagPath, bool BreakLanguage, int Item = 0)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentAdminTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentAdminTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.AdminGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage(), BreakLanguage);

            return CurentTemplate;
        }
        
        public static XmlNode GetXmlNodeFromAdminTemplate(string TagPath, int Item = 0)
        {
            XmlNodeList NodeList;

            if (StaticObject.CurrentAdminTemplateDocument().SelectSingleNode("template_root/" + TagPath) != null)
                NodeList = StaticObject.CurrentAdminTemplateDocument().SelectNodes("template_root/" + TagPath);
            else
                NodeList = StaticObject.AdminGlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            return NodeList[Item];
        }

        public static string GetGlobalTemplate(string TagPath, string GlobalLanguage, int Item = 0, string Attr = null)
        {
            XmlNodeList NodeList = StaticObject.GlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            if (Attr != null)
                return NodeList[Item].Attributes[Attr].Value.ToString();

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(GlobalLanguage);

            return CurentTemplate;
        }

        // Overload
        public static string GetGlobalTemplate(string TagPath, string GlobalLanguage, bool BreakLanguage, int Item = 0)
        {
            XmlNodeList NodeList = StaticObject.GlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            string CurentTemplate = NodeList[Item].InnerTextAfterSetNodeVariant(GlobalLanguage, BreakLanguage);

            return CurentTemplate;
        }

        public static XmlNode GetXmlNodeFromGlobalTemplate(string TagPath, int Item = 0)
        {
            XmlNodeList NodeList = StaticObject.GlobalTemplateDocument.SelectNodes("template_root/" + TagPath);

            return NodeList[Item];
        }
	}
}