using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["page_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string PageId = Request.QueryString["page_id"].ToString();

            DataUse.Page dua = new DataUse.Page();

            if(dua.IsUserPage(ccoc.UserId ,PageId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}