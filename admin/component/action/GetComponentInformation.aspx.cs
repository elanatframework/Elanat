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
    public partial class ActionGetComponentInformation : System.Web.UI.Page
    {
		public ActionGetComponentInformationModel model = new ActionGetComponentInformationModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["component_directory_path"]))
            {
                // Check File Exist
                if (!File.Exists(Server.MapPath(StaticObject.AdminPath + "/" + Request.QueryString["component_directory_path"] + "/catalog.xml")))
                {
                    Response.Write("false");
                    return;
                }

                Response.Write(model.GetInformation(Request.QueryString["component_directory_path"]));
            }
            else
                Response.Write("false");
        }
    }
}