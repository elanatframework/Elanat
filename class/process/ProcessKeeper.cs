using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat
{
	public class ProcessKeeper
    {
        // Client
        public static string ClientIpIsSecure
        {
            get { return (HttpContext.Current.Session["el_current_client:process_keeper_ip_is_secure"] != null) ? HttpContext.Current.Session["el_current_client:process_keeper_ip_is_secure"].ToString() : null; }
            set { HttpContext.Current.Session.Add("el_current_client:process_keeper_ip_is_secure", value); }
        }

        public static string ClientRobotIpIsBlocked
        {
            get { return (HttpContext.Current.Session["el_current_client:process_keeper_robot_ip_is_blocked"] != null) ? HttpContext.Current.Session["el_current_client:process_keeper_robot_ip_is_blocked"].ToString() : null; }
            set { HttpContext.Current.Session.Add("el_current_client:process_keeper_robot_ip_is_blocked", value); }
        }
    }
}