using System.Xml;

namespace Elanat.Head
{
    public class SiteDynamicHead
    {
        public bool ShowDynamicMetaRight = false;
        public bool ShowDynamicMetaRevisitAfter = false;
        public bool ShowDynamicMetaKeywords = false;
        public bool ShowDynamicMetaDescription = false;
        public bool ShowDynamicMetaClassification = false;
        public bool ShowDynamicMetaAuthor = false;
        public bool ShowDynamicMetaCopyright = false;
        public bool ShowDynamicMetaLanguage = false;
        public bool ShowDynamicMetaRobots = false;
        public bool ShowDynamicMetaAapplicationName = false;
        public bool ShowDynamicMetaGenerator = false;
        public bool ShowDynamicMetaJavascriptInactiveRefresh = false;
        public bool ShowDynamicBoxHead = true;
        public bool ShowDynamicStyle = true;

        public string DynamicStyleValue;
        public string DynamicMetaRightValue;
        public string DynamicMetaRevisitAfterValue;
        public string DynamicMetaKeywordsValue;
        public string DynamicMetaDescriptionValue;
        public string DynamicMetaClassificationValue;
        public string DynamicMetaAuthorValue;
        public string DynamicMetaCopyrightValue;
        public string DynamicMetaLanguageValue;
        public string DynamicMetaRobotsValue;
        public string DynamicMetaAapplicationNameValue;
        public string DynamicMetaGeneratorValue;
        public string DynamicBoxHeadValue;

        public string Get()
        {
            string SiteDynamicHead = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/head_list/site/dynamic_head.xml"));

            XmlNode node = doc.SelectSingleNode("dynamic_head_root/dynamic_head_list");

            SiteDynamicHead += (ShowDynamicStyle && node["dynamic_style"].Attributes["active"].Value == "true") ? node["dynamic_style"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp style_physical_path;", DynamicStyleValue) : null;
            SiteDynamicHead += (ShowDynamicMetaRight && node["dynamic_meta_right"].Attributes["active"].Value == "true") ? node["dynamic_meta_right"].InnerText.Replace("$_asp meta_right;", DynamicMetaRightValue) : null;
            SiteDynamicHead += (ShowDynamicMetaRevisitAfter && node["dynamic_meta_revisit_after"].Attributes["active"].Value == "true") ? node["dynamic_meta_revisit_after"].InnerText.Replace("$_asp meta_revisit_after;", DynamicMetaRevisitAfterValue) : null;
            SiteDynamicHead += (ShowDynamicMetaKeywords && node["dynamic_meta_keywords"].Attributes["active"].Value == "true") ? node["dynamic_meta_keywords"].InnerText.Replace("$_asp meta_keywords;", DynamicMetaKeywordsValue) : null;
            SiteDynamicHead += (ShowDynamicMetaDescription && node["dynamic_meta_description"].Attributes["active"].Value == "true") ? node["dynamic_meta_description"].InnerText.Replace("$_asp description;", DynamicMetaDescriptionValue) : null;
            SiteDynamicHead += (ShowDynamicMetaClassification && node["dynamic_meta_classification"].Attributes["active"].Value == "true") ? node["dynamic_meta_classification"].InnerText.Replace("$_asp classification;", DynamicMetaClassificationValue) : null;
            SiteDynamicHead += (ShowDynamicMetaAuthor && node["dynamic_meta_author"].Attributes["active"].Value == "true") ? node["dynamic_meta_author"].InnerText.Replace("$_asp author;", DynamicMetaAuthorValue) : null;
            SiteDynamicHead += (ShowDynamicMetaCopyright && node["dynamic_meta_copyright"].Attributes["active"].Value == "true") ? node["dynamic_meta_copyright"].InnerText.Replace("$_asp copyright;", DynamicMetaCopyrightValue) : null;
            SiteDynamicHead += (ShowDynamicMetaLanguage && node["dynamic_meta_language"].Attributes["active"].Value == "true") ? node["dynamic_meta_language"].InnerText.Replace("$_asp language;", DynamicMetaLanguageValue) : null;
            SiteDynamicHead += (ShowDynamicMetaRobots && node["dynamic_meta_robots"].Attributes["active"].Value == "true") ? node["dynamic_meta_robots"].InnerText.Replace("$_asp robots;", DynamicMetaRobotsValue) : null;
            SiteDynamicHead += (ShowDynamicMetaAapplicationName && node["dynamic_meta_application_name"].Attributes["active"].Value == "true") ? node["dynamic_meta_application_name"].InnerText.Replace("$_asp application_name;", DynamicMetaAapplicationNameValue) : null;
            SiteDynamicHead += (ShowDynamicMetaGenerator && node["dynamic_meta_generator"].Attributes["active"].Value == "true") ? node["dynamic_meta_generator"].InnerText.Replace("$_asp generator;", DynamicMetaGeneratorValue) : null;
            SiteDynamicHead += (ShowDynamicMetaJavascriptInactiveRefresh && node["dynamic_meta_javascript_inactive_refresh"].Attributes["active"].Value == "true") ? node["dynamic_meta_javascript_inactive_refresh"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath) : null;
            SiteDynamicHead += (ShowDynamicBoxHead && node["dynamic_box_head"].Attributes["active"].Value == "true") ? node["dynamic_box_head"].InnerText.Replace("$_asp box_head;", DynamicBoxHeadValue) : null;

            return SiteDynamicHead;
        }
    }

    public class SiteStaticHead
    {
        public string Get()
        {
            string SiteStaticHead = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/head_list/site/static_head.xml"));
            foreach (XmlNode node in doc.GetElementsByTagName("static_head"))
            {
                if (node.Attributes["active"].Value == "true")
                    SiteStaticHead += node.InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            }
            return SiteStaticHead;
        }
    }

    public class AdminDynamicHead
    {
        public bool ShowDynamicStyle = true;
        public bool ShowDynamicMetaLanguage = true;
        public bool ShowDynamicBoxHead = true;

        public string DynamicStyleValue;
        public string DynamicMetaLanguageValue;
        public string DynamicBoxHeadValue;

        public string Get()
        {
            string AdminDynamicHead = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/head_list/admin/dynamic_head.xml"));

            XmlNode node = doc.SelectSingleNode("dynamic_head_root/dynamic_head_list");

            AdminDynamicHead += (ShowDynamicStyle && node["dynamic_style"].Attributes["active"].Value == "true") ? node["dynamic_style"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp style_physical_path;", DynamicStyleValue) : null;
            AdminDynamicHead += (ShowDynamicMetaLanguage && node["dynamic_meta_language"].Attributes["active"].Value == "true") ? node["dynamic_meta_language"].InnerText.Replace("$_asp language;", DynamicMetaLanguageValue) : null;
            AdminDynamicHead += (ShowDynamicBoxHead && node["dynamic_box_head"].Attributes["active"].Value == "true") ? node["dynamic_box_head"].InnerText.Replace("$_asp box_head;", DynamicBoxHeadValue) : null;

            return AdminDynamicHead;
        }
    }

    public class AdminStaticHead
    {
        public string Get()
        {
            string AdminStaticHead = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/head_list/admin/static_head.xml"));
            foreach (XmlNode node in doc.GetElementsByTagName("static_head"))
            {
                if (node.Attributes["active"].Value == "true")
                    AdminStaticHead += node.InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            }
            return AdminStaticHead;
        }
    }
}