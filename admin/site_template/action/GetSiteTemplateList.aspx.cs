﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetSiteTemplateList : System.Web.UI.Page
    {
		public ActionGetSiteTemplateListModel model = new ActionGetSiteTemplateListModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
			model.SetValue(Request.QueryString);
        }
    }
}