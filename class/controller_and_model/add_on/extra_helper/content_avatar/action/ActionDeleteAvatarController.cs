using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteAvatarController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["avatar_path"]))
            {
                string AvatarPath = context.Request.Query["avatar_path"].ToString();

                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + AvatarPath));

                string AvatarDirectoriesPath = AvatarPath.GetTextBeforeLastValue("/");
                string AvatarFileName = AvatarPath.GetTextAfterLastValue("/");

                if (AvatarDirectoriesPath.GetTextAfterLastValue("/") != "thumb")
                    File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + AvatarDirectoriesPath + "/thumb/" + AvatarFileName));


                Write("true");
            }
            else
                Write("false");
        }
    }
}