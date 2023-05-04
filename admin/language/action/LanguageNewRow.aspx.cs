using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionLanguageNewRow : System.Web.UI.Page
    {
        public ActionLanguageNewRowModel model = new ActionLanguageNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["language_id"]))
                return;

            if (!Request.QueryString["language_id"].ToString().IsNumber())
                return;

            model.LanguageIdValue = Request.QueryString["language_id"].ToString();


            model.SetValue();
        }
    }
}