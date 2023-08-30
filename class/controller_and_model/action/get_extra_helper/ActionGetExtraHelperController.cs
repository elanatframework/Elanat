using CodeBehind;

namespace Elanat
{
    public partial class ActionGetExtraHelperController : CodeBehindController
    {
        public ActionGetExtraHelperModel model = new ActionGetExtraHelperModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            string ExtraHelperId = context.Request.Query["extra_helper_id"].ToString();


            // Extra Helper Access Check
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();

            if (!dueh.GetExtraHelperAccessShowCheck(ExtraHelperId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/401");

                IgnoreViewAndModel = true;

                return;
            }

            model.SetValue(ExtraHelperId, context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}