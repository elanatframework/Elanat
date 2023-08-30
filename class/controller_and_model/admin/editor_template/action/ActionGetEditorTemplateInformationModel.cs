using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetEditorTemplateInformationModel : CodeBehindModel
    {
        public string GetInformation(string EditorTemplateDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath + "/catalog.xml"));

            XmlNode EditorTemplateCatalog = doc.SelectSingleNode("editor_template_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/editor_template/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_name;", aol.GetAddOnsLanguage("editor_template_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_category;", aol.GetAddOnsLanguage("editor_template_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_author;", aol.GetAddOnsLanguage("editor_template_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_directory_path;", aol.GetAddOnsLanguage("editor_template_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_physical_name;", aol.GetAddOnsLanguage("editor_template_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_version;", aol.GetAddOnsLanguage("editor_template_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_release_date;", aol.GetAddOnsLanguage("editor_template_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_info;", aol.GetAddOnsLanguage("editor_template_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_license;", aol.GetAddOnsLanguage("editor_template_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_static_head;", aol.GetAddOnsLanguage("editor_template_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_load_tag;", aol.GetAddOnsLanguage("editor_template_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_version_support;", aol.GetAddOnsLanguage("editor_template_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_author_website;", aol.GetAddOnsLanguage("editor_template_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_install_path;", aol.GetAddOnsLanguage("editor_template_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang editor_template_uninstall_path;", aol.GetAddOnsLanguage("editor_template_uninstall_path"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_name;", EditorTemplateCatalog["editor_template_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_category;", EditorTemplateCatalog["editor_template_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_author;", EditorTemplateCatalog["editor_template_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_directory_path;", EditorTemplateCatalog["editor_template_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_physical_name;", EditorTemplateCatalog["editor_template_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_version;", EditorTemplateCatalog["editor_template_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_release_date;", EditorTemplateCatalog["editor_template_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_info;", EditorTemplateCatalog["editor_template_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_license;", EditorTemplateCatalog["editor_template_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_static_head;", EditorTemplateCatalog["editor_template_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_load_tag;", EditorTemplateCatalog["editor_template_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_version_support;", EditorTemplateCatalog["editor_template_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_author_website;", EditorTemplateCatalog["editor_template_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_install_path;", EditorTemplateCatalog["editor_template_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp editor_template_uninstall_path;", EditorTemplateCatalog["editor_template_uninstall_path"].Attributes["value"].Value);

            return InformationTemplate;
        }
    }
}