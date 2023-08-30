using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeGroupController : CodeBehindController
    {
        public ActionChangeGroupModel model = new ActionChangeGroupModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeGroup"]))
            {
                btn_ChangeGroup_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeGroup_Click(HttpContext context)
        {
            model.UserGroupOptionListSelectedValue = context.Request.Form["ddlst_UserGroup"];


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


            model.ChangeGroup();

            model.SuccessView();

            View(model);
        }
    }
}