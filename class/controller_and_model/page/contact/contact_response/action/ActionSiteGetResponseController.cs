using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteGetResponseController : CodeBehindController
    {
        public ActionSiteGetResponseModel model = new ActionSiteGetResponseModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(StaticObject.GetSession("el_contact_response_text")))
            {
                model.SetValue(context);
                View(model);
            }

            IgnoreViewAndModel = true;
        }
    }
}