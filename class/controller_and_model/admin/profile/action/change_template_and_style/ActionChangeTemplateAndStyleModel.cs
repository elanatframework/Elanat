using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeTemplateAndStyleModel : CodeBehindModel
    {
        public string ChangeTemplateAndStyleLanguage { get; set; }
        public string TemplateAndStyleLanguage { get; set; }
        public string UserSiteTemplateLanguage { get; set; }
        public string UserSiteStyleLanguage { get; set; }
        public string UserAdminTemplateLanguage { get; set; }
        public string UserAdminStyleLanguage { get; set; }

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
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            TemplateAndStyleLanguage = aol.GetAddOnsLanguage("template_and_style");
            ChangeTemplateAndStyleLanguage = aol.GetAddOnsLanguage("change_template_and_style");
            UserSiteTemplateLanguage = aol.GetAddOnsLanguage("user_site_template");
            UserSiteStyleLanguage = aol.GetAddOnsLanguage("user_site_style");
            UserAdminTemplateLanguage = aol.GetAddOnsLanguage("user_admin_template");
            UserAdminStyleLanguage = aol.GetAddOnsLanguage("user_admin_style");


            // Set User Info
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
            string UserSiteStyleId = dbdr.dr["site_style_id"].ToString();
            string UserSiteTemplateId = dbdr.dr["site_template_id"].ToString();
            string UserAdminStyleId = dbdr.dr["admin_style_id"].ToString();
            string UserAdminTemplateId = dbdr.dr["admin_template_id"].ToString();

            db.Close();


            // Set Site Style Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleListItem();
            SiteStyleOptionListValue += SiteStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteStyleOptionListValue += lcss.SiteStyleListItem.HtmlInputToOptionTag(UserSiteStyleId);

            // Set Site Template Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateListItem();
            SiteTemplateOptionListValue += SiteTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            SiteTemplateOptionListValue += lcst.SiteTemplateListItem.HtmlInputToOptionTag(UserSiteTemplateId);

            // Set Admin Style Item
            ListClass.AdminStyle lcas = new ListClass.AdminStyle();
            lcas.FillAdminStyleListItem();
            AdminStyleOptionListValue += AdminStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminStyleOptionListValue += lcas.AdminStyleListItem.HtmlInputToOptionTag(UserAdminStyleId);

            // Set Admin Template Item
            ListClass.AdminTemplate lcat = new ListClass.AdminTemplate();
            lcat.FillAdminTemplateListItem();
            AdminTemplateOptionListValue += AdminTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            AdminTemplateOptionListValue += lcat.AdminTemplateListItem.HtmlInputToOptionTag(UserAdminTemplateId);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_UserSiteStyle", SiteStyleOptionListValue);
            InputRequest.Add("ddlst_UserSiteTemplate", SiteTemplateOptionListValue);
            InputRequest.Add("ddlst_UserAdminStyle", AdminStyleOptionListValue);
            InputRequest.Add("ddlst_UserAdminTemplate", AdminTemplateOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_template_and_style");


            UserSiteStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserSiteStyle");
            UserSiteTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserSiteTemplate");
            UserAdminStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserAdminStyle");
            UserAdminTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserAdminTemplate");

            UserSiteStyleCssClass = UserSiteStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserSiteStyle"));
            UserSiteTemplateCssClass = UserSiteTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserSiteTemplate"));
            UserAdminStyleCssClass = UserAdminStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserAdminStyle"));
            UserAdminTemplateCssClass = UserAdminTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserAdminTemplate"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_template_and_style", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_template_and_style/action/SuccessMessage.aspx", true);
        }
    }
}