using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class PluginSiteShowLanguageExtraDropDownListModel : CodeBehindModel
    {
        public void SetValue()
        {
            XmlNode node = StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/extra_html_input/drop_down_list");

            string DropDownListBoxTemplate = node["box"].InnerText;
            string DropDownListListItemTemplate = node["list_item"].InnerText;
            string TmpDropDownListListItemTemplate = "";
            string SumDropDownListListItemTemplate = "";

            // Set Language Item
            ListClass.LanguageList lcla = new ListClass.LanguageList();
            lcla.FillActiveLanguageNameListItem(StaticObject.GetCurrentSiteGlobalLanguage());

            foreach (ListItem item in lcla.ActiveLanguageNameListItem)
            {
                TmpDropDownListListItemTemplate = DropDownListListItemTemplate;

                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp item_name;", item.Text);
                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp item_image;", StaticObject.SitePath + "client/image/language_icon/" + item.Value + ".png");
                TmpDropDownListListItemTemplate = TmpDropDownListListItemTemplate.Replace("$_asp select_item_method;", "href=" + StaticObject.SitePath + "lang/" + item.Value);

                SumDropDownListListItemTemplate += TmpDropDownListListItemTemplate;
            }

            DropDownListBoxTemplate = DropDownListBoxTemplate.Replace("$_asp current_item_image;", StaticObject.SitePath + "client/image/language_icon/" + StaticObject.GetCurrentSiteGlobalLanguage() + ".png");
            DropDownListBoxTemplate = DropDownListBoxTemplate.Replace("$_asp item;", SumDropDownListListItemTemplate);

            Write(DropDownListBoxTemplate);
        }
    }
}