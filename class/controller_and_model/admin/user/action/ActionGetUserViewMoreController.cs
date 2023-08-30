using CodeBehind;

namespace Elanat
{
    public partial class ActionGetUserViewMoreController : CodeBehindController
    {
        public ActionGetUserViewMoreModel model = new ActionGetUserViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["user_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["user_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["user_id"]));

            View(model);
        }
    }
}