using CodeBehind;

namespace Elanat
{
    public partial class ActionUserNewRowController : CodeBehindController
    {
        public ActionUserNewRowModel model = new ActionUserNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["user_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["user_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.UserIdValue = context.Request.Query["user_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}