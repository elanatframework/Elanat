using CodeBehind;

namespace Elanat
{
    public partial class AdminLanguageController : CodeBehindController
    {
        public AdminLanguageModel model = new AdminLanguageModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddLanguage"]))
            {
                btn_AddLanguage_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddLanguage_Click(HttpContext context)
        {
            model.LanguagePathUploadValue = context.Request.Form.Files["upd_LanguagePath"];
            model.UseLanguagePathValue = context.Request.Form["cbx_UseLanguagePath"] == "on";
            model.LanguagePathTextValue = context.Request.Form["txt_LanguagePath"];
            model.LanguageActiveValue = context.Request.Form["cbx_LanguageActive"] == "on";
            model.ShowLinkInSiteValue = context.Request.Form["cbx_ShowLinkInSite"] == "on";
            model.LanguageDefaultSiteOptionListSelectedValue = context.Request.Form["ddlst_LanguageDefaultSite"];


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


            model.AddLanguagePackage();

            View(model);
        }
    }
}