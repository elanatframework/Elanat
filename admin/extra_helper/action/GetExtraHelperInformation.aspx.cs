﻿using System;
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
    public partial class ActionGetExtraHelperInformation : System.Web.UI.Page
    {
		public ActionGetExtraHelperInformationModel model = new ActionGetExtraHelperInformationModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["extra_helper_directory_path"]))
            {
                // Check File Exist
                if (!File.Exists(Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/" + Request.QueryString["extra_helper_directory_path"] + "/catalog.xml")))
                {
                    Response.Write("false");
                    return;
                }

                Response.Write(model.GetInformation(Request.QueryString["extra_helper_directory_path"]));
            }
            else
                Response.Write("false");
        }
    }
}