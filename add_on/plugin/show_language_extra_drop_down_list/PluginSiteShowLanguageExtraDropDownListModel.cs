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
    public class PluginSiteShowLanguageExtraDropDownListModel
    {
        public void SetValue()
        {
            XmlNode node = StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/extra_html_input/drop_down_list");

            string DropDownListBoxTemplate = node["box"].InnerText;
            string DropDownListListItemTemplate = node["list_item"].InnerText;
            string TmpDropDownListListItemTemplate = "";
            string SumDropDownListListItemTemplate = "";

            // Set Language Item
            ListClass lc = new ListClass();
            lc.FillActiveLanguageNameListItem(StaticObject.GetCurrentSiteGlobalLanguage());

            foreach (ListItem item in lc.ActiveLanguageNameListItem)
            {
                TmpDropDownListListItemTemplate = DropDownListListItemTemplate;

                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp item_name;", item.Text);
                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp item_image;", StaticObject.SitePath + "client/image/language_icon/" + item.Value + ".png");
                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp select_item_method;", "href=" + StaticObject.SitePath + "lang/" + item.Value);

                SumDropDownListListItemTemplate += TmpDropDownListListItemTemplate;
            }

            DropDownListBoxTemplate = DropDownListBoxTemplate.Replace("$_asp current_item_image;", StaticObject.SitePath + "client/image/language_icon/" + StaticObject.GetCurrentSiteGlobalLanguage() + ".png");
            DropDownListBoxTemplate = DropDownListBoxTemplate.Replace("$_asp item;", SumDropDownListListItemTemplate);

            HttpContext.Current.Response.Write(DropDownListBoxTemplate);
        }
    }
}