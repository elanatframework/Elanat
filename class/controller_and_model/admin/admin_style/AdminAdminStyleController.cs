using CodeBehind;

namespace Elanat
{
    public partial class AdminAdminStyleController : CodeBehindController
    {
        public AdminAdminStyleModel model = new AdminAdminStyleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddAdminStyle"]))
            {
                btn_AddAdminStyle_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_AddAdminStyle_Click(HttpContext context)
        {
            model.AdminStylePathUploadValue = context.Request.Form.Files["upd_AdminStylePath"];
            model.UseAdminStylePathValue = context.Request.Form["cbx_UseAdminStylePath"] == "on";
            model.AdminStylePathTextValue = context.Request.Form["txt_AdminStylePath"];
            model.AdminStyleActiveValue = context.Request.Form["cbx_AdminStyleActive"] == "on";


            model.AddAdminStyle();

            View(model);
        }
    }
}