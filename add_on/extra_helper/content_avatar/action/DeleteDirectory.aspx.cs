using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["directory_path"]))
            {
                string DirectoryPath = Request.QueryString["directory_path"].ToString();

                System.IO.Directory.Delete(Server.MapPath(StaticObject.SitePath + "client/image/content_avatar/" + DirectoryPath), true);

                Response.Write("true");
            }
            else
                Response.Write("false");
        }
    }
}