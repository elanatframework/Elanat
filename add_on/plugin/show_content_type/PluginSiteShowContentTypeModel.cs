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
    public class PluginSiteShowContentTypeModel
    {
        public void SetValue()
        {
            string LanguageGlobalName = StaticObject.GetCurrentSiteGlobalLanguage();
            XmlDocument doc = new XmlDocument();

            // Set Content Type Item
            ListClass lc = new ListClass();
            lc.FillContentTypeListItem(LanguageGlobalName);

            string ContentTypeBoxTemplate = Template.GetSiteTemplate("view/content_type/box");
            string ContentTypeListItemTemplate = Template.GetSiteTemplate("view/content_type/list_item");
            string TmpContentTypeListItemTemplate = "";
            string SumContentTypeListItemTemplate = "";

            foreach (ListItem item in lc.ContentTypeListItem)
            {
                TmpContentTypeListItemTemplate = ContentTypeListItemTemplate;

                TmpContentTypeListItemTemplate = TmpContentTypeListItemTemplate.Replace("$_asp content_type_value;", item.Value);
                TmpContentTypeListItemTemplate = TmpContentTypeListItemTemplate.Replace("$_asp content_type_name;", item.Text);

                SumContentTypeListItemTemplate += TmpContentTypeListItemTemplate;
            }

            HttpContext.Current.Response.Write(ContentTypeBoxTemplate.Replace("$_asp item;", SumContentTypeListItemTemplate));
        }
    }
}