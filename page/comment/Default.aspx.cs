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
            // Set Option Value
            XmlDocument CommentOptionDocument = new XmlDocument();
            CommentOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));
            XmlNode node = CommentOptionDocument.SelectSingleNode("comment_option_root");


            model.ContentIdValue = Request.Form["hdn_ContentId"];
            model.ParentCommentValue = Request.Form["hdn_ParentComment"];

            if (node["file"].Attributes["active"].Value == "true")
            {
                model.UseUploadPathValue = Request.Form["cbx_UseUploadPath"] == "on";
                model.UploadPathTextValue = Request.Form["txt_UploadPath"];
                model.UploadPathUploadValue = Request.Files["upd_UploadPath"];
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_Text"]) && node["text"].Attributes["active"].Value == "true")
                model.TextValue = Request.Form["txt_Text"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Title"]) && node["title"].Attributes["active"].Value == "true")
                model.TitleValue = Request.Form["txt_Title"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_BirthdayYear"]) && node["birthday"].Attributes["active"].Value == "true")
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

            if (!string.IsNullOrEmpty(Request.Form["txt_Email"]) && node["email"].Attributes["active"].Value == "true")
                model.EmailValue = Request.Form["txt_Email"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_Type"]) && node["type"].Attributes["active"].Value == "true")
                model.TypeOptionListSelectedValue = Request.Form["ddlst_Type"];

            if (!string.IsNullOrEmpty(Request.Form["txt_About"]) && node["about"].Attributes["active"].Value == "true")
                model.AboutValue = Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Address"]) && node["address"].Attributes["active"].Value == "true")
                model.AddressValue = Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(Request.Form["txt_City"]) && node["city"].Attributes["active"].Value == "true")
                model.CityValue = Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Country"]) && node["country"].Attributes["active"].Value == "true")
                model.CountryValue = Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(Request.Form["txt_MobileNumber"]) && node["mobile_number"].Attributes["active"].Value == "true")
                model.MobileNumberValue = Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PhoneNumber"]) && node["phone_number"].Attributes["active"].Value == "true")
                model.PhoneNumberValue = Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PostalCode"]) && node["postal_code"].Attributes["active"].Value == "true")
                model.PostalCodeValue = Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_PublicEmail"]) && node["public_email"].Attributes["active"].Value == "true")
                model.PublicEmailValue = Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealName"]) && node["name"].Attributes["active"].Value == "true")
                model.RealNameValue = Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_RealLastName"]) && node["last_name"].Attributes["active"].Value == "true")
                model.RealLastNameValue = Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_StateOrProvince"]) && node["state_or_province"].Attributes["active"].Value == "true")
                model.StateOrProvinceValue = Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Website"]) && node["website"].Attributes["active"].Value == "true")
                model.WebsiteValue = Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ZipCode"]) && node["zip_code"].Attributes["active"].Value == "true")
                model.ZipCodeValue = Request.Form["txt_ZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]) && node["gender"].Attributes["active"].Value == "true")
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
