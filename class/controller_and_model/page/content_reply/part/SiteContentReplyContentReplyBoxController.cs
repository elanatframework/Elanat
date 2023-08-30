using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyContentReplyBoxController : CodeBehindController
    {
        public SiteContentReplyContentReplyBoxModel model = new SiteContentReplyContentReplyBoxModel();

        public void PageLoad(HttpContext context)
        {
            model.ContentReplyTypeValue = "";
            if(!string.IsNullOrEmpty(context.Request.Query["content_reply_type"]))
                model.ContentReplyTypeValue = context.Request.Query["content_reply_type"];


            if (!string.IsNullOrEmpty(context.Request.Form["txt_Text"]))
            {
                model.TextValue = context.Request.Form["txt_Text"];
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_BirthdayYear"]))
            {
                model.BirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_BirthdayYear"];
                model.BirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_BirthdayMount"];
                model.BirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_BirthdayDay"];
            }
            else
            {
                model.BirthdayYearOptionListSelectedValue = "0000";
                model.BirthdayMountOptionListSelectedValue = "00";
                model.BirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Email"]))
                model.EmailValue = context.Request.Form["txt_Email"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_Type"]))
                model.TypeOptionListSelectedValue = context.Request.Form["ddlst_Type"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_About"]))
                model.AboutValue = context.Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Address"]))
                model.AddressValue = context.Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_City"]))
                model.CityValue = context.Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Country"]))
                model.CountryValue = context.Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_MobileNumber"]))
                model.MobileNumberValue = context.Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PhoneNumber"]))
                model.PhoneNumberValue = context.Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PostalCode"]))
                model.PostalCodeValue = context.Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PublicEmail"]))
                model.PublicEmailValue = context.Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealName"]))
                model.RealNameValue = context.Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealLastName"]))
                model.RealLastNameValue = context.Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_StateOrProvince"]))
                model.StateOrProvinceValue = context.Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Website"]))
                model.WebsiteValue = context.Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ZipCode"]))
                model.ZipCodeValue = context.Request.Form["txt_ZipCode"];

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
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SetValue();

            View(model);
        }
    }
}