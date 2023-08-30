using CodeBehind;

namespace Elanat
{
    public partial class ActionCategoryNewRowController : CodeBehindController
    {
        public ActionCategoryNewRowModel model = new ActionCategoryNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["category_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["category_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.CategoryIdValue = context.Request.Query["category_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}