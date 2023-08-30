using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionContentAvatarNewContentAvatarModel : CodeBehindModel
    {
        public string ParentDirectoryPathValue { get; set; }
        public string ContentAvatarNameValue { get; set; }

        public void SetValue()
        {
            // Set Directory Template
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ContentAvatarListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/file_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            ContentAvatarListItemTemplate = ContentAvatarListItemTemplate.Replace("$_asp file_name;", ContentAvatarNameValue);
            ContentAvatarListItemTemplate = ContentAvatarListItemTemplate.Replace("$_asp parent_directory_path;", ParentDirectoryPathValue + "/");

            Write(ContentAvatarListItemTemplate);
        }
    }
}