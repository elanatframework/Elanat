namespace Elanat
{
    public class HostServerClass
    {
        public long GetAvailableFreeSpaceSize()
        {
            string DriveName = Path.GetPathRoot(StaticObject.ServerMapPath("/"));

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
            string DriveName = Path.GetPathRoot(StaticObject.ServerMapPath("/"));

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
            string DriveName = Path.GetPathRoot(StaticObject.ServerMapPath("/"));

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
    }
}