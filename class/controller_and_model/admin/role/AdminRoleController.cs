using CodeBehind;

namespace Elanat
{
    public partial class AdminRoleController : CodeBehindController
    {
        public AdminRoleModel model = new AdminRoleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddRole"]))
            {
                btn_AddRole_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddRole_Click(HttpContext context)
        {
            model.RoleNameValue = context.Request.Form["txt_RoleName"];
            model.RoleActiveValue = context.Request.Form["cbx_RoleActive"] == "on";
            model.RoleTypeOptionListSelectedValue = context.Request.Form["ddlst_RoleType"];

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


            model.AddRole();

            View(model);
        }
    }
}