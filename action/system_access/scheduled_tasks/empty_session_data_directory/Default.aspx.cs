using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class EmptySessionDataDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/"));
            foreach (DirectoryInfo dir in DirInfo.GetDirectories())
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(dir.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + dir.Name), true);
            }

            FileInfo[] fileInfo = DirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in fileInfo)
            {
                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(file.LastAccessTime.ToString("yyyyMMddHHmmss"))) >= 36000)
                    File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + file.Name));
            }
        }
    }
}
