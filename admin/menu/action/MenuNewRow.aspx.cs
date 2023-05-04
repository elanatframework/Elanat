using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionMenuNewRow : System.Web.UI.Page
    {
        public ActionMenuNewRowModel model = new ActionMenuNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["menu_id"]))
                return;

            if (!Request.QueryString["menu_id"].ToString().IsNumber())
                return;

            model.MenuIdValue = Request.QueryString["menu_id"].ToString();


            model.SetValue();
        }
    }
}