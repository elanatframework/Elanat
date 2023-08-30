using CodeBehind;

namespace Elanat
{
    public partial class ActionGetComponentViewMoreController : CodeBehindController
    {
        public ActionGetComponentViewMoreModel model = new ActionGetComponentViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["component_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["component_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["component_id"]));

            View(model);
        }
    }
}