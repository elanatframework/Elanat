﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class StartAddOnInstall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReCompileIssues rci = new ReCompileIssues();
            rci.StartAddOnInstall(false);
        }
    }
}