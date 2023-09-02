using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentModel : CodeBehindModel
    {
        public string CommentLanguage { get; set; }

        public string ParentCommentValue { get; set; }
        public string ContentIdValue { get; set; }

        public string LastCommentPartValue { get; set; }
        public string InaccessReasonPartValue { get; set; }
        public string CommentBoxPartValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public bool UseUploadPathValue { get; set; } = false;
        public IFormFile UploadPathUploadValue { get; set; }
        public string UploadPathTextValue { get; set; }

        public string TypeOptionListSelectedValue { get; set; } = "";
        public string BirthdayYearOptionListSelectedValue { get; set; }
        public string BirthdayMountOptionListSelectedValue { get; set; }
        public string BirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string AboutValue { get; set; } = "";
        public string AddressValue { get; set; } = "";
        public string CityValue { get; set; } = "";
        public string CountryValue { get; set; } = "";
        public string EmailValue { get; set; } = "";
        public string MobileNumberValue { get; set; } = "";
        public string PhoneNumberValue { get; set; } = "";
        public string PostalCodeValue { get; set; } = "";
        public string PublicEmailValue { get; set; } = "";
        public string TitleValue { get; set; } = "";
        public string TextValue { get; set; } = "";
        public string RealNameValue { get; set; } = "";
        public string RealLastNameValue { get; set; } = "";
        public string StateOrProvinceValue { get; set; } = "";
        public string WebsiteValue { get; set; } = "";
        public string ZipCodeValue { get; set; } = "";

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
            CommentLanguage = aol.GetAddOnsLanguage("comment");


            // Set Last Comment
            if (ElanatConfig.GetNode("properties/show_comment_in_add_comment_box").Attributes["active"].Value == "true" && ParentCommentValue == "0")
            {
                ContentClass cc = new ContentClass();
                LastCommentPartValue = cc.GetContentComment(ContentIdValue);
            }


            // Check Access
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string RoleType = (ccoc.RoleDominantType == "guest") ? "guest" : "user";


            // Add Free Comment Access Check
            if (!ElanatConfig.GetNode("active/add_comment").Attributes["active"].Value.TrueFalseToBoolean())
            {
                InaccessReasonPartValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("add_comment_is_inactive", ccoc.SiteLanguageGlobalName));

                return;
            }


            // Add Free Comment Role Access Check
            if (!StaticObject.RoleAddFreeCommentContentCheck())
            {
                InaccessReasonPartValue = Template.GetSiteTemplate("part/role_access/" + RoleType + "_add/comment").Replace("$_asp return_address;", "content/" + ContentIdValue + "/");

                return;
            }


            // Check Content Comment Send
            DataUse.Comment duc2 = new DataUse.Comment();
            if ((ParentCommentValue != "0") ? !duc2.GetContentVerifyCommentsByCommentId(ParentCommentValue) : !duc2.GetContentVerifyCommentsByContentId(ContentIdValue))
            {
                InaccessReasonPartValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", aol.GetAddOnsLanguage("add_comment_in_this_content_is_inactive"));

                return;
            }


            // Add Comment Reply To Own Content Access Check
            if (ParentCommentValue != "0")
            {
                DataUse.Content Duc = new DataUse.Content();

                if (!Duc.IsUserContent(ccoc.UserId, ContentIdValue))
                {
                    if (StaticObject.RoleReplyCommentOnlyOwnContentCheck())
                    {
                        InaccessReasonPartValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", aol.GetAddOnsLanguage("role_can_not_access_reply_to_comment"));

                        return;
                    }
                }
            }


            // Add Comment Reply Access Check
            if (ParentCommentValue != "0")
            {
                if (!StaticObject.RoleReplyCommentAllContentCheck())
                {
                    InaccessReasonPartValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", aol.GetAddOnsLanguage("role_can_not_access_reply_to_comment"));
                    return;
                }
            }


            CommentBoxPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentCommentBox.aspx");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("hdn_ParentComment", ParentCommentValue);
            InputRequest.Add("hdn_ContentId", ContentIdValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/comment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SendComment()
        {
            // Set Extra Value
            ExtraValue evc = new ExtraValue();


            string UploadFilePhysicalName = "";
            string UploadExtension = "";
            string DirectoryName = "";
            string FileExtension = "";

            // If Use Upload Path
            if (UseUploadPathValue)
            {
                if (!StaticObject.RoleUploadFileCheck())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                    return;
                }

                if (string.IsNullOrEmpty(UploadPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_upload_path_field_because_this_is_necessary", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                    return;
                }

                // Check Authorized Extension
                FileExtension = Path.GetExtension(UploadPathTextValue);

                if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "warning");

                    return;
                }

                UploadFilePhysicalName = Path.GetFileName(UploadPathTextValue);

                evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                DirectoryName = evc.GetCommentUploadDirectoryValue();
                UploadFilePhysicalName = evc.GetCommentUploadFileValue();
                UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/"), UploadFilePhysicalName);


                HttpClient webClient = new HttpClient();

                UploadExtension = Path.GetExtension(UploadFilePhysicalName);


                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(UploadPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
            }
            else
            {
                if (UploadPathUploadValue.HtmlInputHasFile())
                {
                    if (!StaticObject.RoleUploadFileCheck())
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                        return;
                    }

                    // Check Authorized Extension
                    FileExtension = Path.GetExtension(UploadPathUploadValue.FileName);

                    if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "warning");

                        return;
                    }

                    UploadFilePhysicalName = UploadPathUploadValue.FileName;

                    evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                    DirectoryName = evc.GetCommentUploadDirectoryValue();
                    UploadFilePhysicalName = evc.GetCommentUploadFileValue();
                    UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/"), UploadFilePhysicalName);


                    UploadExtension = Path.GetExtension(UploadFilePhysicalName);

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                    if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName)))
                        Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                    UploadPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
                }
            }

            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                // Check Comment Upload File Size
                double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName)).Length;
                string MaxOfUploadSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_comment").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfUploadSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfUploadSizeUpload).ToBitSizeTuning()), "problem");

                    return;
                }
            }


            string TmpUserBirthday = "2000/01/01";

            if (BirthdayYearOptionListSelectedValue != "0000" && BirthdayMountOptionListSelectedValue != "00" && BirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = BirthdayYearOptionListSelectedValue + "/" + BirthdayMountOptionListSelectedValue + "/" + BirthdayDayOptionListSelectedValue;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Comment duc = new DataUse.Comment();

            StringClass sc = new StringClass();

            // Check User Comment Send Without Approval
            bool AddUserCommentWithoutApproval = duc.CheckUserCommentSendWithoutApprovalByGroupId(ccoc.GroupId);
            
            // Get Content Verify Comments
            bool ContentVerifyComments = (ParentCommentValue != "0") ? duc.GetContentVerifyCommentsByCommentId(ParentCommentValue) : duc.GetContentVerifyCommentsByContentId(ContentIdValue);

            // Add Data To Database
            duc.ContentId = ContentIdValue;
            duc.ParentComment = ParentCommentValue;
            duc.UserId = StaticObject.GetCurrentUserId();
            duc.CommentGuestName = ccoc.UserName;
            duc.CommentGuestRealName = StringClass.RemoveHtmlTags(RealNameValue);
            duc.CommentGuestRealLastName = StringClass.RemoveHtmlTags(RealLastNameValue);
            duc.CommentGuestEmail = string.IsNullOrEmpty(EmailValue) ? "" : StringClass.RemoveHtmlTags(EmailValue.ToLower()); 
            duc.CommentTitle = StringClass.RemoveIllegalCharacters(TitleValue);
            duc.CommentText = (StaticObject.RoleWriteHtmlCheck()) ? TextValue : StringClass.RemoveHtmlTags(TextValue);
            duc.CommentText = (StaticObject.RoleWriteScriptCheck()) ? duc.CommentText : StringClass.RemoveScriptTags(duc.CommentText);
            duc.CommentDateSend = DateAndTime.GetDate("yyyy/MM/dd");
            duc.CommentTimeSend = DateAndTime.GetTime("HH:mm:ss");
            if (AddUserCommentWithoutApproval)
                duc.CommentActive = "1";
            else
                duc.CommentActive = (!ContentVerifyComments) ? "1" : "0";
            duc.CommentIpAddress = Security.GetUserIp();
            duc.CommentFileDirectoryPath = DirectoryName;
            duc.CommentFilePhysicalName = UploadFilePhysicalName;
            duc.CommentType = StringClass.RemoveHtmlTags(TypeOptionListSelectedValue);
            duc.CommentGuestPhoneNumber = StringClass.RemoveHtmlTags(PhoneNumberValue);
            duc.CommentGuestAddress = StringClass.RemoveIllegalCharacters(AddressValue);
            duc.CommentGuestPostalCode = StringClass.RemoveHtmlTags(PostalCodeValue);
            duc.CommentGuestAbout = StringClass.RemoveIllegalCharacters(AboutValue);
            duc.CommentGuestBirthday = TmpUserBirthday;
            duc.CommentGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duc.CommentGuestPublicEmail = string.IsNullOrEmpty(PublicEmailValue) ? "" : StringClass.RemoveHtmlTags(PublicEmailValue.ToLower());
            duc.CommentGuestMobileNumber = StringClass.RemoveHtmlTags(MobileNumberValue);
            duc.CommentGuestZipCode = StringClass.RemoveHtmlTags(ZipCodeValue);
            duc.CommentGuestCountry = StringClass.RemoveHtmlTags(CountryValue);
            duc.CommentGuestStateOrProvince = StringClass.RemoveHtmlTags(StateOrProvinceValue);
            duc.CommentGuestCity = StringClass.RemoveHtmlTags(CityValue);
            duc.CommentGuestWebsite = StringClass.RemoveHtmlTags(WebsiteValue);

            // Add Comment
            duc.Add();


            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName)))
                    Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName));

                File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/" + UploadFilePhysicalName));

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // Create Thumbnail Image
                if (FileAndDirectory.IsImageExtension(FileExtension))
                    if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                    {
                        if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/")))
                            Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/"));

                        FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/" + UploadFilePhysicalName, StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/" + UploadFilePhysicalName);
                    }
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("send_comment", duc.CommentTitle);
        }

        public void RoleAccessReplyErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_reply_to_comment", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");
        }

        public void AddCommentInContentInactiveErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("add_comment_in_content_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");
        }

        public void AddCommentInactiveView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("add_comment_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/comment/action/SuccessMessage.aspx?use_retrieved=true");
        }
    }
}