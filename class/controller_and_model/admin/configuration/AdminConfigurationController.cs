using CodeBehind;

namespace Elanat
{
    public partial class AdminConfigurationController : CodeBehindController
    {
        public AdminConfigurationModel model = new AdminConfigurationModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveConfig"]))
            {
                btn_SaveConfig_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveConfig_Click(HttpContext context)
        {
            model.ConfigValue = context.Request.Form["txt_Config"];


            model.SaveConfig();

            View(model);
        }
    }
}