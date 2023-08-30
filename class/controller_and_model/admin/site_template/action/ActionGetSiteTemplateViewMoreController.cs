using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteTemplateViewMoreController : CodeBehindController
    {
        public ActionGetSiteTemplateViewMoreModel model = new ActionGetSiteTemplateViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["site_template_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["site_template_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["site_template_id"]));

            View(model);
        }
    }
}