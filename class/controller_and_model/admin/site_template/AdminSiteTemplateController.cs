using CodeBehind;

namespace Elanat
{
    public partial class AdminSiteTemplateController : CodeBehindController
    {
        public AdminSiteTemplateModel model = new AdminSiteTemplateModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddSiteTemplate"]))
            {
                btn_AddSiteTemplate_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_AddSiteTemplate_Click(HttpContext context)
        {
            model.SiteTemplatePathUploadValue = context.Request.Form.Files["upd_SiteTemplatePath"];
            model.UseSiteTemplatePathValue = context.Request.Form["cbx_UseSiteTemplatePath"] == "on";
            model.SiteTemplatePathTextValue = context.Request.Form["txt_SiteTemplatePath"];
            model.SiteTemplateActiveValue = context.Request.Form["cbx_SiteTemplateActive"] == "on";


            model.AddSiteTemplate();

            View(model);
        }
    }
}