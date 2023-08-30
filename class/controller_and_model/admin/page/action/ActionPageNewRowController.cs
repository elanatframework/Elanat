using CodeBehind;

namespace Elanat
{
    public partial class ActionPageNewRowController : CodeBehindController
    {
        public ActionPageNewRowModel model = new ActionPageNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["page_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["page_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.PageIdValue = context.Request.Query["page_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}