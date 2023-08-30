using CodeBehind;

namespace Elanat
{
    public partial class ActionModuleMenuQueryStringController : CodeBehindController
    {
        public ActionModuleMenuQueryStringModel model = new ActionModuleMenuQueryStringModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["menu_value"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["menu_name"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            string MenuValue = context.Request.Query["menu_value"];
            string MenuName = context.Request.Query["menu_name"];


            Write(model.ViewModuleMenuQueryString(MenuName, MenuValue));

            View(model);
        }
    }
}