using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace elanat
{
    public partial class AdminCategory : System.Web.UI.Page
    {
        public AdminCategoryModel model = new AdminCategoryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddCategory"]))
                btn_AddCategory_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddCategory_Click(object sender, EventArgs e)
        {
            model.CategoryNameValue = Request.Form["txt_CategoryName"];
            model.ParentCategoryOptionListSelectedValue = Request.Form["ddlst_ParentCategory"];
            model.CategorySiteOptionListSelectedValue = Request.Form["ddlst_CategorySite"];
            model.DefaultStyleOptionListSelectedValue = Request.Form["ddlst_DefaultStyle"];
            model.DefaultTemplateOptionListSelectedValue = Request.Form["ddlst_DefaultTemplate"];
            model.CategoryActiveValue = Request.Form["cbx_CategoryActive"] == "on";
            model.CategoryRequireApprovalValue = Request.Form["cbx_CategoryRequireApproval"] == "on";
            model.CategoryPublicAccessShowValue = Request.Form["cbx_CategoryPublicAccessShow"] == "on";
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


            model.AddCategory();
        }
    }
}