using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace elanat
{
    public class HostServerClass
    {
        public long GetAvailableFreeSpaceSize()
        {
            string DriveName = Path.GetPathRoot(HttpContext.Current.Server.MapPath("~"));

            try
            {
                DriveInfo drive = new DriveInfo(DriveName);
                long FreeSpace = drive.AvailableFreeSpace;

                return FreeSpace;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
            }

            return 0;
        }

        public long GetTotalSpaceSize()
        {
            string DriveName = Path.GetPathRoot(HttpContext.Current.Server.MapPath("~"));

            try
            {
                DriveInfo drive = new DriveInfo(DriveName);
                long TotalSize = drive.TotalSize;

                return TotalSize;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
            }

            return 0;
        }

        public long GetRootSpaceSize()
        {
            string DriveName = Path.GetPathRoot(HttpContext.Current.Server.MapPath("~"));

            try
            {
                DriveInfo drive = new DriveInfo(DriveName);
                long FreeSpace = drive.AvailableFreeSpace;
                long TotalSize = drive.TotalSize;

                return TotalSize - FreeSpace;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
            }

            return 0;
        }

        public long GetAvailableFreeMemorySize()
        {
            System.Diagnostics.PerformanceCounter AvailableRamSize = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
            return long.Parse(AvailableRamSize.NextValue().ToString());
        }
    }
}