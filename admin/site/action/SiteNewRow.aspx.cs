using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteNewRow : System.Web.UI.Page
    {
        public ActionSiteNewRowModel model = new ActionSiteNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_id"]))
                return;

            if (!Request.QueryString["site_id"].ToString().IsNumber())
                return;

            model.SiteIdValue = Request.QueryString["site_id"].ToString();


            model.SetValue();
        }
    }
}