using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleInformationOptionModel : CodeBehindModel
    {
        public string InformationOptionLanguage { get; set; }
        public string ActiveFootPrintLanguage { get; set; }
        public string ActiveVisitLanguage { get; set; }
        public string ActiveUserLanguage { get; set; }
        public string ActiveContactLanguage { get; set; }
        public string ActiveCommentLanguage { get; set; }
        public string ActiveContentLanguage { get; set; }
        public string ActiveActiveContentLanguage { get; set; }
        public string ActiveInactiveContentLanguage { get; set; }
        public string ActiveTrashContentLanguage { get; set; }
        public string ActiveDraftContenLanguage { get; set; }
        public string ActiveDelayContentLanguage { get; set; }
        public string ActiveAdminNoteContentLanguage { get; set; }
        public string ActiveAttachmentLanguage { get; set; }
        public string ActiveLogErrorLanguage { get; set; }
        public string ActiveUploadSizeLanguage { get; set; }
        public string ActiveTmpSizeLanguage { get; set; }
        public string SaveInformationOptionLanguage { get; set; }

        public bool ActiveFootPrintValue { get; set; } = false;
        public bool ActiveVisitValue { get; set; } = false;
        public bool ActiveUserValue { get; set; } = false;
        public bool ActiveContactValue { get; set; } = false;
        public bool ActiveCommentValue { get; set; } = false;
        public bool ActiveContentValue { get; set; } = false;
        public bool ActiveActiveContentValue { get; set; } = false;
        public bool ActiveInactiveContentValue { get; set; } = false;
        public bool ActiveTrashContentValue { get; set; } = false;
        public bool ActiveDraftContentValue { get; set; } = false;
        public bool ActiveDelayContentValue { get; set; } = false;
        public bool ActiveAdminNoteContentValue { get; set; } = false;
        public bool ActiveAttachmentValue { get; set; } = false;
        public bool ActiveLogErrorValue { get; set; } = false;
        public bool ActiveUploadSizeValue { get; set; } = false;
        public bool ActiveTmpSizeValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/information/");
            InformationOptionLanguage = aol.GetAddOnsLanguage("information_option");
            ActiveFootPrintLanguage = aol.GetAddOnsLanguage("active_foot_print");
            ActiveVisitLanguage = aol.GetAddOnsLanguage("active_visit");
            ActiveUserLanguage = aol.GetAddOnsLanguage("active_user");
            ActiveContactLanguage = aol.GetAddOnsLanguage("active_contact");
            ActiveCommentLanguage = aol.GetAddOnsLanguage("active_comment");
            ActiveContentLanguage = aol.GetAddOnsLanguage("active_content");
            ActiveActiveContentLanguage = aol.GetAddOnsLanguage("active_active_content");
            ActiveInactiveContentLanguage = aol.GetAddOnsLanguage("active_inactive_content");
            ActiveTrashContentLanguage = aol.GetAddOnsLanguage("active_trash_content");
            ActiveDraftContenLanguage = aol.GetAddOnsLanguage("active_draft_content");
            ActiveDelayContentLanguage = aol.GetAddOnsLanguage("active_delay_content");
            ActiveAdminNoteContentLanguage = aol.GetAddOnsLanguage("active_admin_note_content");
            ActiveAttachmentLanguage = aol.GetAddOnsLanguage("active_attachment");
            ActiveLogErrorLanguage = aol.GetAddOnsLanguage("active_log_error");
            ActiveUploadSizeLanguage = aol.GetAddOnsLanguage("active_upload_size");
            ActiveTmpSizeLanguage = aol.GetAddOnsLanguage("active_tmp_size");
            SaveInformationOptionLanguage = aol.GetAddOnsLanguage("save_information_option");


            // Set Current Value
            XmlDocument InformationOptionDocument = new XmlDocument();
            InformationOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/information/option/information_option.xml"));

            XmlNode node = InformationOptionDocument.SelectSingleNode("information_option_root");

            ActiveFootPrintValue = (node["foot_print"].Attributes["active"].Value == "true");
            ActiveVisitValue = (node["visit"].Attributes["active"].Value == "true");
            ActiveUserValue = (node["user"].Attributes["active"].Value == "true");
            ActiveContactValue = (node["contact"].Attributes["active"].Value == "true");
            ActiveCommentValue = (node["comment"].Attributes["active"].Value == "true");
            ActiveContentValue = (node["content"].Attributes["active"].Value == "true");
            ActiveActiveContentValue = (node["active_content"].Attributes["active"].Value == "true");
            ActiveInactiveContentValue = (node["inactive_content"].Attributes["active"].Value == "true");
            ActiveTrashContentValue = (node["trash_content"].Attributes["active"].Value == "true");
            ActiveDraftContentValue = (node["draft_content"].Attributes["active"].Value == "true");
            ActiveDelayContentValue = (node["delay_content"].Attributes["active"].Value == "true");
            ActiveAdminNoteContentValue = (node["admin_note_content"].Attributes["active"].Value == "true");
            ActiveAttachmentValue = (node["attachment"].Attributes["active"].Value == "true");
            ActiveLogErrorValue = (node["log_error"].Attributes["active"].Value == "true");
            ActiveUploadSizeValue = (node["upload_size"].Attributes["active"].Value == "true");
            ActiveTmpSizeValue = (node["tmp_size"].Attributes["active"].Value == "true");
        }

        public void SaveInformationOption()
        {
            XmlDocument InformationOptionDocument = new XmlDocument();
            InformationOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/information/option/information_option.xml"));

            InformationOptionDocument.SelectSingleNode("information_option_root/foot_print").Attributes["active"].Value = ActiveFootPrintValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/visit").Attributes["active"].Value = ActiveVisitValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/user").Attributes["active"].Value = ActiveUserValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/contact").Attributes["active"].Value = ActiveContactValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/comment").Attributes["active"].Value = ActiveCommentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/content").Attributes["active"].Value = ActiveContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/active_content").Attributes["active"].Value = ActiveActiveContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/inactive_content").Attributes["active"].Value = ActiveInactiveContentValue.BooleanToTrueFalse();

            InformationOptionDocument.SelectSingleNode("information_option_root/trash_content").Attributes["active"].Value = ActiveTrashContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/draft_content").Attributes["active"].Value = ActiveDraftContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/delay_content").Attributes["active"].Value = ActiveDelayContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/admin_note_content").Attributes["active"].Value = ActiveAdminNoteContentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/attachment").Attributes["active"].Value = ActiveAttachmentValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/log_error").Attributes["active"].Value = ActiveLogErrorValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/upload_size").Attributes["active"].Value = ActiveUploadSizeValue.BooleanToTrueFalse();
            InformationOptionDocument.SelectSingleNode("information_option_root/tmp_size").Attributes["active"].Value = ActiveTmpSizeValue.BooleanToTrueFalse();

            InformationOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/information/option/information_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_information_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("information_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/information/"), "success");
        }
    }
}