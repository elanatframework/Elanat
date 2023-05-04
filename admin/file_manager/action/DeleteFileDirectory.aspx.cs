using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteFileDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["file_path"]))
            {
                ProtectionClass pc = new ProtectionClass();
                if (pc.PathIsProtected(Request.QueryString["file_path"].ToString(), "../"))
                {
                    Response.Write("false");
                    return;
                }
                                
                System.IO.File.Delete(Request.MapPath(StaticObject.SitePath + Request.QueryString["file_path"].ToString()));
                Response.Write("true");
				
				
				// Add Reference
				ReferenceClass rc = new ReferenceClass();
				rc.StartEvent("delete_file", Request.QueryString["file_path"].ToString());
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["directory_path"]))
            {
                ProtectionClass pc = new ProtectionClass();
                if (pc.PathIsProtected(Request.QueryString["directory_path"].ToString(), "../"))
                {
                    Response.Write("false");
                    return;
                }

                System.IO.Directory.Delete(Request.MapPath(StaticObject.SitePath + Request.QueryString["directory_path"].ToString()), true);
                Response.Write("true");
				
				
				// Add Reference
				ReferenceClass rc = new ReferenceClass();
				rc.StartEvent("delete_directory", Request.QueryString["directory_path"].ToString());
            }
            else
                Response.Write("false");
        }
    }
}