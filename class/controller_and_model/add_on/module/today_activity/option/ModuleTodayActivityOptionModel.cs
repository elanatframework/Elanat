using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleTodayActivityOptionModel : CodeBehindModel
    {
        public string TodayActivityOptionLanguage { get; set; }
        public string ActiveFootPrintLanguage { get; set; }
        public string ActiveVisitLanguage { get; set; }
        public string ActiveNewUserLanguage { get; set; }
        public string ActiveContactLanguage { get; set; }
        public string ActiveCommentLanguage { get; set; }
        public string ActiveContentLanguage { get; set; }
        public string ActiveActiveContentLanguage { get; set; }
        public string ActiveInactiveContentLanguage { get; set; }
        public string SaveTodayActivityOptionLanguage { get; set; }

        public bool ActiveFootPrintValue { get; set; } = false;
        public bool ActiveVisitValue { get; set; } = false;
        public bool ActiveNewUserValue { get; set; } = false;
        public bool ActiveContactValue { get; set; } = false;
        public bool ActiveCommentValue { get; set; } = false;
        public bool ActiveContentValue { get; set; } = false;
        public bool ActiveActiveContentValue { get; set; } = false;
        public bool ActiveInactiveContentValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/today_activity/");
            TodayActivityOptionLanguage = aol.GetAddOnsLanguage("today_activity_option");
            ActiveFootPrintLanguage = aol.GetAddOnsLanguage("active_foot_print");
            ActiveVisitLanguage = aol.GetAddOnsLanguage("active_visit");
            ActiveNewUserLanguage = aol.GetAddOnsLanguage("active_new_user");
            ActiveContactLanguage = aol.GetAddOnsLanguage("active_contact");
            ActiveCommentLanguage = aol.GetAddOnsLanguage("active_comment");
            ActiveContentLanguage = aol.GetAddOnsLanguage("active_content");
            ActiveActiveContentLanguage = aol.GetAddOnsLanguage("active_active_content");
            ActiveInactiveContentLanguage = aol.GetAddOnsLanguage("active_inactive_content");
            SaveTodayActivityOptionLanguage = aol.GetAddOnsLanguage("save_today_activity_option");


            // Set Current Value
            XmlDocument TodayActivityOptionDocument = new XmlDocument();
            TodayActivityOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/today_activity/option/today_activity_option.xml"));

            XmlNode node = TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root");

            ActiveFootPrintValue = (node["foot_print"].Attributes["active"].Value == "true");
            ActiveVisitValue = (node["visit"].Attributes["active"].Value == "true");
            ActiveNewUserValue = (node["new_user"].Attributes["active"].Value == "true");
            ActiveContactValue = (node["contact"].Attributes["active"].Value == "true");
            ActiveCommentValue = (node["comment"].Attributes["active"].Value == "true");
            ActiveContentValue = (node["content"].Attributes["active"].Value == "true");
            ActiveActiveContentValue = (node["active_content"].Attributes["active"].Value == "true");
            ActiveInactiveContentValue = (node["inactive_content"].Attributes["active"].Value == "true");
        }

        public void SaveTodayActivityOption()
        {
            XmlDocument TodayActivityOptionDocument = new XmlDocument();
            TodayActivityOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/today_activity/option/today_activity_option.xml"));

            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/foot_print").Attributes["active"].Value = ActiveFootPrintValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/visit").Attributes["active"].Value = ActiveVisitValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/new_user").Attributes["active"].Value = ActiveNewUserValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/contact").Attributes["active"].Value = ActiveContactValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/comment").Attributes["active"].Value = ActiveCommentValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/content").Attributes["active"].Value = ActiveContentValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/active_content").Attributes["active"].Value = ActiveActiveContentValue.BooleanToTrueFalse();
            TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root/inactive_content").Attributes["active"].Value = ActiveInactiveContentValue.BooleanToTrueFalse();

            TodayActivityOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/today_activity/option/today_activity_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_today_activity_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("today_activity_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/today_activity/"), "success");
        }
    }
}