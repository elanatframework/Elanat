using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class AdminPage : System.Web.UI.Page
    {
        public AdminPageModel model = new AdminPageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddPage"]))
                btn_AddPage_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddPage_Click(object sender, EventArgs e)
        {
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
            model.PriorityForPageValue = Request.Form["cbx_PriorityForPage"] == "on";
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


            model.AddPage();
        }
    }
}