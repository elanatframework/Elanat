using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteStyleNewRow : System.Web.UI.Page
    {
        public ActionSiteStyleNewRowModel model = new ActionSiteStyleNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_style_id"]))
                return;

            if (!Request.QueryString["site_style_id"].ToString().IsNumber())
                return;

            model.SiteStyleIdValue = Request.QueryString["site_style_id"].ToString();


            model.SetValue();
        }
    }
}