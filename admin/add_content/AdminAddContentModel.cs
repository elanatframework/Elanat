using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminAddContentModel
    {
        public string AddContentLanguage { get; set; }
        public string AddNewContentLanguage { get; set; }
        public string ContentTitleLanguage { get; set; }
        public string ContentTextLanguage { get; set; }
        public string SaveContentLanguage { get; set; }
        public string DraftContentLanguage { get; set; }
        public string EditorTemplateLanguage { get; set; }
        public string AddReadMoreLanguage { get; set; }
        public string StatusLanguage { get; set; }
        public string MetaLanguage { get; set; }
        public string PasswordLanguage { get; set; }
        public string DateAndTimeLanguage { get; set; }
        public string ContentStatusLanguage { get; set; }
        public string CategoryLanguage { get; set; }
        public string ContentTypeLanguage { get; set; }
        public string ContentFreeCommentsLanguage { get; set; }
        public string ContentAlwaysOnTopLanguage { get; set; }
        public string MetaKeywordsLanguage { get; set; }
        public string SourceLanguage { get; set; }
        public string ContentPasswordLanguage { get; set; }
        public string UseDelayPublishLanguage { get; set; }
        public string DatePublishLanguage { get; set; }
        public string TimePublishLanguage { get; set; }
        public string AvatarAndIconLanguage { get; set; }
        public string SelectAvatarLanguage { get; set; }
        public string AccessLanguage { get; set; }
        public string ContentAccessShowLanguage { get; set; }
        public string ContentPublicAccessShowLanguage { get; set; }

        public string ContentIconPath { get; set; } = "";
        public string ContentAvatarValue { get; set; }
        public string ContentAvatarPath { get; set; }
        public string ContentIdValue { get; set; }

        public bool IsEdit { get; set; } = false;
        public bool UseFillContent { get; set; } = false;

        public bool ContentFreeCommentsValue { get; set; } = false;
        public bool ContentAlwaysOnTopValue { get; set; } = false;
        public bool UseDelayPublishValue { get; set; } = false;
        public bool ContentPublicAccessShowValue { get; set; } = true;

        public string ContentTitleValue { get; set; }
        public string ContentTextValue { get; set; }
        public string MetaKeywordsValue { get; set; }
        public string ContentSourceValue { get; set; }
        public string ContentPasswordValue { get; set; }
        public string DatePublishValue { get; set; }
        public string TimePublishValue { get; set; }

        public string ContentTitleAttribute { get; set; }
        public string ContentTextAttribute { get; set; }
        public string MetaKeywordsAttribute { get; set; }
        public string ContentSourceAttribute { get; set; }
        public string ContentPasswordAttribute { get; set; }
        public string DatePublishAttribute { get; set; }
        public string TimePublishAttribute { get; set; }

        public string ContentTitleCssClass { get; set; }
        public string ContentTextCssClass { get; set; }
        public string MetaKeywordsCssClass { get; set; }
        public string ContentSourceCssClass { get; set; }
        public string ContentPasswordCssClass { get; set; }
        public string DatePublishCssClass { get; set; }
        public string TimePublishCssClass { get; set; }

        public string ContentStatusOptionListValue { get; set; }
        public string CategoryOptionListValue { get; set; }
        public string ContentTypeOptionListValue { get; set; }
        public string ContentIconOptionListValue { get; set; }
        public string ContentStatusOptionListSelectedValue { get; set; }
        public string CategoryOptionListSelectedValue { get; set; }
        public string ContentTypeOptionListSelectedValue { get; set; }
        public string ContentIconOptionListSelectedValue { get; set; }

        public string ContentStatusAttribute { get; set; }
        public string CategoryAttribute { get; set; }
        public string ContentTypeAttribute { get; set; }
        public string ContentIconAttribute { get; set; }

        public string ContentStatusCssClass { get; set; }
        public string CategoryCssClass { get; set; }
        public string ContentTypeCssClass { get; set; }
        public string ContentIconCssClass { get; set; }

        public ListItemCollection ContentAccessShowListItem = new ListItemCollection();
        public string ContentAccessShowListValue { get; set; }
        public string ContentAccessShowTemplateValue { get; set; }

        public string ContentAccessShowAttribute { get; set; }
        public string ContentAccessShowCssClass { get; set; }

        public string StatusCssClass { get; set; }
        public string AddContentCssClass { get; set; }
        public string SaveContentCssClass { get; set; }
        public string DraftContentCssClass { get; set; }

        public string ContentTypeScriptFunctionValue { get; set; }

        public List<string> EvaluateErrorList;
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/add_content/");
            AddContentLanguage = aol.GetAddOnsLanguage((IsEdit) ? "edit_content" : "add_content");
            AddNewContentLanguage = aol.GetAddOnsLanguage("add_new_content");
            ContentTitleLanguage = aol.GetAddOnsLanguage("content_title");
            AccessLanguage = aol.GetAddOnsLanguage("access");
            CategoryLanguage = aol.GetAddOnsLanguage("category");
            ContentTypeLanguage = aol.GetAddOnsLanguage("content_type");
            ContentAlwaysOnTopLanguage = aol.GetAddOnsLanguage("content_always_on_top");
            ContentFreeCommentsLanguage = aol.GetAddOnsLanguage("content_comment_is_free");
            MetaKeywordsLanguage = aol.GetAddOnsLanguage("meta_keywords");
            SourceLanguage = aol.GetAddOnsLanguage("source");
            AvatarAndIconLanguage = aol.GetAddOnsLanguage("avatar_and_icon");
            AddContentLanguage = aol.GetAddOnsLanguage("add_content");
            SaveContentLanguage = aol.GetAddOnsLanguage("save_content");
            DraftContentLanguage = aol.GetAddOnsLanguage("to_draft");
            SelectAvatarLanguage = aol.GetAddOnsLanguage("select_avatar_from_list");
            EditorTemplateLanguage = aol.GetAddOnsLanguage("editor_template");
            ContentTextLanguage = aol.GetAddOnsLanguage("content_text");
            UseDelayPublishLanguage = aol.GetAddOnsLanguage("use_delay_publish");
            DatePublishLanguage = aol.GetAddOnsLanguage("date_publish");
            TimePublishLanguage = aol.GetAddOnsLanguage("time_publish");
            StatusLanguage = aol.GetAddOnsLanguage("status");
            MetaLanguage = aol.GetAddOnsLanguage("meta");
            PasswordLanguage = aol.GetAddOnsLanguage("password");
            DateAndTimeLanguage = aol.GetAddOnsLanguage("date_and_time");
            AddReadMoreLanguage = aol.GetAddOnsLanguage("read_more");
            ContentPasswordLanguage = aol.GetAddOnsLanguage("content_password");
            ContentPublicAccessShowLanguage = aol.GetAddOnsLanguage("content_public_access_show");
            ContentAccessShowLanguage = aol.GetAddOnsLanguage("content_access_show");


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Category Item
            lc.FillCategoryListItemTree(StaticObject.GetCurrentAdminSiteId(), "-");
            CategoryOptionListValue += lc.CategoryListItemTree.HtmlInputToOptionTag(CategoryOptionListSelectedValue);

            // Set Content Type Item
            lc.FillContentTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContentTypeOptionListValue += lc.ContentTypeListItem.HtmlInputToOptionTag(ContentTypeOptionListSelectedValue);

            // Set Content Icon Item
            lc.FillIconListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContentIconOptionListValue = ContentIconOptionListValue.HtmlInputAddOptionTag("", "");
            ContentIconOptionListValue += lc.IconListItem.HtmlInputToOptionTag(ContentIconOptionListSelectedValue);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/add_content/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lc.UserRoleListItem);
            ContentAccessShowTemplateValue = hcbl.GetValue();
            ContentAccessShowListValue = hcbl.GetList();
            ContentAccessShowTemplateValue = ContentAccessShowTemplateValue.Replace("$_asp attribute;", ContentAccessShowAttribute);
            ContentAccessShowTemplateValue = ContentAccessShowTemplateValue.Replace("$_asp css_class;", ContentAccessShowCssClass);
            ContentAccessShowTemplateValue = ContentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ContentAccessShowListItem);
            

            // Set Date And Time
            DatePublishValue = DateAndTime.GetDate("yyyy/MM/dd");
            TimePublishValue = DateAndTime.GetTime("HH:mm:ss");


            if (IsEdit)
            {
                AddContentCssClass = AddContentCssClass.AddHtmlClass(" el_hidden");
                DraftContentCssClass = DraftContentCssClass.AddHtmlClass(" el_hidden");
                StatusCssClass = StatusCssClass.AddHtmlClass(" el_zone");

                // Set Language
                ContentStatusLanguage = aol.GetAddOnsLanguage("content_status");

                // Set Content Status Item
                lc.FillContentStatusListItem(StaticObject.GetCurrentAdminGlobalLanguage());
                ContentStatusOptionListValue += lc.ContentStatusListItem.HtmlInputToOptionTag(ContentStatusOptionListSelectedValue);
            }
            else
            {
                SaveContentCssClass = SaveContentCssClass.AddHtmlClass(" el_hidden");
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RoleDominantType == "admin" && !IsEdit)
            {
                StatusCssClass = StatusCssClass.AddHtmlClass(" el_zone");

                // Set Language
                ContentStatusLanguage = aol.GetAddOnsLanguage("content_status");

                // Set Content Status Item
                lc.FillContentStatusListItem(StaticObject.GetCurrentAdminGlobalLanguage());
                ContentStatusOptionListValue += lc.ContentStatusListItem.HtmlInputToOptionTag(ContentStatusOptionListSelectedValue);
            }


            if (UseFillContent)
            {
                // Set Content Access Show Selected Value
                lc.FillContentAccessShowListItem(ContentIdValue);
                ContentAccessShowTemplateValue = ContentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lc.ContentAccessShowListItem);

                // Set Content Meta Keywords Value
                lc.FillContentMetaKeywordsListItem(ContentIdValue);
                foreach (ListItem item in lc.ContentMetaKeywordsListItem)
                    MetaKeywordsValue += item.Text + Environment.NewLine;
                if (lc.ContentMetaKeywordsListItem.Length > 0)
                    MetaKeywordsValue = MetaKeywordsValue.Remove(MetaKeywordsValue.Length - 2, 1);

                // Set Content Source Value
                lc.FillContentSourceListItem(ContentIdValue);
                foreach (ListItem item in lc.ContentSourceListItem)
                    ContentSourceValue += item.Text + Environment.NewLine;
                if (lc.ContentSourceListItem.Length > 0)
                    ContentSourceValue = ContentSourceValue.Remove(ContentSourceValue.Length - 2, 1);

                DataUse.Content duc = new DataUse.Content();
                duc.FillCurrentContent(ContentIdValue);

                CategoryOptionListValue = CategoryOptionListValue.HtmlInputSetSelectValue(duc.CategoryId);
                ContentTitleValue = duc.ContentTitle;
                ContentTextValue= duc.ContentText;
                DatePublishValue = duc.ContentDateCreate;
                TimePublishValue = duc.ContentTimeCreate;
                ContentAlwaysOnTopValue = duc.ContentAlwaysOnTop.ZeroOneToBoolean();
                ContentTypeOptionListValue = (!string.IsNullOrEmpty(ContentTypeOptionListSelectedValue)) ? ContentTypeOptionListValue.HtmlInputSetSelectValue(ContentTypeOptionListSelectedValue) : ContentTypeOptionListValue.HtmlInputSetSelectValue(duc.ContentType);
                ContentTypeOptionListSelectedValue = (!string.IsNullOrEmpty(ContentTypeOptionListSelectedValue)) ? ContentTypeOptionListSelectedValue : duc.ContentType;
                if (IsEdit)
                    ContentStatusOptionListValue = ContentStatusOptionListValue.HtmlInputSetSelectValue(duc.ContentStatus);
                ContentFreeCommentsValue = duc.ContentVerifyComments.ZeroOneToBoolean();
                ContentPasswordValue = duc.ContentPassword;
                ContentPublicAccessShowValue = duc.ContentPublicAccessShow.ZeroOneToBoolean();
                if (!string.IsNullOrEmpty(duc.ContentAvatar))
                {
                    ContentAvatarPath = StaticObject.SitePath + "client/image/content_avatar/" + duc.ContentAvatar;
                    ContentAvatarValue = duc.ContentAvatar;
                }
                ContentIconOptionListValue = ContentIconOptionListValue.HtmlInputSetSelectValue(System.IO.Path.GetFileNameWithoutExtension(duc.ContentIcon));
                if (!string.IsNullOrEmpty(duc.ContentIcon))
                    ContentIconPath = StaticObject.SitePath + "client/image/content_icon/" + duc.ContentIcon;
            }


            if (string.IsNullOrEmpty(StatusCssClass))
                StatusCssClass = "el_hidden";


            // Set Content Type Script Function Load
            string TmpContentType = (!string.IsNullOrEmpty(ContentTypeOptionListSelectedValue)) ? ContentTypeOptionListSelectedValue : lc.ContentTypeListItem[0].Value;

            if (StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + TmpContentType) != null)
                ContentTypeScriptFunctionValue = StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + TmpContentType).Attributes["script_function_value"].Value;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ContentTitle", "");
            InputRequest.Add("txt_ContentText", "");
            InputRequest.Add("ddlst_ContentStatus", ContentStatusOptionListValue);
            InputRequest.Add("ddlst_Category", CategoryOptionListValue);
            InputRequest.Add("ddlst_ContentType", ContentTypeOptionListValue);
            InputRequest.Add("txt_MetaKeywords", "");
            InputRequest.Add("txt_ContentSource", "");
            InputRequest.Add("txt_ContentPassword", "");
            InputRequest.Add("txt_DatePublish", "");
            InputRequest.Add("txt_TimePublish", "");
            InputRequest.Add("ddlst_ContentIcon", ContentIconOptionListValue);
            InputRequest.Add("hdn_ContentId", ContentIdValue);
            InputRequest.Add("hdn_ContentAvatar", ContentAvatarValue);
            InputRequest.Add("cbxlst_ContentAccessShow", ContentAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/add_content/");

            ContentTitleAttribute += vc.ImportantInputAttribute["txt_ContentTitle"];
            ContentTextAttribute += vc.ImportantInputAttribute["txt_ContentText"];
            ContentStatusAttribute += vc.ImportantInputAttribute["ddlst_ContentStatus"];
            CategoryAttribute += vc.ImportantInputAttribute["ddlst_Category"];
            ContentTypeAttribute += vc.ImportantInputAttribute["ddlst_ContentType"];
            MetaKeywordsAttribute += vc.ImportantInputAttribute["txt_MetaKeywords"];
            ContentSourceAttribute += vc.ImportantInputAttribute["txt_ContentSource"];
            ContentPasswordAttribute += vc.ImportantInputAttribute["txt_ContentPassword"];
            DatePublishAttribute += vc.ImportantInputAttribute["txt_DatePublish"];
            TimePublishAttribute += vc.ImportantInputAttribute["txt_TimePublish"];
            ContentIconAttribute += vc.ImportantInputAttribute["ddlst_ContentIcon"];
            ContentAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_ContentAccessShow"];

            ContentTitleCssClass = ContentTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentTitle"]);
            ContentTextCssClass = ContentTextCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentText"]);
            ContentStatusCssClass = ContentStatusCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContentStatus"]);
            CategoryCssClass = CategoryCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_Category"]);
            ContentTypeCssClass = ContentTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContentType"]);
            MetaKeywordsCssClass = MetaKeywordsCssClass.AddHtmlClass(vc.ImportantInputClass["txt_MetaKeywords"]);
            ContentSourceCssClass = ContentSourceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentSource"]);
            ContentPasswordCssClass = ContentPasswordCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentPassword"]);
            DatePublishCssClass = DatePublishCssClass.AddHtmlClass(vc.ImportantInputClass["txt_DatePublish"]);
            TimePublishCssClass = TimePublishCssClass.AddHtmlClass(vc.ImportantInputClass["txt_TimePublish"]);
            ContentIconCssClass = ContentIconCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContentIcon"]);
            ContentAccessShowCssClass = ContentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ContentAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/add_content/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ContentTitleCssClass = ContentTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentTitle"]);
                //ContentTextCssClass = ContentTextCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentText"]);
                //ContentStatusCssClass = ContentStatusCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContentStatus"]);
                //CategoryCssClass = CategoryCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_Category"]);
                //ContentTypeCssClass = ContentTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContentType"]);
                //MetaKeywordsCssClass = MetaKeywordsCssClass.AddHtmlClass(vc.WarningFieldClass["txt_MetaKeywords"]);
                //ContentSourceCssClass = ContentSourceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentSource"]);
                //ContentPasswordCssClass = ContentPasswordCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentPassword"]);
                //DatePublishCssClass = DatePublishCssClass.AddHtmlClass(vc.WarningFieldClass["txt_DatePublish"]);
                //TimePublishCssClass = TimePublishCssClass.AddHtmlClass(vc.WarningFieldClass["txt_TimePublish"]);
                //ContentIconCssClass = ContentIconCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContentIcon"]);
                //ContentAccessShowCssClass = ContentIconCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ContentAccessShow"]);
            }
        }

        public void SaveContent()
        {
            // Access Check
            Access ac = new Access();


            // Change Database Data
            DataUse.Content duc = new DataUse.Content();

            duc.UserId = StaticObject.GetCurrentUserId();
            duc.ContentId = ContentIdValue;
            duc.CategoryId = CategoryOptionListSelectedValue;
            duc.ContentTitle = ContentTitleValue;
            duc.ContentText = (StaticObject.RoleWriteHtmlCheck()) ? ContentTextValue : StringClass.RemoveHtmlTags(ContentTextValue);
            duc.ContentDateCreate = (UseDelayPublishValue) ? DatePublishValue : DateAndTime.GetDate("yyyy/MM/dd");
            duc.ContentTimeCreate = (UseDelayPublishValue) ? TimePublishValue : DateAndTime.GetTime("HH:mm:ss");
            duc.ContentAlwaysOnTop = (StaticObject.RoleAddAlwaysOnTopContentCheck()) ? ContentAlwaysOnTopValue.BooleanToZeroOne() : "0";
            duc.ContentStatus = (UseDelayPublishValue) ? "delay" : ContentStatusOptionListSelectedValue;
            duc.ContentType = ContentTypeOptionListSelectedValue;
            duc.ContentVerifyComments = (StaticObject.RoleAddFreeCommentContentCheck()) ? ContentFreeCommentsValue.BooleanToZeroOne() : "0";
            duc.ContentPassword = ContentPasswordValue;
            duc.ContentVisit = "0";
            duc.ContentPublicAccessShow = ContentPublicAccessShowValue.BooleanToZeroOne();
            if (!string.IsNullOrEmpty(ContentAvatarValue))
                duc.ContentAvatar = ContentAvatarValue;
            duc.ContentIcon = ContentIconOptionListSelectedValue;

            // Edit Content
            duc.Edit();

            // Delete Content Access Show
            duc.DeleteContentAccessShow(duc.ContentId);

            // Set Content Access Show
            duc.SetContentAccessShow(duc.ContentId, ContentAccessShowListItem);

            // Delete Content Keywords
            duc.DeleteContentKeywords(duc.ContentId);

            // Add Content Keywords
            string[] ContentKeywordsList = MetaKeywordsValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            duc.AddContentKeywords(duc.ContentId, ContentKeywordsList);

            // Delete Content Source
            duc.DeleteContentSource(duc.ContentId);

            // Add Content Source
            string[] ContentSourceList = ContentSourceValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            duc.AddContentSource(duc.ContentId, ContentSourceList);

            // Delete Content Avatar
            duc.DeleteContentAvatar(duc.ContentId);

            // Add Content Avatar
            if (!string.IsNullOrEmpty(duc.ContentAvatar))
                duc.AddContentAvatar(duc.ContentId, duc.ContentAvatar);

            // Delete Content Icon
            duc.DeleteContentIcon(duc.ContentId);

            // Add Content Icon
            if (!string.IsNullOrEmpty(duc.ContentIcon))
                duc.AddContentIcon(duc.ContentId, duc.ContentIcon);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_content", duc.ContentTitle);
        }

        public void AddContent(string ContentStatus)
        {
            if ((ContentStatus == "active") && (UseDelayPublishValue))
                ContentStatus = "delay";


            // Access Check
            Access ac = new Access();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ContentStatusOptionListSelectedValue == "admin_note" && ccoc.RoleDominantType == "admin")
                ContentStatus = "admin_note";

            if (!StaticObject.RoleAddContentWithoutApprovalCheck())
                ContentStatus = "inactive";


            // Add Data To Database
            DataUse.Content duc = new DataUse.Content();

            duc.UserId = StaticObject.GetCurrentUserId();
            duc.CategoryId = CategoryOptionListSelectedValue;
            duc.ContentTitle = ContentTitleValue;
            duc.ContentText = (StaticObject.RoleWriteHtmlCheck()) ? ContentTextValue : StringClass.RemoveHtmlTags(ContentTextValue);
            duc.ContentDateCreate = (UseDelayPublishValue) ? DatePublishValue : DateAndTime.GetDate("yyyy/MM/dd");
            duc.ContentTimeCreate = (UseDelayPublishValue) ? TimePublishValue : DateAndTime.GetTime("HH:mm:ss");
            duc.ContentAlwaysOnTop = (StaticObject.RoleAddAlwaysOnTopContentCheck()) ? ContentAlwaysOnTopValue.BooleanToZeroOne() : "0";
            duc.ContentType = ContentTypeOptionListSelectedValue;
            duc.ContentStatus = ContentStatus;
            duc.ContentVerifyComments = (StaticObject.RoleAddFreeCommentContentCheck()) ? ContentFreeCommentsValue.BooleanToZeroOne() : "0";
            duc.ContentPassword = ContentPasswordValue;
            duc.ContentVisit = "0";
            duc.ContentPublicAccessShow = ContentPublicAccessShowValue.BooleanToZeroOne();
            if (!string.IsNullOrEmpty(ContentAvatarValue))
                duc.ContentAvatar = ContentAvatarValue;
            duc.ContentIcon = ContentIconOptionListSelectedValue;

            // Add Content
            duc.Add();

            // Set Content Access Show
            duc.SetContentAccessShow(duc.ContentId, ContentAccessShowListItem);

            // Add Content Rating
            duc.AddContentRating(duc.ContentId);

            // Add Content Keywords
            string[] ContentKeywordsList = MetaKeywordsValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            duc.AddContentKeywords(duc.ContentId, ContentKeywordsList);

            // Add Content Source
            string[] ContentSourceList = ContentSourceValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            duc.AddContentSource(duc.ContentId, ContentSourceList);

            // Add Content Avatar
            if (!string.IsNullOrEmpty(duc.ContentAvatar))
                duc.AddContentAvatar(duc.ContentId, duc.ContentAvatar);

            // Add Content Icon
            if (!string.IsNullOrEmpty(duc.ContentIcon))
                duc.AddContentIcon(duc.ContentId, duc.ContentIcon);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_content", duc.ContentTitle);
        }

        public void SuccessView(string Action)
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/add_content/action/SuccessMessage.aspx?action=" + Action, false);
        }
    }
}