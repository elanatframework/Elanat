using CodeBehind;

namespace Elanat
{
    public partial class AdminStatisticsModel : CodeBehindModel
    {
        public string StatisticsLanguage { get; set; }
        public string SystemLanguage { get; set; }
        public string BrowserAndOsInfoLanguage { get; set; }
        public string WebServerNameLanguage { get; set; }
        public string MachineNameLanguage { get; set; }
        public string UserDomainNameLanguage { get; set; }
        public string UserInteractiveLanguage { get; set; }
        public string UserNameLanguage { get; set; }
        public string OsVersionLanguage { get; set; }
        public string VersionLanguage { get; set; }
        public string OsPlatformLanguage { get; set; }
        public string Is64BitOperatingSystemLanguage { get; set; }
        public string TickCountLanguage { get; set; }
        public string WorkingSetLanguage { get; set; }
        public string SystemPageSizeLanguage { get; set; }
        public string ProcessorCountLanguage { get; set; }
        public string Is64BitProcessLanguage { get; set; }
        public string LogicalDrivesLanguage { get; set; }
        public string CurrentDirectoryLanguage { get; set; }

        public string WebServerNameValue { get; set; }
        public string MachineNameValue { get; set; }
        public string UserDomainNameValue { get; set; }
        public string UserInteractiveValue { get; set; }
        public string UserNameValue { get; set; }
        public string OsVersionValue { get; set; }
        public string VersionValue { get; set; }
        public string OsPlatformValue { get; set; }
        public string Is64BitOperatingSystemValue { get; set; }
        public string TickCountValue { get; set; }
        public string WorkingSetValue { get; set; }
        public string SystemPageSizeValue { get; set; }
        public string ProcessorCountValue { get; set; }
        public string Is64BitProcessValue { get; set; }
        public string LogicalDrivesValue { get; set; }
        public string CurrentDirectoryValue { get; set; }

        public void SetValue(HttpContext context)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/statistics/");
            StatisticsLanguage = aol.GetAddOnsLanguage("statistics");
            SystemLanguage = aol.GetAddOnsLanguage("system");
            BrowserAndOsInfoLanguage = aol.GetAddOnsLanguage("browser_and_os_info");
            WebServerNameLanguage = aol.GetAddOnsLanguage("web_server_name");
            MachineNameLanguage = aol.GetAddOnsLanguage("machine_name");
            UserDomainNameLanguage = aol.GetAddOnsLanguage("user_domain_name");
            UserInteractiveLanguage = aol.GetAddOnsLanguage("user_interactive");
            UserNameLanguage = aol.GetAddOnsLanguage("user_name");
            OsVersionLanguage = aol.GetAddOnsLanguage("os_version");
            VersionLanguage = aol.GetAddOnsLanguage("version");
            OsPlatformLanguage = aol.GetAddOnsLanguage("os_platform");
            Is64BitOperatingSystemLanguage = aol.GetAddOnsLanguage("is_64_bit_operating_system");
            TickCountLanguage = aol.GetAddOnsLanguage("tick_count");
            WorkingSetLanguage = aol.GetAddOnsLanguage("working_set");
            SystemPageSizeLanguage = aol.GetAddOnsLanguage("system_page_size");
            ProcessorCountLanguage = aol.GetAddOnsLanguage("processor_count");
            Is64BitProcessLanguage = aol.GetAddOnsLanguage("is_64_bit_process");
            LogicalDrivesLanguage = aol.GetAddOnsLanguage("logical_drives");
            CurrentDirectoryLanguage = aol.GetAddOnsLanguage("current_directory");

            WebServerNameValue = context.GetServerVariable("SERVER_SOFTWARE");
            MachineNameValue = Environment.MachineName.ToString();
            UserDomainNameValue = Environment.UserDomainName.ToString();
            UserInteractiveValue = (Environment.UserInteractive) ? aol.GetAddOnsLanguage("true") : aol.GetAddOnsLanguage("false");
            UserNameValue = Environment.UserName.ToString();
            OsVersionValue = Environment.OSVersion.ToString();
            VersionValue = Environment.Version.ToString();
            OsPlatformValue = Environment.OSVersion.Platform.ToString();
            Is64BitOperatingSystemValue = (Environment.Is64BitOperatingSystem) ? aol.GetAddOnsLanguage("true") : aol.GetAddOnsLanguage("false");
            TickCountValue = Environment.TickCount.ToString();
            WorkingSetValue = Environment.WorkingSet.ToString();
            SystemPageSizeValue = Environment.SystemPageSize.ToString();
            ProcessorCountValue = Environment.ProcessorCount.ToString();
            Is64BitProcessValue = (Environment.Is64BitProcess) ? aol.GetAddOnsLanguage("true") : aol.GetAddOnsLanguage("false");
            LogicalDrivesValue = String.Join(", ", Environment.GetLogicalDrives());
            CurrentDirectoryValue = Environment.CurrentDirectory.ToString();
        }
    }
}