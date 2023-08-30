using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteStyleNewRowController : CodeBehindController
    {
        public ActionSiteStyleNewRowModel model = new ActionSiteStyleNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["site_style_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.SiteStyleIdValue = context.Request.Query["site_style_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}