using CodeBehind;

namespace Elanat
{
    public partial class AdminAboutController : CodeBehindController
    {
        public AdminAboutModel model = new AdminAboutModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_CheckNewUpdate"]))
            {
                btn_CheckNewUpdate_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_Update"]))
            {
                btn_Update_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_CheckNewUpdate_Click()
        {
            model.CheckNewUpdate();

            View(model);
        }

        protected void btn_Update_Click(HttpContext context)
        {
            model.BreakSupportCheckValue = context.Request.Form["cbx_BreakSupportCheck"] == "on";

            model.Update(context);

            View(model);
        }
    }
}