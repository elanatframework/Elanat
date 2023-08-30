using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFootPrintViewMoreController : CodeBehindController
    {
        public ActionGetFootPrintViewMoreModel model = new ActionGetFootPrintViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["foot_print_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["foot_print_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["foot_print_id"]));

            View(model);
        }
    }
}