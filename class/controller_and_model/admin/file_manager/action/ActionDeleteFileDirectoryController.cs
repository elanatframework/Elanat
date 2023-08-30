using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteFileDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["file_path"]))
            {
                ProtectionClass pc = new ProtectionClass();
                if (pc.PathIsProtected(context.Request.Query["file_path"].ToString(), "../"))
                {
                    Write("false");
                    return;
                }
                                
                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + context.Request.Query["file_path"].ToString()));
                Write("true");
				
				
				// Add Reference
				ReferenceClass rc = new ReferenceClass();
				rc.StartEvent("delete_file", context.Request.Query["file_path"].ToString());
            }
            else if (!string.IsNullOrEmpty(context.Request.Query["directory_path"]))
            {
                ProtectionClass pc = new ProtectionClass();
                if (pc.PathIsProtected(context.Request.Query["directory_path"].ToString(), "../"))
                {
                    Write("false");
                    return;
                }

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + context.Request.Query["directory_path"].ToString()), true);
                Write("true");
				
				
				// Add Reference
				ReferenceClass rc = new ReferenceClass();
				rc.StartEvent("delete_directory", context.Request.Query["directory_path"].ToString());
            }
            else
                Write("false");
        }
    }
}