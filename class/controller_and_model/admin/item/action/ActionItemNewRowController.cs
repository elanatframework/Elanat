using CodeBehind;

namespace Elanat
{
    public partial class ActionItemNewRowController : CodeBehindController
    {
        public ActionItemNewRowModel model = new ActionItemNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["item_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["item_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ItemIdValue = context.Request.Query["item_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}