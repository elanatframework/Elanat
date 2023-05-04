using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionCreateContentTypeValueModel
    {
        private string ContentTypeValue { get; set; } = "";

        public void SetValue(string ContentType)
        {
            if (StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + ContentType) != null)
                ContentTypeValue = StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + ContentType).SetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage()).InnerText;


            HttpContext.Current.Response.Write(ContentTypeValue);
        }
    }
}