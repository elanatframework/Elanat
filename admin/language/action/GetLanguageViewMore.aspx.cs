using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetLanguageViewMore : System.Web.UI.Page
    {
        public ActionGetLanguageViewMoreModel model = new ActionGetLanguageViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["language_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["language_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["language_id"], StaticObject.AdminPath + "/language/"));
            else
                Response.Write("false");
        }
    }
}