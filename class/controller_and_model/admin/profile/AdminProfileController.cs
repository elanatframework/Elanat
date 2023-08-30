using CodeBehind;
namespace Elanat
{
    public partial class AdminProfileController : CodeBehindController
    {
        public AdminProfileModel model = new AdminProfileModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_DeleteFootPrint"]))
            {
                btn_DeleteFootPrint_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_DeleteFootPrint_Click(HttpContext context)
        {
            // Delete Access Check
            Access ac = new Access();
            if (!ac.DeleteOwnComponentAccess("foot_print"))
            {
                model.DeleteFootPrintAccessErrorView();

                View(model);

                return;
            }


            model.DeleteFootPrint();

            model.SuccessView();

            View(model);
        }
    }
}