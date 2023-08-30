using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpUserSiteNameController : CodeBehindController
    {
        public SiteSignUpUserSiteNameModel model = new SiteSignUpUserSiteNameModel();

        public void PageLoad(HttpContext context)
        {
            model.UserSiteNameValue = context.Request.Query["user_site_name_value"];
            model.UserSiteNameCssClass = context.Request.Query["user_site_name_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}