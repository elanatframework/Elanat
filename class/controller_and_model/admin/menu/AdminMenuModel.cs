using CodeBehind;

namespace Elanat
{
    public partial class AdminMenuModel : CodeBehindModel
    {
        public string AddLanguage { get; set; }
        public string AddMenuLanguage { get; set; }
        public string MenuActiveLanguage { get; set; }
        public string MenuPublicAccessShowLanguage { get; set; }
        public string MenuUseBoxLanguage { get; set; }
        public string MenuAccessShowLanguage { get; set; }
        public string MenuLanguage { get; set; }
        public string MenuLocationLanguage { get; set; }
        public string MenuNameLanguage { get; set; }
        public string MenuSiteLanguage { get; set; }
        public string MenuSortIndexLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool MenuActiveValue { get; set; } = false;
        public bool MenuUseBoxValue { get; set; } = false;
        public bool MenuPublicAccessShowValue { get; set; } = false;

        public string MenuLocationOptionListValue { get; set; }
        public string MenuLocationOptionListSelectedValue { get; set; }
        public string MenuSiteOptionListValue { get; set; }
        public string MenuSiteOptionListSelectedValue { get; set; }

        public string MenuNameValue { get; set; }
        public string MenuSortIndexValue { get; set; }

        public string MenuNameAttribute { get; set; }
        public string MenuSortIndexAttribute { get; set; }
        public string MenuLocationAttribute { get; set; }
        public string MenuSiteAttribute { get; set; }

        public string MenuNameCssClass { get; set; }
        public string MenuSortIndexCssClass { get; set; }
        public string MenuLocationCssClass { get; set; }
        public string MenuSiteCssClass { get; set; }

        public List<ListItem> MenuAccessShowListItem = new List<ListItem>();
        public string MenuAccessShowListValue { get; set; }
        public string MenuAccessShowTemplateValue { get; set; }

        public string MenuAccessShowAttribute { get; set; }
        public string MenuAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/menu/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            AddMenuLanguage = aol.GetAddOnsLanguage("add_menu");
            MenuActiveLanguage = aol.GetAddOnsLanguage("menu_active");
            MenuPublicAccessShowLanguage = aol.GetAddOnsLanguage("menu_public_access_show");
            MenuUseBoxLanguage = aol.GetAddOnsLanguage("menu_use_box");
            MenuAccessShowLanguage = aol.GetAddOnsLanguage("menu_access_show");
            MenuLanguage = aol.GetAddOnsLanguage("menu");
            MenuLocationLanguage = aol.GetAddOnsLanguage("menu_location");
            MenuNameLanguage = aol.GetAddOnsLanguage("menu_name");
            MenuSiteLanguage = aol.GetAddOnsLanguage("menu_site");
            MenuSortIndexLanguage = aol.GetAddOnsLanguage("menu_sort_index");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteListItem();
            MenuSiteOptionListValue += lcs.SiteListItem.HtmlInputToOptionTag(MenuSiteOptionListSelectedValue);

            // Set Menu Location
            ListClass.Menu lcm = new ListClass.Menu();
            lcm.FillMenuLocationListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            MenuLocationOptionListValue += lcm.MenuLocationListItem.HtmlInputToOptionTag(MenuLocationOptionListSelectedValue);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Menu Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/menu/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_MenuAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            MenuAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            MenuAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            MenuAccessShowTemplateValue = MenuAccessShowTemplateValue.Replace("$_asp attribute;", MenuAccessShowAttribute);
            MenuAccessShowTemplateValue = MenuAccessShowTemplateValue.Replace("$_asp css_class;", MenuAccessShowCssClass);
            MenuAccessShowTemplateValue = MenuAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(MenuAccessShowListItem);


            MenuSortIndexValue = "0";


            // Set Menu Page List
            ActionGetMenuListModel lm = new ActionGetMenuListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_MenuName", "");
            InputRequest.Add("ddlst_MenuLocation", MenuLocationOptionListValue);
            InputRequest.Add("ddlst_MenuSite", MenuSiteOptionListValue);
            InputRequest.Add("txt_MenuSortIndex", "");
            InputRequest.Add("cbxlst_MenuAccessShow", MenuAccessShowListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/menu/");

            MenuNameAttribute += vc.ImportantInputAttribute.GetValue("txt_MenuName");
            MenuLocationAttribute += vc.ImportantInputAttribute.GetValue("ddlst_MenuLocation");
            MenuSiteAttribute += vc.ImportantInputAttribute.GetValue("ddlst_MenuSite");
            MenuSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_MenuSortIndex");
            MenuAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_MenuAccessShow");

            MenuNameCssClass = MenuNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MenuName"));
            MenuLocationCssClass = MenuLocationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_MenuLocation"));
            MenuSiteCssClass = MenuSiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_MenuSite"));
            MenuSortIndexCssClass = MenuSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MenuSortIndex"));
            MenuAccessShowCssClass = MenuAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_MenuAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/menu/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddMenu()
        {
            // Add Data To Database
            DataUse.Menu dum = new DataUse.Menu();

            dum.SiteId = MenuSiteOptionListSelectedValue;
            dum.MenuName = MenuNameValue;
            dum.MenuLocation = MenuLocationOptionListSelectedValue;
            dum.MenuSortIndex = MenuSortIndexValue;
            dum.MenuUseBox = MenuUseBoxValue.ToString();
            dum.MenuActive = MenuActiveValue.ToString();
            dum.MenuPublicAccessShow = MenuPublicAccessShowValue.BooleanToZeroOne();

            // Add Menu
            dum.AddWithFillReturnDr();

            // Set Menu Access Show
            dum.SetMenuAccessShow(dum.MenuId, MenuAccessShowListItem);


            try { dum.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_menu", dum.MenuName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("menu_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/menu/"), "success", false, StaticObject.AdminPath + "/menu/action/MenuNewRow.aspx?menu_id=" + dum.MenuId, "div_TableBox");
        }
    }
}