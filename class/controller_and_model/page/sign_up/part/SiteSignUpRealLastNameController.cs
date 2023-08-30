using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpRealLastNameController : CodeBehindController
    {
        public SiteSignUpRealLastNameModel model = new SiteSignUpRealLastNameModel();

        public void PageLoad(HttpContext context)
        {
            model.RealLastNameValue = context.Request.Query["real_last_name_value"];
            model.RealLastNameCssClass = context.Request.Query["real_last_name_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}