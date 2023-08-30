using CodeBehind;

namespace Elanat
{
    public partial class ActionContentAvatarNewDirectoryController : CodeBehindController
    {
        public ActionContentAvatarNewDirectoryModel model = new ActionContentAvatarNewDirectoryModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["directory_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.DirectoryNameValue = context.Request.Query["directory_name"].ToString();


            model.SetValue();

            View(model);
        }
    }
}