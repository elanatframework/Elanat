using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetCategoryViewMore : System.Web.UI.Page
    {
        public ActionGetCategoryViewMoreModel model = new ActionGetCategoryViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["category_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["category_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["category_id"]));
            else
                Response.Write("false");
        }
    }
}