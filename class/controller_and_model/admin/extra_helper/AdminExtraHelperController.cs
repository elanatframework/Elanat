using CodeBehind;

namespace Elanat
{
    public partial class AdminExtraHelperController : CodeBehindController
    {
        public AdminExtraHelperModel model = new AdminExtraHelperModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddExtraHelper"]))
            {
                btn_AddExtraHelper_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
       }

        protected void btn_AddExtraHelper_Click(HttpContext context)
        {
            model.ExtraHelperPathUploadValue = context.Request.Form.Files["upd_ExtraHelperPath"];
            model.UseExtraHelperPathValue = context.Request.Form["cbx_UseExtraHelperPath"] == "on";
            model.ExtraHelperPathTextValue = context.Request.Form["txt_ExtraHelperPath"];
            model.PriorityForExtraHelperValue = context.Request.Form["cbx_PriorityForExtraHelper"] == "on";
            model.ExtraHelperCategoryValue = context.Request.Form["txt_ExtraHelperCategory"];
            model.ExtraHelperActiveValue = context.Request.Form["cbx_ExtraHelperActive"] == "on";
            model.ExtraHelperUseLanguageValue = context.Request.Form["cbx_ExtraHelperUseLanguage"] == "on";
            model.ExtraHelperUseModuleValue = context.Request.Form["cbx_ExtraHelperUsModule"] == "on";
            model.ExtraHelperUsePluginValue = context.Request.Form["cbx_ExtraHelperUsePlugin"] == "on";
            model.ExtraHelperUseReplacePartValue = context.Request.Form["cbx_ExtraHelperUseReplacePart"] == "on";
            model.ExtraHelperUseFetchValue = context.Request.Form["cbx_ExtraHelperUseFetch"] == "on";
            model.ExtraHelperUseItemValue = context.Request.Form["cbx_ExtraHelperUseItem"] == "on";
            model.ExtraHelperUseElanatValue = context.Request.Form["cbx_ExtraHelperUseElanat"] == "on";
            model.ExtraHelperCacheDurationValue = context.Request.Form["txt_ExtraHelperCacheDuration"];
            model.ExtraHelperCacheParametersValue = context.Request.Form["txt_ExtraHelperCacheParameters"];
            model.ExtraHelperSortIndexValue = context.Request.Form["txt_ExtraHelperSortIndex"];
            model.ExtraHelperPublicAccessShowValue = context.Request.Form["cbx_ExtraHelperPublicAccessShow"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ExtraHelperAccessShow$"))
                {
                    ListItem ExtraHelperAccessShow = new ListItem();

                    ExtraHelperAccessShow.Value = context.Request.Form[name];
                    ExtraHelperAccessShow.Selected = true;

                    model.ExtraHelperAccessShowListItem.Add(ExtraHelperAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                IgnoreViewAndModel = true;

                return;
            }


            model.AddExtraHelper();

            View(model);
        }
    }
}