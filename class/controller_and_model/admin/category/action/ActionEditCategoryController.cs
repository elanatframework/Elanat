using CodeBehind;

namespace Elanat
{
    public partial class ActionEditCategoryController : CodeBehindController
    {
        public ActionEditCategoryModel model = new ActionEditCategoryModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveCategory"]))
            {
                btn_SaveCategory_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_CategoryId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["category_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["category_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.CategoryIdValue = context.Request.Query["category_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveCategory_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.CategoryNameValue = context.Request.Form["txt_CategoryName"];
            model.ParentCategoryOptionListSelectedValue = context.Request.Form["ddlst_ParentCategory"];
            model.CategorySiteOptionListSelectedValue = context.Request.Form["ddlst_CategorySite"];
            model.DefaultStyleOptionListSelectedValue = context.Request.Form["ddlst_DefaultStyle"];
            model.DefaultTemplateOptionListSelectedValue = context.Request.Form["ddlst_DefaultTemplate"];
            model.CategoryActiveValue = context.Request.Form["cbx_CategoryActive"] == "on";
            model.CategoryRequireApprovalValue = context.Request.Form["cbx_CategoryRequireApproval"] == "on";
            model.CategoryPublicAccessShowValue = context.Request.Form["cbx_CategoryPublicAccessShow"] == "on";
            model.CategoryIdValue = context.Request.Form["hdn_CategoryId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_CategoryAccessShow$"))
                {
                    ListItem CategoryAccessShow = new ListItem();

                    CategoryAccessShow.Value = context.Request.Form[name];
                    CategoryAccessShow.Selected = true;

                    model.CategoryAccessShowListItem.Add(CategoryAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            DataUse.Category duc = new DataUse.Category();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_category", "category_name", model.CategoryNameValue, duc.GetCategoryName(model.CategoryIdValue)))
            {
                model.CategoryNameCssClass = model.CategoryNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                return;
            }


            model.SaveCategory();

            model.SuccessView();

            View(model);
        }
    }
}