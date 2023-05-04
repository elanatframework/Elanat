using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminRoleModel
    {
        public string AddLanguage { get; set; }
        public string RoleNameLanguage { get; set; }
        public string RoleLanguage { get; set; }
        public string AddRoleLanguage { get; set; }
        public string RoleTypeLanguage { get; set; }
        public string RoleBitColumnAccessLanguage { get; set; }
        public string RoleActiveLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool RoleActiveValue { get; set; } = false;

        public string RoleNameValue { get; set; }

        public string RoleNameAttribute { get; set; }

        public string RoleNameCssClass { get; set; }

        public string RoleTypeOptionListValue { get; set; }
        public string RoleTypeOptionListSelectedValue { get; set; }

        public ListItemCollection RoleBitColumnAccessListItem = new ListItemCollection();
        public string RoleBitColumnAccessListValue { get; set; }
        public string RoleBitColumnAccessTemplateValue { get; set; }

        public string RoleBitColumnAccessAttribute { get; set; }
        public string RoleTypeAttribute { get; set; }

        public string RoleBitColumnAccessCssClass { get; set; }
        public string RoleTypeCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/role/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RoleLanguage = aol.GetAddOnsLanguage("role");
            RoleBitColumnAccessLanguage = aol.GetAddOnsLanguage("role_bit_column_access");
            RoleNameLanguage = aol.GetAddOnsLanguage("role_name");
            RoleTypeLanguage = aol.GetAddOnsLanguage("role_type");
            RoleActiveLanguage = aol.GetAddOnsLanguage("role_active");
            AddRoleLanguage = aol.GetAddOnsLanguage("add_role");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Role Bit Column Access List Item
            lc.FillRoleBitColumnAccessListItem();
            HtmlCheckBoxList HtmlCheckBoxListoleBitColumnAccess = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/role/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_RoleBitColumnAccess");
            HtmlCheckBoxListoleBitColumnAccess.AddRange(lc.RoleBitColumnAccessListItem);
            RoleBitColumnAccessTemplateValue = HtmlCheckBoxListoleBitColumnAccess.GetValue();
            RoleBitColumnAccessListValue = HtmlCheckBoxListoleBitColumnAccess.GetList();
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.Replace("$_asp attribute;", RoleBitColumnAccessAttribute);
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.Replace("$_asp css_class;", RoleBitColumnAccessCssClass);
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.HtmlInputSetCheckBoxListValue(RoleBitColumnAccessListItem);

            // Set Role Type List Item
            lc.FillRoleTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            RoleTypeOptionListValue += lc.RoleTypeListItem.HtmlInputToOptionTag(RoleTypeOptionListSelectedValue);


            // Set Role Page List
            ActionGetRoleListModel lm = new ActionGetRoleListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_RoleName", "");
            InputRequest.Add("cbxlst_RoleBitColumnAccess", RoleBitColumnAccessListValue);
            InputRequest.Add("ddlst_RoleType", RoleTypeOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/role/");

            RoleNameAttribute += vc.ImportantInputAttribute["txt_RoleName"];
            RoleBitColumnAccessAttribute += vc.ImportantInputAttribute["cbxlst_RoleBitColumnAccess"];
            RoleTypeAttribute += vc.ImportantInputAttribute["ddlst_RoleType"];

            RoleNameCssClass = RoleNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RoleName"]);
            RoleBitColumnAccessCssClass = RoleBitColumnAccessCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_RoleBitColumnAccess"]);
            RoleTypeCssClass = RoleTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_RoleType"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/role/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //RoleNameCssClass = RoleNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_RoleName"]);
                //RoleBitColumnAccessCssClass = RoleBitColumnAccessCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_RoleBitColumnAccess"]);
                //RoleTypeCssClass = RoleTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_RoleType"]);
            }
        }

        public void AddRole()
        {
            // Add Data To Database
            DataUse.Role dur = new DataUse.Role();

            dur.RoleName = RoleNameValue;
            dur.RoleType = RoleTypeOptionListSelectedValue;
            dur.RoleActive = RoleActiveValue.BooleanToZeroOne();
            dur.RoleBitColumnAccess = RoleBitColumnAccessListItem;

            // Add Role
            dur.AddWithFillReturnDr();


            // Create Role Data
            FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/role_data/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/role_data/" + dur.RoleName + "/"), true);


            try { dur.ReturnDb.Close(); } catch (Exception) { }


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_role", dur.RoleName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/role/"), "success", false, StaticObject.AdminPath + "/role/action/RoleNewRow.aspx?role_id=" + dur.RoleId, "div_TableBox");
        }
    }
}