using CodeBehind;

namespace Elanat
{
    public partial class ActionZipFileDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["file_directory_path"]) || string.IsNullOrEmpty(context.Request.Query["zip_path"]))
            {
                Write("false");
                return;
            }

            string[] FileDirectoryPathArray = context.Request.Query["file_directory_path"].ToString().Split('$');
            string ZipPath = context.Request.Query["zip_path"].ToString();

            int i = 0;
            foreach (string FileDirectoryPath in FileDirectoryPathArray)
            {
                FileDirectoryPathArray[i] = StaticObject.ServerMapPath(FileDirectoryPath);
                i++;
            }

            ZipPath = StaticObject.ServerMapPath(ZipPath);

            ZipFileClass zfc = new ZipFileClass();
            zfc.CreateZip(FileDirectoryPathArray, ZipPath);

            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("zip", context.Request.Query["file_directory_path"].ToString());
        }
    }
}