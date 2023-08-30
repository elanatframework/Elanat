using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteTemplateNewRowController : CodeBehindController
    {
        public ActionSiteTemplateNewRowModel model = new ActionSiteTemplateNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_template_id"]))
                return;

            if (!context.Request.Query["site_template_id"].ToString().IsNumber())
                return;

            model.SiteTemplateIdValue = context.Request.Query["site_template_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}