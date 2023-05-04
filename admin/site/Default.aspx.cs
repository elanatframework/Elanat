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
    public partial class AdminSite : System.Web.UI.Page
    {
        public AdminSiteModel model = new AdminSiteModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddSite"]))
                btn_AddSite_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddSite_Click(object sender, EventArgs e)
        {
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


            model.AddSite();
        }
    }
}