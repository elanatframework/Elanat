using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ExtraHelperShowLogsListModel
    {
        public void SetValue()
        {
            XmlDocument LogListOptionDocument = new XmlDocument();
            LogListOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/show_logs_list/option/show_logs_list_option.xml"));
            XmlNode node = LogListOptionDocument.SelectSingleNode("show_logs_list_option_root");
            int LogsCount = node["logs_count"].Attributes["value"].Value.ToNumber();

            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            string ShowLogsListExtraHelperId = dueh.GetExtraHelperIdByExtraHelperName("show_logs_list");

            string ListItemTemplate = Template.GetAdminTemplate("box_load/log/list_item");
            string RowBoxTemplate = Template.GetAdminTemplate("box_load/log/box");

            ListItemTemplate = ListItemTemplate.Replace("$_asp show_logs_list_extra_helper_id;", ShowLogsListExtraHelperId);

            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/logs"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.log", SearchOption.TopDirectoryOnly);

            for (int i = fileInfo.Length; i > 0; i--)
            {
                if (LogsCount == 0)
                    break;

                LogsCount--;

                TmpListItemTemplate = ListItemTemplate;
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp log_name;", fileInfo[i - 1].Name);
                SumListItemTemplate += TmpListItemTemplate;
            }

            RowBoxTemplate = RowBoxTemplate.Replace("$_asp item;", SumListItemTemplate);

            HttpContext.Current.Response.Write(RowBoxTemplate);
        }
    }
}