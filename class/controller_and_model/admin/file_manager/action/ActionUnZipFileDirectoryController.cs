using CodeBehind;

namespace Elanat
{
    public partial class ActionUnZipFileDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["zip_path"]) || string.IsNullOrEmpty(context.Request.Query["un_zip_path"]) || string.IsNullOrEmpty(context.Request.Query["use_overwrite_extract_existing_file"]))
            {
                Write("false");
                return;
            }

            string ZipPath = context.Request.Query["zip_path"].ToString();
            string UnZipPath = context.Request.Query["un_zip_path"].ToString();
            bool UseOverwriteExtractExistingFile = (context.Request.Query["use_overwrite_extract_existing_file"].ToString() == "true");

            ZipPath = StaticObject.ServerMapPath(StaticObject.SitePath + ZipPath);
            UnZipPath = StaticObject.ServerMapPath(StaticObject.SitePath + UnZipPath);


            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(ZipPath, UnZipPath, UseOverwriteExtractExistingFile);
            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("un_zip", context.Request.Query["un_zip_path"].ToString());
        }
    }
}