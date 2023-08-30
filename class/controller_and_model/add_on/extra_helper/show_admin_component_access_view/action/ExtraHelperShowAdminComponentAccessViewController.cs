using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperShowAdminComponentAccessViewController : CodeBehindController
    {
        public ExtraHelperShowAdminComponentAccessViewModel model = new ExtraHelperShowAdminComponentAccessViewModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["current_component"]))
            {
                IgnoreViewAndModel = true;
                return;
            }


            string ComponentName = context.Request.Query["current_component"].ToString();

            model.SetValue(ComponentName);

            View(model);
        }
    }
}