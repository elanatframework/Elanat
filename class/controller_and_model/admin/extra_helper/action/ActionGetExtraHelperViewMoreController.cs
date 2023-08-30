using CodeBehind;

namespace Elanat
{
    public partial class ActionGetExtraHelperViewMoreController : CodeBehindController
    {
        public ActionGetExtraHelperViewMoreModel model = new ActionGetExtraHelperViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["extra_helper_id"]));

            View(model);
        }
    }
}