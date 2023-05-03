using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SitePrint : System.Web.UI.Page
    {
        public SitePrintModel model = new SitePrintModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
                return;

            if (!Request.QueryString["content_id"].IsNumber())
                return;

            string ContentId = Request.QueryString["content_id"].ToString();


            model.SetValue(ContentId);
        }
    }
}