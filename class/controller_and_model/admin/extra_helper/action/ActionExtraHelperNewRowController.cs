using CodeBehind;

namespace Elanat
{
    public partial class ActionExtraHelperNewRowController : CodeBehindController
    {
        public ActionExtraHelperNewRowModel model = new ActionExtraHelperNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ExtraHelperIdValue = context.Request.Query["extra_helper_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}