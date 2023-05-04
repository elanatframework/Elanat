using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditComment : System.Web.UI.Page
    {
        public ActionEditCommentModel model = new ActionEditCommentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveComment"]))
                btn_SaveComment_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_CommentId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
                    return;

                if (!Request.QueryString["comment_id"].ToString().IsNumber())
                    return;

                model.CommentIdValue = Request.QueryString["comment_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveComment_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ContentIdValue = Request.Form["txt_ContentId"];
            model.ParentCommentValue = Request.Form["txt_ParentComment"];

            model.IsCommentReplyValue = Request.Form["cbx_IsCommentReply"] == "on";
            model.CommentActiveValue = Request.Form["cbx_CommentActive"] == "on";

            model.DeleteCommentFileValue = Request.Form["cbx_DeleteCommentFile"] == "on";
            model.UseUploadPathValue = Request.Form["cbx_UseUploadPath"] == "on";
            model.UploadPathTextValue = Request.Form["txt_UploadPath"];
            model.UploadPathUploadValue = Request.Files["upd_UploadPath"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentText"]))
                model.CommentTextValue = Request.Form["txt_CommentText"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentTitle"]))
                model.CommentTitleValue = Request.Form["txt_CommentTitle"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_CommentGuestBirthdayYear"]))
            {
                model.CommentGuestBirthdayYearOptionListSelectedValue = Request.Form["ddlst_CommentGuestBirthdayYear"];
                model.CommentGuestBirthdayMountOptionListSelectedValue = Request.Form["ddlst_CommentGuestBirthdayMount"];
                model.CommentGuestBirthdayDayOptionListSelectedValue = Request.Form["ddlst_CommentGuestBirthdayDay"];
            }
            else
            {
                model.CommentGuestBirthdayYearOptionListSelectedValue = "0000";
                model.CommentGuestBirthdayMountOptionListSelectedValue = "00";
                model.CommentGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestEmail"]))
                model.CommentGuestEmailValue = Request.Form["txt_CommentGuestEmail"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_CommentType"]))
                model.CommentTypeOptionListSelectedValue = Request.Form["ddlst_CommentType"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestAbout"]))
                model.CommentGuestAboutValue = Request.Form["txt_CommentGuestAbout"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestAddress"]))
                model.CommentGuestAddressValue = Request.Form["txt_CommentGuestAddress"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestCity"]))
                model.CommentGuestCityValue = Request.Form["txt_CommentGuestCity"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestCountry"]))
                model.CommentGuestCountryValue = Request.Form["txt_CommentGuestCountry"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestMobileNumber"]))
                model.CommentGuestMobileNumberValue = Request.Form["txt_CommentGuestMobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestPhoneNumber"]))
                model.CommentGuestPhoneNumberValue = Request.Form["txt_CommentGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestPostalCode"]))
                model.CommentGuestPostalCodeValue = Request.Form["txt_CommentGuestPostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestPublicEmail"]))
                model.CommentGuestPublicEmailValue = Request.Form["txt_CommentGuestPublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestName"]))
                model.CommentGuestNameValue = Request.Form["txt_CommentGuestName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestRealName"]))
                model.CommentGuestRealNameValue = Request.Form["txt_CommentGuestRealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestRealLastName"]))
                model.CommentGuestRealLastNameValue = Request.Form["txt_CommentGuestRealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestStateOrProvince"]))
                model.CommentGuestStateOrProvinceValue = Request.Form["txt_CommentGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestWebsite"]))
                model.CommentGuestWebsiteValue = Request.Form["txt_CommentGuestWebsite"];

            if (!string.IsNullOrEmpty(Request.Form["txt_CommentGuestZipCode"]))
                model.CommentGuestZipCodeValue = Request.Form["txt_CommentGuestZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.CommentIdValue = Request.Form["hdn_CommentId"];
            model.CommentUploadDirectoryValue = Request.Form["hdn_CommentUploadDirectoryValue"];
            model.CommentUploadFileValue = Request.Form["hdn_CommentUploadFileValue"];

            model.CommentDateSendValue = Request.Form["txt_CommentDateSend"];
            model.CommentTimeSendValue = Request.Form["txt_CommentTimeSend"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Comment duc = new DataUse.Comment();

            // Edit Comment From Own Content Access Check
            DataUse.Content Duc2 = new DataUse.Content();

            if (!Duc2.IsUserContent(ccoc.UserId, model.ContentIdValue))
            {
                if (StaticObject.RoleEditCommentOnlyOwnContentCheck())
                {
                    model.RoleCanEditCommentInOnlyOwnContentErrorView();
                    return;
                }
            }

            // Add Comment Reply Access Check
            if (model.IsCommentReplyValue)
            {
                if (!StaticObject.RoleReplyCommentAllContentCheck())
                {
                    model.RoleAccessReplyErrorView();
                    return;
                }
            }

            // Check Content Comment Send
            if ((model.IsCommentReplyValue) ? duc.GetContentVerifyCommentsByCommentId(model.ParentCommentValue) : duc.GetContentVerifyCommentsByContentId(model.ContentIdValue))
            {
                model.AddCommentInContentInactiveErrorView();
                return;
            }


            model.SaveComment();


            model.SuccessView();
        }
    }
}