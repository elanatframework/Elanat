using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPageViewMoreController : CodeBehindController
    {
        public ActionGetPageViewMoreModel model = new ActionGetPageViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["page_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["page_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["page_id"]));

            View(model);
        }
    }
}