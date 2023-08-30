using CodeBehind;

namespace Elanat
{
    public partial class AdminGroupModel : CodeBehindModel
    {
        public string AddLanguage { get; set; }
        public string GroupNameLanguage { get; set; }
        public string GroupLanguage { get; set; }
        public string AddGroupLanguage { get; set; }
        public string GroupRoleLanguage { get; set; }
        public string GroupActiveLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool GroupActiveValue { get; set; } = false;

        public string GroupNameValue { get; set; }

        public string GroupNameAttribute { get; set; }

        public string GroupNameCssClass { get; set; }

        public List<ListItem> GroupRoleListItem = new List<ListItem>();
        public string GroupRoleListValue { get; set; }
        public string GroupRoleTemplateValue { get; set; }

        public string GroupRoleAttribute { get; set; }
        public string GroupRoleCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/group/");
            GroupNameLanguage = aol.GetAddOnsLanguage("group_name");
            AddLanguage = aol.GetAddOnsLanguage("add");
            GroupLanguage = aol.GetAddOnsLanguage("group");
            AddGroupLanguage = aol.GetAddOnsLanguage("add_group");
            GroupRoleLanguage = aol.GetAddOnsLanguage("group_role");
            GroupActiveLanguage = aol.GetAddOnsLanguage("group_active");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/group/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_GroupRole");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            GroupRoleTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            GroupRoleListValue = HtmlCheckBoxListAccessShow.GetList();
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp attribute;", GroupRoleAttribute);
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp css_class;", GroupRoleCssClass);
            GroupRoleTemplateValue = GroupRoleTemplateValue.HtmlInputSetCheckBoxListValue(GroupRoleListItem);


            // Set Group Page List
            ActionGetGroupListModel lm = new ActionGetGroupListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_GroupName", "");
            InputRequest.Add("cbxlst_GroupRole", GroupRoleListValue);

                       
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

        public void AddGroup()
        {
            // Add Data To Database
            DataUse.Group dug = new DataUse.Group();

            dug.GroupName = GroupNameValue;
            dug.GroupActive = GroupActiveValue.BooleanToZeroOne();

            // Add Group
            dug.AddWithFillReturnDr();

            // Add Role Group
            dug.AddRoleGroup(dug.GroupId, GroupRoleListItem);


            try { dug.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_group", dug.GroupName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("group_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/group/"), "success", false, StaticObject.AdminPath + "/group/action/GroupNewRow.aspx?group_id=" + dug.GroupId, "div_TableBox");
        }
    }
}