using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetModuleInformationModel : CodeBehindModel
    {
        public string GetInformation(string ModuleDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNode ModuleCatalog = doc.SelectSingleNode("module_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/module/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_name;", aol.GetAddOnsLanguage("module_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_category;", aol.GetAddOnsLanguage("module_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_author;", aol.GetAddOnsLanguage("module_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_directory_path;", aol.GetAddOnsLanguage("module_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_physical_name;", aol.GetAddOnsLanguage("module_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_version;", aol.GetAddOnsLanguage("module_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_best_load_status;", aol.GetAddOnsLanguage("module_best_load_status"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_release_date;", aol.GetAddOnsLanguage("module_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_info;", aol.GetAddOnsLanguage("module_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_license;", aol.GetAddOnsLanguage("module_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_static_head;", aol.GetAddOnsLanguage("module_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_load_tag;", aol.GetAddOnsLanguage("module_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_version_support;", aol.GetAddOnsLanguage("module_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_author_website;", aol.GetAddOnsLanguage("module_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_install_path;", aol.GetAddOnsLanguage("module_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_uninstall_path;", aol.GetAddOnsLanguage("module_uninstall_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_option_path;", aol.GetAddOnsLanguage("module_option_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_add_access_path;", aol.GetAddOnsLanguage("module_add_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_edit_all_access_path;", aol.GetAddOnsLanguage("module_edit_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_edit_own_access_path;", aol.GetAddOnsLanguage("module_edit_own_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_delete_all_access_path;", aol.GetAddOnsLanguage("module_delete_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang module_delete_own_access_path;", aol.GetAddOnsLanguage("module_delete_own_access_path"));


            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp module_name;", ModuleCatalog["module_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_category;", ModuleCatalog["module_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_author;", ModuleCatalog["module_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_directory_path;", ModuleCatalog["module_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_physical_name;", ModuleCatalog["module_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_version;", ModuleCatalog["module_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_best_load_status;", ModuleCatalog["module_best_load_status"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_release_date;", ModuleCatalog["module_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_info;", ModuleCatalog["module_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp module_license;", ModuleCatalog["module_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp module_static_head;", ModuleCatalog["module_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_load_tag;", ModuleCatalog["module_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_version_support;", ModuleCatalog["module_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_author_website;", ModuleCatalog["module_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp module_install_path;", ModuleCatalog["module_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_uninstall_path;", ModuleCatalog["module_uninstall_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_option_path;", ModuleCatalog["module_option_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp module_add_access_path;", ModuleCatalog["module_add_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_edit_all_access_path;", ModuleCatalog["module_edit_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_edit_own_access_path;", ModuleCatalog["module_edit_own_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_delete_all_access_path;", ModuleCatalog["module_delete_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp module_delete_own_access_path;", ModuleCatalog["module_delete_own_access_path"].InnerXml);


            return InformationTemplate;
        }
    }
}