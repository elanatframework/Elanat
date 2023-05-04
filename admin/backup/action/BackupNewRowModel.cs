using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionBackupNewRowModel
    {
        public string BackupPhysicalNameValue { get; set; }
        
        public void SetValue()
        {
            // Set Backup Template
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/backup/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());


            string SumRowBoxTemplate = "";

            string TmpRowBoxTemplate = RowBoxTemplate;

            long FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "backup/" + BackupPhysicalNameValue)).Length;

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_physical_name;", BackupPhysicalNameValue);
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_size;", FileSize.ToBitSizeTuning());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_extension;", Path.GetExtension(BackupPhysicalNameValue).Remove(0, 1));

            SumRowBoxTemplate += TmpRowBoxTemplate;

            HttpContext.Current.Response.Write(SumRowBoxTemplate);
        }
    }
}