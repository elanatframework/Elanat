using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteViewMoreController : CodeBehindController
    {
        public ActionGetSiteViewMoreModel model = new ActionGetSiteViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["site_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["site_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["site_id"]));

            View(model);
        }
    }
}