using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCreateHtmlForPartPage : System.Web.UI.Page
    {
        public ActionCreateHtmlForPartPageModel model = new ActionCreateHtmlForPartPageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
                return;

            if (!Request.QueryString["page_id"].IsNumber())
                return;

            string PageId = Request.QueryString["page_id"].ProtectSqlInjection();


            model.SetValue(PageId, Request.QueryString);
        }
    }
}