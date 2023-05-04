using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetAdminStyleInformation : System.Web.UI.Page
    {
        public ActionGetAdminStyleInformationModel model = new ActionGetAdminStyleInformationModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["admin_style_directory_path"]))
            {
                // Check File Exist
                if (!File.Exists(Server.MapPath(StaticObject.SitePath + "client/style/admin/" + Request.QueryString["admin_style_directory_path"] + "/catalog.xml")))
                {
                    Response.Write("false");
                    return;
                }

                Response.Write(model.GetInformation(Request.QueryString["admin_style_directory_path"]));
            }
            else
                Response.Write("false");
        }
    }
}