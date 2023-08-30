namespace Elanat
{
	public class RobotIpBlock
    {
        public bool RobotIpIsBlocked()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("robot_ip_is_blocked", "@user_ip" , Security.GetUserIp());

            dbdr.dr.Read();

            bool RobotIpIsBlocked = dbdr.dr["robot_ip_is_blocked"].ToString().TrueFalseToBoolean();

            db.Close();

            return RobotIpIsBlocked;
        }

        public void AddRobotIpBlock()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_robot_ip_block", new List<string>() { "@user_ip", "@date_block", "@time_block" }, new List<string>() { Security.GetUserIp(), DateAndTime.GetDate("yyyy/MM/dd"), DateAndTime.GetTime("HH:mm:ss") });
        }

        public void ResetRequest()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Robot Detection Request Count
            switch (ccoc.RoleDominantType)
            {
                case "admin":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "member":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "guest":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "after_show_captcha_count").ToNumber();
                    break;
            }
            ccoc.RobotDetectionDateTimeLong = DateAndTime.GetDateAndTimeLong();


            Security sc = new Security();
            sc.ResetIpSessionIndexer();
        }
    }
}