using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditContentReply : System.Web.UI.Page
    {
        public ActionEditContentReplyModel model = new ActionEditContentReplyModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveContentReply"]))
                btn_SaveContentReply_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ContentReplyId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["content_reply_id"]))
                    return;

                if (!Request.QueryString["content_reply_id"].ToString().IsNumber())
                    return;

                model.ContentReplyIdValue = Request.QueryString["content_reply_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveContentReply_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ContentIdValue = Request.Form["txt_ContentId"];

            model.ContentReplyActiveValue = Request.Form["cbx_ContentReplyActive"] == "on";

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyText"]))
                model.ContentReplyTextValue = Request.Form["txt_ContentReplyText"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_ContentReplyGuestBirthdayYear"]))
            {
                model.ContentReplyGuestBirthdayYearOptionListSelectedValue = Request.Form["ddlst_ContentReplyGuestBirthdayYear"];
                model.ContentReplyGuestBirthdayMountOptionListSelectedValue = Request.Form["ddlst_ContentReplyGuestBirthdayMount"];
                model.ContentReplyGuestBirthdayDayOptionListSelectedValue = Request.Form["ddlst_ContentReplyGuestBirthdayDay"];
            }
            else
            {
                model.ContentReplyGuestBirthdayYearOptionListSelectedValue = "0000";
                model.ContentReplyGuestBirthdayMountOptionListSelectedValue = "00";
                model.ContentReplyGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestEmail"]))
                model.ContentReplyGuestEmailValue = Request.Form["txt_ContentReplyGuestEmail"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_ContentReplyType"]))
                model.ContentReplyTypeOptionListSelectedValue = Request.Form["ddlst_ContentReplyType"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestAbout"]))
                model.ContentReplyGuestAboutValue = Request.Form["txt_ContentReplyGuestAbout"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestAddress"]))
                model.ContentReplyGuestAddressValue = Request.Form["txt_ContentReplyGuestAddress"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestCity"]))
                model.ContentReplyGuestCityValue = Request.Form["txt_ContentReplyGuestCity"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestCountry"]))
                model.ContentReplyGuestCountryValue = Request.Form["txt_ContentReplyGuestCountry"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestMobileNumber"]))
                model.ContentReplyGuestMobileNumberValue = Request.Form["txt_ContentReplyGuestMobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestPhoneNumber"]))
                model.ContentReplyGuestPhoneNumberValue = Request.Form["txt_ContentReplyGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestPostalCode"]))
                model.ContentReplyGuestPostalCodeValue = Request.Form["txt_ContentReplyGuestPostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestPublicEmail"]))
                model.ContentReplyGuestPublicEmailValue = Request.Form["txt_ContentReplyGuestPublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestName"]))
                model.ContentReplyGuestNameValue = Request.Form["txt_ContentReplyGuestName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestRealName"]))
                model.ContentReplyGuestRealNameValue = Request.Form["txt_ContentReplyGuestRealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestRealLastName"]))
                model.ContentReplyGuestRealLastNameValue = Request.Form["txt_ContentReplyGuestRealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestStateOrProvince"]))
                model.ContentReplyGuestStateOrProvinceValue = Request.Form["txt_ContentReplyGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestWebsite"]))
                model.ContentReplyGuestWebsiteValue = Request.Form["txt_ContentReplyGuestWebsite"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContentReplyGuestZipCode"]))
                model.ContentReplyGuestZipCodeValue = Request.Form["txt_ContentReplyGuestZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.ContentReplyIdValue = Request.Form["hdn_ContentReplyId"];
            model.ContentReplyDateSendValue = Request.Form["txt_ContentReplyDateSend"];
            model.ContentReplyTimeSendValue = Request.Form["txt_ContentReplyTimeSend"];

            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveContentReply();

            model.SuccessView();
        }
    }
}