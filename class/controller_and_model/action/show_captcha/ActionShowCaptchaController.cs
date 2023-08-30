using CodeBehind;

namespace Elanat
{
    public partial class ActionShowCaptchaController : CodeBehindController
    {
        public ActionShowCaptchaModel model = new ActionShowCaptchaModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}