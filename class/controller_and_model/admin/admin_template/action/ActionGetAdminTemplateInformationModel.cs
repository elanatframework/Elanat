using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetAdminTemplateInformationModel : CodeBehindModel
    {
        public string GetInformation(string AdminTemplateDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + AdminTemplateDirectoryPath + "/catalog.xml"));

            XmlNode AdminTemplateCatalog = doc.SelectSingleNode("admin_template_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/admin_template/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_name;", aol.GetAddOnsLanguage("admin_template_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_author;", aol.GetAddOnsLanguage("admin_template_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_directory_path;", aol.GetAddOnsLanguage("admin_template_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_physical_name;", aol.GetAddOnsLanguage("admin_template_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_version;", aol.GetAddOnsLanguage("admin_template_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_release_date;", aol.GetAddOnsLanguage("admin_template_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_info;", aol.GetAddOnsLanguage("admin_template_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_license;", aol.GetAddOnsLanguage("admin_template_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_static_head;", aol.GetAddOnsLanguage("admin_template_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang admin_template_load_tag;", aol.GetAddOnsLanguage("admin_template_load_tag"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_name;", AdminTemplateCatalog["admin_template_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_author;", AdminTemplateCatalog["admin_template_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_directory_path;", AdminTemplateCatalog["admin_template_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_physical_name;", AdminTemplateCatalog["admin_template_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_version;", AdminTemplateCatalog["admin_template_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_release_date;", AdminTemplateCatalog["admin_template_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_info;", AdminTemplateCatalog["admin_template_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_license;", AdminTemplateCatalog["admin_template_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_static_head;", AdminTemplateCatalog["admin_template_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp admin_template_load_tag;", AdminTemplateCatalog["admin_template_load_tag"].InnerXml);

            return InformationTemplate;
        }
    }
}