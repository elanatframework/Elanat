using CodeBehind;

namespace Elanat
{
    public partial class ActionAdminTemplateNewRowController : CodeBehindController
    {
        public ActionAdminTemplateNewRowModel model = new ActionAdminTemplateNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_template_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["admin_template_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.AdminTemplateIdValue = context.Request.Query["admin_template_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}