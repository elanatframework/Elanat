using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminStyleViewMoreController : CodeBehindController
    {
        public ActionGetAdminStyleViewMoreModel model = new ActionGetAdminStyleViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_style_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["admin_style_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["admin_style_id"]));

            View(model);
        }
    }
}