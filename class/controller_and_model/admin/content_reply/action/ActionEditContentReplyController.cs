using CodeBehind;

namespace Elanat
{
    public partial class ActionEditContentReplyController : CodeBehindController
    {
        public ActionEditContentReplyModel model = new ActionEditContentReplyModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveContentReply"]))
            {
                btn_SaveContentReply_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ContentReplyId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["content_reply_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["content_reply_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ContentReplyIdValue = context.Request.Query["content_reply_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveContentReply_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.ContentIdValue = context.Request.Form["txt_ContentId"];

            model.ContentReplyActiveValue = context.Request.Form["cbx_ContentReplyActive"] == "on";

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyText"]))
                model.ContentReplyTextValue = context.Request.Form["txt_ContentReplyText"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_ContentReplyGuestBirthdayYear"]))
            {
                model.ContentReplyGuestBirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_ContentReplyGuestBirthdayYear"];
                model.ContentReplyGuestBirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_ContentReplyGuestBirthdayMount"];
                model.ContentReplyGuestBirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_ContentReplyGuestBirthdayDay"];
            }
            else
            {
                model.ContentReplyGuestBirthdayYearOptionListSelectedValue = "0000";
                model.ContentReplyGuestBirthdayMountOptionListSelectedValue = "00";
                model.ContentReplyGuestBirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestEmail"]))
                model.ContentReplyGuestEmailValue = context.Request.Form["txt_ContentReplyGuestEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_ContentReplyType"]))
                model.ContentReplyTypeOptionListSelectedValue = context.Request.Form["ddlst_ContentReplyType"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestAbout"]))
                model.ContentReplyGuestAboutValue = context.Request.Form["txt_ContentReplyGuestAbout"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestAddress"]))
                model.ContentReplyGuestAddressValue = context.Request.Form["txt_ContentReplyGuestAddress"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestCity"]))
                model.ContentReplyGuestCityValue = context.Request.Form["txt_ContentReplyGuestCity"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestCountry"]))
                model.ContentReplyGuestCountryValue = context.Request.Form["txt_ContentReplyGuestCountry"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestMobileNumber"]))
                model.ContentReplyGuestMobileNumberValue = context.Request.Form["txt_ContentReplyGuestMobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestPhoneNumber"]))
                model.ContentReplyGuestPhoneNumberValue = context.Request.Form["txt_ContentReplyGuestPhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestPostalCode"]))
                model.ContentReplyGuestPostalCodeValue = context.Request.Form["txt_ContentReplyGuestPostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestPublicEmail"]))
                model.ContentReplyGuestPublicEmailValue = context.Request.Form["txt_ContentReplyGuestPublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestName"]))
                model.ContentReplyGuestNameValue = context.Request.Form["txt_ContentReplyGuestName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestRealName"]))
                model.ContentReplyGuestRealNameValue = context.Request.Form["txt_ContentReplyGuestRealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestRealLastName"]))
                model.ContentReplyGuestRealLastNameValue = context.Request.Form["txt_ContentReplyGuestRealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestStateOrProvince"]))
                model.ContentReplyGuestStateOrProvinceValue = context.Request.Form["txt_ContentReplyGuestStateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestWebsite"]))
                model.ContentReplyGuestWebsiteValue = context.Request.Form["txt_ContentReplyGuestWebsite"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ContentReplyGuestZipCode"]))
                model.ContentReplyGuestZipCodeValue = context.Request.Form["txt_ContentReplyGuestZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]))
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.ContentReplyIdValue = context.Request.Form["hdn_ContentReplyId"];
            model.ContentReplyDateSendValue = context.Request.Form["txt_ContentReplyDateSend"];
            model.ContentReplyTimeSendValue = context.Request.Form["txt_ContentReplyTimeSend"];

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


            model.SaveContentReply();

            model.SuccessView();

            View(model);
        }
    }
}