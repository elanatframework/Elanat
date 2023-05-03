using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentUploadPath : System.Web.UI.Page
    {
        public SiteCommentUploadPathModel model = new SiteCommentUploadPathModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.UploadPathTextValue = Request.QueryString["upload_path_text_value"];


            model.SetValue();
        }
    }
}