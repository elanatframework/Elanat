using CodeBehind;

namespace Elanat
{
    public partial class ActionEditGroupModel : CodeBehindModel
    {
        public string GroupNameLanguage { get; set; }
        public string EditGroupLanguage { get; set; }
        public string SaveGroupLanguage { get; set; }
        public string GroupRoleLanguage { get; set; }
        public string GroupActiveLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string GroupIdValue { get; set; }

        public bool GroupActiveValue { get; set; } = false;

        public string GroupNameValue { get; set; }

        public string GroupNameAttribute { get; set; }

        public string GroupNameCssClass { get; set; }

        public List<ListItem> GroupRoleListItem = new List<ListItem>();
        public string GroupRoleListValue { get; set; }
        public string GroupRoleTemplateValue { get; set; }

        public string GroupRoleAttribute { get; set; }
        public string GroupRoleCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/group/");
            GroupNameLanguage = aol.GetAddOnsLanguage("group_name");
            SaveGroupLanguage = aol.GetAddOnsLanguage("save_group");
            EditGroupLanguage = aol.GetAddOnsLanguage("edit_group");
            GroupRoleLanguage = aol.GetAddOnsLanguage("group_role");
            GroupActiveLanguage = aol.GetAddOnsLanguage("group_active");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Group dug = new DataUse.Group();
                dug.FillCurrentGroup(GroupIdValue);

                GroupNameValue = dug.GroupName;
                GroupActiveValue = dug.GroupActive.ZeroOneToBoolean();
            }

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList HtmlCheckBoxListGroupRole = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/group/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_GroupRole");
            HtmlCheckBoxListGroupRole.AddRange(lcu.UserRoleListItem);
            GroupRoleTemplateValue = HtmlCheckBoxListGroupRole.GetValue();
            GroupRoleListValue = HtmlCheckBoxListGroupRole.GetList();
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp attribute;", GroupRoleAttribute);
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp css_class;", GroupRoleCssClass);
            GroupRoleTemplateValue = GroupRoleTemplateValue.HtmlInputSetCheckBoxListValue(GroupRoleListItem);

            // Set Group Role Selected Value
            ListClass.Group lcg = new ListClass.Group();
            lcg.FillGroupRoleListItem(GroupIdValue);
            GroupRoleTemplateValue = GroupRoleTemplateValue.HtmlInputSetCheckBoxListValue(lcg.GroupRoleListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_GroupName", "");
            InputRequest.Add("cbxlst_GroupRole", GroupRoleListValue);
            InputRequest.Add("hdn_GroupId", GroupIdValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/group/");

            GroupNameAttribute += vc.ImportantInputAttribute.GetValue("txt_GroupName");
            GroupRoleAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_GroupRole");

            GroupNameCssClass = GroupNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_GroupName"));
            GroupRoleCssClass = GroupRoleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_GroupRole"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/group/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveGroup()
        {
            // Change Database Data
            DataUse.Group dug = new DataUse.Group();

            dug.GroupId = GroupIdValue;
            dug.GroupName = GroupNameValue;
            dug.GroupActive = GroupActiveValue.BooleanToZeroOne();

            // Edit Group
            dug.Edit();

            // Delete Role Group
            dug.DeleteRoleGroup(dug.GroupId);

            // Add Role Group
            dug.AddRoleGroup(dug.GroupId, GroupRoleListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_group", dug.GroupName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/group/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("group_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/group/")), "problem");
        }
    }
}