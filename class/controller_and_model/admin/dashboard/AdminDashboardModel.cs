using CodeBehind;

namespace Elanat
{
    public partial class AdminDashboardModel : CodeBehindModel
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