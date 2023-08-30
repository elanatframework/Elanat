using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleLastDataOptionModel : CodeBehindModel
    {
        public string LastDataOptionLanguage { get; set; }
        public string ContactCountLanguage { get; set; }
        public string ActiveContactLanguage { get; set; }
        public string CommentCountLanguage { get; set; }
        public string ActiveCommentLanguage { get; set; }
        public string AttachmentCountLanguage { get; set; }
        public string ActiveAttachmentLanguage { get; set; }
        public string ContentCountLanguage { get; set; }
        public string ActiveContentLanguage { get; set; }
        public string FootPrintCountLanguage { get; set; }
        public string ActiveFootPrintLanguage { get; set; }
        public string UserSignUpCountLanguage { get; set; }
        public string ActiveUserSignUpLanguage { get; set; }
        public string ActiveUserCountLanguage { get; set; }
        public string ActiveActiveUserLanguage { get; set; }
        public string SaveTodayActivityOptionLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public bool ActiveContactValue { get; set; } = false;
        public bool ActiveCommentValue { get; set; } = false;
        public bool ActiveAttachmentValue { get; set; } = false;
        public bool ActiveContentValue { get; set; } = false;
        public bool ActiveFootPrintValue { get; set; } = false;
        public bool ActiveUserSignUpValue { get; set; } = false;
        public bool ActiveActiveUserValue { get; set; } = false;

        public string ContactCountValue { get; set; }
        public string CommentCountValue { get; set; }
        public string AttachmentCountValue { get; set; }
        public string ContentCountValue { get; set; }
        public string FootPrintCountValue { get; set; }
        public string UserSignUpCountValue { get; set; }
        public string ActiveUserCountValue { get; set; }

        public string ContactCountAttribute { get; set; }
        public string CommentCountAttribute { get; set; }
        public string AttachmentCountAttribute { get; set; }
        public string ContentCountAttribute { get; set; }
        public string FootPrintCountAttribute { get; set; }
        public string UserSignUpCountAttribute { get; set; }
        public string ActiveUserCountAttribute { get; set; }

        public string ContactCountCssClass { get; set; }
        public string CommentCountCssClass { get; set; }
        public string AttachmentCountCssClass { get; set; }
        public string ContentCountCssClass { get; set; }
        public string FootPrintCountCssClass { get; set; }
        public string UserSignUpCountCssClass { get; set; }
        public string ActiveUserCountCssClass { get; set; }


        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/last_data/");
            LastDataOptionLanguage = aol.GetAddOnsLanguage("last_data_option");
            ContactCountLanguage = aol.GetAddOnsLanguage("contact_count");
            ActiveContactLanguage = aol.GetAddOnsLanguage("active_contact");
            CommentCountLanguage = aol.GetAddOnsLanguage("comment_count");
            ActiveCommentLanguage = aol.GetAddOnsLanguage("active_comment");
            AttachmentCountLanguage = aol.GetAddOnsLanguage("attachment_count");
            ActiveAttachmentLanguage = aol.GetAddOnsLanguage("active_attachment");
            ContentCountLanguage = aol.GetAddOnsLanguage("content_count");
            ActiveContentLanguage = aol.GetAddOnsLanguage("active_content");
            FootPrintCountLanguage = aol.GetAddOnsLanguage("foot_print_count");
            ActiveFootPrintLanguage = aol.GetAddOnsLanguage("active_foot_print");
            UserSignUpCountLanguage = aol.GetAddOnsLanguage("user_sign_up_count");
            ActiveUserSignUpLanguage = aol.GetAddOnsLanguage("active_user_sign_up");
            ActiveUserCountLanguage = aol.GetAddOnsLanguage("active_user_count");
            ActiveActiveUserLanguage = aol.GetAddOnsLanguage("active_active_user");
            SaveTodayActivityOptionLanguage = aol.GetAddOnsLanguage("save_last_data_option");


            // Set Current Value
            if (IsFirstStart)
            {
                XmlDocument LastDataOptionDocument = new XmlDocument();
                LastDataOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/last_data/option/last_data_option.xml"));

                XmlNode node = LastDataOptionDocument.SelectSingleNode("last_data_option_root");

                ActiveContactValue = (node["last_contact"].Attributes["active"].Value == "true");
                ActiveCommentValue = (node["last_comment"].Attributes["active"].Value == "true");
                ActiveAttachmentValue = (node["last_attachment"].Attributes["active"].Value == "true");
                ActiveContentValue = (node["last_content"].Attributes["active"].Value == "true");
                ActiveFootPrintValue = (node["last_foot_print"].Attributes["active"].Value == "true");
                ActiveUserSignUpValue = (node["last_user_sign_up"].Attributes["active"].Value == "true");
                ActiveActiveUserValue = (node["active_users_in_last_24_hours"].Attributes["active"].Value == "true");

                ContactCountValue = node["last_contact"].Attributes["item_count"].Value;
                CommentCountValue = node["last_comment"].Attributes["item_count"].Value;
                AttachmentCountValue = node["last_attachment"].Attributes["item_count"].Value;
                ContentCountValue = node["last_content"].Attributes["item_count"].Value;
                FootPrintCountValue = node["last_foot_print"].Attributes["item_count"].Value;
                UserSignUpCountValue = node["last_user_sign_up"].Attributes["item_count"].Value;
                ActiveUserCountValue = node["active_users_in_last_24_hours"].Attributes["item_count"].Value;
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ContactCount", "");
            InputRequest.Add("txt_CommentCount", "");
            InputRequest.Add("txt_AttachmentCount", "");
            InputRequest.Add("txt_ContentCount", "");
            InputRequest.Add("txt_FootPrintCount", "");
            InputRequest.Add("txt_UserSignUpCount", "");
            InputRequest.Add("txt_ActiveUserCount", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "add_on/module/last_data/");

            ContactCountAttribute += vc.ImportantInputAttribute.GetValue("txt_ContactCount");
            CommentCountAttribute += vc.ImportantInputAttribute.GetValue("txt_CommentCount");
            AttachmentCountAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentCount");
            ContentCountAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentCount");
            FootPrintCountAttribute += vc.ImportantInputAttribute.GetValue("txt_FootPrintCount");
            UserSignUpCountAttribute += vc.ImportantInputAttribute.GetValue("txt_UserSignUpCount");
            ActiveUserCountAttribute += vc.ImportantInputAttribute.GetValue("txt_ActiveUserCount");

            ContactCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContactCount"));
            CommentCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CommentCount"));
            AttachmentCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentCount"));
            ContentCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentCount"));
            FootPrintCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FootPrintCount"));
            UserSignUpCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserSignUpCount"));
            ActiveUserCountCssClass = ContactCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ActiveUserCount"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "add_on/module/last_data/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveLastDataOption()
        {
            XmlDocument LastDataOptionDocument = new XmlDocument();
            LastDataOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/last_data/option/last_data_option.xml"));

            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_contact").Attributes["active"].Value = ActiveContactValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_comment").Attributes["active"].Value = ActiveCommentValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_attachment").Attributes["active"].Value = ActiveAttachmentValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_content").Attributes["active"].Value = ActiveContentValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_foot_print").Attributes["active"].Value = ActiveFootPrintValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_user_sign_up").Attributes["active"].Value = ActiveUserSignUpValue.BooleanToTrueFalse();
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/active_users_in_last_24_hours").Attributes["active"].Value = ActiveActiveUserValue.BooleanToTrueFalse();

            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_contact").Attributes["item_count"].Value = ContactCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_comment").Attributes["item_count"].Value = CommentCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_attachment").Attributes["item_count"].Value = AttachmentCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_content").Attributes["item_count"].Value = ContentCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_foot_print").Attributes["item_count"].Value = FootPrintCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/last_user_sign_up").Attributes["item_count"].Value = UserSignUpCountValue;
            LastDataOptionDocument.SelectSingleNode("last_data_option_root/active_users_in_last_24_hours").Attributes["item_count"].Value = ActiveUserCountValue;

            LastDataOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/last_data/option/last_data_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_last_data_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("last_data_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/last_data/"), "success");
        }
    }
}