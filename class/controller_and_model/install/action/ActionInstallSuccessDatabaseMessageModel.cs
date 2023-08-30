using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionInstallSuccessDatabaseMessageModel : CodeBehindModel
    {
        public string ContentValue { get; set; }
        public string ContentTitle { get; set; }

        public void SetValue(string GlobalLanguage)
        {
            // Set Current Value
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.WebMapPath() + "/../template/template.xml"));

            XmlNode TemplateNode = TemplateDocument.SelectSingleNode("template_root/part");

            XmlDocument LanguageDocument = new XmlDocument();
            LanguageDocument.Load(StaticObject.ServerMapPath(StaticObject.WebMapPath() + "/../language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml"));

            XmlNode LanguageNode = LanguageDocument.SelectSingleNode("add_ons_language_root/add_ons_language");

            ContentTitle = LanguageNode["database_was_fill_successfully"].InnerText;

            ContentValue += TemplateNode["success_text"].InnerText.Replace("$_asp text;", LanguageNode["database_was_fill_successfully"].InnerText);
            ContentValue += TemplateNode["next_line"].InnerText;
            ContentValue += TemplateNode["success_text"].InnerText.Replace("$_asp text;", LanguageNode["connection_attach_successfully_you_can_click_below_link_to_go_to_install_page"].InnerText);
            ContentValue += TemplateNode["next_line"].InnerText;
            ContentValue += TemplateNode["install_page_link"].InnerText.Replace("$_lang install_page;", LanguageNode["install_page"].InnerText);
        }
    }
}