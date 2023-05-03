using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyType : System.Web.UI.Page
    {
        public SiteContentReplyTypeModel model = new SiteContentReplyTypeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.TypeOptionListSelectedValue = Request.QueryString["type_value"];
            model.TypeCssClass = Request.QueryString["type_css_class"];
            model.ContentReplyTypeValue = Request.QueryString["content_reply_type"];

            model.SetValue();


            model.SetImportantField();
        }
    }
}