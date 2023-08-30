using CodeBehind;

namespace Elanat
{
    public partial class AdminPropertiesController : CodeBehindController
    {
        public AdminPropertiesModel model = new AdminPropertiesModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveProperties"]))
            {
                btn_SaveProperties_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveView"]))
            {
                btn_SaveView_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveInclude"]))
            {
                btn_SaveInclude_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveProperties_Click(HttpContext context)
        {
            model.ReadMoreStatusOptionListSelectedValue = context.Request.Form["ddlst_ReadMoreStatus"];
            model.DefaultSiteOptionListSelectedValue = context.Request.Form["ddlst_DefaultSite"];
            model.DefaultPageOptionListSelectedValue = context.Request.Form["ddlst_DefaultPage"];
            model.DefaultSiteLanguageOptionListSelectedValue = context.Request.Form["ddlst_DefaultSiteLanguage"];
            model.DefaultAdminLanguageOptionListSelectedValue = context.Request.Form["ddlst_DefaultAdminLanguage"];
            model.DefaultSiteStyleOptionListSelectedValue = context.Request.Form["ddlst_DefaultSiteStyle"];
            model.DefaultSiteTemplateOptionListSelectedValue = context.Request.Form["ddlst_DefaultSiteTemplate"];
            model.DefaultAdminStyleOptionListSelectedValue = context.Request.Form["ddlst_DefaultAdminStyle"];
            model.DefaultAdminTemplateOptionListSelectedValue = context.Request.Form["ddlst_DefaultAdminTemplate"];
            model.DefaultSystemOptionListSelectedValue = context.Request.Form["ddlst_DefaultSystem"];
            model.DefaultComponentOptionListSelectedValue = context.Request.Form["ddlst_DefaultComponent"];
            model.ContentPageNumberLocationOptionListSelectedValue = context.Request.Form["ddlst_ContentPageNumberLocation"];
            model.CommentInAddCommentBoxLocationOptionListSelectedValue = context.Request.Form["ddlst_CommentInAddCommentBoxLocation"];
            model.ContentInMainPageValue = context.Request.Form["txt_ContentInMainPage"];
            model.ContentPerPageValue = context.Request.Form["txt_ContentPerPage"];
            model.CommentInContentValue = context.Request.Form["txt_CommentInContent"];
            model.CommentReplyInCommentValue = context.Request.Form["txt_CommentReplyInComment"];
            model.RowInMainTableValue = context.Request.Form["txt_RowInMainTable"];
            model.RowPerTableValue = context.Request.Form["txt_RowPerTable"];
            model.ContentTextCharacterLengthValue = context.Request.Form["txt_ContentTextCharacterLength"];
            model.SitePathValue = context.Request.Form["txt_SitePath"];
            model.NullLanguageSuffixValue = context.Request.Form["txt_NullLanguageSuffix"];
            model.CornHourDurationValue = context.Request.Form["txt_CornHourDuration"];
            model.UseSiteAutoResizeValue = context.Request.Form["cbx_UseSiteAutoResize"] == "on";
            model.UseReadMoreValue = context.Request.Form["cbx_UseReadMore"] == "on";
            model.ShowAllSubCategoryWhenSelectFatherCategoryValue = context.Request.Form["cbx_ShowAllSubCategoryWhenSelectFatherCategory"] == "on";
            model.ShowUseCookieMessageAlertValue = context.Request.Form["cbx_ShowUseCookieMessageAlert"] == "on";
            model.UseViewStyleValue = context.Request.Form["cbx_UseViewStyle"] == "on";
            model.CreateExternalLinkForSiteViewStyleValue = context.Request.Form["cbx_CreateExternalLinkForSiteViewStyle"] == "on";
            model.CreateExternalLinkForAdminViewStyleValue = context.Request.Form["cbx_CreateExternalLinkForAdminViewStyle"] == "on";
            model.CreateExternalLinkForUserViewStyleValue = context.Request.Form["cbx_CreateExternalLinkForUserViewStyle"] == "on";
            model.CreateExternalLinkForCurrentViewStyleValue = context.Request.Form["cbx_CreateExternalLinkForCurrentViewStyle"] == "on";
            model.UseSiteClientVariantValue = context.Request.Form["cbx_UseSiteClientVariant"] == "on";
            model.CreateExternalLinkForSiteClientVariantValue = context.Request.Form["cbx_CreateExternalLinkForSiteClientVariant"] == "on";
            model.UseAdminClientVariantValue = context.Request.Form["cbx_UseAdminClientVariant"] == "on";
            model.CreateExternalLinkForAdminClientVariantValue = context.Request.Form["cbx_CreateExternalLinkForAdminClientVariant"] == "on";
            model.UseSiteClientLanguageVariantValue = context.Request.Form["cbx_UseSiteClientLanguageVariant"] == "on";
            model.CreateExternalLinkForSiteClientLanguageVariantValue = context.Request.Form["cbx_CreateExternalLinkForSiteClientLanguageVariant"] == "on";
            model.UseAdminClientLanguageVariantValue = context.Request.Form["cbx_UseAdminClientLanguageVariant"] == "on";
            model.CreateExternalLinkForAdminClientLanguageVariantValue = context.Request.Form["cbx_CreateExternalLinkForAdminClientLanguageVariant"] == "on";
            model.ActiveContentPageNumberValue = context.Request.Form["cbx_ActiveContentPageNumber"] == "on";
            model.UseAjaxForContentPageNumberValue = context.Request.Form["cbx_UseAjaxForContentPageNumber"] == "on";
            model.ShowCommentInAddCommentBoxValue = context.Request.Form["cbx_ShowCommentInAddCommentBox"] == "on";
            model.ActiveServerRefreshValue = context.Request.Form["cbx_ActiveServerRefresh"] == "on";
            model.ActiveScheduledDelayValue = context.Request.Form["cbx_ActiveScheduledDelay"] == "on";
            model.ActiveScheduledLoadValue = context.Request.Form["cbx_ActiveScheduledLoad"] == "on";
            model.ActiveScheduledTimerValue = context.Request.Form["cbx_ActiveScheduledTimer"] == "on";
            model.ActiveScheduledTasksValue = context.Request.Form["cbx_ActiveScheduledTasks"] == "on";
            model.ActiveAddPluginVariantNoteValue = context.Request.Form["cbx_ActiveAddPluginVariantNote"] == "on";
            model.ActiveAddModuleVariantNoteValue = context.Request.Form["cbx_ActiveAddModuleVariantNote"] == "on";
            model.ActiveAddFetchVariantNoteValue = context.Request.Form["cbx_ActiveAddFetchVariantNote"] == "on";
            model.ActiveAddItemVariantNoteValue = context.Request.Form["cbx_ActiveAddItemVariantNote"] == "on";

            
            // Evaluate Field Check
            model.PropertiesEvaluateField(context.Request.Form);
            if (model.FindPropertiesEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.PropertiesEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.SaveProperties();

            View(model);
        }

        protected void btn_SaveView_Click(HttpContext context)
        {
            model.AddCommentLoadTypeInMainPageOptionListSelectedValue = context.Request.Form["ddlst_AddCommentLoadTypeInMainPage"];
            model.AddContentReplyLoadTypeInMainPageOptionListSelectedValue = context.Request.Form["ddlst_AddContentReplyLoadTypeInMainPage"];
            model.AddCommentLoadTypeInContentPageOptionListSelectedValue = context.Request.Form["ddlst_AddCommentLoadTypeInContentPage"];
            model.AddContentReplyLoadTypeInContentPageOptionListSelectedValue = context.Request.Form["ddlst_AddContentReplyLoadTypeInContentPage"];
            model.ShowSiteNameValue = context.Request.Form["cbx_ShowSiteName"] == "on";
            model.ShowSiteSlogonNameValue = context.Request.Form["cbx_ShowSiteSlogonName"] == "on";
            model.ShowContentKeywordsInContentInMainPageValue = context.Request.Form["cbx_ShowContentKeywordsInContentInMainPage"] == "on";
            model.ShowAttachmentInContentInMainPageValue = context.Request.Form["cbx_ShowAttachmentInContentInMainPage"] == "on";
            model.ShowCommentInContentInMainPageValue = context.Request.Form["cbx_ShowCommentInContentInMainPage"] == "on";
            model.ShowAddCommentInContentInMainPageValue = context.Request.Form["cbx_ShowAddCommentInContentInMainPage"] == "on";
            model.ShowAddContentReplyInContentInMainPageValue = context.Request.Form["cbx_ShowAddContentReplyInContentInMainPage"] == "on";
            model.ShowContentReplyInContentInMainPageValue = context.Request.Form["cbx_ShowContentReplyInContentInMainPage"] == "on";
            model.ShowAuthorNameInContentInMainPageValue = context.Request.Form["cbx_ShowAuthorNameInContentInMainPage"] == "on";
            model.ShowCategoryNameInContentInMainPageValue = context.Request.Form["cbx_ShowCategoryNameInContentInMainPage"] == "on";
            model.ShowTitleInContentInMainPageValue = context.Request.Form["cbx_ShowTitleInContentInMainPage"] == "on";
            model.ShowDateInContentInMainPageValue = context.Request.Form["cbx_ShowDateInContentInMainPage"] == "on";
            model.ShowTimeInContentInMainPageValue = context.Request.Form["cbx_ShowTimeInContentInMainPage"] == "on";
            model.ShowVisitInContentInMainPageValue = context.Request.Form["cbx_ShowVisitInContentInMainPage"] == "on";
            model.ShowContentKeywordsInContentInContentPageValue = context.Request.Form["cbx_ShowContentKeywordsInContentInContentPage"] == "on";
            model.ShowAttachmentInContentInContentPageValue = context.Request.Form["cbx_ShowAttachmentInContentInContentPage"] == "on";
            model.ShowCommentInContentInContentPageValue = context.Request.Form["cbx_ShowCommentInContentInContentPage"] == "on";
            model.ShowAddCommentInContentInContentPageValue = context.Request.Form["cbx_ShowAddCommentInContentInContentPage"] == "on";
            model.ShowAddContentReplyInContentInContentPageValue = context.Request.Form["cbx_ShowAddContentReplyInContentInContentPage"] == "on";
            model.ShowContentReplyInContentInContentPageValue = context.Request.Form["cbx_ShowContentReplyInContentInContentPage"] == "on";
            model.ShowAuthorNameInContentInContentPageValue = context.Request.Form["cbx_ShowAuthorNameInContentInContentPage"] == "on";
            model.ShowCategoryNameInContentInContentPageValue = context.Request.Form["cbx_ShowCategoryNameInContentInContentPage"] == "on";
            model.ShowTitleInContentInContentPageValue = context.Request.Form["cbx_ShowTitleInContentInContentPage"] == "on";
            model.ShowDateInContentInContentPageValue = context.Request.Form["cbx_ShowDateInContentInContentPage"] == "on";
            model.ShowTimeInContentInContentPageValue = context.Request.Form["cbx_ShowTimeInContentInContentPage"] == "on";
            model.ShowVisitInContentInContentPageValue = context.Request.Form["cbx_ShowVisitInContentInContentPage"] == "on";


            // Evaluate Field Check
            model.ViewEvaluateField(context.Request.Form);
            if (model.FindViewEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.ViewEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.SaveView();

            View(model);
        }

        protected void btn_SaveInclude_Click(HttpContext context)
        {
            model.IncludeBoxOptionListSelectedValue = context.Request.Form["ddlst_IncludeBox"];
            model.IncludeCaptchaOptionListSelectedValue = context.Request.Form["ddlst_IncludeCaptcha"];
            model.IncludeCalendarOptionListSelectedValue = context.Request.Form["ddlst_IncludeCalendar"];
            model.IncludeFileViewerOptionListSelectedValue = context.Request.Form["ddlst_IncludeFileViewer"];
            model.IncludeWysiwygOptionListSelectedValue = context.Request.Form["ddlst_IncludeWysiwyg"];


            // Evaluate Field Check
            model.IncludeEvaluateField(context.Request.Form);
            if (model.FindIncludeEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.IncludeEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.SaveInclude();

            View(model);
        }
    }
}