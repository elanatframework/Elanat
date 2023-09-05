using System.Xml;

namespace Elanat
{
    public class ScheduledTasks
    {
        public static DateTime LastStartScheduledTasks = DateTime.Now;

        /// <summary>
        /// Do Not Use This Method More Than Once, Because Loop May Be Occur
        /// </summary>
        /// <param name="Type">timer, load</param>
        public void Start(string Type)
        {
            // If Scheduled Tasks Is Active
            if (!StaticObject.UseScheduledTasks)
                return;

            if (Type == "timer" && !StaticObject.UseScheduledTimer)
                return;

            if (Type == "load" && !StaticObject.UseScheduledLoad)
                return;


            int CornHour = StaticObject.CornHourDuration;

            DateTime TmpLastStartScheduledTasks = LastStartScheduledTasks.AddSeconds(CornHour);

            if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - long.Parse(TmpLastStartScheduledTasks.ToString("yyyyMMddHHmmss"))) >= 0)
            {
                foreach (XmlElement element in StaticObject.ScheduledTaskNodeList)
                {
                    StaticObject.ScheduledTasksHasABeenImplemented = true;
                    if (element.Attributes["active"].Value == "true")
                    {
                        if (element.Attributes["type"].Value == Type)
                        {
                            if (element.Attributes["check_type"].Value == "page")
                            {
                                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - (long.Parse(element.Attributes["last_run"].Value) + long.Parse(element.Attributes["corn_hour"].Value))) >= 0)
                                {
                                    Security.UseSystemAccess();
                                    string Path = element.Attributes["path"].Value;
                                    string SystemAccessCodeQueryString = (Path.Contains("?")) ? "&el_system_access_code=" + StaticObject.SystemAccessCode : "?el_system_access_code=" + StaticObject.SystemAccessCode;
                                    PageLoader.LoadPath(Path + SystemAccessCodeQueryString, false);

                                    SetLastRun(element.Attributes["name"].Value);
                                }
                            }

                            if (element.Attributes["check_type"].Value == "method")
                            {
                                string DllType = element.Attributes["dll_type"].Value;
                                string DllMethod = element.Attributes["dll_method"].Value;

                                bool IsNonPublic = false;
                                if (element.Attributes["is_non_public"] != null)
                                    IsNonPublic = (element.Attributes["is_non_public"].Value == "true");

                                int ParameterListCount = 0;

                                if (element["parameter_list"] != null)
                                    ParameterListCount = element["parameter_list"].ChildNodes.Count;

                                object[] ObjectParameters = new object[ParameterListCount];

                                int i = 0;
                                foreach (XmlNode Parameter in element["parameter_list"].ChildNodes)
                                {
                                    ObjectParameters[i] = Parameter.InnerText;
                                    i++;
                                }

                                if ((long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) - (long.Parse(element.Attributes["last_run"].Value) + long.Parse(element.Attributes["corn_hour"].Value))) >= 0)
                                {
                                    MethodLoader ml = new MethodLoader();
                                    ml.StartWithoutReturn(StaticObject.ServerMapPath(element.Attributes["path"].Value), DllType, DllMethod, ObjectParameters, IsNonPublic);
                                }
                            }
                        }
                    }
                    StaticObject.ScheduledTasksHasABeenImplemented = false;
                }

                LastStartScheduledTasks = DateTime.Now;
            }
        }

        private void SetLastRun(string Name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            doc.SelectSingleNode("scheduled_tasks_root/scheduled_tasks_list/scheduled_task[@name='" + Name + "']").Attributes["last_run"].Value = DateTime.Now.ToString("yyyyMMddHHmmss");

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"));

            StaticObject.SetScheduledTaskDocument();
        }

        void IDisposable()
        {
            StaticObject.ScheduledTasksHasABeenImplemented = false;
        }
    }
}