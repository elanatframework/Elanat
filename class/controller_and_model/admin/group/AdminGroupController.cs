using CodeBehind;

namespace Elanat
{
    public partial class AdminGroupController : CodeBehindController
    {
        public AdminGroupModel model = new AdminGroupModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddGroup"]))
            {
                btn_AddGroup_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddGroup_Click(HttpContext context)
        {
            model.GroupNameValue = context.Request.Form["txt_GroupName"];
            model.GroupActiveValue = context.Request.Form["cbx_GroupActive"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_GroupRole$"))
                {
                    ListItem GroupRole = new ListItem();

                    GroupRole.Value = context.Request.Form[name];
                    GroupRole.Selected = true;

                    model.GroupRoleListItem.Add(GroupRole);
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


            model.AddGroup();

            View(model);
        }
    }
}