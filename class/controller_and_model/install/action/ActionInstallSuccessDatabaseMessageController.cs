using CodeBehind;

namespace Elanat
{
    public partial class ActionInstallSuccessDatabaseMessageController : CodeBehindController
    {
        public ActionInstallSuccessDatabaseMessageModel model = new ActionInstallSuccessDatabaseMessageModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            string GlobalLanguage = context.Request.Query["language"].ToString();

            model.SetValue(GlobalLanguage);

            View(model);
        }
    }
}