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
    public class ActionSetLanguageVariantModel
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