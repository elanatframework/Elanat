using CodeBehind;

namespace Elanat
{
    public partial class EmptyTmpDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"));
            foreach (DirectoryInfo dir in DirInfo.GetDirectories())
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(dir.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + dir.Name), true);
            }

            FileInfo[] fileInfo = DirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in fileInfo)
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(file.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + file.Name));
            }
        }
    }
}