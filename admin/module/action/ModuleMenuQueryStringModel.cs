using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionModuleMenuQueryStringModel
    {
        public string ViewModuleMenuQueryString(string MenuName, string MenuValue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/text_box.xml"));

            string ModuleMenuQueryStringInputTemplate = doc.SelectSingleNode("template_root/module_menu_query_string_input_for_add").InnerText;

            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_value;", MenuValue);
            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_name;", MenuName);
            ModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_query_string_value;", "");

            return ModuleMenuQueryStringInputTemplate;
        }
    }
}