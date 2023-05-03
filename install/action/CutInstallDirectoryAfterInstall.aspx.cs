using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionCutInstallDirectoryAfterInstall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            doc.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list/scheduled_task[@name='cut_install_directory_after_install']").Attributes["active"].Value = "true";

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            StaticObject.SetScheduledTaskDocument();
        }
    }
}