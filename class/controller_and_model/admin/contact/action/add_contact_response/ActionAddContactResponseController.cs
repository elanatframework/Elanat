using CodeBehind;

namespace Elanat
{
    public partial class ActionAddContactResponseController : CodeBehindController
    {
        public ActionAddContactResponseModel model = new ActionAddContactResponseModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddContactResponse"]))
            {
                btn_AddContactResponse_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ContactId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["contact_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["contact_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ContactIdValue = context.Request.Query["contact_id"].ToString();
            }


            model.SetValue();

            View(model);
        }

        protected void btn_AddContactResponse_Click(HttpContext context)
        {
            model.ContactIdValue = context.Request.Form["hdn_ContactId"];
            model.ContactResponseValue = context.Request.Form["txt_ContactResponse"];


            model.AddContactResponse();

            model.SuccessView();

            View(model);
        }
    }
}