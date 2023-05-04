using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionPageNewRow : System.Web.UI.Page
    {
        public ActionPageNewRowModel model = new ActionPageNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
                return;

            if (!Request.QueryString["page_id"].ToString().IsNumber())
                return;

            model.PageIdValue = Request.QueryString["page_id"].ToString();


            model.SetValue();
        }
    }
}