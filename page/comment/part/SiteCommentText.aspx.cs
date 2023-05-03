using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentText : System.Web.UI.Page
    {
        public SiteCommentTextModel model = new SiteCommentTextModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.TextValue = Request.QueryString["text_value"];
            model.TextCssClass = Request.QueryString["text_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}