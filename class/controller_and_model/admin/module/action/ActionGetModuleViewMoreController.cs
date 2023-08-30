using CodeBehind;

namespace Elanat
{
    public partial class ActionGetModuleViewMoreController : CodeBehindController
    {
        public ActionGetModuleViewMoreModel model = new ActionGetModuleViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["module_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["module_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["module_id"]));

            View(model);
        }
    }
}