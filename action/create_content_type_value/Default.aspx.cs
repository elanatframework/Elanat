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
    public partial class ActionCreateContentTypeValue : System.Web.UI.Page
    {
        public ActionCreateContentTypeValueModel model = new ActionCreateContentTypeValueModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_type"]))
                return;

            string ContentType = Request.QueryString["content_type"];


            model.SetValue(ContentType);
        }
    }
}