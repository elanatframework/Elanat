using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionSetHandheldLanguageVariantModel : CodeBehindModel
    {
        public string HandheldLanguageCharacterValue { get; set; }
        public string HandheldLanguageVariantOptionListValue { get; set; }
        public string HandheldLanguageVariantCountValue { get; set; }

        public void SetValue()
        {
            XmlNodeList HandheldLanguageNodeList = Language.GetHandheldLanguageVariantNodeList(HandheldLanguageCharacterValue, "en");

            HandheldLanguageVariantCountValue = (HandheldLanguageNodeList.Count < 2) ? "2" : HandheldLanguageNodeList.Count.ToString();
            HandheldLanguageVariantOptionListValue = "";

            foreach (XmlNode node in HandheldLanguageNodeList)
                HandheldLanguageVariantOptionListValue = HandheldLanguageVariantOptionListValue.HtmlInputAddOptionTag(node.InnerText, node.Name);
        }
    }
}