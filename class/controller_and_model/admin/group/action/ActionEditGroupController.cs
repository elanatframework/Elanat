using CodeBehind;

namespace Elanat
{
    public partial class ActionEditGroupController : CodeBehindController
    {
        public ActionEditGroupModel model = new ActionEditGroupModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveGroup"]))
            {
                btn_SaveGroup_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_GroupId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["group_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["group_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.GroupIdValue = context.Request.Query["group_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveGroup_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.GroupNameValue = context.Request.Form["txt_GroupName"];
            model.GroupActiveValue = context.Request.Form["cbx_GroupActive"] == "on";
            model.GroupIdValue = context.Request.Form["hdn_GroupId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_GroupRole$"))
                {
                    ListItem GroupRole = new ListItem();

                    GroupRole.Value = context.Request.Form[name];
                    GroupRole.Selected = true;

                    model.GroupRoleListItem.Add(GroupRole);
                }


            DataUse.Group dug = new DataUse.Group();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_group", "group_name", model.GroupNameValue, dug.GetGroupName(model.GroupIdValue)))
            {
                model.GroupNameCssClass = model.GroupNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                View(model);

                return;
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


            model.SaveGroup();

            model.SuccessView();

            View(model);
        }
    }
}