using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionRestoreBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["backup_physical_name"]))
            {
                Response.Write("false");
                return;
            }

            if (Path.GetExtension(Request.QueryString["backup_physical_name"].ToString()) == ".bak")
            {
                string BackupPhysicalName = Request.QueryString["backup_physical_name"];

                ZipFileSocket zip = new ZipFileSocket();

                zip.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "backup/" + BackupPhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath), true);
            }


            if (Path.GetExtension(Request.QueryString["backup_physical_name"].ToString()) == ".dat")
            {
                string DatabaseName = ElanatConfig.GetNode("/security/database_name").Attributes["value"].Value;
                string BackupDirectoryPath = Server.MapPath(StaticObject.SitePath + "backup/");
                string BackupPhysicalName = Request.QueryString["backup_physical_name"];

                DataUse.Backup dub = new DataUse.Backup();
                dub.Restore(DatabaseName, BackupDirectoryPath, BackupPhysicalName);
                Response.Write("true");


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("restore_backup", Request.QueryString["backup_physical_name"].ToString());
            }             
        }
    }
}