using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat
{
    public class ActionKeepLoginModel
    {
        public string CurrentPathLineValue { get; set; }
        public string UseStartAddOnInstall { get; set; } = "false";

        public void SetValue(string RandomText, string UserId)
        {
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/user_data/user_" + UserId + "/keep_login/keep_login.ini"));

            string UserIdLineValue = Lines[0].ToString().Remove(0, 8); // user_id=
            string UserIpLineValue = Lines[1].ToString().Remove(0, 8); // user_ip=
            string RandomTextLineValue = Lines[2].ToString().Remove(0, 12); // random_text=
            string DateAndTimeLongLineValue = Lines[3].ToString().Remove(0, 19); // date_and_time_long=
            CurrentPathLineValue = Lines[4].ToString().Remove(0, 13); // current_path=
            string LinkLineValue = Lines[5].ToString().Remove(0, 6); // alert=

            if ((RandomTextLineValue == RandomText) && (UserIdLineValue == UserId) && (Security.GetUserIp() == UserIpLineValue) && ((DateAndTime.GetDateAndTimeLong() - 120) < long.Parse(DateAndTimeLongLineValue)))
            {
                SiteLoginModel model = new SiteLoginModel();
                model.Login(UserId);
            }
        }
    }
}