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
    public partial class ExtraHelperShowAdminComponentAccessView : System.Web.UI.Page
    {
        public ExtraHelperShowAdminComponentAccessViewModel model = new ExtraHelperShowAdminComponentAccessViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["current_component"] == null)
                return;


            string ComponentName = Request.QueryString["current_component"].ToString();

            model.SetValue(ComponentName);
        }
    }
}