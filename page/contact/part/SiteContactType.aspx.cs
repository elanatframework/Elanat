using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactType : System.Web.UI.Page
    {
        public SiteContactTypeModel model = new SiteContactTypeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.TypeOptionListSelectedValue = Request.QueryString["type_value"];
            model.TypeCssClass = Request.QueryString["type_css_class"];

            model.SetValue();


            model.SetImportantField();
        }
    }
}