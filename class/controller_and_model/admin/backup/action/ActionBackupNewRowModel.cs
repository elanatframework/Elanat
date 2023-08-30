using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionBackupNewRowModel : CodeBehindModel
    {
        public string BackupPhysicalNameValue { get; set; }
        
        public void SetValue()
        {
            // Set Backup Template
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/backup/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());


            string SumRowBoxTemplate = "";

            string TmpRowBoxTemplate = RowBoxTemplate;

            long FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + BackupPhysicalNameValue)).Length;

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_physical_name;", BackupPhysicalNameValue);
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_size;", FileSize.ToBitSizeTuning());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_extension;", Path.GetExtension(BackupPhysicalNameValue).Remove(0, 1));

            SumRowBoxTemplate += TmpRowBoxTemplate;

            Write(SumRowBoxTemplate);
        }
    }
}