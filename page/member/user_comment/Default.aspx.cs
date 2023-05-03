using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class MemberUserComment : System.Web.UI.Page
    {
        public MemberUserCommentModel model = new MemberUserCommentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set Query String
            string QueryString = (Request.QueryString.Count > 0) ? "?" + Request.QueryString.ToString() : "";


            model.SetValue(QueryString);
        }
    }
}