using CodeBehind;

namespace Elanat
{
    public partial class ActionRestoreBackupController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["backup_physical_name"]))
            {
                Write("false");
                return;
            }

            if (Path.GetExtension(context.Request.Query["backup_physical_name"].ToString()) == ".bak")
            {
                string BackupPhysicalName = context.Request.Query["backup_physical_name"];

                ZipFileClass zip = new ZipFileClass();

                zip.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + BackupPhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath), true);
            }


            if (Path.GetExtension(context.Request.Query["backup_physical_name"].ToString()) == ".dat")
            {
                string DatabaseName = ElanatConfig.GetNode("/security/database_name").Attributes["value"].Value;
                string BackupDirectoryPath = StaticObject.ServerMapPath(StaticObject.SitePath + "backup/");
                string BackupPhysicalName = context.Request.Query["backup_physical_name"];

                DataUse.Backup dub = new DataUse.Backup();
                dub.Restore(DatabaseName, BackupDirectoryPath, BackupPhysicalName);
                Write("true");


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("restore_backup", context.Request.Query["backup_physical_name"].ToString());
            }             
        }
    }
}