using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionBackupNewRow : System.Web.UI.Page
    {
        public ActionBackupNewRowModel model = new ActionBackupNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["backup_physical_name"]))
                return;

            model.BackupPhysicalNameValue = Request.QueryString["backup_physical_name"].ToString();


            model.SetValue();
        }
    }
}