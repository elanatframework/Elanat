using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperContentAvatarModel : CodeBehindModel
    {
        public string ContentAvatarLanguage { get; set; }
        public string AvatarPathLanguage { get; set; }
        public string UseAvatarPathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        public string CreateDirectoryLanguage { get; set; }
        public string DirectoryNameLanguage { get; set; }
        public string AvatarLanguage { get; set; }
        
        public bool UseAvatarPathValue { get; set; } = false;
        public string AvatarPathTextValue { get; set; }
        public IFormFile AvatarPathUploadValue { get; set; }
        public string DirectoryNameValue { get; set; }
        public string ContentAvatarValue { get; set; }
        public string PathValue { get; set; }


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/");
            ContentAvatarLanguage = aol.GetAddOnsLanguage("content_avatar");
            AvatarPathLanguage = aol.GetAddOnsLanguage("avatar_path");
            UseAvatarPathLanguage = aol.GetAddOnsLanguage("use_avatar_path");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
            CreateDirectoryLanguage = aol.GetAddOnsLanguage("create_directory");
            DirectoryNameLanguage = aol.GetAddOnsLanguage("directory_name");
            AvatarLanguage = aol.GetAddOnsLanguage("avatar");


            // Set Current Value
            DirectoryInfo dirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] dirget = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue)).GetDirectories();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string BoxTemplate = doc.SelectSingleNode("template_root/content_avatar/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            // Set Return Directory
            string ReturnDirectoryListItemTemplate = "";
            if (!string.IsNullOrEmpty(PathValue))
            {
                ReturnDirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/return_directory").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            }

            // Set Directory Value
            string DirectoryListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/directory_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
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

            // Set File Value
            string ContentAvatarListItemTemplate = doc.SelectSingleNode("template_root/content_avatar/file_list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
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

            BoxTemplate = BoxTemplate.Replace("$_asp item;", ReturnDirectoryListItemTemplate + SumDirectoryListItemTemplate + SumContentAvatarListItemTemplate);

            ContentAvatarValue = BoxTemplate;
        }

        public void StartUpload()
        {
            string AvatarAvatarPhysicalName = "";
            string AvatarExtension = "";
            string DirectoryName = "upload";

            // If Use Avatar Path
            if (UseAvatarPathValue)
            {
                if (string.IsNullOrEmpty(AvatarPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_avatar_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "problem");
                    return;
                }

                HttpClient webClient = new HttpClient();

                AvatarAvatarPhysicalName = Path.GetFileName(AvatarPathTextValue);

                AvatarExtension = Path.GetExtension(AvatarAvatarPhysicalName);

                if (!FileAndDirectory.IsImageExtension(AvatarExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "problem");
                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AvatarAvatarPhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AvatarPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarAvatarPhysicalName));
            }
            else
            {
                if (!AvatarPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_avatar_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "problem");
                    return;
                }

                AvatarAvatarPhysicalName = AvatarPathUploadValue.FileName;

                AvatarExtension = Path.GetExtension(AvatarAvatarPhysicalName);

                if (!FileAndDirectory.IsImageExtension(AvatarExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "problem");
                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AvatarAvatarPhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AvatarPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarAvatarPhysicalName));
            }

            string AvatarPhysicalName = AvatarAvatarPhysicalName;

            AvatarPhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue), AvatarPhysicalName);

            File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarAvatarPhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue + "/" + AvatarPhysicalName));

            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Create Thumbnail Image
            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue + "/thumb/")))
                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue + "/thumb/"));

            FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "client/image/content_avatar/" + PathValue + "/" + AvatarPhysicalName, StaticObject.SitePath + "client/image/content_avatar/" + PathValue + "/thumb/" + AvatarPhysicalName);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_avatar", AvatarAvatarPhysicalName);

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("avatar_was_upload", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "success", false, StaticObject.SitePath + "add_on/extra_helper/content_avatar/action/ContentAvatarNewContentAvatar.aspx?content_avatar_name=" + AvatarPhysicalName + "&parent_directory_path=/" + PathValue, "div_ContentAvatarList");
        }

        public void CreateDirectory()
        {
            string Path = StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + PathValue);
            string DirectoryName = DirectoryNameValue;

            DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(Path, DirectoryName);

            Directory.CreateDirectory(Path + "/" + DirectoryName);

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("directory_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_avatar/"), "success", false, StaticObject.SitePath + "add_on/extra_helper/content_avatar/action/ContentAvatarNewDirectory.aspx?directory_name=" + DirectoryName, "div_ContentAvatarList");
        }
    }
}