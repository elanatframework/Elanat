namespace Elanat
{
	public class ProcessKeeper
    {
        // Client
        public static string ClientIpIsSecure
        {
            get { return (!string.IsNullOrEmpty(StaticObject.GetSession("el_current_client:process_keeper_ip_is_secure"))) ? StaticObject.GetSession("el_current_client:process_keeper_ip_is_secure") : null; }
            set { StaticObject.SetSession("el_current_client:process_keeper_ip_is_secure", value); }
        }

        public static string ClientRobotIpIsBlocked
        {
            get { return (!string.IsNullOrEmpty(StaticObject.GetSession("el_current_client:process_keeper_robot_ip_is_blocked"))) ? StaticObject.GetSession("el_current_client:process_keeper_robot_ip_is_blocked") : null; }
            set { StaticObject.SetSession("el_current_client:process_keeper_robot_ip_is_blocked", value); }
        }
    }
}