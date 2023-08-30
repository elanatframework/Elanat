using CodeBehind;

namespace Elanat
{
    public partial class SiteContactResponseController : CodeBehindController
    {
        public SiteContactResponseModel model = new SiteContactResponseModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_GetContactResponse"]))
            {
                btn_GetContactResponse_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_GetContactResponse_Click(HttpContext context)
        {
            model.ContactResponseCodeValue = context.Request.Form["txt_ContactResponseCode"];
            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];


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


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();

                View(model);

                return;
            }


            model.GetContactResponse();

            View(model);
        }
    }
}