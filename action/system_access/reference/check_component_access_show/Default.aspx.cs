using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionCheckComponentAccessShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["component_name"]))
            {
                Response.Write("false");
                return;
            }

            string ComponentName = Request.QueryString["component_name"].ToString();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Component duc = new DataUse.Component();
            if (duc.CheckComponentAccessShowByComponentName(ccoc.GroupId, ComponentName))
                Response.Write("true");
        }
    }
}