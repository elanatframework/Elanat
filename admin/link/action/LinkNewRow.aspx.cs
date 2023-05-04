using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionLinkNewRow : System.Web.UI.Page
    {
        public ActionLinkNewRowModel model = new ActionLinkNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["link_id"]))
                return;

            if (!Request.QueryString["link_id"].ToString().IsNumber())
                return;

            model.LinkIdValue = Request.QueryString["link_id"].ToString();


            model.SetValue();
        }
    }
}