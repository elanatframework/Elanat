using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionModuleMenuQueryStringModel : CodeBehindModel
    {
        public string ViewModuleMenuQueryString(string MenuName, string MenuValue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/text_box.xml"));

            string ModuleMenuQueryStringInputTemplate = doc.SelectSingleNode("template_root/module_menu_query_string_input_for_add").InnerText;

            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_value;", MenuValue);
            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_name;", MenuName);
            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_query_string_value;", "");

            return ModuleMenuQueryStringInputTemplate;
        }
    }
}