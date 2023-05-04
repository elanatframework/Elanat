using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.SqlClient;

namespace elanat
{
    public partial class AdminStatistics : System.Web.UI.Page
    {
        public AdminStatisticsModel model = new AdminStatisticsModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}