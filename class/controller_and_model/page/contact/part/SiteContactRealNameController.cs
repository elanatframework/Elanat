using CodeBehind;

namespace Elanat
{
    public partial class SiteContactRealNameController : CodeBehindController
    {
        public SiteContactRealNameModel model = new SiteContactRealNameModel();

        public void PageLoad(HttpContext context)
        {
            model.RealNameValue = context.Request.Query["real_name_value"];
            model.RealNameCssClass = context.Request.Query["real_name_css_class"];
            model.RealNameAttribute = context.Request.Query["real_name_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}