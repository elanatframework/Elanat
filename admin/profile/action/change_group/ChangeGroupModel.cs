﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionChangeGroupModel
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
            string CurrentUserGroup = ccoc.GroupName;


            ListClass lc = new ListClass();

            // Set UserGroup Item
            lc.FillUserGroupListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            UserGroupOptionListValue += lc.UserGroupListItem.HtmlInputToOptionTag(CurrentUserGroup);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_UserGroup", UserGroupOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_group");

            UserGroupAttribute += vc.ImportantInputAttribute["ddlst_UserGroup"];

            UserGroupCssClass = UserGroupCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_UserGroup"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_group", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //UserGroupCssClass = UserGroupCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_UserGroup"]);
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
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_group/action/SuccessMessage.aspx", true);
        }
    }
}