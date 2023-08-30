using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["directory_path"]))
            {
                string DirectoryPath = context.Request.Query["directory_path"].ToString();

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + DirectoryPath), true);

                Write("true");
            }
            else
                Write("false");
        }
    }
}