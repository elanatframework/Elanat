using CodeBehind;

namespace Elanat
{
    public partial class ActionAttachmentNewRowController : CodeBehindController
    {
        public ActionAttachmentNewRowModel model = new ActionAttachmentNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["attachment_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["attachment_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.AttachmentIdValue = context.Request.Query["attachment_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}