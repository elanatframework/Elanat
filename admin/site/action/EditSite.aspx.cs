using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditSite : System.Web.UI.Page
    {
        public ActionEditSiteModel model = new ActionEditSiteModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveSite"]))
                btn_SaveSite_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_SiteId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["site_id"]))
                    return;

                if (!Request.QueryString["site_id"].ToString().IsNumber())
                    return;

                model.SiteIdValue = Request.QueryString["site_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveSite_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.SiteNameValue = Request.Form["txt_SiteName"];
            model.SiteGlobalNameValue = Request.Form["txt_SiteGlobalName"];
            model.SiteSloganNameValue = Request.Form["txt_SiteSloganName"];
            model.SiteTitleValue = Request.Form["txt_SiteTitle"];
            model.SiteDateFormatValue = Request.Form["txt_SiteDateFormat"];
            model.SiteTimeFormatValue = Request.Form["txt_SiteTimeFormat"];
            model.SiteAddressValue = Request.Form["txt_SiteAddress"];
            model.SitePhoneNumberValue = Request.Form["txt_SitePhoneNumber"];
            model.SiteEmailValue = Request.Form["txt_SiteEmail"];
            model.SiteActivitiesValue = Request.Form["txt_SiteActivities"];
            model.SiteOtherInfoValue = Request.Form["txt_SiteOtherInfo"];
            model.SiteStaticHeadValue = Request.Form["txt_SiteStaticHead"];
            model.SiteDescriptionMetaValue = Request.Form["txt_SiteDescriptionMeta"];
            model.SiteRightsMetaValue = Request.Form["txt_SiteRightsMeta"];
            model.SiteKeywordsMetaValue = Request.Form["txt_SiteKeywordsMeta"];
            model.SiteClassificationMetaValue = Request.Form["txt_SiteClassificationMeta"];
            model.SiteRevisitAfterMetaValue = Request.Form["txt_SiteRevisitAfterMeta"];
            model.SiteDateCreateValue = Request.Form["txt_SiteDateCreate"];
            model.SiteTimeCreateValue = Request.Form["txt_SiteTimeCreate"];
            model.SiteVisitValue = Request.Form["txt_SiteVisit"];
            model.SiteLanguageOptionListSelectedValue = Request.Form["ddlst_SiteLanguage"];
            model.SiteDefaultPageOptionListSelectedValue = Request.Form["ddlst_SiteDefaultPage"];
            model.SiteSiteStyleOptionListSelectedValue = Request.Form["ddlst_SiteSiteStyle"];
            model.SiteSiteTemplateOptionListSelectedValue = Request.Form["ddlst_SiteSiteTemplate"];
            model.SiteAdminStyleOptionListSelectedValue = Request.Form["ddlst_SiteAdminStyle"];
            model.SiteAdminTemplateOptionListSelectedValue = Request.Form["ddlst_SiteAdminTemplate"];
            model.SiteCalendarOptionListSelectedValue = Request.Form["ddlst_SiteCalendar"];
            model.SiteFirstDayOfWeekOptionListSelectedValue = Request.Form["ddlst_SiteFirstDayOfWeek"];
            model.SiteTimeZoneOptionListSelectedValue = Request.Form["ddlst_SiteTimeZone"];
            model.SiteActiveValue = Request.Form["cbx_SiteActive"] == "on";
            model.SiteShowLinkInSiteValue = Request.Form["cbx_SiteShowLinkInSite"] == "on";
            model.SiteUseDescriptionMetaValue = Request.Form["cbx_SiteUseDescriptionMeta"] == "on";
            model.SiteUseRightsMetaValue = Request.Form["cbx_SiteUseRightsMeta"] == "on";
            model.SiteUseKeywordsMetaValue = Request.Form["cbx_SiteUseKeywordsMeta"] == "on";
            model.SiteUseClassificationMetaValue = Request.Form["cbx_SiteUseClassificationMeta"] == "on";
            model.SiteUseRevisitAfterMetaValue = Request.Form["cbx_SiteUseRevisitAfterMeta"] == "on";
            model.SitePublicAccessShowValue = Request.Form["cbx_SitePublicAccessShow"] == "on";
            model.SiteIdValue = Request.Form["hdn_SiteId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_SiteAccessShow$"))
                {
                    ListItem SiteAccessShow = new ListItem();

                    SiteAccessShow.Value = Request.Form[name];
                    SiteAccessShow.Selected = true;

                    model.SiteAccessShowListItem.Add(SiteAccessShow);
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


            DataUse.Site dus = new DataUse.Site();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_site", "site_name", model.SiteNameValue, dus.GetSiteName(model.SiteIdValue)))
            {
                model.SiteNameCssClass = model.SiteNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnSiteNameErrorView();

                return;
            }

            if (common.ExistValueToColumnCheck("el_site", "site_global_name", model.SiteGlobalNameValue, dus.GetSiteGlobalName(model.SiteIdValue)))
            {
                model.SiteGlobalNameCssClass = model.SiteGlobalNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnSiteGlobalNameErrorView();

                return;
            }


            model.SaveSite(sender, e);

            model.SuccessView();
        }
    }
}