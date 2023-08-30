using CodeBehind;

namespace Elanat
{
    public partial class ActionCutFileDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["file_directory_path"]))
            {
                Write("false");
                return;
            }

            context.Session.SetString("el_file_manager:file_directory_copy_list", context.Request.Query["file_directory_path"].ToString());
            context.Session.SetString("el_file_manager:switch_copy_cut", "cut");
            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("cut_file_directory", context.Request.Query["file_directory_path"].ToString());
        }
    }
}