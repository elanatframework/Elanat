using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminTemplateViewMoreController : CodeBehindController
    {
        public ActionGetAdminTemplateViewMoreModel model = new ActionGetAdminTemplateViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_template_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["admin_template_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["admin_template_id"]));

            View(model);
        }
    }
}