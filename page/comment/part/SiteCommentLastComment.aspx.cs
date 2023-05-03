using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentLastComment : System.Web.UI.Page
    {
        public SiteCommentLastCommentModel model = new SiteCommentLastCommentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ContentId = int.Parse(Request.QueryString["content_id"]).ToString();

            model.SetValue(ContentId);
        }
    }
}