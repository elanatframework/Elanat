using CodeBehind;

namespace Elanat
{
    public partial class AdminSiteStyleController : CodeBehindController
    {
        public AdminSiteStyleModel model = new AdminSiteStyleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddSiteStyle"]))
            {
                btn_AddSiteStyle_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_AddSiteStyle_Click(HttpContext context)
        {
            model.SiteStylePathUploadValue = context.Request.Form.Files["upd_SiteStylePath"];
            model.UseSiteStylePathValue = context.Request.Form["cbx_UseSiteStylePath"] == "on";
            model.SiteStylePathTextValue = context.Request.Form["txt_SiteStylePath"];
            model.SiteStyleActiveValue = context.Request.Form["cbx_SiteStyleActive"] == "on";


            model.AddSiteStyle();

            View(model);
        }
    }
}