using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminCommentModel
    {
        public string CommentLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddCommentLanguage { get; set; }
        public string ContentIdLanguage { get; set; }
        public string IsCommentReplyLanguage { get; set; }
        public string ParentCommentLanguage { get; set; }
        public string CommentActiveLanguage { get; set; }
        public string CommentGuestNameLanguage { get; set; }
        public string CommentGuestRealNameLanguage { get; set; }
        public string CommentGuestRealLastNameLanguage { get; set; }
        public string CommentGuestEmailLanguage { get; set; }
        public string CommentTypeLanguage { get; set; }
        public string CommentTitleLanguage { get; set; }
        public string CommentTextLanguage { get; set; }
        public string CommentGuestPhoneNumberLanguage { get; set; }
        public string CommentGuestAddressLanguage { get; set; }
        public string CommentGuestPostalCodeLanguage { get; set; }
        public string CommentGuestAboutLanguage { get; set; }
        public string CommentGuestBirthdayLanguage { get; set; }
        public string CommentGuestGenderLanguage { get; set; }
        public string MaleLanguage { get; set; }
        public string FemaleLanguage { get; set; }
        public string UnknownLanguage { get; set; }
        public string CommentGuestWebsiteLanguage { get; set; }
        public string CommentGuestPublicEmailLanguage { get; set; }
        public string CommentGuestCountryLanguage { get; set; }
        public string CommentGuestStateOrProvinceLanguage { get; set; }
        public string CommentGuestCityLanguage { get; set; }
        public string CommentGuestMobileNumberLanguage { get; set; }
        public string CommentGuestZipCodeLanguage { get; set; }
        public string UploadPathLanguage { get; set; }
        public string UseUploadPathLanguage { get; set; }

        public bool CommentActiveValue { get; set; } = false;
        public bool IsCommentReplyValue { get; set; } = false;

        public string ParentCommentValue { get; set; }
        public string ContentIdValue { get; set; }

        public string CommentTypeOptionListValue { get; set; }
        public string CommentTypeOptionListSelectedValue { get; set; }

        public string LastCommentPartValue { get; set; }
        public string InaccessReasonPartValue { get; set; }
        public string CommentBoxPartValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public bool UseUploadPathValue { get; set; } = false;
        public HttpPostedFile UploadPathUploadValue { get; set; }
        public string UploadPathTextValue { get; set; }

        public string CommentGuestBirthdayYearOptionListValue { get; set; }
        public string CommentGuestBirthdayMountOptionListValue { get; set; }
        public string CommentGuestBirthdayDayOptionListValue { get; set; }
        public string CommentGuestBirthdayYearOptionListSelectedValue { get; set; }
        public string CommentGuestBirthdayMountOptionListSelectedValue { get; set; }
        public string CommentGuestBirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string CommentGuestAboutValue { get; set; } = "";
        public string CommentGuestAddressValue { get; set; } = "";
        public string CommentGuestCityValue { get; set; } = "";
        public string CommentGuestCountryValue { get; set; } = "";
        public string CommentGuestEmailValue { get; set; } = "";
        public string CommentGuestMobileNumberValue { get; set; } = "";
        public string CommentGuestPhoneNumberValue { get; set; } = "";
        public string CommentGuestPostalCodeValue { get; set; } = "";
        public string CommentGuestPublicEmailValue { get; set; } = "";
        public string CommentTitleValue { get; set; } = "";
        public string CommentTextValue { get; set; } = "";
        public string CommentGuestNameValue { get; set; } = "";
        public string CommentGuestRealNameValue { get; set; } = "";
        public string CommentGuestRealLastNameValue { get; set; } = "";
        public string CommentGuestStateOrProvinceValue { get; set; } = "";
        public string CommentGuestWebsiteValue { get; set; } = "";
        public string CommentGuestZipCodeValue { get; set; } = "";

        public string ContentIdCssClass { get; set; }
        public string ParentCommentCssClass { get; set; }
        public string CommentGuestAboutCssClass { get; set; }
        public string CommentGuestAddressCssClass { get; set; }
        public string CommentGuestCityCssClass { get; set; }
        public string CommentGuestCountryCssClass { get; set; }
        public string CommentGuestEmailCssClass { get; set; }
        public string CommentGuestMobileNumberCssClass { get; set; }
        public string CommentGuestPhoneNumberCssClass { get; set; }
        public string CommentGuestPostalCodeCssClass { get; set; }
        public string CommentGuestPublicEmailCssClass { get; set; }
        public string CommentTitleCssClass { get; set; }
        public string CommentTextCssClass { get; set; }
        public string CommentGuestNameCssClass { get; set; }
        public string CommentGuestRealNameCssClass { get; set; }
        public string CommentGuestRealLastNameCssClass { get; set; }
        public string CommentGuestStateOrProvinceCssClass { get; set; }
        public string CommentGuestWebsiteCssClass { get; set; }
        public string CommentGuestZipCodeCssClass { get; set; }
        public string CommentTypeCssClass { get; set; }
        public string CommentGuestBirthdayYearCssClass { get; set; }
        public string CommentGuestBirthdayMountCssClass { get; set; }
        public string CommentGuestBirthdayDayCssClass { get; set; }

        public string ContentIdAttribute { get; set; }
        public string ParentCommentAttribute { get; set; }
        public string CommentGuestAboutAttribute { get; set; }
        public string CommentGuestAddressAttribute { get; set; }
        public string CommentGuestCityAttribute { get; set; }
        public string CommentGuestCountryAttribute { get; set; }
        public string CommentGuestEmailAttribute { get; set; }
        public string CommentGuestMobileNumberAttribute { get; set; }
        public string CommentGuestPhoneNumberAttribute { get; set; }
        public string CommentGuestPostalCodeAttribute { get; set; }
        public string CommentGuestPublicEmailAttribute { get; set; }
        public string CommentTitleAttribute { get; set; }
        public string CommentTextAttribute { get; set; }
        public string CommentGuestNameAttribute { get; set; }
        public string CommentGuestRealNameAttribute { get; set; }
        public string CommentGuestRealLastNameAttribute { get; set; }
        public string CommentGuestStateOrProvinceAttribute { get; set; }
        public string CommentGuestWebsiteAttribute { get; set; }
        public string CommentGuestZipCodeAttribute { get; set; }
        public string CommentTypeAttribute { get; set; }
        public string CommentGuestBirthdayYearAttribute { get; set; }
        public string CommentGuestBirthdayMountAttribute { get; set; }
        public string CommentGuestBirthdayDayAttribute { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            AddCommentLanguage = aol.GetAddOnsLanguage("add_comment");
            CommentLanguage = aol.GetAddOnsLanguage("comment");
            ContentIdLanguage = aol.GetAddOnsLanguage("content_id");
            CommentGuestNameLanguage = aol.GetAddOnsLanguage("comment_guest_name");
            CommentGuestRealNameLanguage = aol.GetAddOnsLanguage("comment_guest_real_name");
            CommentGuestRealLastNameLanguage = aol.GetAddOnsLanguage("comment_guest_real_last_name");
            CommentGuestEmailLanguage = aol.GetAddOnsLanguage("comment_guest_email");
            CommentTypeLanguage = aol.GetAddOnsLanguage("comment_type");
            CommentGuestAboutLanguage = aol.GetAddOnsLanguage("comment_guest_about");
            CommentGuestAddressLanguage = aol.GetAddOnsLanguage("comment_guest_address");
            CommentGuestBirthdayLanguage = aol.GetAddOnsLanguage("comment_guest_birthday");
            CommentGuestGenderLanguage = aol.GetAddOnsLanguage("comment_guest_gender");
            FemaleLanguage = aol.GetAddOnsLanguage("female");
            MaleLanguage = aol.GetAddOnsLanguage("male");
            UnknownLanguage = aol.GetAddOnsLanguage("unknown");
            CommentGuestPhoneNumberLanguage = aol.GetAddOnsLanguage("comment_guest_phone_number");
            CommentGuestPostalCodeLanguage = aol.GetAddOnsLanguage("comment_guest_postal_code");
            CommentGuestWebsiteLanguage = aol.GetAddOnsLanguage("comment_guest_website");
            CommentGuestPublicEmailLanguage = aol.GetAddOnsLanguage("comment_guest_public_email");
            CommentGuestCountryLanguage = aol.GetAddOnsLanguage("comment_guest_country");
            CommentGuestStateOrProvinceLanguage = aol.GetAddOnsLanguage("comment_guest_state_or_province");
            CommentGuestCityLanguage = aol.GetAddOnsLanguage("comment_guest_city");
            CommentGuestMobileNumberLanguage = aol.GetAddOnsLanguage("comment_guest_mobile_number");
            CommentGuestZipCodeLanguage = aol.GetAddOnsLanguage("comment_guest_zip_code");
            CommentTitleLanguage = aol.GetAddOnsLanguage("comment_title");
            CommentTextLanguage = aol.GetAddOnsLanguage("comment_text");
            CommentActiveLanguage = aol.GetAddOnsLanguage("comment_active");
            IsCommentReplyLanguage = aol.GetAddOnsLanguage("is_comment_reply");
            ParentCommentLanguage = aol.GetAddOnsLanguage("parent_comment");
            UploadPathLanguage = aol.GetAddOnsLanguage("file_path");
            UseUploadPathLanguage = aol.GetAddOnsLanguage("use_upload_path");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Type Item
            lc.FillCommentTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            CommentTypeOptionListValue += lc.CommentTypeListItem.HtmlInputToOptionTag(CommentTypeOptionListSelectedValue);

            // Set Birthday Item
            lc.FillBirthdayListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            CommentGuestBirthdayDayOptionListValue += CommentGuestBirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            CommentGuestBirthdayDayOptionListValue += lc.BirthdayDayListItem.HtmlInputToOptionTag(CommentGuestBirthdayDayOptionListSelectedValue);
            CommentGuestBirthdayMountOptionListValue += CommentGuestBirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            CommentGuestBirthdayMountOptionListValue += lc.BirthdayMountListItem.HtmlInputToOptionTag(CommentGuestBirthdayMountOptionListSelectedValue);
            CommentGuestBirthdayYearOptionListValue += CommentGuestBirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            CommentGuestBirthdayYearOptionListValue += lc.BirthdayYearListItem.HtmlInputToOptionTag(CommentGuestBirthdayYearOptionListSelectedValue);


            ContentIdValue = "0";
            ParentCommentValue = "0";
            GenderUnknownValue = true;


            // Set Comment Page List
            ActionGetCommentListModel lm = new ActionGetCommentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ContentId", "");
            InputRequest.Add("txt_ParentComment", "");
            InputRequest.Add("txt_CommentGuestAbout", "");
            InputRequest.Add("txt_CommentGuestAddress", "");
            InputRequest.Add("txt_CommentGuestCity", "");
            InputRequest.Add("txt_CommentGuestCountry", "");
            InputRequest.Add("txt_CommentGuestEmail", "");
            InputRequest.Add("txt_CommentGuestPhoneNumber", "");
            InputRequest.Add("txt_CommentGuestPostalCode", "");
            InputRequest.Add("txt_CommentGuestPublicEmail", "");
            InputRequest.Add("txt_CommentTitle", "");
            InputRequest.Add("txt_CommentText", "");
            InputRequest.Add("txt_CommentGuestName", "");
            InputRequest.Add("txt_CommentGuestRealName", "");
            InputRequest.Add("txt_CommentGuestRealLastName", "");
            InputRequest.Add("txt_CommentGuestStateOrProvince", "");
            InputRequest.Add("txt_CommentGuestWebsite", "");
            InputRequest.Add("txt_CommentGuestZipCode", "");
            InputRequest.Add("ddlst_CommentType", CommentTypeOptionListValue);
            InputRequest.Add("ddlst_CommentGuestBirthdayYear", CommentGuestBirthdayYearOptionListValue);
            InputRequest.Add("ddlst_CommentGuestBirthdayMount", CommentGuestBirthdayMountOptionListValue);
            InputRequest.Add("ddlst_CommentGuestBirthdayDay", CommentGuestBirthdayDayOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/comment/");

            ContentIdAttribute += vc.ImportantInputAttribute["txt_ContentId"];
            ParentCommentAttribute += vc.ImportantInputAttribute["txt_ParentComment"];
            CommentGuestAboutAttribute += vc.ImportantInputAttribute["txt_CommentGuestAbout"];
            CommentGuestAddressAttribute += vc.ImportantInputAttribute["txt_CommentGuestAddress"];
            CommentGuestCityAttribute += vc.ImportantInputAttribute["txt_CommentGuestCity"];
            CommentGuestCountryAttribute += vc.ImportantInputAttribute["txt_CommentGuestCountry"];
            CommentGuestEmailAttribute += vc.ImportantInputAttribute["txt_CommentGuestEmail"];
            CommentGuestPhoneNumberAttribute += vc.ImportantInputAttribute["txt_CommentGuestPhoneNumber"];
            CommentGuestPostalCodeAttribute += vc.ImportantInputAttribute["txt_CommentGuestPostalCode"];
            CommentGuestPublicEmailAttribute += vc.ImportantInputAttribute["txt_CommentGuestPublicEmail"];
            CommentTitleAttribute += vc.ImportantInputAttribute["txt_CommentTitle"];
            CommentTextAttribute += vc.ImportantInputAttribute["txt_CommentText"];
            CommentGuestNameAttribute += vc.ImportantInputAttribute["txt_CommentGuestName"];
            CommentGuestRealNameAttribute += vc.ImportantInputAttribute["txt_CommentGuestRealName"];
            CommentGuestRealLastNameAttribute += vc.ImportantInputAttribute["txt_CommentGuestRealLastName"];
            CommentGuestStateOrProvinceAttribute += vc.ImportantInputAttribute["txt_CommentGuestStateOrProvince"];
            CommentGuestWebsiteAttribute += vc.ImportantInputAttribute["txt_CommentGuestWebsite"];
            CommentGuestZipCodeAttribute += vc.ImportantInputAttribute["txt_CommentGuestZipCode"];
            CommentTypeAttribute += vc.ImportantInputAttribute["ddlst_CommentType"];
            CommentGuestBirthdayYearAttribute += vc.ImportantInputAttribute["ddlst_CommentGuestBirthdayYear"];
            CommentGuestBirthdayMountAttribute += vc.ImportantInputAttribute["ddlst_CommentGuestBirthdayMount"];
            CommentGuestBirthdayDayAttribute += vc.ImportantInputAttribute["ddlst_CommentGuestBirthdayDay"];

            ContentIdCssClass = ContentIdCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentId"]);
            ParentCommentCssClass = ParentCommentCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ParentComment"]);
            CommentGuestAboutCssClass = CommentGuestAboutCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestAbout"]);
            CommentGuestAddressCssClass = CommentGuestAddressCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestAddress"]);
            CommentGuestCityCssClass = CommentGuestCityCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestCity"]);
            CommentGuestCountryCssClass = CommentGuestCountryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestCountry"]);
            CommentGuestEmailCssClass = CommentGuestEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestEmail"]);
            CommentGuestPhoneNumberCssClass = CommentGuestPhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestPhoneNumber"]);
            CommentGuestPostalCodeCssClass = CommentGuestPostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestPostalCode"]);
            CommentGuestPublicEmailCssClass = CommentGuestPublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestPublicEmail"]);
            CommentTitleCssClass = CommentTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentTitle"]);
            CommentTextCssClass = CommentTextCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentText"]);
            CommentGuestNameCssClass = CommentGuestNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestName"]);
            CommentGuestRealNameCssClass = CommentGuestRealNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestRealName"]);
            CommentGuestRealLastNameCssClass = CommentGuestRealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestRealLastName"]);
            CommentGuestStateOrProvinceCssClass = CommentGuestStateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestStateOrProvince"]);
            CommentGuestWebsiteCssClass = CommentGuestWebsiteCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestWebsite"]);
            CommentGuestZipCodeCssClass = CommentGuestZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CommentGuestZipCode"]);
            CommentTypeCssClass = CommentTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_CommentType"]);
            CommentGuestBirthdayYearCssClass = CommentGuestBirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_CommentGuestBirthdayYear"]);
            CommentGuestBirthdayMountCssClass = CommentGuestBirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_CommentGuestBirthdayMount"]);
            CommentGuestBirthdayDayCssClass = CommentGuestBirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_CommentGuestBirthdayDay"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/comment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ContentIdCssClass = ContentIdCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentId"]);
                //ParentCommentCssClass = ParentCommentCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ParentComment"]);
                //CommentGuestAboutCssClass = CommentGuestAboutCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestAbout"]);
                //CommentGuestAddressCssClass = CommentGuestAddressCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestAddress"]);
                //CommentGuestCityCssClass = CommentGuestCityCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestCity"]);
                //CommentGuestCountryCssClass = CommentGuestCountryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestCountry"]);
                //CommentGuestEmailCssClass = CommentGuestEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestEmail"]);
                //CommentGuestPhoneNumberCssClass = CommentGuestPhoneNumberCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestPhoneNumber"]);
                //CommentGuestPostalCodeCssClass = CommentGuestPostalCodeCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestPostalCode"]);
                //CommentGuestPublicEmailCssClass = CommentGuestPublicEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestPublicEmail"]);
                //CommentTitleCssClass = CommentTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentTitle"]);
                //CommentTextCssClass = CommentTextCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentText"]);
                //CommentGuestNameCssClass = CommentGuestNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestName"]);
                //CommentGuestRealNameCssClass = CommentGuestRealNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestRealName"]);
                //CommentGuestRealLastNameCssClass = CommentGuestRealLastNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestRealLastName"]);
                //CommentGuestStateOrProvinceCssClass = CommentGuestStateOrProvinceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestStateOrProvince"]);
                //CommentGuestWebsiteCssClass = CommentGuestWebsiteCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestWebsite"]);
                //CommentGuestZipCodeCssClass = CommentGuestZipCodeCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CommentGuestZipCode"]);
                //CommentTypeCssClass = CommentTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_CommentType"]);
                //CommentGuestBirthdayYearCssClass = CommentGuestBirthdayYearCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_CommentGuestBirthdayYear"]);
                //CommentGuestBirthdayMountCssClass = CommentGuestBirthdayMountCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_CommentGuestBirthdayMount"]);
                //CommentGuestBirthdayDayCssClass = CommentGuestBirthdayDayCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_CommentGuestBirthdayDay"]);
            }
        }

        public void AddComment()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Comment duc = new DataUse.Comment();


            // Get Content Verify Comments
            bool ContentVerifyComments = (IsCommentReplyValue) ? duc.GetContentVerifyCommentsByCommentId(ParentCommentValue) : duc.GetContentVerifyCommentsByContentId(ContentIdValue);


            // Check User Comment Send Without Approval
            bool AddUserCommentWithoutApproval = duc.CheckUserCommentSendWithoutApprovalByGroupId(ccoc.GroupId);


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
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                if (string.IsNullOrEmpty(UploadPathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_upload_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                // Check Authorized Extension
                FileExtension = Path.GetExtension(UploadPathTextValue);

                if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "warning");

                UploadFilePhysicalName = Path.GetFileName(UploadPathTextValue);

                evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                DirectoryName = evc.GetCommentUploadDirectoryValue();
                UploadFilePhysicalName = evc.GetCommentUploadFileValue();
                UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/"), UploadFilePhysicalName);


                System.Net.WebClient webClient = new System.Net.WebClient();

                UploadExtension = Path.GetExtension(UploadFilePhysicalName);


                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(UploadPathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
            }
            else
            {
                if (UploadPathUploadValue.HtmlInputHasFile())
                {
                    if (!StaticObject.RoleUploadFileCheck())
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "problem");

                    // Check Authorized Extension
                    FileExtension = Path.GetExtension(UploadPathUploadValue.FileName);

                    if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/comment/"), "warning");

                    UploadFilePhysicalName = UploadPathUploadValue.FileName;

                    evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                    DirectoryName = evc.GetCommentUploadDirectoryValue();
                    UploadFilePhysicalName = evc.GetCommentUploadFileValue();
                    UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/"), UploadFilePhysicalName);


                    UploadExtension = Path.GetExtension(UploadFilePhysicalName);

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName)))
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                    UploadPathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
                }
            }

            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                // Check Comment Upload File Size
                double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName)).Length;
                string MaxOfUploadSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_comment").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfUploadSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfUploadSizeUpload).ToBitSizeTuning()), "problem");
                }
            }


            string TmpUserBirthday = "2000/01/01";

            if (CommentGuestBirthdayYearOptionListSelectedValue != "0000" && CommentGuestBirthdayMountOptionListSelectedValue != "00" && CommentGuestBirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = CommentGuestBirthdayYearOptionListSelectedValue + "/" + CommentGuestBirthdayMountOptionListSelectedValue + "/" + CommentGuestBirthdayDayOptionListSelectedValue;


            // Add Data To Database
            duc.ContentId = ContentIdValue;
            duc.UserId = StaticObject.GetCurrentUserId();
            duc.ParentComment = (IsCommentReplyValue) ? ParentCommentValue : "0";
            duc.CommentGuestName = StringClass.RemoveHtmlTags(CommentGuestNameValue);
            duc.CommentGuestRealName = StringClass.RemoveHtmlTags(CommentGuestRealNameValue);
            duc.CommentGuestRealLastName = StringClass.RemoveHtmlTags(CommentGuestRealLastNameValue);
            duc.CommentGuestEmail = string.IsNullOrEmpty(CommentGuestEmailValue) ? "" : StringClass.RemoveHtmlTags(CommentGuestEmailValue.ToLower());
            duc.CommentTitle = StringClass.RemoveIllegalCharacters(CommentTitleValue);
            duc.CommentText = (StaticObject.RoleWriteHtmlCheck()) ? CommentTextValue : StringClass.RemoveHtmlTags(CommentTextValue);
            duc.CommentText = (StaticObject.RoleWriteScriptCheck()) ? duc.CommentText : StringClass.RemoveScriptTags(duc.CommentText);
            duc.CommentDateSend = DateAndTime.GetDate("yyyy/MM/dd");
            duc.CommentTimeSend = DateAndTime.GetTime("HH:mm:ss");
            if (AddUserCommentWithoutApproval)
                duc.CommentActive = "1";
            else
                duc.CommentActive = (!ContentVerifyComments) ? CommentActiveValue.BooleanToZeroOne() : "0";
            duc.CommentIpAddress = Security.GetUserIp();
            duc.CommentFileDirectoryPath = DirectoryName;
            duc.CommentFilePhysicalName = UploadFilePhysicalName;
            duc.CommentType = StringClass.RemoveHtmlTags(CommentTypeOptionListSelectedValue);
            duc.CommentGuestPhoneNumber = StringClass.RemoveHtmlTags(CommentGuestPhoneNumberValue);
            duc.CommentGuestAddress = StringClass.RemoveHtmlTags(CommentGuestAddressValue);
            duc.CommentGuestPostalCode = StringClass.RemoveHtmlTags(CommentGuestPostalCodeValue);
            duc.CommentGuestAbout = StringClass.RemoveHtmlTags(CommentGuestAboutValue);
            duc.CommentGuestBirthday = TmpUserBirthday;
            duc.CommentGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duc.CommentGuestPublicEmail = string.IsNullOrEmpty(CommentGuestPublicEmailValue) ? "" : StringClass.RemoveHtmlTags(CommentGuestPublicEmailValue.ToLower());
            duc.CommentGuestMobileNumber = StringClass.RemoveHtmlTags(CommentGuestMobileNumberValue);
            duc.CommentGuestZipCode = StringClass.RemoveHtmlTags(CommentGuestZipCodeValue);
            duc.CommentGuestCountry = StringClass.RemoveHtmlTags(CommentGuestCountryValue);
            duc.CommentGuestStateOrProvince = StringClass.RemoveHtmlTags(CommentGuestStateOrProvinceValue);
            duc.CommentGuestCity = StringClass.RemoveHtmlTags(CommentGuestCityValue);
            duc.CommentGuestWebsite = StringClass.RemoveHtmlTags(CommentGuestWebsiteValue);

            // Add Comment
            duc.AddWithFillReturnDr();


            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName)))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName));

                File.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/" + UploadFilePhysicalName));

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // Create Thumbnail Image
                if (FileAndDirectory.IsImageExtension(FileExtension))
                    if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                    {
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/")))
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/"));

                        FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "upload/comment/" + DirectoryName + "/" + UploadFilePhysicalName, StaticObject.SitePath + "upload/comment/" + DirectoryName + "/thumb/" + UploadFilePhysicalName);
                    }
            }


            try { duc.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_comment", duc.CommentTitle);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("comment_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/"), "success", false, StaticObject.AdminPath + "/comment/action/CommentNewRow.aspx?comment_id=" + duc.CommentId, "div_TableBox");
        }

        public void AddCommentInactiveView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("add_comment_is_inactive", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/"), "problem");
        }

        public void RoleAccessReplyErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_reply_to_comment", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/"), "problem");
        }

        public void AddCommentInContentInactiveErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("add_comment_in_content_is_inactive", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/comment/"), "problem");
        }
    }
}