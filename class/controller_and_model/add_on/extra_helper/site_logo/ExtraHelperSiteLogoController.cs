using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperSiteLogoController : CodeBehindController
    {
        public ExtraHelperSiteLogoModel model = new ExtraHelperSiteLogoModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.UseLogoPathValue = context.Request.Form["cbx_UseLogoPath"] == "on";
            model.LogoPathTextValue = context.Request.Form["txt_LogoPath"];
            model.LogoPathUploadValue = context.Request.Form.Files["upd_LogoPath"];
            model.SiteOptionListSelectedValue = context.Request.Form["ddlst_Site"];

            model.StartUpload();

            View(model);
        }
    }
}