using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetPatchInformationModel : CodeBehindModel
    {
        public string GetInformation(string PatchDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + PatchDirectoryPath + "/catalog.xml"));

            XmlNode PatchCatalog = doc.SelectSingleNode("patch_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/patch/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_name;", aol.GetAddOnsLanguage("patch_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_category;", aol.GetAddOnsLanguage("patch_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_author;", aol.GetAddOnsLanguage("patch_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_directory_path;", aol.GetAddOnsLanguage("patch_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_version;", aol.GetAddOnsLanguage("patch_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_release_date;", aol.GetAddOnsLanguage("patch_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_info;", aol.GetAddOnsLanguage("patch_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_license;", aol.GetAddOnsLanguage("patch_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_version_support;", aol.GetAddOnsLanguage("patch_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_author_website;", aol.GetAddOnsLanguage("patch_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_install_path;", aol.GetAddOnsLanguage("patch_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang patch_uninstall_path;", aol.GetAddOnsLanguage("patch_uninstall_path"));


            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp patch_name;", PatchCatalog["patch_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_category;", PatchCatalog["patch_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_author;", PatchCatalog["patch_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_directory_path;", PatchCatalog["patch_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_version;", PatchCatalog["patch_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_release_date;", PatchCatalog["patch_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_info;", PatchCatalog["patch_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_license;", PatchCatalog["patch_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_version_support;", PatchCatalog["patch_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_author_website;", PatchCatalog["patch_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_install_path;", PatchCatalog["patch_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp patch_uninstall_path;", PatchCatalog["patch_uninstall_path"].Attributes["value"].Value);


            return InformationTemplate;
        }
    }
}