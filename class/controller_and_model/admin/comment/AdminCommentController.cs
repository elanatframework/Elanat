using CodeBehind;

namespace Elanat
{
    public partial class AdminCommentController : CodeBehindController
    {
        public AdminCommentModel model = new AdminCommentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddComment"]))
            {
                btn_AddComment_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddComment_Click(HttpContext context)
        {
            model.ContentIdValue = context.Request.Form["txt_ContentId"];
            model.ParentCommentValue = context.Request.Form["txt_ParentComment"];

            model.IsCommentReplyValue = context.Request.Form["cbx_IsCommentReply"] == "on";
            model.CommentActiveValue = context.Request.Form["cbx_CommentActive"] == "on";

            model.UseUploadPathValue = context.Request.Form["cbx_UseUploadPath"] == "on";
            model.UploadPathTextValue = context.Request.Form["txt_UploadPath"];
            model.UploadPathUploadValue = context.Request.Form.Files["upd_UploadPath"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentText"]))
                model.CommentTextValue = context.Request.Form["txt_CommentText"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentTitle"]))
                model.CommentTitleValue = context.Request.Form["txt_CommentTitle"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_CommentGuestBirthdayYear"]))
            {
                model.CommentGuestBirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_CommentGuestBirthdayYear"];
                model.CommentGuestBirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_CommentGuestBirthdayMount"];
                model.CommentGuestBirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_CommentGuestBirthdayDay"];
            }
            else
            {
                model.CommentGuestBirthdayYearOptionListSelectedValue = "0000";
                model.CommentGuestBirthdayMountOptionListSelectedValue = "00";
                model.CommentGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestEmail"]))
                model.CommentGuestEmailValue = context.Request.Form["txt_CommentGuestEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_CommentType"]))
                model.CommentTypeOptionListSelectedValue = context.Request.Form["ddlst_CommentType"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestAbout"]))
                model.CommentGuestAboutValue = context.Request.Form["txt_CommentGuestAbout"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestAddress"]))
                model.CommentGuestAddressValue = context.Request.Form["txt_CommentGuestAddress"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestCity"]))
                model.CommentGuestCityValue = context.Request.Form["txt_CommentGuestCity"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestCountry"]))
                model.CommentGuestCountryValue = context.Request.Form["txt_CommentGuestCountry"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestMobileNumber"]))
                model.CommentGuestMobileNumberValue = context.Request.Form["txt_CommentGuestMobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestPhoneNumber"]))
                model.CommentGuestPhoneNumberValue = context.Request.Form["txt_CommentGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestPostalCode"]))
                model.CommentGuestPostalCodeValue = context.Request.Form["txt_CommentGuestPostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestPublicEmail"]))
                model.CommentGuestPublicEmailValue = context.Request.Form["txt_CommentGuestPublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestName"]))
                model.CommentGuestNameValue = context.Request.Form["txt_CommentGuestName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestRealName"]))
                model.CommentGuestRealNameValue = context.Request.Form["txt_CommentGuestRealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestRealLastName"]))
                model.CommentGuestRealLastNameValue = context.Request.Form["txt_CommentGuestRealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestStateOrProvince"]))
                model.CommentGuestStateOrProvinceValue = context.Request.Form["txt_CommentGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestWebsite"]))
                model.CommentGuestWebsiteValue = context.Request.Form["txt_CommentGuestWebsite"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_CommentGuestZipCode"]))
                model.CommentGuestZipCodeValue = context.Request.Form["txt_CommentGuestZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Comment duc = new DataUse.Comment();

            // Add Comment Reply To Own Content Access Check
            if (model.IsCommentReplyValue)
            {
                DataUse.Content Duc2 = new DataUse.Content();

                if (!Duc2.IsUserContent(ccoc.UserId, model.ContentIdValue))
                {
                    if (StaticObject.RoleReplyCommentOnlyOwnContentCheck())
                    {
                        model.RoleAccessReplyErrorView();

                        View(model);

                        return;
                    }
                }
            }

            // Add Comment Reply Access Check
            if (model.IsCommentReplyValue)
            {
                if (!StaticObject.RoleReplyCommentAllContentCheck())
                {
                    model.RoleAccessReplyErrorView();

                    View(model);

                    return;
                }
            }
            
            // Check Comment Send
            if (ElanatConfig.GetNode("active/add_comment").Attributes["active"].Value != "true")
            {
                model.AddCommentInactiveView();

                View(model);

                return;
            }

            // Check Content Comment Send
            if ((model.IsCommentReplyValue) ? !duc.GetContentVerifyCommentsByCommentId(model.ParentCommentValue) : !duc.GetContentVerifyCommentsByContentId(model.ContentIdValue))
            {
                model.AddCommentInContentInactiveErrorView();

                View(model);

                return;
            }


            model.AddComment();

            View(model);
        }
    }
}