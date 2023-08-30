using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionContentAvatarNewDirectoryModel : CodeBehindModel
    {
        public string DirectoryNameValue { get; set; }

        public void SetValue()
        {
            // Set Directory Template
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string DirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/directory_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            DirectoryListItemTemplate = DirectoryListItemTemplate.Replace("$_asp directory_name;", DirectoryNameValue);

            Write(DirectoryListItemTemplate);
        }
    }
}