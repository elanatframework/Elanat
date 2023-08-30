using CodeBehind;

namespace Elanat
{
    public partial class ActionShowProtectionAttachmentController : CodeBehindController
    {
        public ActionShowProtectionAttachmentModel model = new ActionShowProtectionAttachmentModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_attachment").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(context.Request.Query["captcha_value"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["attachment_password"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["attachment_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["attachment_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["captcha_value"].ToString().MatchByCaptcha())
            {
                IgnoreViewAndModel = true;
                return;
            }


            string AttachmentId = context.Request.Query["attachment_id"];
            string AttachmentPassword = context.Request.Query["attachment_password"].ToString().ProtectSqlInjection();

            model.SetValue(AttachmentId, AttachmentPassword);

            View(model);
        }
    }
}