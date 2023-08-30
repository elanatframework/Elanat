using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperSearchOptionController : CodeBehindController
    {
        public ExtraHelperSearchOptionModel model = new ExtraHelperSearchOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveSearchOption"]))
            {
                btn_SaveSearchOption_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveSearchOption_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.MinimumSearchCharacterValue = context.Request.Form["txt_MinimumSearchCharacter"];
            model.SearchedPerPageValue = context.Request.Form["txt_SearchedPerPage"];
            model.NextSearchDelayValue = context.Request.Form["txt_NextSearchDelay"];
            model.ActiveTitleTextSearchValue = context.Request.Form["cbx_ActiveTitleTextSearch"] == "on";
            model.ActiveDateSearchValue = context.Request.Form["cbx_ActiveDateSearch"] == "on";
            model.ActiveCategorySearchValue = context.Request.Form["cbx_ActiveCategorySearch"] == "on";
            model.SaveSearchedTextToFootPrintValue = context.Request.Form["cbx_SaveSearchedTextToFootPrint"] == "on";


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


            model.SaveSearchOption();

            View(model);
        }
    }
}