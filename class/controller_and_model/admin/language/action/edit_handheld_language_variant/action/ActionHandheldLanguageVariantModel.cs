using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionHandheldLanguageVariantModel : CodeBehindModel
    {
        public string ViewHandheldLanguageVariant(string HandheldLanguageVariantValue)
        {
            // Set Current Value
            ListClass.LanguageList lcl = new ListClass.LanguageList();

            // Add Handheld Language Input For Edit
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            string LanguageInputTemplate = doc.SelectSingleNode("template_root/handheld_language_input_for_edit").InnerText;
            string SumLanguageInputTemplate = "";
            string TmpLanguageInputTemplate = "";

            foreach (ListItem item in lcl.LanguageNameListItem)
            {
                XmlDocument LanguageDocument = new XmlDocument();
                LanguageDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "/language/" + item.Value + "/handheld.xml"));

                char FirstCharacter = HandheldLanguageVariantValue[0];

                XmlNode Node = LanguageDocument.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + HandheldLanguageVariantValue);

                string LanguageValue = Node.InnerText;
                string HandheldLanguageValue = Node.InnerText; ;

                TmpLanguageInputTemplate = LanguageInputTemplate;
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_global_name;", item.Value);
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_name;", item.Text);
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_value;", HandheldLanguageValue);

                SumLanguageInputTemplate += TmpLanguageInputTemplate;
            }

            return SumLanguageInputTemplate;
        }
    }
}