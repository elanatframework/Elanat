using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetContentAvatarListModel : CodeBehindModel
    {
        public string ContentAvatarValue { get; set; }
        public string PathValue { get; set; }

        public void SetValue()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] dirget = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue)).GetDirectories();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string BoxTemplate = doc.SelectSingleNode("template_root/content_avatar_select/box").InnerText;

            // Set Return Directory
            string ReturnDirectoryListItemTemplate = "";
            if (!string.IsNullOrEmpty(PathValue))
            {
                ReturnDirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar_select/return_directory").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            }

            // Set Directory Value
            string DirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar_select/directory_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string TmpDirectoryListItemTemplate;
            string SumDirectoryListItemTemplate = "";

            foreach (DirectoryInfo dir in dirget)
            {
                if (dir.Name == "thumb")
                    continue;

                TmpDirectoryListItemTemplate = DirectoryListItemTemplate;
                TmpDirectoryListItemTemplate = TmpDirectoryListItemTemplate.Replace("$_asp directory_name;", dir.Name);
                SumDirectoryListItemTemplate += TmpDirectoryListItemTemplate;
            }


            // Set None File Value
            string NoneContentAvatarListItemTemplate = doc.SelectSingleNode("template_root/content_avatar_select/none_file_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());


            // Set File Value
            string ContentAvatarListItemTemplate = doc.SelectSingleNode("template_root/content_avatar_select/file_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string TmpContentAvatarListItemTemplate;
            string SumContentAvatarListItemTemplate = "";

            foreach (FileInfo file in fileInfo)
            {
                if (file.Name == "none.png")
                    continue;

                TmpContentAvatarListItemTemplate = ContentAvatarListItemTemplate;
                TmpContentAvatarListItemTemplate = TmpContentAvatarListItemTemplate.Replace("$_asp file_name;", file.Name);
                TmpContentAvatarListItemTemplate = TmpContentAvatarListItemTemplate.Replace("$_asp parent_directory_path;", PathValue + "/");
                SumContentAvatarListItemTemplate += TmpContentAvatarListItemTemplate;
            }

            BoxTemplate = BoxTemplate.Replace("$_asp item;", ReturnDirectoryListItemTemplate + SumDirectoryListItemTemplate + NoneContentAvatarListItemTemplate + SumContentAvatarListItemTemplate);

            ContentAvatarValue = BoxTemplate;
        }
    }
}