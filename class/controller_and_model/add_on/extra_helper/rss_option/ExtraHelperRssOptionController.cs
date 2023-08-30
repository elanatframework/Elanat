using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperRssOptionController : CodeBehindController
    {
        public ExtraHelperRssOptionModel model = new ExtraHelperRssOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveRssOption"]))
            {
                btn_SaveRssOption_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveRssOption_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.FeedCountValue = context.Request.Form["txt_FeedCount"];
            model.ContentTextLengthValue = context.Request.Form["txt_ContentTextLength"];
            model.RssCacheValue = context.Request.Form["txt_RssCache"];
            model.UseRemoveHtmlTagValue = context.Request.Form["cbx_UseRemoveHtmlTag"] == "on";
            model.ActiveAuthorFeedValue = context.Request.Form["cbx_ActiveAuthorFeed"] == "on";
            model.ActiveCategoryFeedValue = context.Request.Form["cbx_ActiveCategoryFeed"] == "on";
            model.ActiveContentTypeFeedValue = context.Request.Form["cbx_ActiveContentTypeFeed"] == "on";


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveRssOption();

            View(model);
        }
    }
}