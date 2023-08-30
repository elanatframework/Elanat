using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetExtraHelperInformationModel : CodeBehindModel
    {
        public string GetInformation(string ExtraHelperDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/catalog.xml"));

            XmlNode ExtraHelperCatalog = doc.SelectSingleNode("extra_helper_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/extra_helper/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_name;", aol.GetAddOnsLanguage("extra_helper_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_category;", aol.GetAddOnsLanguage("extra_helper_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_author;", aol.GetAddOnsLanguage("extra_helper_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_directory_path;", aol.GetAddOnsLanguage("extra_helper_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_physical_name;", aol.GetAddOnsLanguage("extra_helper_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_load_type;", aol.GetAddOnsLanguage("extra_helper_load_type"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_version;", aol.GetAddOnsLanguage("extra_helper_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_release_date;", aol.GetAddOnsLanguage("extra_helper_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_info;", aol.GetAddOnsLanguage("extra_helper_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_license;", aol.GetAddOnsLanguage("extra_helper_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_static_head;", aol.GetAddOnsLanguage("extra_helper_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_load_tag;", aol.GetAddOnsLanguage("extra_helper_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_version_support;", aol.GetAddOnsLanguage("extra_helper_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_author_website;", aol.GetAddOnsLanguage("extra_helper_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_install_path;", aol.GetAddOnsLanguage("extra_helper_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang extra_helper_uninstall_path;", aol.GetAddOnsLanguage("extra_helper_uninstall_path"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_name;", ExtraHelperCatalog["extra_helper_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_category;", ExtraHelperCatalog["extra_helper_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_author;", ExtraHelperCatalog["extra_helper_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_directory_path;", ExtraHelperCatalog["extra_helper_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_physical_name;", ExtraHelperCatalog["extra_helper_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_load_type;", ExtraHelperCatalog["extra_helper_load_type"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_version;", ExtraHelperCatalog["extra_helper_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_release_date;", ExtraHelperCatalog["extra_helper_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_info;", ExtraHelperCatalog["extra_helper_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_license;", ExtraHelperCatalog["extra_helper_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_static_head;", ExtraHelperCatalog["extra_helper_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_load_tag;", ExtraHelperCatalog["extra_helper_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_version_support;", ExtraHelperCatalog["extra_helper_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_author_website;", ExtraHelperCatalog["extra_helper_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_install_path;", ExtraHelperCatalog["extra_helper_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp extra_helper_uninstall_path;", ExtraHelperCatalog["extra_helper_uninstall_path"].Attributes["value"].Value);

            return InformationTemplate;
        }
    }
}