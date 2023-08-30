using CodeBehind;

namespace Elanat
{
    public partial class ActionTextCreatorController : CodeBehindController
    {
        public ActionTextCreatorModel model = new ActionTextCreatorModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["value"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            string Value = context.Request.Query["value"];

            model.SetValue(Value, context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}