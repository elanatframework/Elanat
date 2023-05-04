using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditCategory : System.Web.UI.Page
    {
        public ActionEditCategoryModel model = new ActionEditCategoryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveCategory"]))
                btn_SaveCategory_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_CategoryId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["category_id"]))
                    return;

                if (!Request.QueryString["category_id"].ToString().IsNumber())
                    return;

                model.CategoryIdValue = Request.QueryString["category_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveCategory_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.CategoryNameValue = Request.Form["txt_CategoryName"];
            model.ParentCategoryOptionListSelectedValue = Request.Form["ddlst_ParentCategory"];
            model.CategorySiteOptionListSelectedValue = Request.Form["ddlst_CategorySite"];
            model.DefaultStyleOptionListSelectedValue = Request.Form["ddlst_DefaultStyle"];
            model.DefaultTemplateOptionListSelectedValue = Request.Form["ddlst_DefaultTemplate"];
            model.CategoryActiveValue = Request.Form["cbx_CategoryActive"] == "on";
            model.CategoryRequireApprovalValue = Request.Form["cbx_CategoryRequireApproval"] == "on";
            model.CategoryPublicAccessShowValue = Request.Form["cbx_CategoryPublicAccessShow"] == "on";
            model.CategoryIdValue = Request.Form["hdn_CategoryId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_CategoryAccessShow$"))
                {
                    ListItem CategoryAccessShow = new ListItem();

                    CategoryAccessShow.Value = Request.Form[name];
                    CategoryAccessShow.Selected = true;

                    model.CategoryAccessShowListItem.Add(CategoryAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
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
        }
    }
}