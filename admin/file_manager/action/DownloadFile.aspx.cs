using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["file_path"]))
            {
                Response.Write("false");
                return;
            }

            if (!System.IO.Path.GetFileName(Request.QueryString["file_path"].ToString()).Contains('.'))
            {
                Response.Write("false");
                return;
            }

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(Request.QueryString["file_path"].ToString()));
            Response.TransmitFile(Server.MapPath(StaticObject.SitePath + Request.QueryString["file_path"].ToString()));
            Response.End();
        }
    }
}