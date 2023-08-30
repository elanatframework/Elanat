using CodeBehind;

namespace Elanat
{
    public partial class ActionViewNewRowController : CodeBehindController
    {
        public ActionViewNewRowModel model = new ActionViewNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["view_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["view_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ViewIdValue = context.Request.Query["view_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}