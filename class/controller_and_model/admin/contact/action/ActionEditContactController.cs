using CodeBehind;

namespace Elanat
{
    public partial class ActionEditContactController : CodeBehindController
    {
        public ActionEditContactModel model = new ActionEditContactModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveContact"]))
            {
                btn_SaveContact_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ContactId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["contact_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["contact_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ContactIdValue = context.Request.Query["contact_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveContact_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.DeleteContactFileValue = context.Request.Form["cbx_DeleteContactFile"] == "on";
            model.UseUploadPathValue = context.Request.Form["cbx_UseUploadPath"] == "on";
            model.UploadPathTextValue = context.Request.Form["txt_UploadPath"];
            model.UploadPathUploadValue = context.Request.Form.Files["upd_UploadPath"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactText"]))
                model.ContactTextValue = context.Request.Form["txt_ContactText"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactTitle"]))
                model.ContactTitleValue = context.Request.Form["txt_ContactTitle"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_ContactGuestBirthdayYear"]))
            {
                model.ContactGuestBirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_ContactGuestBirthdayYear"];
                model.ContactGuestBirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_ContactGuestBirthdayMount"];
                model.ContactGuestBirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_ContactGuestBirthdayDay"];
            }
            else
            {
                model.ContactGuestBirthdayYearOptionListSelectedValue = "0000";
                model.ContactGuestBirthdayMountOptionListSelectedValue = "00";
                model.ContactGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestEmail"]))
                model.ContactGuestEmailValue = context.Request.Form["txt_ContactGuestEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_ContactType"]))
                model.ContactTypeOptionListSelectedValue = context.Request.Form["ddlst_ContactType"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestAbout"]))
                model.ContactGuestAboutValue = context.Request.Form["txt_ContactGuestAbout"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestAddress"]))
                model.ContactGuestAddressValue = context.Request.Form["txt_ContactGuestAddress"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestCity"]))
                model.ContactGuestCityValue = context.Request.Form["txt_ContactGuestCity"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestCountry"]))
                model.ContactGuestCountryValue = context.Request.Form["txt_ContactGuestCountry"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestMobileNumber"]))
                model.ContactGuestMobileNumberValue = context.Request.Form["txt_ContactGuestMobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestPhoneNumber"]))
                model.ContactGuestPhoneNumberValue = context.Request.Form["txt_ContactGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestPostalCode"]))
                model.ContactGuestPostalCodeValue = context.Request.Form["txt_ContactGuestPostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestPublicEmail"]))
                model.ContactGuestPublicEmailValue = context.Request.Form["txt_ContactGuestPublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestName"]))
                model.ContactGuestNameValue = context.Request.Form["txt_ContactGuestName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestRealName"]))
                model.ContactGuestRealNameValue = context.Request.Form["txt_ContactGuestRealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestRealLastName"]))
                model.ContactGuestRealLastNameValue = context.Request.Form["txt_ContactGuestRealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestStateOrProvince"]))
                model.ContactGuestStateOrProvinceValue = context.Request.Form["txt_ContactGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestWebsite"]))
                model.ContactGuestWebsiteValue = context.Request.Form["txt_ContactGuestWebsite"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContactGuestZipCode"]))
                model.ContactGuestZipCodeValue = context.Request.Form["txt_ContactGuestZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.ContactIdValue = context.Request.Form["hdn_ContactId"];
            model.ContactUploadDirectoryValue = context.Request.Form["hdn_ContactUploadDirectoryValue"];
            model.ContactUploadFileValue = context.Request.Form["hdn_ContactUploadFileValue"];

            model.ContactDateSendValue = context.Request.Form["txt_ContactDateSend"];
            model.ContactTimeSendValue = context.Request.Form["txt_ContactTimeSend"];


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


            model.SaveContact();


            model.SuccessView();

            View(model);
        }
    }
}