using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPatchViewMoreController : CodeBehindController
    {
        public ActionGetPatchViewMoreModel model = new ActionGetPatchViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["patch_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["patch_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["patch_id"]));

            View(model);
        }
    }
}