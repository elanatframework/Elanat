using CodeBehind;

namespace Elanat
{
    public partial class AdminCategoryController : CodeBehindController
    {
        public AdminCategoryModel model = new AdminCategoryModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddCategory"]))
            {
                btn_AddCategory_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddCategory_Click(HttpContext context)
        {
            model.CategoryNameValue = context.Request.Form["txt_CategoryName"];
            model.ParentCategoryOptionListSelectedValue = context.Request.Form["ddlst_ParentCategory"];
            model.CategorySiteOptionListSelectedValue = context.Request.Form["ddlst_CategorySite"];
            model.DefaultStyleOptionListSelectedValue = context.Request.Form["ddlst_DefaultStyle"];
            model.DefaultTemplateOptionListSelectedValue = context.Request.Form["ddlst_DefaultTemplate"];
            model.CategoryActiveValue = context.Request.Form["cbx_CategoryActive"] == "on";
            model.CategoryRequireApprovalValue = context.Request.Form["cbx_CategoryRequireApproval"] == "on";
            model.CategoryPublicAccessShowValue = context.Request.Form["cbx_CategoryPublicAccessShow"] == "on";
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


            model.AddCategory();

            View(model);
        }
    }
}