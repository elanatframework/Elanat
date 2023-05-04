using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserFootPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["foot_print_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["foot_print_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string FootPrintId = Request.QueryString["foot_print_id"].ToString();

            DataUse.FootPrint dufp = new DataUse.FootPrint();

            if (dufp.IsUserFootPrint(ccoc.UserId, FootPrintId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}