using CodeBehind;

namespace Elanat
{
    public partial class ActionNewPasswordController : CodeBehindController
    {
        public ActionNewPasswordModel model = new ActionNewPasswordModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(context.Request.Query["value"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["user_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            string UserId = context.Request.Query["user_id"];
            string Value = context.Request.Query["value"];

            model.SetValue(UserId, Value);

            View(model);
        }
    }
}