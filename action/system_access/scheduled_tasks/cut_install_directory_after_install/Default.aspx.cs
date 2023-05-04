using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class CutInstallDirectoryAfterInstall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "install/"));
            dir.MoveTo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/install"));


            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            doc.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list/scheduled_task[@name='cut_install_directory_after_install']").Attributes["active"].Value = "false";

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            StaticObject.SetScheduledTaskDocument();
        }
    }
}