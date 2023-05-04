using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class StartTimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScheduledTimer.Main();
        }
    }
}