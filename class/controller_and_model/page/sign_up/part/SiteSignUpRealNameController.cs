using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpRealNameController : CodeBehindController
    {
        public SiteSignUpRealNameModel model = new SiteSignUpRealNameModel();

        public void PageLoad(HttpContext context)
        {
            model.RealNameValue = context.Request.Query["real_name_value"];
            model.RealNameCssClass = context.Request.Query["real_name_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}