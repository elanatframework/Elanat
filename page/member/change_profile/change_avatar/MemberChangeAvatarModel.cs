using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class MemberChangeAvatarModel
    {
        public string ChangeAvatarLanguage { get; set; }
        public string AvatarPathLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UseAvatarPathLanguage { get; set; }
        
        public bool UseAvatarPathValue { get; set; } = false;
        public string AvatarPathTextValue { get; set; }
        public HttpPostedFile AvatarPathUploadValue { get; set; }
        public string AvatarIconValue { get; set; }
        
        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/");
            MemberLanguage = aol.GetAddOnsLanguage("member");
            AvatarPathLanguage = aol.GetAddOnsLanguage("avatar_path");
            ChangeAvatarLanguage = aol.GetAddOnsLanguage("change_avatar");
            UseAvatarPathLanguage = aol.GetAddOnsLanguage("use_avatar_path");


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            AvatarIconValue = ccoc.UserId;
        }

        public void ChangeAvatar()
        {
            string UserAvatarFilePhysicalName = "";
            string UserAvatarExtension = "";
            string DirectoryName = "logo";

            // If Use Logo Path
            if (UseAvatarPathValue)
            {
                if (string.IsNullOrEmpty(AvatarPathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_avatar_path_field_because_this_is_necessary", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                UserAvatarFilePhysicalName = Path.GetFileName(AvatarPathTextValue);

                UserAvatarExtension = Path.GetExtension(UserAvatarFilePhysicalName);

                if (!FileAndDirectory.IsImageExtension(UserAvatarExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(UserAvatarFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AvatarPathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UserAvatarFilePhysicalName));
            }
            else
            {
                if (!AvatarPathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_avatar_upload_field_because_this_is_necessary", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/"), "problem");

                UserAvatarFilePhysicalName = AvatarPathUploadValue.FileName;

                UserAvatarExtension = Path.GetExtension(UserAvatarFilePhysicalName);

                if (!FileAndDirectory.IsImageExtension(UserAvatarExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(UserAvatarFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AvatarPathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UserAvatarFilePhysicalName));
            }

            // Convert Image To Png Format
            FileAndDirectory fad = new FileAndDirectory();
            fad.ConvertImageToPngFormat(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UserAvatarFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UserAvatarFilePhysicalName + ".tmp"));

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string UserAvatarPhysicalName = ccoc.UserId;

            if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/image/user_avatar/" + UserAvatarPhysicalName + ".png")))
                File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/image/user_avatar/" + UserAvatarPhysicalName + ".png"));

            File.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UserAvatarFilePhysicalName + ".tmp"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/image/user_avatar/" + UserAvatarPhysicalName + ".png"));

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            AvatarIconValue = UserAvatarPhysicalName;


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_avatar", ccoc.UserId);

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_avatar_was_upload", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_avatar/"), "success");
        }
    }
}