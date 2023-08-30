using CodeBehind;

namespace Elanat
{
    public partial class ActionGetCategoryViewMoreController : CodeBehindController
    {
        public ActionGetCategoryViewMoreModel model = new ActionGetCategoryViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["category_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["category_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["category_id"]));

            View(model);
        }
    }
}