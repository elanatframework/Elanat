namespace Elanat.DataUse
{
    public class Backup
    {
        public void Restore(string DatabaseName, string BackupDirectoryPath, string BackupPhysicalName)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("resore_backup", new List<string>() { "@database_name", "@backup_directory_path", "@backup_physical_name" }, new List<string>() { DatabaseName, BackupDirectoryPath, BackupPhysicalName });
        }
    }
}