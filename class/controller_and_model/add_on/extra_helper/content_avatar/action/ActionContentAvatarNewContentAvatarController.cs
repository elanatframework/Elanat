using CodeBehind;

namespace Elanat
{
    public partial class ActionContentAvatarNewContentAvatarController : CodeBehindController
    {
        public ActionContentAvatarNewContentAvatarModel model = new ActionContentAvatarNewContentAvatarModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_avatar_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["parent_directory_path"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ContentAvatarNameValue = context.Request.Query["content_avatar_name"].ToString();
            model.ParentDirectoryPathValue = context.Request.Query["parent_directory_path"].ToString();


            model.SetValue();

            View(model);
        }
    }
}