using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteGetResponseController : CodeBehindController
    {
        public ActionSiteGetResponseModel model = new ActionSiteGetResponseModel();

        public void PageLoad(HttpContext context)
        {
            if (context.Session.GetString("el_contact_response_text") != null)
            {
                model.SetValue(context);

                View(model);

                return;
            }

            IgnoreViewAndModel = true;
        }
    }
}