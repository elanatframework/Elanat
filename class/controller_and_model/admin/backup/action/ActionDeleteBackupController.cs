using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteBackupController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["backup_physical_name"]))
            {
                Write("false");
                return;
            }

            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + context.Request.Query["backup_physical_name"].ToString()));
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_backup", context.Request.Query["backup_physical_name"].ToString());
        }
    }
}