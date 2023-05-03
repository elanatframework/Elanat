using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteCommentType : System.Web.UI.Page
    {
        public SiteCommentTypeModel model = new SiteCommentTypeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.TypeOptionListSelectedValue = Request.QueryString["type_value"];
            model.TypeCssClass = Request.QueryString["type_css_class"];
            model.CommentTypeValue = Request.QueryString["comment_type"];

            model.SetValue();


            model.SetImportantField();
        }
    }
}