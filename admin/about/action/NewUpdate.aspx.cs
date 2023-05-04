using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionNewUpdate : System.Web.UI.Page
    {
        public ActionNewUpdateModel model = new ActionNewUpdateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}