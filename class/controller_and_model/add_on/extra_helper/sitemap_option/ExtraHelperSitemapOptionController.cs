using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperSitemapOptionController : CodeBehindController
    {
        public ExtraHelperSitemapOptionModel model = new ExtraHelperSitemapOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveSitemapOption"]))
            {
                btn_SaveSitemapOption_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveSitemapOption_Click(HttpContext context)
        {
            model.ActiveLanguageValue = context.Request.Form["cbx_ActiveLanguage"] == "on";
            model.ActiveSiteValue = context.Request.Form["cbx_ActiveSite"] == "on";
            model.ActivePageValue = context.Request.Form["cbx_ActivePage"] == "on";
            model.ActiveContentTypeValue = context.Request.Form["cbx_ActiveContentType"] == "on";
            model.ActiveCategoryValue = context.Request.Form["cbx_ActiveCategory"] == "on";
            model.ActiveLinkValue = context.Request.Form["cbx_ActiveLink"] == "on";

            model.SaveSitemapOption();

            View(model);
        }
    }
}