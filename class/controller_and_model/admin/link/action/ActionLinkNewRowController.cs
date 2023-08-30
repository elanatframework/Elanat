using CodeBehind;

namespace Elanat
{
    public partial class ActionLinkNewRowController : CodeBehindController
    {
        public ActionLinkNewRowModel model = new ActionLinkNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["link_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["link_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.LinkIdValue = context.Request.Query["link_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}