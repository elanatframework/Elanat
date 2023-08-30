using CodeBehind;

namespace Elanat
{
    public partial class ActionEditViewController : CodeBehindController
    {
        public ActionEditViewModel model = new ActionEditViewModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveView"]))
            {
                btn_SaveView_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ViewId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["view_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["view_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ViewIdValue = context.Request.Query["view_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveView_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.ViewNameValue = context.Request.Form["txt_ViewName"];
            model.ViewQueryStringValue = context.Request.Form["txt_ViewQueryString"];
            model.ViewBackgroundColorValue = context.Request.Form["txt_ViewBackgroundColor"];
            model.ViewFontSizeValue = context.Request.Form["txt_ViewFontSize"];
            model.ViewCommonLightTextColorValue = context.Request.Form["txt_ViewCommonLightTextColor"];
            model.ViewCommonMiddleTextColorValue = context.Request.Form["txt_ViewCommonMiddleTextColor"];
            model.ViewCommonDarkTextColorValue = context.Request.Form["txt_ViewCommonDarkTextColor"];
            model.ViewNaturalLightTextColorValue = context.Request.Form["txt_ViewNaturalLightTextColor"];
            model.ViewNaturalMiddleTextColorValue = context.Request.Form["txt_ViewNaturalMiddleTextColor"];
            model.ViewNaturalDarkTextColorValue = context.Request.Form["txt_ViewNaturalDarkTextColor"];
            model.ViewCommonLightBackgroundColorValue = context.Request.Form["txt_ViewCommonLightBackgroundColor"];
            model.ViewCommonMiddleBackgroundColorValue = context.Request.Form["txt_ViewCommonMiddleBackgroundColor"];
            model.ViewCommonDarkBackgroundColorValue = context.Request.Form["txt_ViewCommonDarkBackgroundColor"];
            model.ViewNaturalLightBackgroundColorValue = context.Request.Form["txt_ViewNaturalLightBackgroundColor"];
            model.ViewNaturalMiddleBackgroundColorValue = context.Request.Form["txt_ViewNaturalMiddleBackgroundColor"];
            model.ViewNaturalDarkBackgroundColorValue = context.Request.Form["txt_ViewNaturalDarkBackgroundColor"];
            model.ViewStaticHeadValue = context.Request.Form["txt_ViewStaticHead"];
            model.ViewMatchTypeOptionListSelectedValue = context.Request.Form["ddlst_ViewMatchType"];
            model.ViewSiteStyleOptionListSelectedValue = context.Request.Form["ddlst_ViewSiteStyle"];
            model.ViewSiteTemplateOptionListSelectedValue = context.Request.Form["ddlst_ViewSiteTemplate"];
            model.ViewIncludeHeaderBarPartValue = context.Request.Form["cbx_ViewIncludeHeaderBarPart"] == "on";
            model.ViewShowHeaderBarLeftValue = context.Request.Form["cbx_ViewShowHeaderBarLeft"] == "on";
            model.ViewShowHeaderBarRightValue = context.Request.Form["cbx_ViewShowHeaderBarRight"] == "on";
            model.ViewShowHeaderBarBoxValue = context.Request.Form["cbx_ViewShowHeaderBarBox"] == "on";
            model.ViewFillHeaderBarLeftValue = context.Request.Form["cbx_ViewFillHeaderBarLeft"] == "on";
            model.ViewFillHeaderBarRightValue = context.Request.Form["cbx_ViewFillHeaderBarRight"] == "on";
            model.ViewFillHeaderBarBoxValue = context.Request.Form["cbx_ViewFillHeaderBarBox"] == "on";
            model.ViewIncludeHeaderPartValue = context.Request.Form["cbx_ViewIncludeHeaderPart"] == "on";
            model.ViewShowHeaderMenuValue = context.Request.Form["cbx_ViewShowHeaderMenu"] == "on";
            model.ViewShowHeader1Value = context.Request.Form["cbx_ViewShowHeader1"] == "on";
            model.ViewShowHeader2Value = context.Request.Form["cbx_ViewShowHeader2"] == "on";
            model.ViewFillHeaderMenuValue = context.Request.Form["cbx_ViewFillHeaderMenu"] == "on";
            model.ViewFillHeader1Value = context.Request.Form["cbx_ViewFillHeader1"] == "on";
            model.ViewFillHeader2Value = context.Request.Form["cbx_ViewFillHeader2"] == "on";
            model.ViewIncludeMenuPartValue = context.Request.Form["cbx_ViewIncludeMenuPart"] == "on";
            model.ViewShowMenuValue = context.Request.Form["cbx_ViewShowMenu"] == "on";
            model.ViewFillMenuValue = context.Request.Form["cbx_ViewFillMenu"] == "on";
            model.ViewIncludeMainPartValue = context.Request.Form["cbx_ViewIncludeMainPart"] == "on";
            model.ViewShowAfterHeaderValue = context.Request.Form["cbx_ViewShowAfterHeader"] == "on";
            model.ViewShowBeforeContentValue = context.Request.Form["cbx_ViewShowBeforeContent"] == "on";
            model.ViewShowAfterContentValue = context.Request.Form["cbx_ViewShowAfterContent"] == "on";
            model.ViewShowLeftMenuValue = context.Request.Form["cbx_ViewShowLeftMenu"] == "on";
            model.ViewShowRightMenuValue = context.Request.Form["cbx_ViewShowRightMenu"] == "on";
            model.ViewShowBeforeFooterValue = context.Request.Form["cbx_ViewShowBeforeFooter"] == "on";
            model.ViewFillAfterHeaderValue = context.Request.Form["cbx_ViewFillAfterHeader"] == "on";
            model.ViewFillBeforeContentValue = context.Request.Form["cbx_ViewFillBeforeContent"] == "on";
            model.ViewFillAfterContentValue = context.Request.Form["cbx_ViewFillAfterContent"] == "on";
            model.ViewFillLeftMenuValue = context.Request.Form["cbx_ViewFillLeftMenu"] == "on";
            model.ViewFillRightMenuValue = context.Request.Form["cbx_ViewFillRightMenu"] == "on";
            model.ViewFillBeforeFooterValue = context.Request.Form["cbx_ViewFillBeforeFooter"] == "on";
            model.ViewIncludeFooterPartValue = context.Request.Form["cbx_ViewIncludeFooterPart"] == "on";
            model.ViewShowFooterMenuValue = context.Request.Form["cbx_ViewShowFooterMenu"] == "on";
            model.ViewShowFooter1Value = context.Request.Form["cbx_ViewShowFooter1"] == "on";
            model.ViewShowFooter2Value = context.Request.Form["cbx_ViewShowFooter2"] == "on";
            model.ViewFillFooterMenuValue = context.Request.Form["cbx_ViewFillFooterMenu"] == "on";
            model.ViewFillFooter1Value = context.Request.Form["cbx_ViewFillFooter1"] == "on";
            model.ViewFillFooter2Value = context.Request.Form["cbx_ViewFillFooter2"] == "on";
            model.ViewIncludeFooterBarPartValue = context.Request.Form["cbx_ViewIncludeFooterBarPart"] == "on";
            model.ViewShowFooterBarLeftValue = context.Request.Form["cbx_ViewShowFooterBarLeft"] == "on";
            model.ViewShowFooterBarRightValue = context.Request.Form["cbx_ViewShowFooterBarRight"] == "on";
            model.ViewShowFooterBarBoxValue = context.Request.Form["cbx_ViewShowFooterBarBox"] == "on";
            model.ViewFillFooterBarLeftValue = context.Request.Form["cbx_ViewFillFooterBarLeft"] == "on";
            model.ViewFillFooterBarRightValue = context.Request.Form["cbx_ViewFillFooterBarRight"] == "on";
            model.ViewFillFooterBarBoxValue = context.Request.Form["cbx_ViewFillFooterBarBox"] == "on";
            model.ViewActiveValue = context.Request.Form["cbx_ViewActive"] == "on";
            model.ViewIdValue = context.Request.Form["hdn_ViewId"];


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


            DataUse.View duv = new DataUse.View();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_view", "view_name", model.ViewNameValue, duv.GetViewName(model.ViewIdValue)))
            {
                model.ViewNameCssClass = model.ViewNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                View(model);

                return;
            }


            model.SaveView();

            model.SuccessView();

            View(model);
        }
    }
}