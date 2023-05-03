﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class MemberChangeTemplateAndStyleModel
    {
        public string ChangeTemplateAndStyleLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UserSiteTemplateLanguage { get; set; }
        public string UserSiteStyleLanguage { get; set; }
        public string UserAdminTemplateLanguage { get; set; }
        public string UserAdminStyleLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public string SiteStyleOptionListValue { get; set; }
        public string SiteTemplateOptionListValue { get; set; }
        public string AdminStyleOptionListValue { get; set; }
        public string AdminTemplateOptionListValue { get; set; }
        public string SiteStyleOptionListSelectedValue { get; set; }
        public string SiteTemplateOptionListSelectedValue { get; set; }
        public string AdminStyleOptionListSelectedValue { get; set; }
        public string AdminTemplateOptionListSelectedValue { get; set; }

        public string UserSiteStyleAttribute { get; set; }
        public string UserSiteTemplateAttribute { get; set; }
        public string UserAdminStyleAttribute { get; set; }
        public string UserAdminTemplateAttribute { get; set; }

        public string UserSiteStyleCssClass { get; set; }
        public string UserSiteTemplateCssClass { get; set; }
        public string UserAdminStyleCssClass { get; set; }
        public string UserAdminTemplateCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_options/change_template_and_style/");
            MemberLanguage = aol.GetAddOnsLanguage("member");
            ChangeTemplateAndStyleLanguage = aol.GetAddOnsLanguage("change_template_and_style");
            UserSiteTemplateLanguage = aol.GetAddOnsLanguage("user_site_template");
            UserSiteStyleLanguage = aol.GetAddOnsLanguage("user_site_style");
            UserAdminTemplateLanguage = aol.GetAddOnsLanguage("user_admin_template");
            UserAdminStyleLanguage = aol.GetAddOnsLanguage("user_admin_style");


            // Set User Info
            if (IsFirstStart)
            {
                DataBaseSocket db = new DataBaseSocket();

                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                DataBaseDataReader dbdr = new DataBaseDataReader();
			    dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);

                if (dbdr.dr == null || !dbdr.dr.HasRows)
                {
                    db.Close();
                    return;
                }

                dbdr.dr.Read();

                // Set Current Value
                SiteStyleOptionListSelectedValue = dbdr.dr["site_style_id"].ToString();
                SiteTemplateOptionListSelectedValue = dbdr.dr["site_template_id"].ToString();
                AdminStyleOptionListSelectedValue = dbdr.dr["admin_style_id"].ToString();
                AdminTemplateOptionListSelectedValue = dbdr.dr["admin_template_id"].ToString();

                db.Close();
            }

            ListClass lc = new ListClass();

            // Set Site Style Item
            lc.FillSiteStyleListItem();
            SiteStyleOptionListValue += SiteStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteStyleOptionListValue += lc.SiteStyleListItem.HtmlInputToOptionTag(SiteStyleOptionListSelectedValue);

            // Set Site Template Item
            lc.FillSiteTemplateListItem();
            SiteTemplateOptionListValue += SiteTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteTemplateOptionListValue += lc.SiteTemplateListItem.HtmlInputToOptionTag(SiteTemplateOptionListSelectedValue);


            // Set Admin Style Item
            lc.FillAdminStyleListItem();
            AdminStyleOptionListValue += AdminStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminStyleOptionListValue += lc.AdminStyleListItem.HtmlInputToOptionTag(AdminStyleOptionListSelectedValue);


            // Set Admin Template Item
            lc.FillAdminTemplateListItem();
            AdminTemplateOptionListValue += AdminTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminTemplateOptionListValue += lc.AdminTemplateListItem.HtmlInputToOptionTag(AdminTemplateOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_UserSiteStyle", SiteStyleOptionListValue);
            InputRequest.Add("ddlst_UserSiteTemplate", SiteTemplateOptionListValue);
            InputRequest.Add("ddlst_UserAdminStyle", AdminStyleOptionListValue);
            InputRequest.Add("ddlst_UserAdminTemplate", AdminTemplateOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/member/change_options/change_template_and_style/");


            UserSiteStyleAttribute += vc.ImportantInputAttribute["ddlst_UserSiteStyle"];
            UserSiteTemplateAttribute += vc.ImportantInputAttribute["ddlst_UserSiteTemplate"];
            UserAdminStyleAttribute += vc.ImportantInputAttribute["ddlst_UserAdminStyle"];
            UserAdminTemplateAttribute += vc.ImportantInputAttribute["ddlst_UserAdminTemplate"];

            UserSiteStyleCssClass = UserSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserSiteStyle"]);
            UserSiteTemplateCssClass = UserSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserSiteTemplate"]);
            UserAdminStyleCssClass = UserAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserAdminStyle"]);
            UserAdminTemplateCssClass = UserAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserAdminTemplate"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/member/change_options/change_template_and_style/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentSiteGlobalLanguage(), "problem");

                //UserSiteStyleCssClass = UserSiteStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserSiteStyle"]);
                //UserSiteTemplateCssClass = UserSiteTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserSiteTemplate"]);
                //UserAdminStyleCssClass = UserAdminStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserAdminStyle"]);
                //UserAdminTemplateCssClass = UserAdminTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserAdminTemplate"]);
            }
        }

        public void ChangeTemplateAndStyle()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.TemplateAndStyle dutas = new DataUse.TemplateAndStyle();
            dutas.ChangeUserTemplateAndStyle(ccoc.UserId, SiteStyleOptionListSelectedValue, SiteTemplateOptionListSelectedValue, AdminStyleOptionListSelectedValue, AdminTemplateOptionListSelectedValue);


            // Set Run Time Update

            if (SiteStyleOptionListSelectedValue != "0")
            {
                // Update Site Style
                ccoc.SiteStyleId = SiteStyleOptionListSelectedValue;
                DataUse.SiteStyle duss = new DataUse.SiteStyle();

                duss.FillCurrentSiteStyle(ccoc.SiteStyleId);
                ccoc.SiteStylePhysicalPath = duss.SiteStyleDirectoryPath + "/" + duss.SiteStylePhysicalName;
            }


            // Update Admin Style
            if (AdminStyleOptionListSelectedValue != "0")
            {
                ccoc.AdminStyleId = AdminStyleOptionListSelectedValue;
                DataUse.AdminStyle duas = new DataUse.AdminStyle();

                duas.FillCurrentAdminStyle(ccoc.AdminStyleId);
                ccoc.AdminStylePhysicalPath = duas.AdminStyleDirectoryPath + "/" + duas.AdminStylePhysicalName;
            }


            // Update Site Template
            if (SiteTemplateOptionListSelectedValue != "0")
            {
                ccoc.SiteTemplateId = SiteTemplateOptionListSelectedValue;
                DataUse.SiteTemplate dust = new DataUse.SiteTemplate();

                dust.FillCurrentSiteTemplate(ccoc.SiteTemplateId);
                ccoc.SiteTemplatePhysicalPath = dust.SiteTemplateDirectoryPath + "/" + dust.SiteTemplatePhysicalName;
            }


            // Update Admin Template
            if (AdminTemplateOptionListSelectedValue != "0")
            {
                ccoc.AdminTemplateId = AdminTemplateOptionListSelectedValue;
                DataUse.AdminTemplate duat = new DataUse.AdminTemplate();

                duat.FillCurrentAdminTemplate(ccoc.AdminTemplateId);
                ccoc.AdminTemplatePhysicalPath = duat.AdminTemplateDirectoryPath + "/" + duat.AdminTemplatePhysicalName;
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_template_and_style", ccoc.UserId);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/member/change_options/change_template_and_style/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}