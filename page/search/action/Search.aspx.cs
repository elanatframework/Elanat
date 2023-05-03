using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSearch : System.Web.UI.Page
    {
        public ActionSearchModel model = new ActionSearchModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue(Request.QueryString);
        }
    }
}