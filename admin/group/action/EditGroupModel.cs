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
    public class ActionEditGroupModel
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

        public ListItemCollection GroupRoleListItem = new ListItemCollection();
        public string GroupRoleListValue { get; set; }
        public string GroupRoleTemplateValue { get; set; }

        public string GroupRoleAttribute { get; set; }
        public string GroupRoleCssClass { get; set; }

        public List<string> EvaluateErrorList;
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

            ListClass lc = new ListClass();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList HtmlCheckBoxListGroupRole = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/group/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_GroupRole");
            HtmlCheckBoxListGroupRole.AddRange(lc.UserRoleListItem);
            GroupRoleTemplateValue = HtmlCheckBoxListGroupRole.GetValue();
            GroupRoleListValue = HtmlCheckBoxListGroupRole.GetList();
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp attribute;", GroupRoleAttribute);
            GroupRoleTemplateValue = GroupRoleTemplateValue.Replace("$_asp css_class;", GroupRoleCssClass);
            GroupRoleTemplateValue = GroupRoleTemplateValue.HtmlInputSetCheckBoxListValue(GroupRoleListItem);

            // Set Group Role Selected Value
            lc.FillGroupRoleListItem(GroupIdValue);
            GroupRoleTemplateValue = GroupRoleTemplateValue.HtmlInputSetCheckBoxListValue(lc.GroupRoleListItem);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_GroupName", "");
            InputRequest.Add("cbxlst_GroupRole", GroupRoleListValue);
            InputRequest.Add("hdn_GroupId", GroupIdValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/group/");

            GroupNameAttribute += vc.ImportantInputAttribute["txt_GroupName"];
            GroupRoleAttribute += vc.ImportantInputAttribute["cbxlst_GroupRole"];

            GroupNameCssClass = GroupNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_GroupName"]);
            GroupRoleCssClass = GroupRoleCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_GroupRole"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/group/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //GroupNameCssClass = GroupNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_GroupName"]);
                //GroupRoleCssClass = GroupRoleCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_GroupRole"]);
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
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/group/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("group_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/group/")), "problem");
        }
    }
}