using CodeBehind;

namespace Elanat
{
    public partial class SiteSearchController : CodeBehindController
    {
        public SiteSearchModel model = new SiteSearchModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_Search"]))
            {
                btn_Search_Click(context);
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Query["search"]))
                SetQuerySearch(context);


            model.SetValue();

            View(model);
        }

        protected void btn_Search_Click(HttpContext context)
        {
            if(!string.IsNullOrEmpty(context.Request.Form["ddlst_Category"]))
                model.CategoryOptionListSelectedValue = context.Request.Form["ddlst_Category"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_TitleOrText"]))
                model.TitleOrTextOptionListSelectedValue = context.Request.Form["ddlst_TitleOrText"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_SearchFrom"]))
                model.SearchFromValue = context.Request.Form["txt_SearchFrom"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_SearchUntil"]))
                model.SearchUntilValue = context.Request.Form["txt_SearchUntil"];

            model.SearchValue = context.Request.Form["txt_Search"];

            model.Search(context);

            View(model);
        }

        private void SetQuerySearch(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["category"]))
                model.CategoryOptionListSelectedValue = context.Request.Query["category"].ToString();

            if (!string.IsNullOrEmpty(context.Request.Query["type"]))
                model.TitleOrTextOptionListSelectedValue = context.Request.Query["type"].ToString();

            if (!string.IsNullOrEmpty(context.Request.Query["from_date"]))
                model.SearchFromValue = context.Request.Query["from_date"].ToString();

            if (!string.IsNullOrEmpty(context.Request.Query["until_date"]))
                model.SearchUntilValue = context.Request.Query["until_date"].ToString();

            model.SearchValue = context.Request.Query["search"].ToString();

            model.Search(context, true);
        }
    }
}