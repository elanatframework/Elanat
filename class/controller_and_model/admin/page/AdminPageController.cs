using CodeBehind;

namespace Elanat
{
    public partial class AdminPageController : CodeBehindController
    {
        public AdminPageModel model = new AdminPageModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddPage"]))
            {
                btn_AddPage_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddPage_Click(HttpContext context)
        {
            model.PagePathUploadValue = context.Request.Form.Files["upd_PagePath"];
            model.UsePagePathValue = context.Request.Form["cbx_UsePagePath"] == "on";
            model.PagePathTextValue = context.Request.Form["txt_PagePath"];
            model.PageGlobalNameValue = context.Request.Form["txt_PageGlobalName"];
            model.PageNameValue = context.Request.Form["txt_PageName"];
            model.PageTitleValue = context.Request.Form["txt_PageTitle"];
            model.PageCategoryValue = context.Request.Form["txt_PageCategory"];
            model.PageQueryStringValue = context.Request.Form["txt_PageQueryString"];
            model.PageCacheDurationValue = context.Request.Form["txt_PageCacheDuration"];
            model.PageCacheParametersValue = context.Request.Form["txt_PageCacheParameters"];
            model.PageRevisitAfternMetaValue = context.Request.Form["txt_PageRevisitAfternMeta"];
            model.PageStaticHeadValue = context.Request.Form["txt_PageStaticHead"];
            model.PageLoadTagValue = context.Request.Form["txt_PageLoadTag"];
            model.PageDescriptionMetaValue = context.Request.Form["txt_PageDescriptionMeta"];
            model.PageRightsMetaValue = context.Request.Form["txt_PageRightsMeta"];
            model.PageKeywordsMetaValue = context.Request.Form["txt_PageKeywordsMeta"];
            model.PageClassificationMetaValue = context.Request.Form["txt_PageClassificationMeta"];
            model.PageCopyrightMetaValue = context.Request.Form["txt_PageCopyrightMeta"];
            model.PageRobotsMetaValue = context.Request.Form["txt_PageRobotsMeta"];
            model.PageLoadTypeOptionListSelectedValue = context.Request.Form["ddlst_PageLoadType"];
            model.PageStyleOptionListSelectedValue = context.Request.Form["ddlst_PageStyle"];
            model.PageTemplateOptionListSelectedValue = context.Request.Form["ddlst_PageTemplate"];
            model.PriorityForPageValue = context.Request.Form["cbx_PriorityForPage"] == "on";
            model.PagePublicSiteValue = context.Request.Form["PagePublicSite"] == "on";
            model.PageActiveValue = context.Request.Form["cbx_PageActive"] == "on";
            model.PageUseLanguageValue = context.Request.Form["cbx_PageUseLanguage"] == "on";
            model.PageUsePluginValue = context.Request.Form["cbx_PageUsePage"] == "on";
            model.PageUseModuleValue = context.Request.Form["cbx_PageUseModule"] == "on";
            model.PageUseReplacePartValue = context.Request.Form["cbx_PageUseReplacePart"] == "on";
            model.PageUseFetchValue = context.Request.Form["cbx_PageUseFetch"] == "on";
            model.PageUseItemValue = context.Request.Form["cbx_PageUseItem"] == "on";
            model.PageUseElanatValue = context.Request.Form["cbx_PageUseElanat"] == "on";
            model.PageShowLinkInSiteValue = context.Request.Form["cbx_PageShowLinkInSite"] == "on";
            model.PageLoadAloneValue = context.Request.Form["cbx_PageLoadAlone"] == "on";
            model.PageUseHtmlValue = context.Request.Form["cbx_PageUseHtml"] == "on";
            model.PageUseLanguageMetaValue = context.Request.Form["cbx_PageUseLanguageMeta"] == "on";
            model.PageUseApplicationNameMetaValue = context.Request.Form["cbx_PageUseApplicationNameMeta"] == "on";
            model.PageUseGeneratorMetaValue = context.Request.Form["cbx_PageUseGeneratorMeta"] == "on";
            model.PageUseAuthorMetaValue = context.Request.Form["cbx_PageUseAuthorMeta"] == "on";
            model.PageUseJavascriptInactiveRefreshMetaValue = context.Request.Form["cbx_PageUseJavascriptInactiveRefreshMeta"] == "on";
            model.PageUseRevisitAfterMetaValue = context.Request.Form["cbx_PageUseRevisitAfterMeta"] == "on";
            model.PageUseStaticHeadValue = context.Request.Form["cbx_PageUseStaticHead"] == "on";
            model.PageUseLoadTagValue = context.Request.Form["cbx_PageUseLoadTag"] == "on";
            model.PageUseDescriptionMetaValue = context.Request.Form["cbx_PageUseDescriptionMeta"] == "on";
            model.PageUseRightsMetaValue = context.Request.Form["cbx_PageUseRightsMeta"] == "on";
            model.PageUseKeywordsMetaValue = context.Request.Form["cbx_PageUseKeywordsMeta"] == "on";
            model.PageUseClassificationMetaValue = context.Request.Form["cbx_PageUseClassificationMeta"] == "on";
            model.PageUseCopyrightMetaValue = context.Request.Form["cbx_PageUseCopyrightMeta"] == "on";
            model.PageUseRobotsMetaValue = context.Request.Form["cbx_PageUseRobotsMeta"] == "on";
            model.PagePublicAccessShowValue = context.Request.Form["cbx_PagePublicAccessShow"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PageSite$"))
                {
                    ListItem PageSite = new ListItem();

                    PageSite.Value = context.Request.Form[name];
                    PageSite.Selected = true;

                    model.PageSiteListItem.Add(PageSite);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PageAccessShow$"))
                {
                    ListItem PageAccessShow = new ListItem();

                    PageAccessShow.Value = context.Request.Form[name];
                    PageAccessShow.Selected = true;

                    model.PageAccessShowListItem.Add(PageAccessShow);
                }


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


            model.AddPage();

            View(model);
        }
    }
}