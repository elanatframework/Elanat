using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditPage : System.Web.UI.Page
    {
        public ActionEditPageModel model = new ActionEditPageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SavePage"]))
                btn_SavePage_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_PageId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
                    return;

                if (!Request.QueryString["page_id"].ToString().IsNumber())
                    return;

                model.PageIdValue = Request.QueryString["page_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SavePage_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.PagePathUploadValue = Request.Files["upd_PagePath"];
            model.UsePagePathValue = Request.Form["cbx_UsePagePath"] == "on";
            model.PagePathTextValue = Request.Form["txt_PagePath"];
            model.PageGlobalNameValue = Request.Form["txt_PageGlobalName"];
            model.PageNameValue = Request.Form["txt_PageName"];
            model.PageTitleValue = Request.Form["txt_PageTitle"];
            model.PageCategoryValue = Request.Form["txt_PageCategory"];
            model.PageQueryStringValue = Request.Form["txt_PageQueryString"];
            model.PageCacheDurationValue = Request.Form["txt_PageCacheDuration"];
            model.PageCacheParametersValue = Request.Form["txt_PageCacheParameters"];
            model.PageRevisitAfternMetaValue = Request.Form["txt_PageRevisitAfternMeta"];
            model.PageStaticHeadValue = Request.Form["txt_PageStaticHead"];
            model.PageLoadTagValue = Request.Form["txt_PageLoadTag"];
            model.PageDescriptionMetaValue = Request.Form["txt_PageDescriptionMeta"];
            model.PageRightsMetaValue = Request.Form["txt_PageRightsMeta"];
            model.PageKeywordsMetaValue = Request.Form["txt_PageKeywordsMeta"];
            model.PageClassificationMetaValue = Request.Form["txt_PageClassificationMeta"];
            model.PageCopyrightMetaValue = Request.Form["txt_PageCopyrightMeta"];
            model.PageRobotsMetaValue = Request.Form["txt_PageRobotsMeta"];
            model.PageLoadTypeOptionListSelectedValue = Request.Form["ddlst_PageLoadType"];
            model.PageStyleOptionListSelectedValue = Request.Form["ddlst_PageStyle"];
            model.PageTemplateOptionListSelectedValue = Request.Form["ddlst_PageTemplate"];
            model.PagePublicSiteValue = Request.Form["PagePublicSite"] == "on";
            model.PageActiveValue = Request.Form["cbx_PageActive"] == "on";
            model.PageUseLanguageValue = Request.Form["cbx_PageUseLanguage"] == "on";
            model.PageUsePluginValue = Request.Form["cbx_PageUsePage"] == "on";
            model.PageUseModuleValue = Request.Form["cbx_PageUseModule"] == "on";
            model.PageUseReplacePartValue = Request.Form["cbx_PageUseReplacePart"] == "on";
            model.PageUseFetchValue = Request.Form["cbx_PageUseFetch"] == "on";
            model.PageUseItemValue = Request.Form["cbx_PageUseItem"] == "on";
            model.PageUseElanatValue = Request.Form["cbx_PageUseElanat"] == "on";
            model.PageShowLinkInSiteValue = Request.Form["cbx_PageShowLinkInSite"] == "on";
            model.PageLoadAloneValue = Request.Form["cbx_PageLoadAlone"] == "on";
            model.PageUseHtmlValue = Request.Form["cbx_PageUseHtml"] == "on";
            model.PageUseLanguageMetaValue = Request.Form["cbx_PageUseLanguageMeta"] == "on";
            model.PageUseApplicationNameMetaValue = Request.Form["cbx_PageUseApplicationNameMeta"] == "on";
            model.PageUseGeneratorMetaValue = Request.Form["cbx_PageUseGeneratorMeta"] == "on";
            model.PageUseAuthorMetaValue = Request.Form["cbx_PageUseAuthorMeta"] == "on";
            model.PageUseJavascriptInactiveRefreshMetaValue = Request.Form["cbx_PageUseJavascriptInactiveRefreshMeta"] == "on";
            model.PageUseRevisitAfterMetaValue = Request.Form["cbx_PageUseRevisitAfterMeta"] == "on";
            model.PageUseStaticHeadValue = Request.Form["cbx_PageUseStaticHead"] == "on";
            model.PageUseLoadTagValue = Request.Form["cbx_PageUseLoadTag"] == "on";
            model.PageUseDescriptionMetaValue = Request.Form["cbx_PageUseDescriptionMeta"] == "on";
            model.PageUseRightsMetaValue = Request.Form["cbx_PageUseRightsMeta"] == "on";
            model.PageUseKeywordsMetaValue = Request.Form["cbx_PageUseKeywordsMeta"] == "on";
            model.PageUseClassificationMetaValue = Request.Form["cbx_PageUseClassificationMeta"] == "on";
            model.PageUseCopyrightMetaValue = Request.Form["cbx_PageUseCopyrightMeta"] == "on";
            model.PageUseRobotsMetaValue = Request.Form["cbx_PageUseRobotsMeta"] == "on";
            model.PagePublicAccessShowValue = Request.Form["cbx_PagePublicAccessShow"] == "on";
            model.PageIdValue = Request.Form["hdn_PAgeId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PageSite$"))
                {
                    ListItem PageSite = new ListItem();

                    PageSite.Value = Request.Form[name];
                    PageSite.Selected = true;

                    model.PageSiteListItem.Add(PageSite);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PageAccessShow$"))
                {
                    ListItem PageAccessShow = new ListItem();

                    PageAccessShow.Value = Request.Form[name];
                    PageAccessShow.Selected = true;

                    model.PageAccessShowListItem.Add(PageAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            DataUse.Page dup = new DataUse.Page();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_page", "page_name", model.PageNameValue, dup.GetPageName(model.PageIdValue)))
            {
                model.PageNameCssClass = model.PageNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnPageNameErrorView();

                return;
            }

            if (common.ExistValueToColumnCheck("el_page", "page_global_name", model.PageGlobalNameValue, dup.GetPageGlobalName(model.PageIdValue)))
            {
                model.PageGlobalNameCssClass = model.PageGlobalNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnPageGlobalNameErrorView();

                return;
            }


            model.SavePage();

            model.SuccessView();
        }
    }
}