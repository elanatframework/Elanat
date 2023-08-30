using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLanguageController : CodeBehindController
    {
        public ActionEditLanguageModel model = new ActionEditLanguageModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveLanguage"]))
            {
                btn_SaveLanguage_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_LanguageId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["language_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["language_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.LanguageIdValue = context.Request.Query["language_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveLanguage_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.LanguageActiveValue = context.Request.Form["cbx_LanguageActive"] == "on";
            model.ShowLinkInSiteValue = context.Request.Form["cbx_ShowLinkInSite"] == "on";
            model.LanguageDefaultSiteOptionListSelectedValue = context.Request.Form["ddlst_LanguageDefaultSite"];
            model.LanguageIdValue = context.Request.Form["hdn_LanguageId"];


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


            model.SaveLanguage();

            model.SuccessView();

            View(model);
        }
    }
}