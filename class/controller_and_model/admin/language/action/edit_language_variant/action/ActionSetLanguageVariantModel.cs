using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionSetLanguageVariantModel : CodeBehindModel
    {
        public string LanguageCharacterValue { get; set; }
        public string LanguageVariantOptionListValue { get; set; }
        public string LanguageVariantCountValue { get; set; }

        public void SetValue()
        {
            XmlNodeList LanguageNodeList = Language.GetLanguageVariantNodeList(LanguageCharacterValue, "en");

            LanguageVariantCountValue = (LanguageNodeList.Count < 2) ? "2" : LanguageNodeList.Count.ToString();

            foreach (XmlNode node in LanguageNodeList)
                LanguageVariantOptionListValue = LanguageVariantOptionListValue.HtmlInputAddOptionTag(node.InnerText, node.Name);
        }
    }
}