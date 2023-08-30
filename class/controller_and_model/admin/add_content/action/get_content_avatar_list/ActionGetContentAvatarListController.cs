using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContentAvatarListController : CodeBehindController
    {
        public ActionGetContentAvatarListModel model = new ActionGetContentAvatarListModel();

        public void PageLoad(HttpContext context)
        {
            string CurrentPath = "";

            if (!string.IsNullOrEmpty(context.Request.Query["path"]))
                CurrentPath = context.Request.Query["path"].ToString();

            model.PathValue = CurrentPath;


            model.SetValue();

            View(model);
        }
    }
}