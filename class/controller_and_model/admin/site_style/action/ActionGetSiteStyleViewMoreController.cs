using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteStyleViewMoreController : CodeBehindController
    {
        public ActionGetSiteStyleViewMoreModel model = new ActionGetSiteStyleViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["site_style_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["site_style_id"]));

            View(model);
        }
    }
}