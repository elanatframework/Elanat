using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeTemplateAndStyleController : CodeBehindController
    {
        public ActionChangeTemplateAndStyleModel model = new ActionChangeTemplateAndStyleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeTemplateAndStyle"]))
            {
                btn_ChangeTemplateAndStyle_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeTemplateAndStyle_Click(HttpContext context)
        {
            model.SiteStyleOptionListSelectedValue = context.Request.Form["ddlst_UserSiteStyle"];
            model.SiteTemplateOptionListSelectedValue = context.Request.Form["ddlst_UserSiteTemplate"];
            model.AdminStyleOptionListSelectedValue = context.Request.Form["ddlst_UserAdminStyle"];
            model.AdminTemplateOptionListSelectedValue = context.Request.Form["ddlst_UserAdminTemplate"];


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


            model.ChangeTemplateAndStyle();

            model.SuccessView();

            View(model);
        }
    }
}