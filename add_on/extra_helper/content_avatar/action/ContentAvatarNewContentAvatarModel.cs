﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionContentAvatarNewContentAvatarModel
    {
        public string ParentDirectoryPathValue { get; set; }
        public string ContentAvatarNameValue { get; set; }

        public void SetValue()
        {
            // Set Directory Template
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ContentAvatarListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/file_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            ContentAvatarListItemTemplate = ContentAvatarListItemTemplate.Replace("$_asp file_name;", ContentAvatarNameValue);
            ContentAvatarListItemTemplate = ContentAvatarListItemTemplate.Replace("$_asp parent_directory_path;", ParentDirectoryPathValue + "/");

            HttpContext.Current.Response.Write(ContentAvatarListItemTemplate);
        }
    }
}