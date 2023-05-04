using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetFileDirectoryViewMore : System.Web.UI.Page
    {
        public ActionGetFileDirectoryViewMoreModel model = new ActionGetFileDirectoryViewMoreModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["file_directory_path"]))
            {
                Response.Write(model.GetViewMore(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Request.QueryString["file_directory_path"].ToString())));
            }
            else
                Response.Write("false");
        }
    }
}