using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionTextCreator : System.Web.UI.Page
    {
        public ActionTextCreatorModel model = new ActionTextCreatorModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["value"]))
                return;

            string Value = Request.QueryString["value"];

            model.SetValue(Value, Request.QueryString);
        }
    }
}