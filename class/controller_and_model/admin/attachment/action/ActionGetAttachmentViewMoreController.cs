using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAttachmentViewMoreController : CodeBehindController
    {
        public ActionGetAttachmentViewMoreModel model = new ActionGetAttachmentViewMoreModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["attachment_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["attachment_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["attachment_id"]));

            View(model);
        }
    }
}