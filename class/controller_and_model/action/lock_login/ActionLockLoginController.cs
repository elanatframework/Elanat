using CodeBehind;

namespace Elanat
{
    public partial class ActionLockLoginController : CodeBehindController
    {
        public ActionLockLoginModel model = new ActionLockLoginModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/lock_login_page").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(context.Request.Query["code"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (Security.GetCodeIni("lock_login_password_value") != context.Request.Query["code"])
            {
                IgnoreViewAndModel = true;
                return;
            }


            model.SetValue();

            View(model);
        }
    }
}