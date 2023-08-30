using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCutInstallDirectoryAfterInstallController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            doc.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list/scheduled_task[@name='cut_install_directory_after_install']").Attributes["active"].Value = "true";

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            StaticObject.SetScheduledTaskDocument();
        }
    }
}