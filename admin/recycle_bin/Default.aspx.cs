using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace elanat
{
    public partial class AdminRecycleBin : System.Web.UI.Page
    {
        public AdminRecycleBinModel model = new AdminRecycleBinModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue(Request.QueryString);
        }
    }
}