using CodeBehind;

namespace Elanat
{
    public partial class ActionGetRoleViewMoreController : CodeBehindController
    {
        public ActionGetRoleViewMoreModel model = new ActionGetRoleViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["role_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["role_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["role_id"]));

            View(model);
        }
    }
}