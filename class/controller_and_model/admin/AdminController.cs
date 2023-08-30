using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminController : CodeBehindController
    {
        public AdminModel model = new AdminModel();
        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            View(model);
        }
    }
}