using CodeBehind;

namespace Elanat
{
    public partial class AdminSiteController : CodeBehindController
    {
        public AdminSiteModel model = new AdminSiteModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddSite"]))
            {
                btn_AddSite_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddSite_Click(HttpContext context)
        {
            model.SiteNameValue = context.Request.Form["txt_SiteName"];
            model.SiteGlobalNameValue = context.Request.Form["txt_SiteGlobalName"];
            model.SiteSloganNameValue = context.Request.Form["txt_SiteSloganName"];
            model.SiteTitleValue = context.Request.Form["txt_SiteTitle"];
            model.SiteDateFormatValue = context.Request.Form["txt_SiteDateFormat"];
            model.SiteTimeFormatValue = context.Request.Form["txt_SiteTimeFormat"];
            model.SiteAddressValue = context.Request.Form["txt_SiteAddress"];
            model.SitePhoneNumberValue = context.Request.Form["txt_SitePhoneNumber"];
            model.SiteEmailValue = context.Request.Form["txt_SiteEmail"];
            model.SiteActivitiesValue = context.Request.Form["txt_SiteActivities"];
            model.SiteOtherInfoValue = context.Request.Form["txt_SiteOtherInfo"];
            model.SiteStaticHeadValue = context.Request.Form["txt_SiteStaticHead"];
            model.SiteDescriptionMetaValue = context.Request.Form["txt_SiteDescriptionMeta"];
            model.SiteRightsMetaValue = context.Request.Form["txt_SiteRightsMeta"];
            model.SiteKeywordsMetaValue = context.Request.Form["txt_SiteKeywordsMeta"];
            model.SiteClassificationMetaValue = context.Request.Form["txt_SiteClassificationMeta"];
            model.SiteRevisitAfterMetaValue = context.Request.Form["txt_SiteRevisitAfterMeta"];
            model.SiteLanguageOptionListSelectedValue = context.Request.Form["ddlst_SiteLanguage"];
            model.SiteDefaultPageOptionListSelectedValue = context.Request.Form["ddlst_SiteDefaultPage"];
            model.SiteSiteStyleOptionListSelectedValue = context.Request.Form["ddlst_SiteSiteStyle"];
            model.SiteSiteTemplateOptionListSelectedValue = context.Request.Form["ddlst_SiteSiteTemplate"];
            model.SiteAdminStyleOptionListSelectedValue = context.Request.Form["ddlst_SiteAdminStyle"];
            model.SiteAdminTemplateOptionListSelectedValue = context.Request.Form["ddlst_SiteAdminTemplate"];
            model.SiteCalendarOptionListSelectedValue = context.Request.Form["ddlst_SiteCalendar"];
            model.SiteFirstDayOfWeekOptionListSelectedValue = context.Request.Form["ddlst_SiteFirstDayOfWeek"];
            model.SiteTimeZoneOptionListSelectedValue = context.Request.Form["ddlst_SiteTimeZone"];
            model.SiteActiveValue = context.Request.Form["cbx_SiteActive"] == "on";
            model.SiteShowLinkInSiteValue = context.Request.Form["cbx_SiteShowLinkInSite"] == "on";
            model.SiteUseDescriptionMetaValue = context.Request.Form["cbx_SiteUseDescriptionMeta"] == "on";
            model.SiteUseRightsMetaValue = context.Request.Form["cbx_SiteUseRightsMeta"] == "on";
            model.SiteUseKeywordsMetaValue = context.Request.Form["cbx_SiteUseKeywordsMeta"] == "on";
            model.SiteUseClassificationMetaValue = context.Request.Form["cbx_SiteUseClassificationMeta"] == "on";
            model.SiteUseRevisitAfterMetaValue = context.Request.Form["cbx_SiteUseRevisitAfterMeta"] == "on";
            model.SitePublicAccessShowValue = context.Request.Form["cbx_SitePublicAccessShow"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_SiteAccessShow$"))
                {
                    ListItem SiteAccessShow = new ListItem();

                    SiteAccessShow.Value = context.Request.Form[name];
                    SiteAccessShow.Selected = true;

                    model.SiteAccessShowListItem.Add(SiteAccessShow);
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


            model.AddSite();

            View(model);
        }
    }
}