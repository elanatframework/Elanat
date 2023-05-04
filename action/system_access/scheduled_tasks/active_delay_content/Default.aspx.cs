using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActiveDelayContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_delay_content", new List<string>() { "@current_date", "@current_time" }, new List<string>() { DateAndTime.GetDate("yyyy/MM/dd"), DateAndTime.GetTime("HH:mm:ss") });
        }
    }
}