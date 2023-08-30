using CodeBehind;

namespace Elanat
{
    public partial class ActionKeepLoginController : CodeBehindController
    {
        public ActionKeepLoginModel model = new ActionKeepLoginModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);


            if (!string.IsNullOrEmpty(context.Request.Query["use_start_add_on_install"]))
            {
                if (context.Request.Query["use_start_add_on_install"].ToString() == "true")
                    model.UseStartAddOnInstall = "true";
            }


            string RandomText = context.Request.Cookies["el_current_user-keep_login_random_text"];
            string UserId = context.Request.Cookies["el_current_user-keep_login_user_id"];

            model.SetValue(RandomText, UserId);

            View(model);
        }
    }
}