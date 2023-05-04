using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminDashboardModel
    {
        public string DashboardLanguage { get; set; }

        public string DashboardLocationValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/dashboard/");
            DashboardLanguage = aol.GetAddOnsLanguage("dashboard");


            // Get Dashboard Template
            MenuClass mc = new MenuClass();
            DashboardLocationValue = mc.GetAdminMenu("dashboard");
        }
    }
}