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
    public partial class ActionGetFetchInformation : System.Web.UI.Page
    {
		public ActionGetFetchInformationModel model = new ActionGetFetchInformationModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["fetch_name"]))
            {
                // Check File Exist
                if (!File.Exists(Server.MapPath(StaticObject.SitePath + "add_on/fetch/" + Request.QueryString["fetch_name"] + "/catalog.xml")))
                {
                    Response.Write("false");
                    return;
                }

                Response.Write(model.GetInformation(Request.QueryString["fetch_name"]));
            }
            else
                Response.Write("false");
        }
    }
}