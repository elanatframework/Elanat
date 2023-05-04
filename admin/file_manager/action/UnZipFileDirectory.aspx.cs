using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionUnZipFileDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["zip_path"]) || string.IsNullOrEmpty(Request.QueryString["un_zip_path"]) || string.IsNullOrEmpty(Request.QueryString["use_overwrite_extract_existing_file"]))
            {
                Response.Write("false");
                return;
            }

            string ZipPath = Request.QueryString["zip_path"].ToString();
            string UnZipPath = Request.QueryString["un_zip_path"].ToString();
            bool UseOverwriteExtractExistingFile = (Request.QueryString["use_overwrite_extract_existing_file"].ToString() == "true");

            ZipPath = HttpContext.Current.Server.MapPath(StaticObject.SitePath + ZipPath);
            UnZipPath = HttpContext.Current.Server.MapPath(StaticObject.SitePath + UnZipPath);


            ZipFileSocket zfs = new ZipFileSocket();
            zfs.UnZip(ZipPath, UnZipPath, UseOverwriteExtractExistingFile);
            Response.Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("un_zip", Request.QueryString["un_zip_path"].ToString());
        }
    }
}