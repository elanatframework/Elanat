using CodeBehind;

namespace Elanat
{
    public partial class AdminRecycleBinController : CodeBehindController
    {
        public AdminRecycleBinModel model = new AdminRecycleBinModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}