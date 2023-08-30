using CodeBehind;

namespace Elanat
{
    public partial class ActionEditExtraHelperController : CodeBehindController
    {
        public ActionEditExtraHelperModel model = new ActionEditExtraHelperModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveExtraHelper"]))
            {
                btn_SaveExtraHelper_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ExtraHelperId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ExtraHelperIdValue = context.Request.Query["extra_helper_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveExtraHelper_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.ExtraHelperPathUploadValue = context.Request.Form.Files["upd_ExtraHelperPath"];
            model.UseExtraHelperPathValue = context.Request.Form["cbx_UseExtraHelperPath"] == "on";
            model.ExtraHelperPathTextValue = context.Request.Form["txt_ExtraHelperPath"];
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
            model.ExtraHelperIdValue = context.Request.Form["hdn_ExtraHelperId"];

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

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveExtraHelper();

            model.SuccessView();

            View(model);
        }
    }
}