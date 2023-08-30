using CodeBehind;

namespace Elanat
{
    public partial class ActionCreateHtmlForPartPageController : CodeBehindController
    {
        public ActionCreateHtmlForPartPageModel model = new ActionCreateHtmlForPartPageModel();

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

            string PageId = context.Request.Query["page_id"].ToString().ProtectSqlInjection();


            model.SetValue(context, PageId, context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}