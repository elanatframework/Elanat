using CodeBehind;

namespace Elanat
{
    public partial class AdminAttachmentModel : CodeBehindModel
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

        public IFormFile AttachmentPathUploadValue { get; set; }
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

        public List<ListItem> AttachmentAccessShowListItem = new List<ListItem>();
        public string AttachmentAccessShowListValue { get; set; }
        public string AttachmentAccessShowTemplateValue { get; set; }

        public string AttachmentAccessShowAttribute { get; set; }
        public string AttachmentAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
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


            // Set User Role
            ListClass.User lcU = new ListClass.User();
            lcU.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/attachment/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lcU.UserRoleListItem);
            AttachmentAccessShowTemplateValue = hcbl.GetValue();
            AttachmentAccessShowListValue = hcbl.GetList();
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp attribute;", AttachmentAccessShowAttribute);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp css_class;", AttachmentAccessShowCssClass);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(AttachmentAccessShowListItem);


            // Set Attachment Page List
            ActionGetAttachmentListModel lm = new ActionGetAttachmentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_AttachmentName", "");
            InputRequest.Add("txt_AttachmentPassword", "");
            InputRequest.Add("txt_AttachmentAbout", "");
            InputRequest.Add("txt_AttachmentContent", "");
            InputRequest.Add("cbxlst_AttachmentAccessShow", AttachmentAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/attachment/");

            AttachmentNameAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentName");
            AttachmentPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentPassword");
            AttachmentAboutAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentAbout");
            AttachmentContentAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentContent");
            AttachmentAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_AttachmentAccessShow");

            AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentName"));
            AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentPassword"));
            AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentAbout"));
            AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentContent"));
            AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_AttachmentAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/attachment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_attachment_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                AttachmentFilePhysicalName = Path.GetFileName(AttachmentPathTextValue);

                FileExtension = Path.GetExtension(AttachmentFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AttachmentFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AttachmentPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName));
            }
            else
            {
                if (!AttachmentPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_attachment_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");

                    return;
                }

                AttachmentFilePhysicalName = AttachmentPathUploadValue.FileName;

                FileExtension = Path.GetExtension(AttachmentFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AttachmentFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AttachmentPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName));
            }

            ev.FilePhysicalName = AttachmentFilePhysicalName;
            string AttachmentPhysicalName = ev.GetAttachmentFileValue();

            // Check Attachment File Size
            long FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_attachment").Attributes["value"].Value;

            if (FileSize > long.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "problem");

                return;
            }

            // Check Authorized Extension
            if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage()), "warning");

                return;
            }


            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath)))
                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath));

            AttachmentPhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath), AttachmentPhysicalName);

            // Move Attachment File In "attachment" Directory To Attachment
            File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AttachmentFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/" + AttachmentPhysicalName));

            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Create Thumbnail Image
            if (FileAndDirectory.IsImageExtension(FileExtension))
                if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                {
                    if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/thumb/")))
                        Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + AttachmentDirectoryPath + "/thumb/"));

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
            string[] AttachmentContentIdList = AttachmentContentValue.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            dua.AddAttachmentContent(dua.AttachmentId, AttachmentContentIdList);


            try { dua.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_attachment", AttachmentPhysicalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("attachment_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/"), "success", false, StaticObject.AdminPath + "/attachment/action/AttachmentNewRow.aspx?attachment_id=" + dua.AttachmentId, "div_TableBox");
        }
    }
}