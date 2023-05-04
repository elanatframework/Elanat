using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminComment : System.Web.UI.Page
    {
        public AdminCommentModel model = new AdminCommentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddComment"]))
                btn_AddComment_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddComment_Click(object sender, EventArgs e)
        {
            model.ContentIdValue = Request.Form["txt_ContentId"];
            model.ParentCommentValue = Request.Form["txt_ParentComment"];

            model.IsCommentReplyValue = Request.Form["cbx_IsCommentReply"] == "on";
            model.CommentActiveValue = Request.Form["cbx_CommentActive"] == "on";

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

            // Add Comment Reply To Own Content Access Check
            if (model.IsCommentReplyValue)
            {
                DataUse.Content Duc2 = new DataUse.Content();

                if (!Duc2.IsUserContent(ccoc.UserId, model.ContentIdValue))
                {
                    if (StaticObject.RoleReplyCommentOnlyOwnContentCheck())
                    {
                        model.RoleAccessReplyErrorView();
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
                    return;
                }
            }
            
            // Check Comment Send
            if (ElanatConfig.GetNode("active/add_comment").Attributes["active"].Value != "true")
            {
                model.AddCommentInactiveView();
                return;
            }

            // Check Content Comment Send
            if ((model.IsCommentReplyValue) ? !duc.GetContentVerifyCommentsByCommentId(model.ParentCommentValue) : !duc.GetContentVerifyCommentsByContentId(model.ContentIdValue))
            {
                model.AddCommentInContentInactiveErrorView();
                return;
            }


            model.AddComment();
        }
    }
}