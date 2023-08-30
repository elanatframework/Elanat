using CodeBehind;

namespace Elanat
{
    public partial class ActionFetchNewRowController : CodeBehindController
    {
        public ActionFetchNewRowModel model = new ActionFetchNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["fetch_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.FetchIdValue = context.Request.Query["fetch_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}