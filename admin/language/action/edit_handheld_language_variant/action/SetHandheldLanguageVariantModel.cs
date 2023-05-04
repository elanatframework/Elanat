using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionSetHandheldLanguageVariantModel
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