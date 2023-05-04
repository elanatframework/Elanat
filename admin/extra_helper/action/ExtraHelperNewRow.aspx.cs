using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionExtraHelperNewRow : System.Web.UI.Page
    {
        public ActionExtraHelperNewRowModel model = new ActionExtraHelperNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["extra_helper_id"]))
                return;

            if (!Request.QueryString["extra_helper_id"].ToString().IsNumber())
                return;

            model.ExtraHelperIdValue = Request.QueryString["extra_helper_id"].ToString();


            model.SetValue();
        }
    }
}