using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ExtraHelperShowAdminComponentAccessViewModel
    {
        public string ComponentAccessViewLanguage { get; set; }
        public string CurrentComponentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string ComponentName)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/show_admin_component_access_view/");
            ComponentAccessViewLanguage = aol.GetAddOnsLanguage("component_access_view");
            CurrentComponentLanguage = Language.GetHandheldLanguage(ComponentName, StaticObject.GetCurrentAdminGlobalLanguage());


            DataUse.Component duc = new DataUse.Component();

            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            string AccessViewTemplate = Template.GetAdminTemplate("part/add_on_access_view/component");

            duc.FillComponentRoleAccess(ComponentId);

            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_show;", duc.ComponentAccessShow.BooleanToTrueFalse());
            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_add;", duc.ComponentAccessAdd.BooleanToTrueFalse());
            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_edit_own;", duc.ComponentAccessEditOwn.BooleanToTrueFalse());
            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_edit_all;", duc.ComponentAccessEditAll.BooleanToTrueFalse());
            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_delete_own;", duc.ComponentAccessDeleteOwn.BooleanToTrueFalse());
            AccessViewTemplate = AccessViewTemplate.Replace("$_asp access_delete_all;", duc.ComponentAccessDeleteAll.BooleanToTrueFalse());

            ContentValue = AccessViewTemplate;
        }
    }
}