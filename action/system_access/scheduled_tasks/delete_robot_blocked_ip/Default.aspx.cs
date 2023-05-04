using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class DeleteRobotBlockedIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Number 86400 Seconds Is One Day
            int DayDifference = (StaticObject.RobotDetectionIpBlockDuration >= 86400)? StaticObject.RobotDetectionIpBlockDuration / 86400 : 0;
            int SecondsDifference = (DayDifference > 0)? StaticObject.RobotDetectionIpBlockDuration % 86400 : StaticObject.RobotDetectionIpBlockDuration;

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_robot_blocked_ip", new List<string>() { "@current_date", "@current_time" }, new List<string>() { DateAndTime.GetDate("yyyy/MM/dd", DayDifference), DateAndTime.GetTime("HH:mm:ss", SecondsDifference) });


            StaticObject.IpSessionIndexerKeeperName = new List<string>();
            StaticObject.IpSessionIndexerKeeperValue = new List<int>();
        }
    }
}