using CodeBehind;

namespace Elanat
{
    public partial class ActionAdminStyleNewRowController : CodeBehindController
    {
        public ActionAdminStyleNewRowModel model = new ActionAdminStyleNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_style_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["admin_style_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.AdminStyleIdValue = context.Request.Query["admin_style_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}