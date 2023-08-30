using CodeBehind;

namespace Elanat
{
    public partial class SiteEmailController : CodeBehindController
    {
        public SiteEmailModel model = new SiteEmailModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SendEmail"]))
            {
                btn_SendEmail_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ContentId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["content_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ContentIdValue = context.Request.Query["content_id"].ToString(); ;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SendEmail_Click(HttpContext context)
        {
            model.ContentIdValue = context.Request.Form["hdn_ContentId"];
            model.YourEmailValue = context.Request.Form["txt_YourEmail"];
            model.RecipientsEmailValue = context.Request.Form["txt_RecipientsEmail"];
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


            model.SendEmail(context);

            model.SuccessView();

            View(model);
        }
    }
}