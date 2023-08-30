using CodeBehind;

namespace Elanat
{
    public partial class EmptySessionDataDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/"));
            foreach (DirectoryInfo dir in DirInfo.GetDirectories())
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(dir.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + dir.Name), true);
            }

            FileInfo[] fileInfo = DirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in fileInfo)
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(file.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + file.Name));
            }
        }
    }
}