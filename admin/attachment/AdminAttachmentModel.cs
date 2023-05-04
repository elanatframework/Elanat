using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminAttachmentModel
    {
        public string AttachmentLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AttachmentPathLanguage { get; set; }
        public string UseAttachmentPathLanguage { get; set; }
        public string AttachmentNameLanguage { get; set; }
        public string AttachmentActiveLanguage { get; set; }
        public string AttachmentAboutLanguage { get; set; }
        public string AttachmentPasswordLanguage { get; set; }
        public string AttachmentContentLanguage { get; set; }
        public string AttachmentAccessShowLanguage { get; set; }
        public string AttachmentPublicAccessShowLanguage { get; set; }
        public string AddAttachmentLanguage { get; set; }

        public bool AttachmentActiveValue { get; set; } = false;
        public bool AttachmentPublicAccessShowValue { get; set; } = false;
        public bool UseAttachmentPathValue { get; set; } = false;

        public HttpPostedFile AttachmentPathUploadValue { get; set; }
        public string AttachmentPathTextValue { get; set; }

        public string AttachmentNameValue { get; set; }
        public string AttachmentAboutValue { get; set; }
        public string AttachmentContentValue { get; set; }
        public string AttachmentPasswordValue { get; set; }

        public string AttachmentNameAttribute { get; set; }
        public string AttachmentAboutAttribute { get; set; }
        public string AttachmentContentAttribute { get; set; }
        public string AttachmentPasswordAttribute { get; set; }

        public string AttachmentNameCssClass { get; set; }
        public string AttachmentAboutCssClass { get; set; }
        public string AttachmentContentCssClass { get; set; }
        public string AttachmentPasswordCssClass { get; set; }

        public ListItemCollection AttachmentAccessShowListItem = new ListItemCollection();
        public string AttachmentAccessShowListValue { get; set; }
        public string AttachmentAccessShowTemplateValue { get; set; }

        public string AttachmentAccessShowAttribute { get; set; }
        public string AttachmentAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/");
            AttachmentLanguage = aol.GetAddOnsLanguage("attachment");
            AttachmentAboutLanguage = aol.GetAddOnsLanguage("attachment_about");
            AttachmentContentLanguage = aol.GetAddOnsLanguage("attachment_content");
            AttachmentNameLanguage = aol.GetAddOnsLanguage("attachment_name");
            AttachmentPathLanguage = aol.GetAddOnsLanguage("attachment_path");
            AttachmentPasswordLanguage = aol.GetAddOnsLanguage("attachment_password");
            AddAttachmentLanguage = aol.GetAddOnsLanguage("add_attachment");
            AttachmentAccessShowLanguage = aol.GetAddOnsLanguage("attachment_access_show");
            AddLanguage = aol.GetAddOnsLanguage("add");
            UseAttachmentPathLanguage = aol.GetAddOnsLanguage("use_attachment_path");
            AttachmentPublicAccessShowLanguage = aol.GetAddOnsLanguage("attachment_public_access_show");
            AttachmentActiveLanguage = aol.GetAddOnsLanguage("attachment_active");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/attachment/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lc.UserRoleListItem);
            AttachmentAccessShowTemplateValue = hcbl.GetValue();
            AttachmentAccessShowListValue = hcbl.GetList();
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp attribute;", AttachmentAccessShowAttribute);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp css_class;", AttachmentAccessShowCssClass);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(AttachmentAccessShowListItem);


            // Set Attachment Page List
            ActionGetAttachmentListModel lm = new ActionGetAttachmentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_AttachmentName", "");
            InputRequest.Add("txt_AttachmentPassword", "");
            InputRequest.Add("txt_AttachmentAbout", "");
            InputRequest.Add("txt_AttachmentContent", "");
            InputRequest.Add("cbxlst_AttachmentAccessShow", AttachmentAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/attachment/");

            AttachmentNameAttribute += vc.ImportantInputAttribute["txt_AttachmentName"];
            AttachmentPasswordAttribute += vc.ImportantInputAttribute["txt_AttachmentPassword"];
            AttachmentAboutAttribute += vc.ImportantInputAttribute["txt_AttachmentAbout"];
            AttachmentContentAttribute += vc.ImportantInputAttribute["txt_AttachmentContent"];
            AttachmentAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_AttachmentAccessShow"];

            AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentName"]);
            AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentPassword"]);
            AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentAbout"]);
            AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentContent"]);
            AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_AttachmentAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/attachment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentName"]);
                //AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentPassword"]);
                //AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentAbout"]);
                //AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentContent"]);
                //AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_AttachmentAccessShow"]);
            }
        }

        public void AddAttachment()
        {
            // Set Extra Value
            ExtraValue ev = new ExtraValue();

            string AttachmentDirectoryPath = ev.GetAttachmentDirectoryValue();

            string AttachmentFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "attachment";

            // If Use Attachment Path
            if (UseAttachmentPathValue)
            {
                if (string.IsNullOrEmpty(AttachmentPathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_attachment_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                AttachmentFilePhysicalName = Path.GetFileName(AttachmentPathTextValue);

                FileExtension = Path.GetExtension(AttachmentFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AttachmentFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AttachmentPathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName));
            }
            else
            {
                if (!AttachmentPathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_attachment_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");

                AttachmentFilePhysicalName = AttachmentPathUploadValue.FileName;

                FileExtension = Path.GetExtension(AttachmentFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AttachmentFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AttachmentPathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName));
            }

            ev.FilePhysicalName = AttachmentFilePhysicalName;
            string AttachmentPhysicalName = ev.GetAttachmentFileValue();

            // Check Attachment File Size
            long FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_attachment").Attributes["value"].Value;

            if (FileSize > long.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");
            }

            // Check Authorized Extension
            if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage()), "warning");
            }


            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath));

            AttachmentPhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath), AttachmentPhysicalName);

            // Move Attachment File In "attachment" Directory To Attachment
            File.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/" + AttachmentPhysicalName));

            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Create Thumbnail Image
            if (FileAndDirectory.IsImageExtension(FileExtension))
                if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                {
                    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/thumb/")))
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/thumb/"));

                    FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/" + AttachmentPhysicalName, StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/thumb/" + AttachmentPhysicalName);
                }


            // Add Data To Database
            DataUse.Attachment dua = new DataUse.Attachment();

            dua.UserId = StaticObject.GetCurrentUserId();
            dua.AttachmentDirectoryPath = AttachmentDirectoryPath;
            dua.AttachmentPhysicalName = AttachmentPhysicalName;
            dua.AttachmentName = AttachmentNameValue;
            dua.AttachmentAbout = AttachmentAboutValue;
            dua.AttachmentSize = FileSize.ToString("0000000000000");
            dua.AttachmentPassword = AttachmentPasswordValue;
            dua.AttachmentNumberOfVisit = "0";
            dua.AttachmentActive = AttachmentActiveValue.BooleanToZeroOne();
            dua.AttachmentPublicAccessShow = AttachmentPublicAccessShowValue.BooleanToZeroOne();

            // Add Attachment
            dua.AddWithFillReturnDr();

            // Set Attachment Access Show
            dua.SetAttachmentAccessShow(dua.AttachmentId, AttachmentAccessShowListItem);

            // Add Attachment Content
            string[] AttachmentContentIdList = AttachmentContentValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            dua.AddAttachmentContent(dua.AttachmentId, AttachmentContentIdList);


            try { dua.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_attachment", AttachmentPhysicalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("attachment_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "success", false, StaticObject.AdminPath + "/attachment/action/AttachmentNewRow.aspx?attachment_id=" + dua.AttachmentId, "div_TableBox");
        }
    }
}