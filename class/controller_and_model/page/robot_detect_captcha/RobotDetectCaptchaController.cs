using CodeBehind;

namespace Elanat
{
    public partial class RobotDetectCaptchaController : CodeBehindController
    {
        public RobotDetectCaptchaModel model = new RobotDetectCaptchaModel();

        public void PageLoad(HttpContext context)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RobotDetectionRequestCount > 0)
            {
                IgnoreViewAndModel = true;
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Form["btn_SetCaptcha"]))
            {
                btn_SetCaptcha_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SetCaptcha_Click(HttpContext context)
        {
            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();

                View(model);

                return;
            }


            model.SetCaptcha();

            View(model);
        }
    }
}