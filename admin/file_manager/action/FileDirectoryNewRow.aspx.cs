using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionFileDirectoryNewRow : System.Web.UI.Page
    {
        public ActionFileDirectoryNewRowModel model = new ActionFileDirectoryNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["file_directory_path"]))
                return;

            model.FileDirectoryPathValue = Request.QueryString["file_directory_path"].ToString();


            model.SetValue();
        }
    }
}