using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionCopyFileDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["file_directory_path"]))
            {
                Response.Write("false");
                return;
            }

            Session.Add("el_file_manager:file_directory_copy_list", Request.QueryString["file_directory_path"].ToString());
            Session.Add("el_file_manager:switch_copy_cut", "copy");
            Response.Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("copy_file_directory", Request.QueryString["file_directory_path"].ToString());               
        }
    }
}