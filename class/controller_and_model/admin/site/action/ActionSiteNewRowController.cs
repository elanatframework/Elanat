using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteNewRowController : CodeBehindController
    {
        public ActionSiteNewRowModel model = new ActionSiteNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["site_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.SiteIdValue = context.Request.Query["site_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}