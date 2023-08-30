using CodeBehind;

namespace Elanat
{
    public partial class ActionEditRoleModel : CodeBehindModel
    {
        public string RoleNameLanguage { get; set; }
        public string EditRoleLanguage { get; set; }
        public string SaveRoleLanguage { get; set; }
        public string RoleTypeLanguage { get; set; }
        public string RoleBitColumnAccessLanguage { get; set; }
        public string RoleActiveLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string RoleIdValue { get; set; }

        public bool RoleActiveValue { get; set; } = false;

        public string RoleNameValue { get; set; }

        public string RoleNameAttribute { get; set; }

        public string RoleNameCssClass { get; set; }

        public string RoleTypeOptionListValue { get; set; }
        public string RoleTypeOptionListSelectedValue { get; set; }

        public List<ListItem> RoleBitColumnAccessListItem = new List<ListItem>();
        public string RoleBitColumnAccessListValue { get; set; }
        public string RoleBitColumnAccessTemplateValue { get; set; }

        public string RoleBitColumnAccessAttribute { get; set; }
        public string RoleTypeAttribute { get; set; }

        public string RoleBitColumnAccessCssClass { get; set; }
        public string RoleTypeCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/role/");
            SaveRoleLanguage = aol.GetAddOnsLanguage("save_role");
            EditRoleLanguage = aol.GetAddOnsLanguage("edit_role");
            RoleBitColumnAccessLanguage = aol.GetAddOnsLanguage("role_bit_column_access");
            RoleNameLanguage = aol.GetAddOnsLanguage("role_name");
            RoleTypeLanguage = aol.GetAddOnsLanguage("role_type");
            RoleActiveLanguage = aol.GetAddOnsLanguage("role_active");


            // Set Current Value
            DataUse.Role dur = new DataUse.Role();
            dur.FillCurrentRole(RoleIdValue);

            if (IsFirstStart)
            {
                RoleNameValue = dur.RoleName;
                RoleTypeOptionListSelectedValue = dur.RoleType;
                RoleActiveValue = dur.RoleActive.ZeroOneToBoolean();
            }

            ListClass.Role lcr = new ListClass.Role();

            // Set Role Bit Column Access List Item
            lcr.FillRoleBitColumnAccessListItem();
            HtmlCheckBoxList HtmlCheckBoxListoleBitColumnAccess = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/role/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_RoleBitColumnAccess");
            HtmlCheckBoxListoleBitColumnAccess.AddRange(lcr.RoleBitColumnAccessListItem);
            RoleBitColumnAccessTemplateValue = HtmlCheckBoxListoleBitColumnAccess.GetValue();
            RoleBitColumnAccessListValue = HtmlCheckBoxListoleBitColumnAccess.GetList();
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.Replace("$_asp attribute;", RoleBitColumnAccessAttribute);
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.Replace("$_asp css_class;", RoleBitColumnAccessCssClass);
            RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.HtmlInputSetCheckBoxListValue(RoleBitColumnAccessListItem);

            // Set Role Type List Item
            lcr.FillRoleTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            RoleTypeOptionListValue += lcr.RoleTypeListItem.HtmlInputToOptionTag(RoleTypeOptionListSelectedValue);

            // Set Role Bit Column Access Selected Value
            if (IsFirstStart)
                RoleBitColumnAccessTemplateValue = RoleBitColumnAccessTemplateValue.HtmlInputSetCheckBoxListValue(dur.RoleBitColumnAccess);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_RoleName", "");
            InputRequest.Add("cbxlst_RoleBitColumnAccess", RoleBitColumnAccessListValue);
            InputRequest.Add("ddlst_RoleType", RoleTypeOptionListValue);
            InputRequest.Add("hdn_RoleId", RoleIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/role/", "edit");

            RoleNameAttribute += vc.ImportantInputAttribute.GetValue("txt_RoleName");
            RoleBitColumnAccessAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_RoleBitColumnAccess");
            RoleTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_RoleType");

            RoleNameCssClass = RoleNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RoleName"));
            RoleBitColumnAccessCssClass = RoleBitColumnAccessCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_RoleBitColumnAccess"));
            RoleTypeCssClass = RoleTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_RoleType"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/role/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveRole()
        {
            DataUse.Role dur = new DataUse.Role();


            // Set Current Value
            dur.FillCurrentRole(RoleIdValue);

            string CurrentRoleName = dur.RoleName;


            // Change Database Data
            dur.RoleId = RoleIdValue;
            dur.RoleName = RoleNameValue;
            dur.RoleType = RoleTypeOptionListSelectedValue;
            dur.RoleActive = RoleActiveValue.BooleanToZeroOne();
            dur.RoleBitColumnAccess = RoleBitColumnAccessListItem;

            // Edit Role
            dur.Edit();


            // Change Role Data
            if (CurrentRoleName != dur.RoleName)
                Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/role_data/" + CurrentRoleName + "/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/role_data/" + dur.RoleName + "/"));


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_role", dur.RoleName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/role/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("role_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/role/")), "problem");
        }
    }
}