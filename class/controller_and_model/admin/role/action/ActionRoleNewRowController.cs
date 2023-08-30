using CodeBehind;

namespace Elanat
{
    public partial class ActionRoleNewRowController : CodeBehindController
    {
        public ActionRoleNewRowModel model = new ActionRoleNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["role_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["role_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.RoleIdValue = context.Request.Query["role_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}