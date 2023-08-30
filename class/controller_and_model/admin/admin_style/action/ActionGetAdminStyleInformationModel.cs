using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetAdminStyleInformationModel : CodeBehindModel
    {
        public string GetInformation(string AdminStyleDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/" + AdminStyleDirectoryPath + "/catalog.xml"));

            XmlNode AdminStyleCatalog = doc.SelectSingleNode("admin_style_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/admin_style/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_name;", aol.GetAddOnsLanguage("admin_style_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_template;", aol.GetAddOnsLanguage("admin_style_template"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_author;", aol.GetAddOnsLanguage("admin_style_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_directory_path;", aol.GetAddOnsLanguage("admin_style_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_physical_name;", aol.GetAddOnsLanguage("admin_style_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_right_to_left_language_support;", aol.GetAddOnsLanguage("admin_style_right_to_left_language_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_view_support;", aol.GetAddOnsLanguage("admin_style_view_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_responsive_support;", aol.GetAddOnsLanguage("admin_style_responsive_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_version;", aol.GetAddOnsLanguage("admin_style_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_release_date;", aol.GetAddOnsLanguage("admin_style_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_info;", aol.GetAddOnsLanguage("admin_style_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_license;", aol.GetAddOnsLanguage("admin_style_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_static_head;", aol.GetAddOnsLanguage("admin_style_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_style_load_tag;", aol.GetAddOnsLanguage("admin_style_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_view_style;", aol.GetAddOnsLanguage("admin_view_style"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_name;", AdminStyleCatalog["admin_style_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_template;", AdminStyleCatalog["admin_style_template"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_author;", AdminStyleCatalog["admin_style_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_directory_path;", AdminStyleCatalog["admin_style_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_physical_name;", AdminStyleCatalog["admin_style_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_right_to_left_language_support;", AdminStyleCatalog["admin_style_right_to_left_language_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_view_support;", AdminStyleCatalog["admin_style_view_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_responsive_support;", AdminStyleCatalog["admin_style_responsive_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_version;", AdminStyleCatalog["admin_style_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_release_date;", AdminStyleCatalog["admin_style_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_info;", AdminStyleCatalog["admin_style_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_license;", AdminStyleCatalog["admin_style_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_static_head;", AdminStyleCatalog["admin_style_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_style_load_tag;", AdminStyleCatalog["admin_style_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_view_style;", AdminStyleCatalog["admin_view_style"].OuterXml);

            return InformationTemplate;
        }
    }
}