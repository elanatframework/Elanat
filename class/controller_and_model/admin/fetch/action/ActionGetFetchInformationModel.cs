using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetFetchInformationModel : CodeBehindModel
    {
        public string GetInformation(string FetchName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchName + "/catalog.xml"));

            XmlNode FetchCatalog = doc.SelectSingleNode("fetch_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/fetch/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/fetch/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_name;", aol.GetAddOnsLanguage("fetch_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_category;", aol.GetAddOnsLanguage("fetch_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_author;", aol.GetAddOnsLanguage("fetch_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_version;", aol.GetAddOnsLanguage("fetch_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_release_date;", aol.GetAddOnsLanguage("fetch_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_info;", aol.GetAddOnsLanguage("fetch_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_license;", aol.GetAddOnsLanguage("fetch_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_version_support;", aol.GetAddOnsLanguage("fetch_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang fetch_author_website;", aol.GetAddOnsLanguage("fetch_author_website"));


            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_name;", FetchCatalog["fetch_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_category;", FetchCatalog["fetch_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_author;", FetchCatalog["fetch_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_version;", FetchCatalog["fetch_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_release_date;", FetchCatalog["fetch_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_info;", FetchCatalog["fetch_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_license;", FetchCatalog["fetch_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_version_support;", FetchCatalog["fetch_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp fetch_author_website;", FetchCatalog["fetch_author_website"].InnerText);


            return InformationTemplate;
        }

    }
}