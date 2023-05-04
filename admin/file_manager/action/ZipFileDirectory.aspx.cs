using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionZipFileDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["file_directory_path"]) || string.IsNullOrEmpty(Request.QueryString["zip_path"]))
            {
                Response.Write("false");
                return;
            }

            string[] FileDirectoryPathArray = Request.QueryString["file_directory_path"].ToString().Split('$');
            string ZipPath = Request.QueryString["zip_path"].ToString();

            int i = 0;
            foreach (string FileDirectoryPath in FileDirectoryPathArray)
            {
                FileDirectoryPathArray[i] = Server.MapPath(StaticObject.SitePath + FileDirectoryPath);
                i++;
            }

            ZipPath = HttpContext.Current.Server.MapPath(StaticObject.SitePath + ZipPath);

            ZipFileSocket zfs = new ZipFileSocket();
            zfs.CreateZip(FileDirectoryPathArray, ZipPath);

            Response.Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("zip", Request.QueryString["file_directory_path"].ToString());
        }
    }
}