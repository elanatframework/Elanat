using CodeBehind;

namespace Elanat
{
    public partial class SiteContactTypeController : CodeBehindController
    {
        public SiteContactTypeModel model = new SiteContactTypeModel();

        public void PageLoad(HttpContext context)
        {
            model.TypeOptionListSelectedValue = context.Request.Query["type_value"];
            model.TypeCssClass = context.Request.Query["type_css_class"];

            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}