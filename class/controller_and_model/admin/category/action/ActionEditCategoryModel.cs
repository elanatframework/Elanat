using CodeBehind;

namespace Elanat
{
    public partial class ActionEditCategoryModel : CodeBehindModel
    {
        public string EditCategoryLanguage { get; set; }
        public string SaveCategoryLanguage { get; set; }
        public string CategoryNameLanguage { get; set; }
        public string ParentCategoryLanguage { get; set; }
        public string CategorySiteLanguage { get; set; }
        public string DefaultStyleLanguage { get; set; }
        public string DefaultTemplateLanguage { get; set; }
        public string CategoryActiveLanguage { get; set; }
        public string CategoryRequireApprovalLanguage { get; set; }
        public string CategoryAccessShowLanguage { get; set; }
        public string CategoryPublicAccessShowLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string CategoryIdValue { get; set; }

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

        public List<ListItem> CategoryAccessShowListItem = new List<ListItem>();
        public string CategoryAccessShowListValue { get; set; }
        public string CategoryAccessShowTemplateValue { get; set; }

        public string CategoryAccessShowAttribute { get; set; }
        public string CategoryAccessShowCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/category/");
            CategoryNameLanguage = aol.GetAddOnsLanguage("category_name");
            CategorySiteLanguage = aol.GetAddOnsLanguage("category_site");
            EditCategoryLanguage = aol.GetAddOnsLanguage("edit_category");
            CategoryRequireApprovalLanguage = aol.GetAddOnsLanguage("category_require_approval");
            DefaultStyleLanguage = aol.GetAddOnsLanguage("style");
            DefaultTemplateLanguage = aol.GetAddOnsLanguage("template");
            ParentCategoryLanguage = aol.GetAddOnsLanguage("parent_category");
            CategoryActiveLanguage = aol.GetAddOnsLanguage("category_active");
            CategoryPublicAccessShowLanguage = aol.GetAddOnsLanguage("category_public_access_show");
            CategoryAccessShowLanguage = aol.GetAddOnsLanguage("category_access_show");
            SaveCategoryLanguage = aol.GetAddOnsLanguage("save_category");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Category duc = new DataUse.Category();
                duc.FillCurrentCategory(CategoryIdValue);

                CategorySiteOptionListSelectedValue = duc.SiteId;
                CategoryNameValue = duc.CategoryName;
                CategoryRequireApprovalValue = duc.RequireApproval.ZeroOneToBoolean();
                ParentCategoryOptionListSelectedValue = duc.ParentCategory;
                DefaultStyleOptionListSelectedValue = duc.SiteStyleId;
                DefaultTemplateOptionListSelectedValue = duc.SiteTemplateId;
                CategoryPublicAccessShowValue = duc.CategoryPublicAccessShow.ZeroOneToBoolean();
                CategoryActiveValue = duc.CategoryActive.ZeroOneToBoolean();
            }
                        
            ListClass.Category lcc = new ListClass.Category();

            // Set Parent Category
            lcc.FillCategoryListItemTree(StaticObject.GetCurrentAdminSiteId(), "-");
            ParentCategoryOptionListValue += ParentCategoryOptionListValue.HtmlInputAddOptionTag("", "0");
            ParentCategoryOptionListValue += lcc.CategoryListItemTree.HtmlInputToOptionTag(ParentCategoryOptionListSelectedValue);

            // Set Site Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteListItem();
            CategorySiteOptionListValue += CategorySiteOptionListValue.HtmlInputAddOptionTag("", "0");
            CategorySiteOptionListValue += lcs.SiteListItem.HtmlInputToOptionTag(CategorySiteOptionListSelectedValue);

            // Set Site Style Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleListItem();
            DefaultStyleOptionListValue += DefaultStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            DefaultStyleOptionListValue += lcss.SiteStyleListItem.HtmlInputToOptionTag(DefaultStyleOptionListSelectedValue);

            // Set Site Template Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateListItem();
            DefaultTemplateOptionListValue += DefaultTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            DefaultTemplateOptionListValue += lcst.SiteTemplateListItem.HtmlInputToOptionTag(DefaultTemplateOptionListSelectedValue);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/category/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lcu.UserRoleListItem);
            CategoryAccessShowTemplateValue = hcbl.GetValue();
            CategoryAccessShowListValue = hcbl.GetList();
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.Replace("$_asp attribute;", CategoryAccessShowAttribute);
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.Replace("$_asp css_class;", CategoryAccessShowCssClass);
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(CategoryAccessShowListItem);

            // Set Category Access Show Selected Value
            lcc.FillCategoryAccessShowListItem(CategoryIdValue);
            CategoryAccessShowTemplateValue = CategoryAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcc.CategoryAccessShowListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_CategoryName", "");
            InputRequest.Add("ddlst_ParentCategory", ParentCategoryOptionListValue);
            InputRequest.Add("ddlst_CategorySite", CategorySiteOptionListValue);
            InputRequest.Add("ddlst_DefaultStyle", DefaultStyleOptionListValue);
            InputRequest.Add("ddlst_DefaultTemplate", DefaultTemplateOptionListValue);
            InputRequest.Add("cbxlst_CategoryAccessShow", CategoryAccessShowListValue);
            InputRequest.Add("hdn_CategoryId", CategoryIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/category/", "edit");

            CategoryNameAttribute += vc.ImportantInputAttribute.GetValue("txt_CategoryName");
            ParentCategoryAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ParentCategory");
            CategorySiteAttribute += vc.ImportantInputAttribute.GetValue("ddlst_CategorySite");
            DefaultStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultStyle");
            DefaultTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_DefaultTemplate");
            CategoryAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_CategoryAccessShow");

            CategoryNameCssClass = CategoryNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_CategoryName"));
            ParentCategoryCssClass = ParentCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ParentCategory"));
            CategorySiteCssClass = CategorySiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_CategorySite"));
            DefaultStyleCssClass = DefaultStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultStyle"));
            DefaultTemplateCssClass = DefaultTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_DefaultTemplate"));
            CategoryAccessShowCssClass = CategoryAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_CategoryAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/category/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveCategory()
        {
            DataUse.Category duc = new DataUse.Category();

            // Change Database Data
            duc.CategoryId = CategoryIdValue;
            duc.SiteId = CategorySiteOptionListSelectedValue;
            duc.CategoryName = CategoryNameValue;
            duc.RequireApproval = CategoryRequireApprovalValue.BooleanToZeroOne();
            duc.ParentCategory = ParentCategoryOptionListSelectedValue;
            duc.SiteStyleId = DefaultStyleOptionListSelectedValue;
            duc.SiteTemplateId = DefaultTemplateOptionListSelectedValue;
            duc.CategoryPublicAccessShow = CategoryPublicAccessShowValue.BooleanToZeroOne();
            duc.CategoryActive = CategoryActiveValue.ToString();

            // Edit Category
            duc.Edit();

            // Delete Category Access Show
            duc.DeleteCategoryAccessShow(duc.CategoryId);

            // Set Category Access Show
            duc.SetCategoryAccessShow(duc.CategoryId, CategoryAccessShowListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_category", duc.CategoryName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/category/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("category_name", StaticObject.GetCurrentAdminGlobalLanguage())), "problem");
        }
    }
}