using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteTemplateNewRow : System.Web.UI.Page
    {
        public ActionSiteTemplateNewRowModel model = new ActionSiteTemplateNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_template_id"]))
                return;

            if (!Request.QueryString["site_template_id"].ToString().IsNumber())
                return;

            model.SiteTemplateIdValue = Request.QueryString["site_template_id"].ToString();


            model.SetValue();
        }
    }
}