using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionLanguageVariantModel : CodeBehindModel
    {
        public string ViewLanguageVariant(string LanguageVariantValue)
        {
            // Set Current Value
            ListClass.LanguageList lcl = new ListClass.LanguageList();

            // Add Language Input For Edit
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            string LanguageInputTemplate = doc.SelectSingleNode("template_root/language_input_for_edit").InnerText;
            string SumLanguageInputTemplate = "";
            string TmpLanguageInputTemplate = "";

            foreach (ListItem item in lcl.LanguageNameListItem)
            {
                XmlDocument LanguageDocument = new XmlDocument();
                LanguageDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "/language/" + item.Value + "/" + item.Value + ".xml"));

                char FirstCharacter = LanguageVariantValue[0];

                XmlNode Node = LanguageDocument.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariantValue);

                string LanguageValue = Node.InnerText;

                TmpLanguageInputTemplate = LanguageInputTemplate;
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_global_name;", item.Value);
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_name;", item.Text);
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_value;", LanguageValue);

                SumLanguageInputTemplate += TmpLanguageInputTemplate;
            }

            return SumLanguageInputTemplate;
        }
    }
}