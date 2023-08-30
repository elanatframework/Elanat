using CodeBehind;

namespace Elanat
{
    public partial class ActionConfigurationSetConfigController : CodeBehindController
    {
        public ActionConfigurationSetConfigModel model = new ActionConfigurationSetConfigModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["config_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ConfigNameValue = context.Request.Query["config_name"].ToString();


            // Role Bit Column Access Check
            Access ac = new Access();
            if (ac.AggregationRoleBitColumnAccess("role_" + model.ConfigNameValue + "_configuration") == "0")
            {
                Write(GlobalClass.Alert(Language.GetAddOnsLanguage("you_do_not_have_access_to_this_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/configuration/"), StaticObject.GetCurrentAdminGlobalLanguage(), "warning"));

                IgnoreViewAndModel = true;

                return;
            }

            model.SetValue(context);

            View(model);
        }
    }
}