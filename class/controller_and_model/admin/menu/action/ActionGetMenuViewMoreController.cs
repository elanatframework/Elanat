using CodeBehind;

namespace Elanat
{
    public partial class ActionGetMenuViewMoreController : CodeBehindController
    {
        public ActionGetMenuViewMoreModel model = new ActionGetMenuViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["menu_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["menu_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["menu_id"]));

            View(model);
        }
    }
}