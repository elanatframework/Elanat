using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class SiteComment : System.Web.UI.Page
    {
        public SiteCommentModel model = new SiteCommentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SendComment"]))
                btn_SendComment_Click(sender, e);

            if (string.IsNullOrEmpty(model.ContentIdValue))
            {
                if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
                    return;

                if (!Request.QueryString["content_id"].IsNumber())
                    return;

                model.ContentIdValue = Request.QueryString["content_id"].ToString();
            }

            if (string.IsNullOrEmpty(model.ParentCommentValue))
                if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
                    model.ParentCommentValue = "0";
                else
                    if (!Request.QueryString["comment_id"].IsNumber())
                        return;
                    else
                        model.ParentCommentValue = Request.QueryString["comment_id"].ToString();


            if (string.IsNullOrEmpty(Request.Form["ddlst_Type"]))
                if (!string.IsNullOrEmpty(Request.QueryString["comment_type"]))
                    model.TypeOptionListSelectedValue = Request.QueryString["comment_type"].ToString();


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SendComment_Click(object sender, EventArgs e)
        {
            model.ContentIdValue = Request.Form["hdn_ContentId"];
            model.ParentCommentValue = Request.Form["hdn_ParentComment"];

            model.UseUploadPathValue = Request.Form["cbx_UseUploadPath"] == "on";
            model.UploadPathTextValue = Request.Form["txt_UploadPath"];
            model.UploadPathUploadValue = Request.Files["upd_UploadPath"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Text"]))
                model.TextValue = Request.Form["txt_Text"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Title"]))
                model.TitleValue = Request.Form["txt_Title"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_BirthdayYear"]))
            {
                model.BirthdayYearOptionListSelectedValue = Request.Form["ddlst_BirthdayYear"];
                model.BirthdayMountOptionListSelectedValue = Request.Form["ddlst_BirthdayMount"];
                model.BirthdayDayOptionListSelectedValue = Request.Form["ddlst_BirthdayDay"];
            }
            else
            {
                model.BirthdayYearOptionListSelectedValue = "0000";
                model.BirthdayMountOptionListSelectedValue = "00";
                model.BirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_Email"]))
                model.EmailValue = Request.Form["txt_Email"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_Type"]))
                model.TypeOptionListSelectedValue = Request.Form["ddlst_Type"];

            if (!string.IsNullOrEmpty(Request.Form["txt_About"]))
                model.AboutValue = Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Address"]))
                model.AddressValue = Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(Request.Form["txt_City"]))
                model.CityValue = Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Country"]))
                model.CountryValue = Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(Request.Form["txt_MobileNumber"]))
                model.MobileNumberValue = Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PhoneNumber"]))
                model.PhoneNumberValue = Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PostalCode"]))
                model.PostalCodeValue = Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PublicEmail"]))
                model.PublicEmailValue = Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealName"]))
                model.RealNameValue = Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealLastName"]))
                model.RealLastNameValue = Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_StateOrProvince"]))
                model.StateOrProvinceValue = Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Website"]))
                model.WebsiteValue = Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ZipCode"]))
                model.ZipCodeValue = Request.Form["txt_ZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.CaptchaTextValue = Request.Form["txt_Captcha"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            if (ElanatConfig.GetNode("active/add_comment").Attributes["active"].Value != "true")
            {
                model.AddCommentInactiveView();
                return;
            }

            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
                return;
            }


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Comment duc = new DataUse.Comment();

            // Add Comment Reply To Own Content Access Check
            if (model.ParentCommentValue != "0")
            {
                DataUse.Content Duc = new DataUse.Content();

                if (!Duc.IsUserContent(ccoc.UserId, model.ContentIdValue))
                {
                    if (StaticObject.RoleReplyCommentOnlyOwnContentCheck())
                    {
                        model.RoleAccessReplyErrorView();
                        return;
                    }
                }
            }

            // Add Comment Reply Access Check
            if (model.ParentCommentValue != "0")
            {
                if (!StaticObject.RoleReplyCommentAllContentCheck())
                {
                    model.RoleAccessReplyErrorView();
                    return;
                }
            }

            // Check Content Comment Send
            if ((model.ParentCommentValue != "0") ? !duc.GetContentVerifyCommentsByCommentId(model.ParentCommentValue) : !duc.GetContentVerifyCommentsByContentId(model.ContentIdValue))
            {
                model.AddCommentInContentInactiveErrorView();
                return;
            }


            model.SendComment();


            model.SuccessView();
        }
    }
}