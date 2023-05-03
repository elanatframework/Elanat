using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactText : System.Web.UI.Page
    {
        public SiteContactTextModel model = new SiteContactTextModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.TextValue = Request.QueryString["text_value"];
            model.TextCssClass = Request.QueryString["text_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}