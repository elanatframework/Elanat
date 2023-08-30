using CodeBehind;

namespace Elanat
{
    public partial class ActionGetItemViewMoreController : CodeBehindController
    {
        public ActionGetItemViewMoreModel model = new ActionGetItemViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["item_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["item_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["item_id"]));

            View(model);
        }
    }
}