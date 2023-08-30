using CodeBehind;

namespace Elanat
{
    public partial class ActionGetGroupViewMoreController : CodeBehindController
    {
        public ActionGetGroupViewMoreModel model = new ActionGetGroupViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["group_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["group_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["group_id"]));

            View(model);
        }
    }
}