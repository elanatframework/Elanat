using CodeBehind;

namespace Elanat
{
    public partial class ActionFileDirectoryNewRowController : CodeBehindController
    {
        public ActionFileDirectoryNewRowModel model = new ActionFileDirectoryNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["file_directory_path"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.FileDirectoryPathValue = context.Request.Query["file_directory_path"].ToString();


            model.SetValue();

            View(model);
        }
    }
}