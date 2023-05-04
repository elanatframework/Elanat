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
    public class ActionContentAvatarNewDirectoryModel
    {
        public string DirectoryNameValue { get; set; }

        public void SetValue()
        {
            // Set Directory Template
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string DirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/directory_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            DirectoryListItemTemplate = DirectoryListItemTemplate.Replace("$_asp directory_name;", DirectoryNameValue);

            HttpContext.Current.Response.Write(DirectoryListItemTemplate);
        }
    }
}