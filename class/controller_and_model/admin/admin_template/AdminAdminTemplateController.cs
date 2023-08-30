using CodeBehind;

namespace Elanat
{
    public partial class AdminAdminTemplateController : CodeBehindController
    {
        public AdminAdminTemplateModel model = new AdminAdminTemplateModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddAdminTemplate"]))
            {
                btn_AddAdminTemplate_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_AddAdminTemplate_Click(HttpContext context)
        {
            model.AdminTemplatePathUploadValue = context.Request.Form.Files["upd_AdminTemplatePath"];
            model.UseAdminTemplatePathValue = context.Request.Form["cbx_UseAdminTemplatePath"] == "on";
            model.AdminTemplatePathTextValue = context.Request.Form["txt_AdminTemplatePath"];
            model.AdminTemplateActiveValue = context.Request.Form["cbx_AdminTemplateActive"] == "on";


            model.AddAdminTemplate();

            View(model);
        }
    }
}