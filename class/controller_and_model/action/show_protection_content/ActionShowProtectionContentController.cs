using CodeBehind;

namespace Elanat
{
    public partial class ActionShowProtectionContentController : CodeBehindController
    {
        public ActionShowProtectionContentModel model = new ActionShowProtectionContentModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(context.Request.Query["captcha_value"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["content_password"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

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

            if (!context.Request.Query["captcha_value"].ToString().MatchByCaptcha())
            {
                IgnoreViewAndModel = true;
                return;
            }


            string ContentId = context.Request.Query["content_id"];
            string ContentPassword = context.Request.Query["content_password"].ToString().ProtectSqlInjection();

            model.SetValue(ContentId, ContentPassword);

            View(model);
        }
    }
}