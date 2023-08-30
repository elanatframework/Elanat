using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpUserNameController : CodeBehindController
    {
        public SiteSignUpUserNameModel model = new SiteSignUpUserNameModel();

        public void PageLoad(HttpContext context)
        {
            model.UserNameValue = context.Request.Query["user_name_value"];
            model.UserNameCssClass = context.Request.Query["user_name_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}