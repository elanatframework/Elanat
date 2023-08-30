using CodeBehind;

namespace Elanat
{
    public partial class ActionGetLinkViewMoreController : CodeBehindController
    {
        public ActionGetLinkViewMoreModel model = new ActionGetLinkViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["link_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["link_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["link_id"]));

            View(model);
        }
    }
}