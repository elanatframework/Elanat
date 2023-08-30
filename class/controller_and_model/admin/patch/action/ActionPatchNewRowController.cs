using CodeBehind;

namespace Elanat
{
    public partial class ActionPatchNewRowController : CodeBehindController
    {
        public ActionPatchNewRowModel model = new ActionPatchNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["patch_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["patch_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.PatchIdValue = context.Request.Query["patch_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}