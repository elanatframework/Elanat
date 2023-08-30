using CodeBehind;

namespace Elanat
{
    public partial class ActionGroupNewRowController : CodeBehindController
    {
        public ActionGroupNewRowModel model = new ActionGroupNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["group_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["group_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.GroupIdValue = context.Request.Query["group_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}