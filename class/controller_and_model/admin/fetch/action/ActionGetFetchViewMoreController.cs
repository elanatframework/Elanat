using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFetchViewMoreController : CodeBehindController
    {
        public ActionGetFetchViewMoreModel model = new ActionGetFetchViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["fetch_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["fetch_id"]));

            View(model);
        }
    }
}