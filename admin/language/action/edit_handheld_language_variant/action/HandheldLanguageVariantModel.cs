using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionHandheldLanguageVariantModel
    {
        public string ViewHandheldLanguageVariant(string HandheldLanguageVariantValue)
        {
            // Set Current Value
            ListClass lc = new ListClass();

            // Add Handheld Language Input For Edit
            lc.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            string LanguageInputTemplate = doc.SelectSingleNode("template_root/handheld_language_input_for_edit").InnerText;
            string SumLanguageInputTemplate = "";
            string TmpLanguageInputTemplate = "";

            foreach (ListItem item in lc.LanguageNameListItem)
            {
                XmlDocument LanguageDocument = new XmlDocument();
                LanguageDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "/language/" + item.Value + "/handheld.xml"));

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