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
    public partial class SiteContentReply : System.Web.UI.Page
    {
        public SiteContentReplyModel model = new SiteContentReplyModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SendContentReply"]))
                btn_SendContentReply_Click(sender, e);

            if (string.IsNullOrEmpty(model.ContentIdValue))
            {
                if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
                    return;

                if (!Request.QueryString["content_id"].IsNumber())
                    return;

                model.ContentIdValue = Request.QueryString["content_id"].ToString();
            }


            if (string.IsNullOrEmpty(Request.Form["ddlst_Type"]))
                if (!string.IsNullOrEmpty(Request.QueryString["content_reply_type"]))
                    model.TypeOptionListSelectedValue = Request.QueryString["content_reply_type"].ToString();


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }
    
        protected void btn_SendContentReply_Click(object sender, EventArgs e)
        {            
            // Set Option Value
            XmlDocument ContentReplyOptionDocument = new XmlDocument();
            ContentReplyOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/content_reply_option/option/content_reply_option.xml"));
            XmlNode node = ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root");


            model.ContentIdValue = Request.Form["hdn_ContentId"];

            if (!string.IsNullOrEmpty(Request.Form["txt_Text"]) && node["text"].Attributes["active"].Value == "true")
                model.TextValue = Request.Form["txt_Text"];
            

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


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
                return;
            }


            model.SendContentReply();

            model.SuccessView();
        }
    }
}
