using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditView : System.Web.UI.Page
    {
        public ActionEditViewModel model = new ActionEditViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveView"]))
                btn_SaveView_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ViewId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["view_id"]))
                    return;

                if (!Request.QueryString["view_id"].ToString().IsNumber())
                    return;

                model.ViewIdValue = Request.QueryString["view_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveView_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ViewNameValue = Request.Form["txt_ViewName"];
            model.ViewQueryStringValue = Request.Form["txt_ViewQueryString"];
            model.ViewBackgroundColorValue = Request.Form["txt_ViewBackgroundColor"];
            model.ViewFontSizeValue = Request.Form["txt_ViewFontSize"];
            model.ViewCommonLightTextColorValue = Request.Form["txt_ViewCommonLightTextColor"];
            model.ViewCommonMiddleTextColorValue = Request.Form["txt_ViewCommonMiddleTextColor"];
            model.ViewCommonDarkTextColorValue = Request.Form["txt_ViewCommonDarkTextColor"];
            model.ViewNaturalLightTextColorValue = Request.Form["txt_ViewNaturalLightTextColor"];
            model.ViewNaturalMiddleTextColorValue = Request.Form["txt_ViewNaturalMiddleTextColor"];
            model.ViewNaturalDarkTextColorValue = Request.Form["txt_ViewNaturalDarkTextColor"];
            model.ViewCommonLightBackgroundColorValue = Request.Form["txt_ViewCommonLightBackgroundColor"];
            model.ViewCommonMiddleBackgroundColorValue = Request.Form["txt_ViewCommonMiddleBackgroundColor"];
            model.ViewCommonDarkBackgroundColorValue = Request.Form["txt_ViewCommonDarkBackgroundColor"];
            model.ViewNaturalLightBackgroundColorValue = Request.Form["txt_ViewNaturalLightBackgroundColor"];
            model.ViewNaturalMiddleBackgroundColorValue = Request.Form["txt_ViewNaturalMiddleBackgroundColor"];
            model.ViewNaturalDarkBackgroundColorValue = Request.Form["txt_ViewNaturalDarkBackgroundColor"];
            model.ViewStaticHeadValue = Request.Form["txt_ViewStaticHead"];
            model.ViewMatchTypeOptionListSelectedValue = Request.Form["ddlst_ViewMatchType"];
            model.ViewSiteStyleOptionListSelectedValue = Request.Form["ddlst_ViewSiteStyle"];
            model.ViewSiteTemplateOptionListSelectedValue = Request.Form["ddlst_ViewSiteTemplate"];
            model.ViewIncludeHeaderBarPartValue = Request.Form["cbx_ViewIncludeHeaderBarPart"] == "on";
            model.ViewShowHeaderBarLeftValue = Request.Form["cbx_ViewShowHeaderBarLeft"] == "on";
            model.ViewShowHeaderBarRightValue = Request.Form["cbx_ViewShowHeaderBarRight"] == "on";
            model.ViewShowHeaderBarBoxValue = Request.Form["cbx_ViewShowHeaderBarBox"] == "on";
            model.ViewFillHeaderBarLeftValue = Request.Form["cbx_ViewFillHeaderBarLeft"] == "on";
            model.ViewFillHeaderBarRightValue = Request.Form["cbx_ViewFillHeaderBarRight"] == "on";
            model.ViewFillHeaderBarBoxValue = Request.Form["cbx_ViewFillHeaderBarBox"] == "on";
            model.ViewIncludeHeaderPartValue = Request.Form["cbx_ViewIncludeHeaderPart"] == "on";
            model.ViewShowHeaderMenuValue = Request.Form["cbx_ViewShowHeaderMenu"] == "on";
            model.ViewShowHeader1Value = Request.Form["cbx_ViewShowHeader1"] == "on";
            model.ViewShowHeader2Value = Request.Form["cbx_ViewShowHeader2"] == "on";
            model.ViewFillHeaderMenuValue = Request.Form["cbx_ViewFillHeaderMenu"] == "on";
            model.ViewFillHeader1Value = Request.Form["cbx_ViewFillHeader1"] == "on";
            model.ViewFillHeader2Value = Request.Form["cbx_ViewFillHeader2"] == "on";
            model.ViewIncludeMenuPartValue = Request.Form["cbx_ViewIncludeMenuPart"] == "on";
            model.ViewShowMenuValue = Request.Form["cbx_ViewShowMenu"] == "on";
            model.ViewFillMenuValue = Request.Form["cbx_ViewFillMenu"] == "on";
            model.ViewIncludeMainPartValue = Request.Form["cbx_ViewIncludeMainPart"] == "on";
            model.ViewShowAfterHeaderValue = Request.Form["cbx_ViewShowAfterHeader"] == "on";
            model.ViewShowBeforeContentValue = Request.Form["cbx_ViewShowBeforeContent"] == "on";
            model.ViewShowAfterContentValue = Request.Form["cbx_ViewShowAfterContent"] == "on";
            model.ViewShowLeftMenuValue = Request.Form["cbx_ViewShowLeftMenu"] == "on";
            model.ViewShowRightMenuValue = Request.Form["cbx_ViewShowRightMenu"] == "on";
            model.ViewShowBeforeFooterValue = Request.Form["cbx_ViewShowBeforeFooter"] == "on";
            model.ViewFillAfterHeaderValue = Request.Form["cbx_ViewFillAfterHeader"] == "on";
            model.ViewFillBeforeContentValue = Request.Form["cbx_ViewFillBeforeContent"] == "on";
            model.ViewFillAfterContentValue = Request.Form["cbx_ViewFillAfterContent"] == "on";
            model.ViewFillLeftMenuValue = Request.Form["cbx_ViewFillLeftMenu"] == "on";
            model.ViewFillRightMenuValue = Request.Form["cbx_ViewFillRightMenu"] == "on";
            model.ViewFillBeforeFooterValue = Request.Form["cbx_ViewFillBeforeFooter"] == "on";
            model.ViewIncludeFooterPartValue = Request.Form["cbx_ViewIncludeFooterPart"] == "on";
            model.ViewShowFooterMenuValue = Request.Form["cbx_ViewShowFooterMenu"] == "on";
            model.ViewShowFooter1Value = Request.Form["cbx_ViewShowFooter1"] == "on";
            model.ViewShowFooter2Value = Request.Form["cbx_ViewShowFooter2"] == "on";
            model.ViewFillFooterMenuValue = Request.Form["cbx_ViewFillFooterMenu"] == "on";
            model.ViewFillFooter1Value = Request.Form["cbx_ViewFillFooter1"] == "on";
            model.ViewFillFooter2Value = Request.Form["cbx_ViewFillFooter2"] == "on";
            model.ViewIncludeFooterBarPartValue = Request.Form["cbx_ViewIncludeFooterBarPart"] == "on";
            model.ViewShowFooterBarLeftValue = Request.Form["cbx_ViewShowFooterBarLeft"] == "on";
            model.ViewShowFooterBarRightValue = Request.Form["cbx_ViewShowFooterBarRight"] == "on";
            model.ViewShowFooterBarBoxValue = Request.Form["cbx_ViewShowFooterBarBox"] == "on";
            model.ViewFillFooterBarLeftValue = Request.Form["cbx_ViewFillFooterBarLeft"] == "on";
            model.ViewFillFooterBarRightValue = Request.Form["cbx_ViewFillFooterBarRight"] == "on";
            model.ViewFillFooterBarBoxValue = Request.Form["cbx_ViewFillFooterBarBox"] == "on";
            model.ViewActiveValue = Request.Form["cbx_ViewActive"] == "on";
            model.ViewIdValue = Request.Form["hdn_ViewId"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            DataUse.View duv = new DataUse.View();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_view", "view_name", model.ViewNameValue, duv.GetViewName(model.ViewIdValue)))
            {
                model.ViewNameCssClass = model.ViewNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                return;
            }


            model.SaveView();

            model.SuccessView();
        }
    }
}