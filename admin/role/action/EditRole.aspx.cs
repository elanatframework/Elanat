using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionEditRole : System.Web.UI.Page
    {
        public ActionEditRoleModel model = new ActionEditRoleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveRole"]))
                btn_SaveRole_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_RoleId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["role_id"]))
                    return;

                if (!Request.QueryString["role_id"].ToString().IsNumber())
                    return;

                model.RoleIdValue = Request.QueryString["role_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveRole_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.RoleNameValue = Request.Form["txt_RoleName"];
            model.RoleActiveValue = Request.Form["cbx_RoleActive"] == "on";
            model.RoleTypeOptionListSelectedValue = Request.Form["ddlst_RoleType"];
            model.RoleIdValue = Request.Form["hdn_RoleId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_RoleBitColumnAccess$"))
                {
                    ListItem RoleBitColumnAccess = new ListItem();

                    RoleBitColumnAccess.Value = Request.Form[name];
                    RoleBitColumnAccess.Selected = true;

                    model.RoleBitColumnAccessListItem.Add(RoleBitColumnAccess);
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


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            DataUse.Role dur = new DataUse.Role();

            if (common.ExistValueToColumnCheck("el_role", "role_name", model.RoleNameValue, dur.GetRoleName(model.RoleIdValue)))
            {
                model.RoleNameCssClass = model.RoleNameCssClass.AddHtmlClass("el_warning_field");
                
                model.ExistValueToColumnErrorView();

                return;
            }


            model.SaveRole();

            model.SuccessView();
        }
    }
}