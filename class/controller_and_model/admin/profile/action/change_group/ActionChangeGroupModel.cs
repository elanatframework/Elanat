using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeGroupModel : CodeBehindModel
    {
        public string GroupLanguage { get; set; }
        public string ChangeGroupLanguage { get; set; }
        public string UserGroupLanguage { get; set; }

        public string UserGroupOptionListValue { get; set; }
        public string UserGroupOptionListSelectedValue { get; set; }

        public string UserGroupAttribute { get; set; }
        public string FirstDayOfWeekAttribute { get; set; }
        public string TimeZoneAttribute { get; set; }

        public string UserGroupCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            GroupLanguage = aol.GetAddOnsLanguage("group");
            ChangeGroupLanguage = aol.GetAddOnsLanguage("change_group");
            UserGroupLanguage = aol.GetAddOnsLanguage("user_group");


            // Set User Info
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Current Value
            string CurrentUserGroupId = ccoc.GroupId;


            // Set User Group Item
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserGroupListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            UserGroupOptionListValue += lcu.UserGroupListItem.HtmlInputToOptionTag(CurrentUserGroupId);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_UserGroup", UserGroupOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_group");

            UserGroupAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserGroup");

            UserGroupCssClass = UserGroupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserGroup"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_group", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void ChangeGroup()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.User duu = new DataUse.User();
            duu.ChangeUserGroup(ccoc.UserId, UserGroupOptionListSelectedValue);


            // Set Run Time Update
            ccoc.GroupId = UserGroupOptionListSelectedValue;

            ccoc.FillUserClientSetting(duu.UserId, false);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_group", ccoc.UserId);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_group/action/SuccessMessage.aspx", true);
        }
    }
}