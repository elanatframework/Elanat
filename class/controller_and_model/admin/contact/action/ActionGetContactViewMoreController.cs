using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContactViewMoreController : CodeBehindController
    {
        public ActionGetContactViewMoreModel model = new ActionGetContactViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["contact_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["contact_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["contact_id"]));

            View(model);
        }
    }
}