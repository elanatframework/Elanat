using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleTodayActivityModel : CodeBehindModel
    {
        public string TodayActivityLanguage { get; set; }

        public string FootPrintValue { get; set; } = "";
        public string VisitValue { get; set; } = "";
        public string NewUserValue { get; set; } = "";
        public string NewContactValue { get; set; } = "";
        public string NewCommentValue { get; set; } = "";
        public string NewContentValue { get; set; } = "";
        public string NewActiveContentValue { get; set; } = "";
        public string NewInactiveContentValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/today_activity/");
            TodayActivityLanguage = aol.GetAddOnsLanguage("today_activity");
			
			
            // Set Current Value
            XmlDocument TodayActivityOptionDocument = new XmlDocument();
            TodayActivityOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/today_activity/option/today_activity_option.xml"));

            XmlNode node = TodayActivityOptionDocument.SelectSingleNode("today_activity_option_root");

            // Set Foot Print
            if (node["foot_print"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_foot_print");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang foot_print;", aol.GetAddOnsLanguage("foot_print"));

                DataUse.FootPrint dufp = new DataUse.FootPrint();
                BoxTemplate = BoxTemplate.Replace("$_asp today_foot_print_value;", dufp.GetTodayFootPrintCount());

                FootPrintValue = BoxTemplate;
            }

            // Set Common
            if (node["visit"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_visit");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang visit;", aol.GetAddOnsLanguage("visit"));

                DataUse.Common duc = new DataUse.Common();
                BoxTemplate = BoxTemplate.Replace("$_asp today_visit_value;", duc.GetTodayVisitCount());

                VisitValue = BoxTemplate;
            }

            // Set User
            if (node["new_user"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_user");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang new_user;", aol.GetAddOnsLanguage("new_user"));

                DataUse.User duu = new DataUse.User();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_user_value;", duu.GetTodayNewUserCount());

                NewUserValue = BoxTemplate;
            }

            // Set Contact
            if (node["contact"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_contact");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang contact;", aol.GetAddOnsLanguage("contact"));

                DataUse.Contact duc = new DataUse.Contact();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_contact_value;", duc.GetTodayNewContactCount());

                NewContactValue = BoxTemplate;
            }

            // Set Comment
            if (node["comment"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_comment");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang comment;", aol.GetAddOnsLanguage("comment"));

                DataUse.Comment duc = new DataUse.Comment();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_comment_value;", duc.GetTodayNewCommentCount());

                NewCommentValue = BoxTemplate;
            }

            // Set Content
            if (node["content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_content");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang content;", aol.GetAddOnsLanguage("content"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_content_value;", duc.GetTodayNewContentCount());

                NewContentValue = BoxTemplate;
            }

            // Set Active Content
            if (node["active_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_active_content");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang active;", aol.GetAddOnsLanguage("active"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_active_content_value;", duc.GetTodayNewActiveContentCount());

                NewActiveContentValue = BoxTemplate;
            }

            // Set Inactive Content
            if (node["inactive_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/today_activity/today_new_inactive_content");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang inactive;", aol.GetAddOnsLanguage("inactive"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp today_new_inactive_content_value;", duc.GetTodayNewInactiveContentCount());

                NewInactiveContentValue = BoxTemplate;
            }
        }
    }
}