using CodeBehind;

namespace Elanat
{
    public partial class ActionMenuNewRowController : CodeBehindController
    {
        public ActionMenuNewRowModel model = new ActionMenuNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["menu_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["menu_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.MenuIdValue = context.Request.Query["menu_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}