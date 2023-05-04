using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditContact : System.Web.UI.Page
    {
        public ActionEditContactModel model = new ActionEditContactModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveContact"]))
                btn_SaveContact_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ContactId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["contact_id"]))
                    return;

                if (!Request.QueryString["contact_id"].ToString().IsNumber())
                    return;

                model.ContactIdValue = Request.QueryString["contact_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveContact_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.DeleteContactFileValue = Request.Form["cbx_DeleteContactFile"] == "on";
            model.UseUploadPathValue = Request.Form["cbx_UseUploadPath"] == "on";
            model.UploadPathTextValue = Request.Form["txt_UploadPath"];
            model.UploadPathUploadValue = Request.Files["upd_UploadPath"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactText"]))
                model.ContactTextValue = Request.Form["txt_ContactText"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactTitle"]))
                model.ContactTitleValue = Request.Form["txt_ContactTitle"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_ContactGuestBirthdayYear"]))
            {
                model.ContactGuestBirthdayYearOptionListSelectedValue = Request.Form["ddlst_ContactGuestBirthdayYear"];
                model.ContactGuestBirthdayMountOptionListSelectedValue = Request.Form["ddlst_ContactGuestBirthdayMount"];
                model.ContactGuestBirthdayDayOptionListSelectedValue = Request.Form["ddlst_ContactGuestBirthdayDay"];
            }
            else
            {
                model.ContactGuestBirthdayYearOptionListSelectedValue = "0000";
                model.ContactGuestBirthdayMountOptionListSelectedValue = "00";
                model.ContactGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestEmail"]))
                model.ContactGuestEmailValue = Request.Form["txt_ContactGuestEmail"];

            if (!string.IsNullOrEmpty(Request.Form["ddlst_ContactType"]))
                model.ContactTypeOptionListSelectedValue = Request.Form["ddlst_ContactType"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestAbout"]))
                model.ContactGuestAboutValue = Request.Form["txt_ContactGuestAbout"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestAddress"]))
                model.ContactGuestAddressValue = Request.Form["txt_ContactGuestAddress"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestCity"]))
                model.ContactGuestCityValue = Request.Form["txt_ContactGuestCity"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestCountry"]))
                model.ContactGuestCountryValue = Request.Form["txt_ContactGuestCountry"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestMobileNumber"]))
                model.ContactGuestMobileNumberValue = Request.Form["txt_ContactGuestMobileNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestPhoneNumber"]))
                model.ContactGuestPhoneNumberValue = Request.Form["txt_ContactGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestPostalCode"]))
                model.ContactGuestPostalCodeValue = Request.Form["txt_ContactGuestPostalCode"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestPublicEmail"]))
                model.ContactGuestPublicEmailValue = Request.Form["txt_ContactGuestPublicEmail"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestName"]))
                model.ContactGuestNameValue = Request.Form["txt_ContactGuestName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestRealName"]))
                model.ContactGuestRealNameValue = Request.Form["txt_ContactGuestRealName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestRealLastName"]))
                model.ContactGuestRealLastNameValue = Request.Form["txt_ContactGuestRealLastName"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestStateOrProvince"]))
                model.ContactGuestStateOrProvinceValue = Request.Form["txt_ContactGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestWebsite"]))
                model.ContactGuestWebsiteValue = Request.Form["txt_ContactGuestWebsite"];

            if (!string.IsNullOrEmpty(Request.Form["txt_ContactGuestZipCode"]))
                model.ContactGuestZipCodeValue = Request.Form["txt_ContactGuestZipCode"];

            if (!string.IsNullOrEmpty(Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.ContactIdValue = Request.Form["hdn_ContactId"];
            model.ContactUploadDirectoryValue = Request.Form["hdn_ContactUploadDirectoryValue"];
            model.ContactUploadFileValue = Request.Form["hdn_ContactUploadFileValue"];

            model.ContactDateSendValue = Request.Form["txt_ContactDateSend"];
            model.ContactTimeSendValue = Request.Form["txt_ContactTimeSend"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveContact();


            model.SuccessView();
        }
    }
}