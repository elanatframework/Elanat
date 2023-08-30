using CodeBehind;

namespace Elanat
{
    public partial class ActionGetLanguageViewMoreController : CodeBehindController
    {
        public ActionGetLanguageViewMoreModel model = new ActionGetLanguageViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["language_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["language_id"], StaticObject.AdminPath + "/language/"));

            View(model);
        }
    }
}