using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class AdminProperties : System.Web.UI.Page
    {
        public AdminPropertiesModel model = new AdminPropertiesModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveProperties"]))
                btn_SaveProperties_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveView"]))
                btn_SaveView_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveInclude"]))
                btn_SaveInclude_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveProperties_Click(object sender, EventArgs e)
        {
            model.ReadMoreStatusOptionListSelectedValue = Request.Form["ddlst_ReadMoreStatus"];
            model.DefaultSiteOptionListSelectedValue = Request.Form["ddlst_DefaultSite"];
            model.DefaultPageOptionListSelectedValue = Request.Form["ddlst_DefaultPage"];
            model.DefaultSiteLanguageOptionListSelectedValue = Request.Form["ddlst_DefaultSiteLanguage"];
            model.DefaultAdminLanguageOptionListSelectedValue = Request.Form["ddlst_DefaultAdminLanguage"];
            model.DefaultSiteStyleOptionListSelectedValue = Request.Form["ddlst_DefaultSiteStyle"];
            model.DefaultSiteTemplateOptionListSelectedValue = Request.Form["ddlst_DefaultSiteTemplate"];
            model.DefaultAdminStyleOptionListSelectedValue = Request.Form["ddlst_DefaultAdminStyle"];
            model.DefaultAdminTemplateOptionListSelectedValue = Request.Form["ddlst_DefaultAdminTemplate"];
            model.DefaultSystemOptionListSelectedValue = Request.Form["ddlst_DefaultSystem"];
            model.DefaultComponentOptionListSelectedValue = Request.Form["ddlst_DefaultComponent"];
            model.ContentPageNumberLocationOptionListSelectedValue = Request.Form["ddlst_ContentPageNumberLocation"];
            model.CommentInAddCommentBoxLocationOptionListSelectedValue = Request.Form["ddlst_CommentInAddCommentBoxLocation"];
            model.ContentInMainPageValue = Request.Form["txt_ContentInMainPage"];
            model.ContentPerPageValue = Request.Form["txt_ContentPerPage"];
            model.CommentInContentValue = Request.Form["txt_CommentInContent"];
            model.CommentReplyInCommentValue = Request.Form["txt_CommentReplyInComment"];
            model.RowInMainTableValue = Request.Form["txt_RowInMainTable"];
            model.RowPerTableValue = Request.Form["txt_RowPerTable"];
            model.ContentTextCharacterLengthValue = Request.Form["txt_ContentTextCharacterLength"];
            model.SitePathValue = Request.Form["txt_SitePath"];
            model.NullLanguageSuffixValue = Request.Form["txt_NullLanguageSuffix"];
            model.CornHourDurationValue = Request.Form["txt_CornHourDuration"];
            model.UseSiteAutoResizeValue = Request.Form["cbx_UseSiteAutoResize"] == "on";
            model.UseReadMoreValue = Request.Form["cbx_UseReadMore"] == "on";
            model.ShowAllSubCategoryWhenSelectFatherCategoryValue = Request.Form["cbx_ShowAllSubCategoryWhenSelectFatherCategory"] == "on";
            model.ShowUseCookieMessageAlertValue = Request.Form["cbx_ShowUseCookieMessageAlert"] == "on";
            model.UseViewStyleValue = Request.Form["cbx_UseViewStyle"] == "on";
            model.CreateExternalLinkForSiteViewStyleValue = Request.Form["cbx_CreateExternalLinkForSiteViewStyle"] == "on";
            model.CreateExternalLinkForAdminViewStyleValue = Request.Form["cbx_CreateExternalLinkForAdminViewStyle"] == "on";
            model.CreateExternalLinkForUserViewStyleValue = Request.Form["cbx_CreateExternalLinkForUserViewStyle"] == "on";
            model.CreateExternalLinkForCurrentViewStyleValue = Request.Form["cbx_CreateExternalLinkForCurrentViewStyle"] == "on";
            model.UseSiteClientVariantValue = Request.Form["cbx_UseSiteClientVariant"] == "on";
            model.CreateExternalLinkForSiteClientVariantValue = Request.Form["cbx_CreateExternalLinkForSiteClientVariant"] == "on";
            model.UseAdminClientVariantValue = Request.Form["cbx_UseAdminClientVariant"] == "on";
            model.CreateExternalLinkForAdminClientVariantValue = Request.Form["cbx_CreateExternalLinkForAdminClientVariant"] == "on";
            model.UseSiteClientLanguageVariantValue = Request.Form["cbx_UseSiteClientLanguageVariant"] == "on";
            model.CreateExternalLinkForSiteClientLanguageVariantValue = Request.Form["cbx_CreateExternalLinkForSiteClientLanguageVariant"] == "on";
            model.UseAdminClientLanguageVariantValue = Request.Form["cbx_UseAdminClientLanguageVariant"] == "on";
            model.CreateExternalLinkForAdminClientLanguageVariantValue = Request.Form["cbx_CreateExternalLinkForAdminClientLanguageVariant"] == "on";
            model.ActiveContentPageNumberValue = Request.Form["cbx_ActiveContentPageNumber"] == "on";
            model.UseAjaxForContentPageNumberValue = Request.Form["cbx_UseAjaxForContentPageNumber"] == "on";
            model.ShowCommentInAddCommentBoxValue = Request.Form["cbx_ShowCommentInAddCommentBox"] == "on";
            model.ActiveServerRefreshValue = Request.Form["cbx_ActiveServerRefresh"] == "on";
            model.ActiveScheduledDelayValue = Request.Form["cbx_ActiveScheduledDelay"] == "on";
            model.ActiveScheduledLoadValue = Request.Form["cbx_ActiveScheduledLoad"] == "on";
            model.ActiveScheduledTimerValue = Request.Form["cbx_ActiveScheduledTimer"] == "on";
            model.ActiveScheduledTasksValue = Request.Form["cbx_ActiveScheduledTasks"] == "on";
            model.ActiveAddPluginVariantNoteValue = Request.Form["cbx_ActiveAddPluginVariantNote"] == "on";
            model.ActiveAddModuleVariantNoteValue = Request.Form["cbx_ActiveAddModuleVariantNote"] == "on";
            model.ActiveAddFetchVariantNoteValue = Request.Form["cbx_ActiveAddFetchVariantNote"] == "on";
            model.ActiveAddItemVariantNoteValue = Request.Form["cbx_ActiveAddItemVariantNote"] == "on";

            
            // Evaluate Field Check
            model.PropertiesEvaluateField(Request.Form);
            if (model.FindPropertiesEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.PropertiesEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.SaveProperties();
        }

        protected void btn_SaveView_Click(object sender, EventArgs e)
        {
            model.AddCommentLoadTypeInMainPageOptionListSelectedValue = Request.Form["ddlst_AddCommentLoadTypeInMainPage"];
            model.AddContentReplyLoadTypeInMainPageOptionListSelectedValue = Request.Form["ddlst_AddContentReplyLoadTypeInMainPage"];
            model.AddCommentLoadTypeInContentPageOptionListSelectedValue = Request.Form["ddlst_AddCommentLoadTypeInContentPage"];
            model.AddContentReplyLoadTypeInContentPageOptionListSelectedValue = Request.Form["ddlst_AddContentReplyLoadTypeInContentPage"];
            model.ShowSiteNameValue = Request.Form["cbx_ShowSiteName"] == "on";
            model.ShowSiteSlogonNameValue = Request.Form["cbx_ShowSiteSlogonName"] == "on";
            model.ShowContentKeywordsInContentInMainPageValue = Request.Form["cbx_ShowContentKeywordsInContentInMainPage"] == "on";
            model.ShowAttachmentInContentInMainPageValue = Request.Form["cbx_ShowAttachmentInContentInMainPage"] == "on";
            model.ShowCommentInContentInMainPageValue = Request.Form["cbx_ShowCommentInContentInMainPage"] == "on";
            model.ShowAddCommentInContentInMainPageValue = Request.Form["cbx_ShowAddCommentInContentInMainPage"] == "on";
            model.ShowAddContentReplyInContentInMainPageValue = Request.Form["cbx_ShowAddContentReplyInContentInMainPage"] == "on";
            model.ShowContentReplyInContentInMainPageValue = Request.Form["cbx_ShowContentReplyInContentInMainPage"] == "on";
            model.ShowAuthorNameInContentInMainPageValue = Request.Form["cbx_ShowAuthorNameInContentInMainPage"] == "on";
            model.ShowCategoryNameInContentInMainPageValue = Request.Form["cbx_ShowCategoryNameInContentInMainPage"] == "on";
            model.ShowTitleInContentInMainPageValue = Request.Form["cbx_ShowTitleInContentInMainPage"] == "on";
            model.ShowDateInContentInMainPageValue = Request.Form["cbx_ShowDateInContentInMainPage"] == "on";
            model.ShowTimeInContentInMainPageValue = Request.Form["cbx_ShowTimeInContentInMainPage"] == "on";
            model.ShowVisitInContentInMainPageValue = Request.Form["cbx_ShowVisitInContentInMainPage"] == "on";
            model.ShowContentKeywordsInContentInContentPageValue = Request.Form["cbx_ShowContentKeywordsInContentInContentPage"] == "on";
            model.ShowAttachmentInContentInContentPageValue = Request.Form["cbx_ShowAttachmentInContentInContentPage"] == "on";
            model.ShowCommentInContentInContentPageValue = Request.Form["cbx_ShowCommentInContentInContentPage"] == "on";
            model.ShowAddCommentInContentInContentPageValue = Request.Form["cbx_ShowAddCommentInContentInContentPage"] == "on";
            model.ShowAddContentReplyInContentInContentPageValue = Request.Form["cbx_ShowAddContentReplyInContentInContentPage"] == "on";
            model.ShowContentReplyInContentInContentPageValue = Request.Form["cbx_ShowContentReplyInContentInContentPage"] == "on";
            model.ShowAuthorNameInContentInContentPageValue = Request.Form["cbx_ShowAuthorNameInContentInContentPage"] == "on";
            model.ShowCategoryNameInContentInContentPageValue = Request.Form["cbx_ShowCategoryNameInContentInContentPage"] == "on";
            model.ShowTitleInContentInContentPageValue = Request.Form["cbx_ShowTitleInContentInContentPage"] == "on";
            model.ShowDateInContentInContentPageValue = Request.Form["cbx_ShowDateInContentInContentPage"] == "on";
            model.ShowTimeInContentInContentPageValue = Request.Form["cbx_ShowTimeInContentInContentPage"] == "on";
            model.ShowVisitInContentInContentPageValue = Request.Form["cbx_ShowVisitInContentInContentPage"] == "on";


            // Evaluate Field Check
            model.ViewEvaluateField(Request.Form);
            if (model.FindViewEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.ViewEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.SaveView();
        }

        protected void btn_SaveInclude_Click(object sender, EventArgs e)
        {
            model.IncludeBoxOptionListSelectedValue = Request.Form["ddlst_IncludeBox"];
            model.IncludeCaptchaOptionListSelectedValue = Request.Form["ddlst_IncludeCaptcha"];
            model.IncludeCalendarOptionListSelectedValue = Request.Form["ddlst_IncludeCalendar"];
            model.IncludeFileViewerOptionListSelectedValue = Request.Form["ddlst_IncludeFileViewer"];
            model.IncludeWysiwygOptionListSelectedValue = Request.Form["ddlst_IncludeWysiwyg"];


            // Evaluate Field Check
            model.IncludeEvaluateField(Request.Form);
            if (model.FindIncludeEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.IncludeEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.SaveInclude();
        }
    }
}