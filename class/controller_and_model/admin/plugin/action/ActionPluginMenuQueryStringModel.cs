using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionPluginMenuQueryStringModel : CodeBehindModel
    {
        public string ViewPluginMenuQueryString(string MenuName, string MenuValue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/text_box.xml"));

            string PluginMenuQueryStringInputTemplate = doc.SelectSingleNode("template_root/plugin_menu_query_string_input_for_add").InnerText;

            PluginMenuQueryStringInputTemplate = PluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_value;", MenuValue);
            PluginMenuQueryStringInputTemplate = PluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_name;", MenuName);
            PluginMenuQueryStringInputTemplate = PluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_query_string_value;", "");

            return PluginMenuQueryStringInputTemplate;
        }
    }
}