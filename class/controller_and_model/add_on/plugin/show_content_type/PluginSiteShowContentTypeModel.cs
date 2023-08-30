using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class PluginSiteShowContentTypeModel : CodeBehindModel
    {
        public void SetValue()
        {
            string LanguageGlobalName = StaticObject.GetCurrentSiteGlobalLanguage();


            // Set Content Type Item
            ListClass.Content lcc = new ListClass.Content();
            lcc.FillContentTypeListItem(LanguageGlobalName);

            string ContentTypeBoxTemplate = Template.GetSiteTemplate("view/content_type/box");
            string ContentTypeListItemTemplate = Template.GetSiteTemplate("view/content_type/list_item");
            string TmpContentTypeListItemTemplate = "";
            string SumContentTypeListItemTemplate = "";

            foreach (ListItem item in lcc.ContentTypeListItem)
            {
                TmpContentTypeListItemTemplate = ContentTypeListItemTemplate;

                TmpContentTypeListItemTemplate = TmpContentTypeListItemTemplate.Replace("$_asp content_type_value;", item.Value);
                TmpContentTypeListItemTemplate = TmpContentTypeListItemTemplate.Replace("$_asp content_type_name;", item.Text);

                SumContentTypeListItemTemplate += TmpContentTypeListItemTemplate;
            }

            Write(ContentTypeBoxTemplate.Replace("$_asp item;", SumContentTypeListItemTemplate));
        }
    }
}