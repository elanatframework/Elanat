using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionCategoryNewRow : System.Web.UI.Page
    {
        public ActionCategoryNewRowModel model = new ActionCategoryNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["category_id"]))
                return;

            if (!Request.QueryString["category_id"].ToString().IsNumber())
                return;

            model.CategoryIdValue = Request.QueryString["category_id"].ToString();


            model.SetValue();
        }
    }
}