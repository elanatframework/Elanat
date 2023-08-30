using CodeBehind;

namespace Elanat
{
    public partial class ActionEditRoleController : CodeBehindController
    {
        public ActionEditRoleModel model = new ActionEditRoleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveRole"]))
            {
                btn_SaveRole_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_RoleId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["role_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["role_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.RoleIdValue = context.Request.Query["role_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveRole_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.RoleNameValue = context.Request.Form["txt_RoleName"];
            model.RoleActiveValue = context.Request.Form["cbx_RoleActive"] == "on";
            model.RoleTypeOptionListSelectedValue = context.Request.Form["ddlst_RoleType"];
            model.RoleIdValue = context.Request.Form["hdn_RoleId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_RoleBitColumnAccess$"))
                {
                    ListItem RoleBitColumnAccess = new ListItem();

                    RoleBitColumnAccess.Value = context.Request.Form[name];
                    RoleBitColumnAccess.Selected = true;

                    model.RoleBitColumnAccessListItem.Add(RoleBitColumnAccess);
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


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            DataUse.Role dur = new DataUse.Role();

            if (common.ExistValueToColumnCheck("el_role", "role_name", model.RoleNameValue, dur.GetRoleName(model.RoleIdValue)))
            {
                model.RoleNameCssClass = model.RoleNameCssClass.AddHtmlClass("el_warning_field");
                
                model.ExistValueToColumnErrorView();

                View(model);

                return;
            }


            model.SaveRole();

            model.SuccessView();

            View(model);
        }
    }
}