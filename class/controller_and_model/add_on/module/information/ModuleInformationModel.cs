using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleInformationModel : CodeBehindModel
    {
        public string InformationLanguage { get; set; }

        public string FootPrintValue { get; set; } = "";
        public string VisitValue { get; set; } = "";
        public string UserValue { get; set; } = "";
        public string ContactValue { get; set; } = "";
        public string CommentValue { get; set; } = "";
        public string ContentValue { get; set; } = "";
        public string ActiveContentValue { get; set; } = "";
        public string InactiveContentValue { get; set; } = "";
        public string TrashContentValue { get; set; } = "";
        public string DraftContentValue { get; set; } = "";
        public string DelayContentValue { get; set; } = "";
        public string AdminNoteContentValue { get; set; } = "";
        public string AttachmentValue { get; set; } = "";
        public string LogErrorValue { get; set; } = "";
        public string UploadSizeValue { get; set; } = "";
        public string TmpSizeValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/information/");
            InformationLanguage = aol.GetAddOnsLanguage("information");
			
			
            // Set Current Value
            XmlDocument InformationOptionDocument = new XmlDocument();
            InformationOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/information/option/information_option.xml"));

            XmlNode node = InformationOptionDocument.SelectSingleNode("information_option_root");

            // Set Foot Print
            if (node["foot_print"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/foot_print");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang foot_print;", aol.GetAddOnsLanguage("foot_print"));

                DataUse.FootPrint dufp = new DataUse.FootPrint();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_foot_print_value;", dufp.GetFootPrintCount());

                FootPrintValue = BoxTemplate;
            }

            // Set Common
            if (node["visit"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/visit");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang visit;", aol.GetAddOnsLanguage("visit"));

                DataUse.Common duc = new DataUse.Common();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_visit_value;", duc.GetVisitCount());

                VisitValue = BoxTemplate;
            }

            // Set User
            if (node["user"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/user");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang user;", aol.GetAddOnsLanguage("user"));

                DataUse.User duu = new DataUse.User();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_user_value;", duu.GetUserCount());

                UserValue = BoxTemplate;
            }

            // Set Contact
            if (node["contact"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/contact");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang contact;", aol.GetAddOnsLanguage("contact"));

                DataUse.Contact duc = new DataUse.Contact();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_contact_value;", duc.GetContactCount());

                ContactValue = BoxTemplate;
            }

            // Set Comment
            if (node["comment"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/comment");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang comment;", aol.GetAddOnsLanguage("comment"));

                DataUse.Comment duc = new DataUse.Comment();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_comment_value;", duc.GetCommentCount());

                CommentValue = BoxTemplate;
            }

            // Set Content
            if (node["content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/content");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang content;", aol.GetAddOnsLanguage("content"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_content_value;", duc.GetContentCount());

                ContentValue = BoxTemplate;
            }

            // Set Active Content
            if (node["active_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/active");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang active;", aol.GetAddOnsLanguage("active"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_active_content_value;", duc.GetActiveContentCount());

                ActiveContentValue = BoxTemplate;
            }

            // Set Inactive Content
            if (node["inactive_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/inactive");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang inactive;", aol.GetAddOnsLanguage("inactive"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_inactive_content_value;", duc.GetInactiveContentCount());

                InactiveContentValue = BoxTemplate;
            }

            // Set Trash Content
            if (node["trash_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/trash");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang trash;", aol.GetAddOnsLanguage("trash"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_trash_content_value;", duc.GetTrashContentCount());

                TrashContentValue = BoxTemplate;
            }

            // Set Draft Content
            if (node["draft_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/draft");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang draft;", aol.GetAddOnsLanguage("draft"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_draft_content_value;", duc.GetDraftContentCount());

                DraftContentValue = BoxTemplate;
            }

            // Set Delay Content
            if (node["delay_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/delay");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang delay;", aol.GetAddOnsLanguage("delay"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_delay_content_value;", duc.GetDelayContentCount());

                DelayContentValue = BoxTemplate;
            }

            // Set Admin Note Content
            if (node["admin_note_content"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/admin_note");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang admin_note;", aol.GetAddOnsLanguage("admin_note"));

                DataUse.Content duc = new DataUse.Content();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_admin_note_content_value;", duc.GetAdminNoteContentCount());

                AdminNoteContentValue = BoxTemplate;
            }

            // Set Attachment
            if (node["attachment"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/attachment");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang attachment;", aol.GetAddOnsLanguage("attachment"));

                DataUse.Attachment dua = new DataUse.Attachment();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_attachment_value;", dua.GetAttachmentCount());

                AttachmentValue = BoxTemplate;
            }

            // Set Log Error
            if (node["log_error"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/log_error");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang log_error;", aol.GetAddOnsLanguage("log_error"));

                FileAndDirectory fad = new FileAndDirectory();
                BoxTemplate = BoxTemplate.Replace("$_asp number_of_log_error_value;", fad.GetDirectoryFilesCount(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/logs")).ToString());

                LogErrorValue = BoxTemplate;
            }

            // Set Upload Size
            if (node["upload_size"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/upload_size");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang upload_size;", aol.GetAddOnsLanguage("upload_size"));

                FileAndDirectory fad = new FileAndDirectory();
                BoxTemplate = BoxTemplate.Replace("$_asp upload_directory_size_value;", fad.GetDirectoryFileSize(StaticObject.ServerMapPath(StaticObject.SitePath + "upload"), false).ToBitSizeTuning());

                UploadSizeValue = BoxTemplate;
            }

            // Set Tmp Size
            if (node["tmp_size"].Attributes["active"].Value == "true")
            {
                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/information/tmp_size");

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang tmp_size;", aol.GetAddOnsLanguage("tmp_size"));

                FileAndDirectory fad = new FileAndDirectory();
                BoxTemplate = BoxTemplate.Replace("$_asp tmp_directory_size_value;", fad.GetDirectoryFileSize(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp"), false).ToBitSizeTuning());

                TmpSizeValue = BoxTemplate;
            }
        }
    }
}