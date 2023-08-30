using CodeBehind;

namespace Elanat
{
    public partial class ActionComponentNewRowController : CodeBehindController
    {
        public ActionComponentNewRowModel model = new ActionComponentNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["component_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["component_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ComponentIdValue = context.Request.Query["component_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}