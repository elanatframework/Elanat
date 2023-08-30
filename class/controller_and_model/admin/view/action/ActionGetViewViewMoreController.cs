using CodeBehind;

namespace Elanat
{
    public partial class ActionGetViewViewMoreController : CodeBehindController
    {
        public ActionGetViewViewMoreModel model = new ActionGetViewViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["view_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["view_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["view_id"]));

            View(model);
        }
    }
}