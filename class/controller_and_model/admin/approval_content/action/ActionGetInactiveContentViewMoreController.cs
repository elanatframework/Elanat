using CodeBehind;

namespace Elanat
{
    public partial class ActionGetInactiveContentViewMoreController : CodeBehindController
    {
        public ActionGetInactiveContentViewMoreModel model = new ActionGetInactiveContentViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["content_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["content_id"]));

            View(model);
        }
    }
}