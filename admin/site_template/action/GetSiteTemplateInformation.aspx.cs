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
    public partial class ActionGetSiteTemplateInformation : System.Web.UI.Page
    {
        public ActionGetSiteTemplateInformationModel model = new ActionGetSiteTemplateInformationModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["site_template_directory_path"]))
            {
                // Check File Exist
                if (!File.Exists(Server.MapPath(StaticObject.SitePath + "template/site/" + Request.QueryString["site_template_directory_path"] + "/catalog.xml")))
                {
                    Response.Write("false");
                    return;
                }

                Response.Write(model.GetInformation(Request.QueryString["site_template_directory_path"]));
            }
            else
                Response.Write("false");
        }
    }
}