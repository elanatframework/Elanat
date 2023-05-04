using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionPatchNewRow : System.Web.UI.Page
    {
        public ActionPatchNewRowModel model = new ActionPatchNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["patch_id"]))
                return;

            if (!Request.QueryString["patch_id"].ToString().IsNumber())
                return;

            model.PatchIdValue = Request.QueryString["patch_id"].ToString();


            model.SetValue();
        }
    }
}