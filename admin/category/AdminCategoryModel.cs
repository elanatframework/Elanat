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
    public class AdminCategoryModel
    {
        public string CategoryLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddCategoryLanguage { get; set; }
        public string CategoryNameLanguage { get; set; }
        public string ParentCategoryLanguage { get; set; }
        public string CategorySiteLanguage { get; set; }
        public string DefaultStyleLanguage { get; set; }
        public string DefaultTemplateLanguage { get; set; }
        public string CategoryActiveLanguage { get; set; }
        public string CategoryRequireApprovalLanguage { get; set; }
        public string CategoryAccessShowLanguage { get; set; }
        public string CategoryPublicAccessShowLanguage { get; set; }

        public bool CategoryActiveValue { get; set; } = false;
        public bool CategoryRequireApprovalValue { get; set; } = false;
        public bool CategoryPublicAccessShowValue { get; set; } = false;

        public string CategoryNameValue { get; set; }

        public string CategoryNameAttribute { get; set; }

        public string CategoryNameCssClass { get; set; }

        public string ParentCategoryOptionListValue { get; set; }
        public string CategorySiteOptionListValue { get; set; }
        public string DefaultStyleOptionListValue { get; set; }
        public string DefaultTemplateOptionListValue { get; set; }
        public string ParentCategoryOptionListSelectedValue { get; set; }
        public string CategorySiteOptionListSelectedValue { get; set; }
        public string DefaultStyleOptionListSelectedValue { get; set; }
        public string DefaultTemplateOptionListSelectedValue { get; set; }

        public string ParentCategoryAttribute { get; set; }
        public string CategorySiteAttribute { get; set; }
        public string DefaultStyleAttribute { get; set; }
        public string DefaultTemplateAttribute { get; set; }

        public string ParentCategoryCssClass { get; set; }
        public string CategorySiteCssClass { get; set; }
        public string DefaultStyleCssClass { get; set; }
        public string DefaultTemplateCssClass { get; set; }

        public ListItemCollection CategoryAccessShowListItem = new ListItemCollection();
        public string CategoryAccessShowListValue { get; set; }
        public string CategoryAccessShowTemplateValue { get; set; }

        public string CategoryAccessShowAttribute { get; set; }
        public string CategoryAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/category/");
            CategoryNameLanguage = aol.GetAddOnsLanguage("category_name");
            CategoryLanguage = aol.GetAddOnsLanguage("category");
            CategorySiteLanguage = aol.GetAddOnsLanguage("category_site");
            AddCategoryLanguage = aol.GetAddOnsLanguage("add_category");
            CategoryActiveLanguage = aol.GetAddOnsLanguage("category_active");
            CategoryRequireApprovalLanguage = aol.GetAddOnsLanguage("category_require_approval");
            DefaultStyleLanguage = aol.GetAddOnsLanguage("style");
            DefaultTemplateLanguage = aol.GetAddOnsLanguage("template");
            ParentCategoryLanguage = aol.GetAddOnsLanguage("parent_category");
            CategoryAccessShowLanguage = aol.GetAddOnsLanguage("category_access_show");
            CategoryPublicAccessShowLanguage = aol.GetAddOnsLanguage("category_public_access_show");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Parent Category
            lc.FillCategoryListItemTree(StaticObject.GetCurrentAdminSiteId(), "-");
            ParentCategoryOptionListValue += ParentCategoryOptionListValue.HtmlInputAddOptionTag("", "0");
            ParentCategoryOptionListValue += lc.CategoryListItemTree.HtmlInputToOptionTag();

            // Set Site Item
            lc.FillSiteListItem();
            CategorySiteOptionListValue += CategorySiteOptionListValue.HtmlInputAddOptionTag("", "0");
            CategorySiteOptionListValue += lc.SiteListItem.HtmlInputToOptionTag();

            // Set Site Style Item
            lc.FillSiteStyleListItem();
            DefaultStyleOptionListValue += DefaultStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            DefaultStyleOptionListValue += lc.SiteStyleListItem.HtmlInputToOptionTag();

            // Set Site Template Item
            lc.FillSiteTemplateListItem();
            DefaultTemplateOptionListValue += DefaultTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            DefaultTemplateOptionListValue += lc.SiteTemplateListItem.HtmlInputToOptionTag();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/category/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lc.UserRoleListItem);
            CategoryAccessShowTemplateValue = hcbl.GetValue();
            CategoryAccessShowListValue = hcbl.GetList();
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.Replace("$_asp attribute;", CategoryAccessShowAttribute);
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.Replace("$_asp css_class;", CategoryAccessShowCssClass);
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(CategoryAccessShowListItem);


            // Set Category Page List
            ActionGetCategoryListModel lm = new ActionGetCategoryListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_CategoryName", "");
            InputRequest.Add("ddlst_ParentCategory", ParentCategoryOptionListValue);
            InputRequest.Add("ddlst_CategorySite", CategorySiteOptionListValue);
            InputRequest.Add("ddlst_DefaultStyle", DefaultStyleOptionListValue);
            InputRequest.Add("ddlst_DefaultTemplate", DefaultTemplateOptionListValue);
            InputRequest.Add("cbxlst_CategoryAccessShow", CategoryAccessShowListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/category/");

            CategoryNameAttribute += vc.ImportantInputAttribute["txt_CategoryName"];
            ParentCategoryAttribute += vc.ImportantInputAttribute["ddlst_ParentCategory"];
            CategorySiteAttribute += vc.ImportantInputAttribute["ddlst_CategorySite"];
            DefaultStyleAttribute += vc.ImportantInputAttribute["ddlst_DefaultStyle"];
            DefaultTemplateAttribute += vc.ImportantInputAttribute["ddlst_DefaultTemplate"];
            CategoryAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_CategoryAccessShow"];

            CategoryNameCssClass = CategoryNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_CategoryName"]);
            ParentCategoryCssClass = ParentCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ParentCategory"]);
            CategorySiteCssClass = CategorySiteCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_CategorySite"]);
            DefaultStyleCssClass = DefaultStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_DefaultStyle"]);
            DefaultTemplateCssClass = DefaultTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_DefaultTemplate"]);
            CategoryAccessShowCssClass = CategoryAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_CategoryAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/category/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");
                
                //CategoryNameCssClass = CategoryNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_CategoryName"]);
                //ParentCategoryCssClass = ParentCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ParentCategory"]);
                //CategorySiteCssClass = CategorySiteCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_CategorySite"]);
                //DefaultStyleCssClass = DefaultStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_DefaultStyle"]);
                //DefaultTemplateCssClass = DefaultTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_DefaultTemplate"]);
                //CategoryAccessShowCssClass = CategoryAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_CategoryAccessShow"]);
            }
        }

        public void AddCategory()
        {
            // Add Data To Database
            DataUse.Category duc = new DataUse.Category();

            duc.SiteId = CategorySiteOptionListSelectedValue;
            duc.CategoryName = CategoryNameValue;
            duc.RequireApproval = CategoryRequireApprovalValue.BooleanToZeroOne();
            duc.ParentCategory = ParentCategoryOptionListSelectedValue;
            duc.SiteStyleId = DefaultStyleOptionListSelectedValue;
            duc.SiteTemplateId = DefaultTemplateOptionListSelectedValue;
            duc.CategoryPublicAccessShow = CategoryPublicAccessShowValue.BooleanToZeroOne();
            duc.CategoryActive = CategoryActiveValue.BooleanToZeroOne();

            // Add Category
            duc.AddWithFillReturnDr();

            // Set Category Access Show
            duc.SetCategoryAccessShow(duc.CategoryId, CategoryAccessShowListItem);


            // Re Create Category Map 
            ListClass li = new ListClass();
            li.FillSiteGlobalNameListItem();

            CategoryMap cm = new CategoryMap();

            foreach (ListItem item in li.SiteGlobalNameListItem)
                cm.CreateCategoryMap(item.Text, item.Value);


            try { duc.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_category", duc.CategoryName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("category_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/category/"), "success", false, StaticObject.AdminPath + "/category/action/CategoryNewRow.aspx?category_id=" + duc.CategoryId, "div_TableBox");
        }
    }
}